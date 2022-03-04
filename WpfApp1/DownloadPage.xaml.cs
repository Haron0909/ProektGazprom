using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.Scripts;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class DownloadPage : Page
    {
        
        public DownloadPage()
        {
            InitializeComponent();
          
           

        }
        public int index = 100;
        public List<string> asign = new List<string>();
        Protocol protocol = new Protocol();
        public string filename = "";
        public string rangetext = "1";


        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            
          
                OpenFileDialog openFileDialog = new OpenFileDialog();
                var WordApp = new Microsoft.Office.Interop.Word.Application();
                char[] delimiterChars = { '.', '\r' };
                string str = "";
                
                if (openFileDialog.ShowDialog() == true)
                {

                    var doc = WordApp.Documents.Open(openFileDialog.FileName);
                    rangetext = doc.Range().Text.ToString();
                    index = rangetext.IndexOf("РЕШИЛИ:");
                    rangetext = rangetext.Substring(index);
                    index = rangetext.IndexOf(":") + 3;
                    rangetext = rangetext.Substring(index);
                    index = rangetext.IndexOf("Председатель");
                    rangetext = rangetext.Remove(index);

                    index = openFileDialog.FileName.IndexOf("Пр");
                    filename = openFileDialog.FileName.Substring(index);
                    index = filename.IndexOf(".d");
                    filename = filename.Remove(index);
                    str = protocol.ProtocolAdd(filename);
                    MessageBox.Show(str);
                    doc.Close();
                }

                str = " ";
                for (int i = 0; i < rangetext.Length; i++)
                {
                    str = str + rangetext[i];
                    if (rangetext[i].Equals('\r'))
                    {

                        asign.Add(str + "\n\n");
                        str = " ";
                    }

                }
                str = "";

                if (WordApp != null)
                {
                    string a = "";
                    int i = 0;
                    int j = 1;
                    index = rangetext.IndexOf("Ответственны");
                    for (i = 0; i < asign.Count; i++)
                    {
                        a = asign[i];

                    }
                }
                foreach (string a in asign)
                {
                    Asignment.Items.Add(a);
                }
                foreach (string a in asign)
                {
                    str += a;
                }
                textblock1.Text = str;
                User user = new User();
                List<string> usersfio;

                usersfio = user.AllUsers();
                foreach (string u in usersfio)
                {
                    Executor.Items.Add(u);
                }
          
        }

        private void SendAssign_Click(object sender, RoutedEventArgs e)
        {
           
                User user = new User();
                Assignment assignment = new Assignment();
                int Userid;
                int Protocolid;
                string res;
                if (Executor.Text.Length > 0)
                {
                    if (Responsible.Text.Length > 0)
                    {
                        if (SpecificDate.SelectedDate.HasValue)
                        {
                            if (AssignText.Text.Length > 0 && AssignText.Text != "Сюда будут писать поручение")
                            {
                                res = SpecificDate.SelectedDate.ToString();
                                Userid = user.FindUserId(Executor.Text);
                                Protocolid = protocol.GetProtocolId(filename);
                                res = assignment.AssignmentAdd(AssignText.Text, res, Userid, Responsible.Text, Protocolid);
                                MessageBox.Show(res);
                            }
                        }
                        if (NotSpecificDate.Text.Length > 0 && NotSpecificDate.Text != "Если срока нет пишите сюда")
                        {
                            if (AssignText.Text.Length > 0 && AssignText.Text != "Сюда будут писать поручение")
                            {
                                res = NotSpecificDate.Text;
                                Userid = user.FindUserId(Executor.Text);
                                Protocolid = protocol.GetProtocolId(filename);
                                res = assignment.AssignmentAdd(AssignText.Text, res, Userid, Responsible.Text, Protocolid);
                                MessageBox.Show(res);
                            }
                        }
                    }
                }
        }
    }
}
