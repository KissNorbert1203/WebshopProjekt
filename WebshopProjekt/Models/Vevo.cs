using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopProjekt.Models
{
    internal class Vevo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public int LoyaltyPoints { get; set; }

        public Vevo()
        {
        }

        public Vevo(int userId, string phoneNumber, string address, string city, string country, DateTime birthDate, int loyaltyPoints)
        {
            UserId = userId;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            Country = country;
            BirthDate = birthDate;
            LoyaltyPoints = loyaltyPoints;
        }
    }
}
