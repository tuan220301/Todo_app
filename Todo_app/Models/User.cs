using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Todo_app.Database
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public DateTime DateLogin { get; set; }
    }
}