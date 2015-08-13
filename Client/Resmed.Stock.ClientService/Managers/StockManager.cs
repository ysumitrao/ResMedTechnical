using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resmed.Stock.ClientService.ResmedStockServiceProxy;
using Resmed.Stock.ClientService.Common;
using Resmed.MEP.Mask.ClientService.Faults;
using System.ServiceModel;

namespace Resmed.Stock.ClientService.Managers
{
    public class StockManager:IStockManager
    {
        public IList<string> GetAllSymbols()
        {
            List<String> symbols = null;
            try
            {
                using (WcfClientProxy<StockServiceClient, IStockService> proxy = WcfHelper.CreateServiceProxy())
                {
                    symbols = proxy.MakeCall(c => c.GetAllSymbols());
                }
            }
            catch (FaultException ex)
            {
                FaultHandler.Handle(ex);
            }

            return symbols;
        }


        public IList<Site> GetAllSites()
        {
            List<Site> sites = null;
            try
            {
                using (WcfClientProxy<StockServiceClient, IStockService> proxy = WcfHelper.CreateServiceProxy())
                {
                    sites = proxy.MakeCall(c => c.GetAllSites());
                }
            }
            catch (FaultException ex)
            {
                FaultHandler.Handle(ex);
            }

            return sites;
        }


        public IList<StockFileViewModel> GetAllStockFiles(string SiteId = null, string StockId = null)
        {
            List<StockFileViewModel> stockFiles = null;
            try
            {
                using (WcfClientProxy<StockServiceClient, IStockService> proxy = WcfHelper.CreateServiceProxy())
                {
                    stockFiles = proxy.MakeCall(c => c.GetAllStockFiles(SiteId, StockId));
                }
            }
            catch (FaultException ex)
            {
                FaultHandler.Handle(ex);
            }

            return stockFiles;
        }


        public IList<StockSymbol> GetSymbols()
        {
            List<StockSymbol> symbols = null;
            try
            {
                using (WcfClientProxy<StockServiceClient, IStockService> proxy = WcfHelper.CreateServiceProxy())
                {
                    symbols = proxy.MakeCall(c => c.GetSymbols());
                }
            }
            catch (FaultException ex)
            {
                FaultHandler.Handle(ex);
            }

            return symbols;
        }


        public bool ExtractStockFilesFromSites()
        {
            bool isExtracted = false;
            try
            {
                using (WcfClientProxy<StockServiceClient, IStockService> proxy = WcfHelper.CreateServiceProxy())
                {
                    isExtracted = proxy.MakeCall(c => c.ExtractStockFilesFromSites());
                }
            }
            catch (FaultException ex)
            {
                FaultHandler.Handle(ex);
            }

            return isExtracted;
        }


        public bool RemoveAllStockFiles()
        {
            bool isDeleted = false;
            try
            {
                using (WcfClientProxy<StockServiceClient, IStockService> proxy = WcfHelper.CreateServiceProxy())
                {
                    isDeleted = proxy.MakeCall(c => c.RemoveAllStockFiles());
                }
            }
            catch (FaultException ex)
            {
                FaultHandler.Handle(ex);
            }

            return isDeleted;
        }


        public StockFileViewModel GetStockFile(string StockFileId)
        {
            StockFileViewModel stockFile = null;
            try
            {
                using (WcfClientProxy<StockServiceClient, IStockService> proxy = WcfHelper.CreateServiceProxy())
                {
                    stockFile = proxy.MakeCall(c => c.GetStockFile(StockFileId));
                }
            }
            catch (FaultException ex)
            {
                FaultHandler.Handle(ex);
            }

            return stockFile;
        }
    }
}
