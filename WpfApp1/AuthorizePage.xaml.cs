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
using WpfApp1.Scripts;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AuthorizePage.xaml
    /// </summary>
    public partial class AuthorizePage : Page
    {
        public AuthorizePage()
        {
            InitializeComponent();

        }
       public string role = "";
        CheckAccess check = new CheckAccess();
        public void Authoriz_Click(object sender, RoutedEventArgs e)
        {
            
            if (Login.Text.Length > 0)
            {
                if (Password.Password.Length > 0)
                {
                   
                    auth(Login.Text,Password.Password);
                    check.AuthCheck = "Авторизирован";
                    check.Role = role;

                }
                else
                {
                    MessageBox.Show("Введите пароль");
                }
            }
            else
            {
                MessageBox.Show("Введите логин");
            }
          
        }

        void auth(string log, string pass )
        {
           
            string[] authorizeData =  new string[2];
            authorizeData[0] = log;
            authorizeData[1] = pass;

            if (authorizeData.Length == 2)
            {
                FindUser find = new FindUser();
                string Find = find.FindUserMethod(authorizeData);
                int index = Find.IndexOf("|");
                role = Find.Remove(index);
                index = Find.IndexOf("|")+1;
                Find = Find.Substring(index);
                if (Find == "Авторизирован")
                {
                    MessageBox.Show(Find +$" ваша роль: {role}");
                    Authoriz.IsEnabled = false;
                    

                }
                else
                {
                    MessageBox.Show("Такого пользователя нет. Зарегистрируйте пользователя у админа");
                  
                }
              
            }
            else
            {
                MessageBox.Show("Такого пользователя нет. Зарегистрируйте пользователя у админа");
            }
            

        }


    }
  
}
