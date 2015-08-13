using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resmed.Stock.ClientService.Managers;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using Resmed.Stock.Common.ViewModel;

namespace Resmed.Stock.Test
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void GetAllSymbols()
        {
            var manager = new StockManager();
            var symbols = manager.GetAllSymbols();
            Assert.IsTrue(symbols.Count > 0);
        }

        [TestMethod]
        public void GetAllSites()
        {
            var manager = new StockManager();
            var sites = manager.GetAllSites();
            Assert.IsTrue(sites.Count > 0);
        }

        [TestMethod]
        public void GetSymbols()
        {
            var manager = new StockManager();
            var symbols = manager.GetSymbols();
            Assert.IsTrue(symbols.Count > 0);
        }

        [TestMethod]
        public void GetAllStockFiles()
        {
            var manager = new StockManager();
            var lststockFiles = manager.GetAllStockFiles();
            Assert.IsTrue(lststockFiles != null);
        }

        [TestMethod]
        public void GetAllStockFilesFromCriteria()
        {
            var manager = new StockManager();
            var lststockFiles = manager.GetAllStockFiles("1", "1");
            Assert.IsTrue(lststockFiles != null);
        }

        [TestMethod]
        public void GetStockFile()
        {
            var manager = new StockManager();
            manager.ExtractStockFilesFromSites();
            var lstSstockFiles = manager.GetAllStockFiles();
            Assert.IsTrue(lstSstockFiles.Count > 0 && manager.GetStockFile(lstSstockFiles[0].Id.ToString()) != null);
        }

        [TestMethod]
        public void ExtractStockFilesFromSites()
        {
            var manager = new StockManager();
            manager.RemoveAllStockFiles();
            bool isExtracted = manager.ExtractStockFilesFromSites();
            Assert.IsTrue(isExtracted);
        }

        [TestMethod]
        public void RemoveAllStockFiles()
        {
            var manager = new StockManager();
            manager.ExtractStockFilesFromSites();
            bool isDeleted = manager.RemoveAllStockFiles();
            Assert.IsTrue(isDeleted);
        }
    }  
}
