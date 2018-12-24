using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InterfaceLibrary
{
    public interface IFileAccess
    {
        int WriteToFileXML();
        int ExportToExcel();
    }
}
