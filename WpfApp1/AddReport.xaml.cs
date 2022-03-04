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
    /// Логика взаимодействия для AddReport.xaml
    /// </summary>
    public partial class AddReport : Page
    {
        public List<string> AllProtocl = new List<string>();
        public List<string> AllAssig = new List<string>();
        Protocol protocol = new Protocol();
        Assignment assignment = new Assignment();
        FindUser user = new FindUser(); 
        public AddReport()
        {
            InitializeComponent();
           
            AllProtocl = protocol.GetAllProtocol();
            foreach(string p in AllProtocl)
            {
                ChoiceProtocol.Items.Add(p);
            }
           

        }

        private void AddReportButton_Click(object sender, RoutedEventArgs e)
        {
            Reports reports = new Reports();
            int assigId;
            int protoId;
            if (ChoiceProtocol.Text.Length > 0)
            {
                if (ChoiceAssign.Text.Length > 0)
                {
                    if(ReportField.Text.Length>0 && ReportField.Text != "Поле для отёта")
                    {
                        protoId = protocol.GetProtocolId(ChoiceProtocol.Text);
                        assigId = assignment.GetAssignmentId(ChoiceAssign.Text);
                        string res = reports.AddReport(ReportField.Text, assigId, protoId, user.UsId);
                        MessageBox.Show(res);
                    }
                }
            }

        }

        private void ChoiceProtocol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string protocolName;
            int protoId;
            protocolName = ChoiceProtocol.Text;
            protoId = protocol.GetProtocolId(protocolName);
            AllAssig = assignment.GetAllAssignments(protoId);
            foreach (string p in AllAssig)
            {
                ChoiceAssign.Items.Add(p);
            }
        }
    }
}
