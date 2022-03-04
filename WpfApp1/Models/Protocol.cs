using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Scripts;

namespace WpfApp1.Models
{
    class Protocol
    {
        public int id { get; set; }
        public string ProtocolName { get; set; }

        public string ProtocolAdd(string fileName)
        {
            bool flag = false;
            using (DataBaseContext db = new DataBaseContext())
            {
                var protocolname = db.Protocol.ToList();
                foreach(Protocol p in protocolname)
                {
                    if(p.ProtocolName != fileName)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                if(flag == true)
                {
                    var protocol = new Protocol { ProtocolName = fileName };
                    db.Protocol.Add(protocol);
                    db.SaveChanges();
                }
            }
            if (flag == true)
            {
                return "Протокол добавлен";
            }
            else
            {
                return "Такой протокол уже имеется";
            }
            
        }
        public int GetProtocolId(string protname)
        {
            int id = 0;
            using (DataBaseContext db = new DataBaseContext())
            {
                var protocolname = db.Protocol.ToList();
                foreach (Protocol p in protocolname)
                {
                    if (p.ProtocolName == protname)
                    {
                        id =p.id;
                    }
                }            
            }
            return id;
        }
        public List<string> GetAllProtocol()
        {
            List<string> AllProtocol = new List<string>();
            using (DataBaseContext db = new DataBaseContext())
            {
                var protocolname = db.Protocol.ToList();
                foreach (Protocol p in protocolname)
                {
                    AllProtocol.Add(p.ProtocolName);
                }
            }

            return AllProtocol;
        }

    }
}
