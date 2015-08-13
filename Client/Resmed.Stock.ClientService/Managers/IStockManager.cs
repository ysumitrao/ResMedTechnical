using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resmed.Stock.ClientService.ResmedStockServiceProxy;

namespace Resmed.Stock.ClientService.Managers
{
    public interface IStockManager
    {
        IList<String> GetAllSymbols();

        IList<Site> GetAllSites();

        IList<StockSymbol> GetSymbols();

        IList<StockFileViewModel> GetAllStockFiles(string SiteId = null, string StockId = null);

        StockFileViewModel GetStockFile(string StockFileId);

        bool ExtractStockFilesFromSites();

        bool RemoveAllStockFiles();
    }
}
