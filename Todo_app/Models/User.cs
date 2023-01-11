using SQLite;
using System;

namespace Todo_app.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public DateTime DateLogin { get; set; }
    }
}