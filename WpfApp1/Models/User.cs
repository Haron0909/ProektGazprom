using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Scripts;

namespace WpfApp1.Models
{
    class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string fio { get; set; }
        public int departmentId { get; set; }
        public string role { get; set; }
       
        public List<string> AllUsers()
        {
             List<string> usersFio = new List<string>();
            using (DataBaseContext db = new DataBaseContext())
            {
                var users = db.Users.ToList();

                foreach (User u in users)
                {
                    usersFio.Add(u.fio);
                }
            }
            return usersFio;
        }
        public int FindUserId(string userFio)
        {
            int id = 0;
            using (DataBaseContext db = new DataBaseContext())
            {
                var users = db.Users.ToList();

                foreach (User u in users)
                {
                    if (u.fio == userFio)
                    {
                        id = u.id;

                    }

                }
            }
            return id;
        }
    }
}
