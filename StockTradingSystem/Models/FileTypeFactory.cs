using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTradingSystem
{
    public class FileTypeFactory
    {
        private Dictionary<string, FileType> fileTypes = new Dictionary<string, FileType>();

        public FileTypeFactory()
        {
            fileTypes.Add("xml", new XmlFileType());
            fileTypes.Add("text", new TextFileType());
            fileTypes.Add("csv", new CsvFileType());
        }

        public FileType FileTypes(string fileType)
        {
            return fileTypes[fileType];
        }
    }

    public abstract class FileType
    {
        public abstract string GetFileType();
    }

    public class XmlFileType : FileType
    {
        public override string GetFileType()
        {
            return "text/xml";
        }
    }

    public class TextFileType : FileType
    {
        public override string GetFileType()
        {
            return "text/xml";
        }
    }

    public class CsvFileType : FileType
    {
        public override string GetFileType()
        {
            return "text/csv";
        }
    }
}