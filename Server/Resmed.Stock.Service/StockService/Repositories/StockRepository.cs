using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using Resmed.Stock.Service;
using Microsoft.Practices.Unity;
using Resmed.Stock.Core;
using Resmed.Stock.Common.ViewModel;
using System.Net;
using System.IO;

namespace Resmed.Stock.Repositories
{
    public class StockRepository: ServiceBase,IStockRepository
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(StockRepository));

        public StockRepository(IUnityContainer unityContainer)
        {
            UnityContainer = unityContainer;
        }

        public IList<string> GetAllSymbols()
        {
            using (var context = new StockEntities())
            {
                return context.StockSymbols.Select(x => x.Symbol).ToList(); 
            }
        }


        public IList<Site> GetAllSites()
        {
            using (var context = new StockEntities())
            {
                return context.Sites.ToList();
            }
        }


        public IList<StockFileViewModel> GetAllStockFiles(string SiteId, string StockId)
        {
            using (var context = new StockEntities())
            {
                int _siteId = Convert.ToInt32(SiteId);
                int _stockId = Convert.ToInt32(StockId);
                var result = (from se in context.StockFiles
                              join s in context.Sites on se.SiteId equals s.ID
                              where _siteId == 0 ? 1 == 1 : se.SiteId == _siteId
                              join ss in context.StockSymbols on se.StockId equals ss.ID
                              where _stockId == 0 ? 1 == 1 : se.StockId == _stockId
                              select new StockFileViewModel
                       {
                           Format = s.Format,
                           Name = s.Name,
                           Url = s.Url,
                           Symbol = ss.Symbol,
                           Id = se.ID,
                           SiteId = se.SiteId,
                           StockId = se.StockId,
                           FileName = se.FileName,
                           DownloadedDate = se.DownloadedDate.Value
                       }).ToList<StockFileViewModel>();

                return result;
            }
        }

        public IList<StockSymbol> GetSymbols()
        {
            using (var context = new StockEntities())
            {
                return context.StockSymbols.ToList();
            }
        }

        public bool ExtractStockFilesFromSites()
        {
            using (var context = new StockEntities())
            {
                bool isExtracted = false;
                var sitesWithSymbol = (from site in context.Sites
                            from symbol in context.StockSymbols
                            select new { site, symbol }).ToList();

                for (int count = 0; count < sitesWithSymbol.Count; count++)
                {
                    string fileContent = ExtractDataFromSites(sitesWithSymbol[count].site.Url.Replace("{0}", sitesWithSymbol[count].symbol.Symbol));
                    if(!String.IsNullOrEmpty(fileContent))
                    {
                        var stockFile = new StockFile();
                        stockFile.SiteId = sitesWithSymbol[count].site.ID;
                        stockFile.StockId = sitesWithSymbol[count].symbol.ID;
                        stockFile.FileName = sitesWithSymbol[count].site.Name + "_" + sitesWithSymbol[count].symbol.Symbol;
                        stockFile.File = fileContent;
                        stockFile.DownloadedDate = DateTime.Now;

                        context.StockFiles.AddObject(stockFile);                                               
                    }                    
                }

                context.SaveChanges(); 
                isExtracted = true;
                return isExtracted;
            }            
        }

        public bool RemoveAllStockFiles()
        {
            using (var context = new StockEntities())
            {
                bool isDeleted = false;
                var records = from s in context.StockFiles select s;

                foreach (var record in records)
                {
                    context.StockFiles.DeleteObject(record);                    
                }

                context.SaveChanges();
                isDeleted = true;
                return isDeleted;
            }
        }

        public StockFileViewModel GetStockFile(string StockFileId)
        {
            int iStockFileId = Convert.ToInt32(StockFileId);
            using (var context = new StockEntities())
            {
                var stockFile = (from sf in context.StockFiles
                                 join s in context.Sites on sf.SiteId equals s.ID
                                 where sf.ID == iStockFileId
                                 select new StockFileViewModel
                                 {
                                     Format = s.Format,
                                     File = sf.File,
                                     FileName = sf.FileName
                                 }).FirstOrDefault();

                return stockFile;
            }
        }

        private string ExtractDataFromSites(string url)
        {
            System.Net.WebClient webClient = new WebClient();
            webClient.Proxy = HttpWebRequest.GetSystemWebProxy();
            webClient.Proxy.Credentials = CredentialCache.DefaultCredentials;

            Stream strm = webClient.OpenRead(url);
            StreamReader sr = new StreamReader(strm);
            string result = sr.ReadToEnd();
            strm.Close();

            return result;
        } 
    }
}