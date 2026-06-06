using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopProjekt.Models
{
    internal class Termek
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }

        public Termek()
        {
        }

        public Termek(string name, decimal price, string category, string brand)
        {
            Name = name;
            Price = price;
            Category = category;
            Brand = brand;
        }

        
    }
}
