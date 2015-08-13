using Resmed.Stock.ClientService.Managers;
using StockTradingSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace StockTradingSystem.Controllers
{
    public class StockDetailsController : Controller
    {
        // GET: StockDetails
        public ActionResult Index()
        {
            StockDetails stockDetails = new StockDetails();
            var manager = new StockManager();
            stockDetails.Sites = manager.GetAllSites();
            stockDetails.Symbols = manager.GetSymbols();
            return View(stockDetails);
        }

        [HttpGet]
        public ActionResult ShowStockFiles(string siteId, string stockId)
        {
            StockDetails stockDetails = new StockDetails();
            var manager = new StockManager();
            stockDetails.lstStockFilesViewModel = manager.GetAllStockFiles(siteId, stockId);
            return Json(stockDetails.lstStockFilesViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void GenerateStockFiles()
        {
            var manager = new StockManager();
            manager.ExtractStockFilesFromSites();
        }

        [HttpPost]
        public void RemoveAllStockFiles()
        {
            var manager = new StockManager();
            manager.RemoveAllStockFiles();
        }

        [HttpGet]
        public ActionResult ViewFiles(string stockFileId)
        {
            var manager = new StockManager();
            StockDetails stockDetails = new StockDetails();
            stockDetails.StockFilesViewModel = manager.GetStockFile(stockFileId);
            
            byte[] byteArray = Encoding.UTF8.GetBytes(stockDetails.StockFilesViewModel.File);
            FileTypeFactory fileFactory = new FileTypeFactory();
            FileType fileTypeClass = fileFactory.FileTypes(stockDetails.StockFilesViewModel.Format.ToLower());
            string fileType = fileTypeClass.GetFileType();
            return File(byteArray, fileType);
        }
    }
}