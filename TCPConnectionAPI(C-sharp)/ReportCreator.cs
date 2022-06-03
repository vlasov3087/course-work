using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPConnectionAPI_C_sharp_
{
    static public class ReportCreator
    {
        public static string CreateReportAboutCarriers()
        {
            using (IDataViewPermision db = new DatabaseContext())
            {
                var carriers = db.FindEmployeesWhere(c => c != null);
                string report = "Учет сотрудников на " + DateTime.Now + "\n\n";
                foreach (var item in carriers)
                {
                    report += "Полное имя: " + item.FullName + "\n";
                    report += "Должность: " + item.Position + "\n";
                    report += "Опыт: " + item.Experience + "\n";
                    report += '\n';
                }
                return report;
            }
        }
    }
}
