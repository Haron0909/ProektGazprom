using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Scripts
{
    class FindUser
    {
        public int UsId { get; set; }
        public string Urole { get; set; }
        public string FindUserMethod(string[] auth)
        {

            string flag = "Зарегистрируйте пользователя у админа";
          
            using (DataBaseContext db = new DataBaseContext())
             {
                var users = db.Users.ToList();
            
            foreach (User u in users)
             {
                    if (u.login == auth[0] && u.password == auth[1])
                    {
                        flag = $"{u.role}|Авторизирован";
                        UsId = u.id;
                        Urole = u.role;
                        break;
                    }
                    else
                    {
                        return flag;
                    }
             }
            }
            return flag;
        }
       


    }
}
