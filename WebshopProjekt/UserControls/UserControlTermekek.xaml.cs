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
    /// Interaction logic for UserControlTermekek.xaml
    /// </summary>
    public partial class UserControlTermekek : UserControl
    {
        List<Termek> termekek;
        Termek valasztottTermek;
        public UserControlTermekek()
        {
            InitializeComponent();
            termekek = new List<Termek>();
            ReadDatabase();
            mentesBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            torlesBtn.Visibility = Visibility.Hidden;
        }

        private void ReadDatabase()
        {
            NevTxtBx.Text = "";
            ArTxtBx.Text = "";
            KategoriaTxtBx.Text = "";
            MarkaTxtBx.Text = "";

            var TermekRepository = new GenericRepository<Termek>(App.databasePath);
            var TermekLekerdezes = TermekRepository.GetAll();
            datagridTermekek.ItemsSource = TermekLekerdezes;

            mentesBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            torlesBtn.Visibility = Visibility.Hidden;
        }

        private void datagridTermekek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            modBtn.Visibility = Visibility.Visible;
            torlesBtn.Visibility = Visibility.Visible;
            mentesBtn.Visibility = Visibility.Hidden;
            if (datagridTermekek.SelectedItem != null)
            {
                valasztottTermek = (Termek)datagridTermekek.SelectedItem;
                NevTxtBx.Text = valasztottTermek.Name;
                ArTxtBx.Text = valasztottTermek.Price.ToString();
                KategoriaTxtBx.Text = valasztottTermek.Category;
                MarkaTxtBx.Text = valasztottTermek.Brand;
            }
        }
        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {
            //uj termék objektum
            Termek ujTermek = new Termek(NevTxtBx.Text, decimal.Parse(ArTxtBx.Text), KategoriaTxtBx.Text, MarkaTxtBx.Text);

            var TermekRepository = new GenericRepository<Termek>(App.databasePath);
            TermekRepository.insert(ujTermek);

            ReadDatabase();
        }

        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {
            var TermekRepository = new GenericRepository<Termek>(App.databasePath);
            TermekRepository.delete(valasztottTermek);

            ReadDatabase();
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            valasztottTermek.Name = NevTxtBx.Text;
            valasztottTermek.Price = decimal.Parse(ArTxtBx.Text);
            valasztottTermek.Category = KategoriaTxtBx.Text;
            valasztottTermek.Brand = MarkaTxtBx.Text;

            //repo update
            var TermekRepository = new GenericRepository<Termek>(App.databasePath);
            TermekRepository.update(valasztottTermek);

            ReadDatabase();
        }
    }
}
