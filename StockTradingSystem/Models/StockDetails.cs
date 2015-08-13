using Resmed.Stock.ClientService.ResmedStockServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace StockTradingSystem.Models
{
    public class StockDetails
    {
        public IList<Site> Sites { get; set; }
        public IList<StockSymbol> Symbols { get; set; }
        public IList<StockFileViewModel> lstStockFilesViewModel { get; set; }
        public StockFileViewModel StockFilesViewModel { get; set; }
    }
}
