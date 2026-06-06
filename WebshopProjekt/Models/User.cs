using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopProjekt.Models
{
    internal class User
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }

        public User()
        {
        }

        public string SzerepkorNev => Enum.GetName(typeof(Szerepkor), Role) ?? "Ismeretlen";

        public User(string username, string password, string email, int role)
        {
            Username = username;
            Password = password;
            Email = email;
            Role = role;
        }
    }
}
