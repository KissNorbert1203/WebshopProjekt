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
using System.Windows.Shapes;
using WebshopProjekt.Models;
using WebshopProjekt.Services;

namespace WebshopProjekt.Views
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string userName = loginUserText.Text;
            string passwordHas = PasswordHelper.HashPassword(loginPasswordText.Password);

            if (!string.IsNullOrEmpty(loginUserText.Text) || !string.IsNullOrEmpty(loginPasswordText.Password))
            {
                using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                {
                    var user = connection.Table<User>().FirstOrDefault(u => u.Username == userName);

                    //ha van ilyen felhasznalo
                    if (user != null)
                    {
                        //jelszoellenorzes
                        if (user.Password == passwordHas)
                        {
                            //sikeres
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Belépés megtagadva!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Belépés megtagadva!");
                    }
                }
            }
        }
    }
}
