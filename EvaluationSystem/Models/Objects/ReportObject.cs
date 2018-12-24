using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Models.Objects
{
    public class ReportObject
    {
        private DataTable _studentReport;
        private DataTable _teamReport;
        private DataTable _classReport;

        public DataTable StudentReport { get => _studentReport; set => _studentReport = value; }
        public DataTable TeamReport { get => _teamReport; set => _teamReport = value; }
        public DataTable ClassReport { get => _classReport; set => _classReport = value; }
    }
}
