using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Resmed.Stock.Core;
using Resmed.Stock.Common.ViewModel;

namespace Resmed.Stock.Service
{
     [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface IStockService
    {
        [OperationContract]
        IList<String> GetAllSymbols();
        
        [OperationContract]
        IList<Site> GetAllSites();

        [OperationContract]
        IList<StockSymbol> GetSymbols();

        [OperationContract]
        IList<StockFileViewModel> GetAllStockFiles(string SiteId, string StockId);

        [OperationContract]
        StockFileViewModel GetStockFile(string StockFileId);

        [OperationContract]
        bool ExtractStockFilesFromSites();

        [OperationContract]
        bool RemoveAllStockFiles();
    }
}
