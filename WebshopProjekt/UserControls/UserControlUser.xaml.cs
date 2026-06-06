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
using WebshopProjekt.Models;
using WebshopProjekt.Services;

namespace WebshopProjekt.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlUser.xaml
    /// </summary>
    public partial class UserControlUser : UserControl
    {
        List<User> users;
        User valasztottUser;
        public UserControlUser()
        {
            InitializeComponent();
            users = new List<User>();
            ReadDatabase();
            mentesBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            torlesBtn.Visibility = Visibility.Hidden;
            szerepkorBx.ItemsSource = Enum.GetNames(typeof(Szerepkor));
        }

        private void ReadDatabase()
        {
            szerepkorBx.SelectedItem = Enum.GetName(typeof(Szerepkor), Szerepkor.Guest);
            UsernameTxtBx.Text = "";
            PasswordBx.Password = "";
            EmailTxtBx.Text = "";

            var UserRepository = new GenericRepository<User>(App.databasePath);
            var UserLekerdezes = UserRepository.GetAll();
            datagridUsers.ItemsSource = UserLekerdezes;

            mentesBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            torlesBtn.Visibility = Visibility.Hidden;
        }
        private void datagridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            modBtn.Visibility = Visibility.Visible;
            torlesBtn.Visibility = Visibility.Visible;
            mentesBtn.Visibility = Visibility.Hidden;
            if (datagridUsers.SelectedItem != null)
            {
                valasztottUser = (User)datagridUsers.SelectedItem;
                UsernameTxtBx.Text = valasztottUser.Username;
                PasswordBx.Password = valasztottUser.Password;
                EmailTxtBx.Text = valasztottUser.Email;
                szerepkorBx.Text = valasztottUser.SzerepkorNev;
            }
        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {
            string selectedSzerepkorNev = (string)szerepkorBx.SelectedItem;
            Szerepkor selectedSzerepkor = (Szerepkor)Enum.Parse(typeof(Szerepkor), selectedSzerepkorNev);
            int selectedSzerepkorId = (int)selectedSzerepkor;

            User ujUser = new User(UsernameTxtBx.Text, PasswordHelper.HashPassword(PasswordBx.Password), EmailTxtBx.Text, selectedSzerepkorId);

            //uj user repo, insert to db
            var UserRepository = new GenericRepository<User>(App.databasePath);
            UserRepository.insert(ujUser);

            ReadDatabase();
        }

        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {
            var UserRepository = new GenericRepository<User>(App.databasePath);
            UserRepository.delete(valasztottUser);

            ReadDatabase();
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            valasztottUser.Username = UsernameTxtBx.Text;

            if (PasswordBx.Password != "")
            {
                valasztottUser.Password = PasswordHelper.HashPassword(PasswordBx.Password);
            }

            valasztottUser.Email = EmailTxtBx.Text;

            string selectedSzerepkorNev = (string)szerepkorBx.SelectedItem;
            Szerepkor selectedSzerepkor = (Szerepkor)Enum.Parse(typeof(Szerepkor), selectedSzerepkorNev);
            int selectedSzerepkorId = (int)selectedSzerepkor;

            valasztottUser.Role = selectedSzerepkorId;

            //repo update
            var UserRepository = new GenericRepository<User>(App.databasePath);
            UserRepository.update(valasztottUser); 
            
            ReadDatabase();
        }

    }
}
