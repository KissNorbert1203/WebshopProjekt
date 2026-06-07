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

namespace WebshopProjekt.Views
{
    /// <summary>
    /// Interaction logic for SzallitasiAdatokWindow.xaml
    /// </summary>
    public partial class SzallitasiAdatokWindow : Window
    {
        public Adatok SzallitasiAdat { get; private set; }

        public SzallitasiAdatokWindow()
        {
            InitializeComponent();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            var teljesNev = FullNameBox.Text.Trim();
            var iranyitoszamText = PostalCodeBox.Text.Trim();
            var telepules = CityBox.Text.Trim();
            var utcaHazszam = AddressBox.Text.Trim();
            var telefon = PhoneBox.Text.Trim();
            var email = EmailBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(teljesNev) ||
                string.IsNullOrWhiteSpace(iranyitoszamText) ||
                string.IsNullOrWhiteSpace(telepules) ||
                string.IsNullOrWhiteSpace(utcaHazszam))
            {
                MessageBox.Show("Kérlek töltsd ki a kötelező mezőket: Név, Irányítószám, Város, Cím.", "Hiányzó adatok", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(iranyitoszamText.Replace(" ", "").Replace("\u00A0", ""), out int iranyitoszam))
            {
                MessageBox.Show("Az irányítószám nem érvényes szám.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Telefonszám validálás: tilosak nem numerikus karakterek (engedélyezzük szóközöket, kötőjeleket és + jelet, de ellenőrzés számjegyekre)
            var phoneClean = telefon.Replace(" ", "")
                                    .Replace("\u00A0", "")
                                    .Replace("-", "")
                                    .Replace("(", "")
                                    .Replace(")", "");

            // Ha + jel az elején, eltávolítjuk csak az ellenőrzéshez (megtartjuk az eredeti formátumot az Adatok-ban)
            if (phoneClean.StartsWith("+")) phoneClean = phoneClean.Substring(1);

            if (string.IsNullOrWhiteSpace(phoneClean) || !long.TryParse(phoneClean, out _))
            {
                MessageBox.Show("Érvénytelen karakter a telefonszámnál. Kérlek csak számokat, opcionálisan szóközt, kötőjelet vagy előtagként '+' jelet használj.", "Hiba a telefonszámnál", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SzallitasiAdat = new Adatok(
                teljesNev,
                iranyitoszam,
                telepules,
                utcaHazszam,
                telefon,
                email
            );

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
