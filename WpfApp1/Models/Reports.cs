using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Scripts;

namespace WpfApp1.Models
{
    class Reports
    {
        public int id { get; set; }
        public string reportText { get; set; }
        public int assignmentId { get; set; }
        public int protocolId { get; set; }
        public DateTime DateDownload { get; set; }
        public int userId { get; set; }

        public string AddReport(string text,int assigId,int protoId,int Uid)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var reports = new Reports {reportText=text,assignmentId=assigId,protocolId=protoId,DateDownload=DateTime.Today,userId=Uid};

                db.Reports.Add(reports);
                db.SaveChanges();

            }
            return "Отчёт добавлен";
        }

        public List<string> GetAllReportsById(int id)
        {
            List<string> allreports = new List<string>();

            using (DataBaseContext db = new DataBaseContext())
            {
                var reports = db.Reports.ToList();
                foreach (Reports p in reports)
                {
                    if (p.assignmentId == id)
                    {
                        allreports.Add(p.reportText);
                    }
                    
                }
            }
            return allreports;
        }
    }
}
