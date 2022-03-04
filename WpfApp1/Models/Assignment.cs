using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Scripts;

namespace WpfApp1.Models
{
    class Assignment
    {

        public int id { get; set; }
        public string assignmentText { get; set; }
        public string DeliveredDate { get; set; }
        public int userId { get; set; }
        public string responsible { get; set; }
        public int protocolId { get; set; }

        public string AssignmentAdd(string assig,string DelDat,int uId,string resp,int protId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var assignments = new Assignment { assignmentText = assig, DeliveredDate = DelDat, userId=uId,responsible=resp, protocolId = protId };

                db.Assignments.Add(assignments);
                db.SaveChanges();

            }
            return "Поручение добавлено";
        }
        public List<string> GetAllAssignments(int id)
        {
            List<string> AllAssig = new List<string>();
            using (DataBaseContext db = new DataBaseContext())
            {
                var assig = db.Assignments.ToList();
                foreach (Assignment p in assig)
                {
                    if(p.protocolId == id)
                    {
                        AllAssig.Add(p.assignmentText);
                    }
                    
                }
            }

            return AllAssig;
        }
        public int GetAssignmentId(string assigtext)
        {
            int id = 0;
            using (DataBaseContext db = new DataBaseContext())
            {
                var assigText = db.Assignments.ToList();
                foreach (Assignment a in assigText)
                {
                    if (a.assignmentText == assigtext)
                    {
                        id = a.id;
                    }
                }
            }
            return id;
        }
    }
}
