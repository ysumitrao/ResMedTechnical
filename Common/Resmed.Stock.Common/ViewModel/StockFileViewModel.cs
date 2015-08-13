using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Resmed.Stock.Common.ViewModel
{
    public partial class StockFileViewModel
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public string Format { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int StockId { get; set; }
        public string Symbol { get; set; }
        public string FileName { get; set; }
        public string File { get; set; }
        public DateTime? DownloadedDate { get; set; }
    }
}
