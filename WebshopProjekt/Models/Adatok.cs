using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopProjekt.Models
{
    public class Adatok
    {

        public string TeljesNev { get; set; }
        public int Iranyitoszam { get; set; }
        public string Telepules { get; set; }
        public string UtcaHazszam { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public Adatok()
        {
        }

        public Adatok(string teljesNev, int iranyitoszam, string telepules, string utcaHazszam, string telefon, string email)
        {
            TeljesNev = teljesNev;
            Iranyitoszam = iranyitoszam;
            Telepules = telepules;
            UtcaHazszam = utcaHazszam;
            Telefon = telefon;
            Email = email;
        }
    }
}
