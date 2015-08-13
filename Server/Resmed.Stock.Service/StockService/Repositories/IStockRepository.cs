using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resmed.Stock.Core;
using Resmed.Stock.Common.ViewModel;

namespace Resmed.Stock.Repositories
{
    public interface IStockRepository
    {
        IList<String> GetAllSymbols();

        IList<Site> GetAllSites();

        IList<StockSymbol> GetSymbols();
        IList<StockFileViewModel> GetAllStockFiles(string SiteId, string StockId);
        StockFileViewModel GetStockFile(string StockFileId);
        bool ExtractStockFilesFromSites();
        bool RemoveAllStockFiles();
    }
}
