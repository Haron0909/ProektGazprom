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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CheckingReports.xaml
    /// </summary>
    public partial class CheckingReports : Page
    {
        public List<string> AllProtocl = new List<string>();
        public List<string> AllAssig = new List<string>();
        Protocol protocol = new Protocol();
        Assignment assignment = new Assignment();
        Reports reports = new Reports();
        public CheckingReports()
        {
            InitializeComponent();
            AllProtocl = protocol.GetAllProtocol();
            foreach (string p in AllProtocl)
            {
                ChoiceProtocol.Items.Add(p);
            }
        }

        private void FormButton_Click(object sender, RoutedEventArgs e)
        {
/*            List<string> Allreports= new List<string>();
            string protocolName;
            int protoId;
            object prop = "Table Grid 8";
            int AssigId;
            var application = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();
            document = application.Documents.Add();
           
            protocolName = ChoiceProtocol.Text;
            protoId = protocol.GetProtocolId(protocolName);
            AllAssig = assignment.GetAllAssignments(protoId);
            foreach(string a in AllAssig)
            {
                AssigId = assignment.GetAssignmentId(a);
                document.Paragraphs;
                Allreports = reports.GetAllReportsById(AssigId);
                foreach(string r in Allreports)
                {
                    document.Content.Paragraphs.Add(r);
                }
            }

            
            
           

            application.Visible = true;*/
        }
    }
}
