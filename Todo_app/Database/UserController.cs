using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using SQLite;
using Todo_app.Models;


namespace Todo_app.Database
{
    public class UserController
    {
        private readonly SQLiteConnection db;
        public UserController()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            db = new SQLiteConnection(System.IO.Path.Combine(folder, "UsersDatabase.db3"));
            db.CreateTable<User>();
        }
        public bool CreateUer(User list_user)
        {
            try
            {
                db.Insert(list_user);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }
        public List<User> ReadUser()
        {
            try
            {
                return db.Table<User>().ToList();
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return null;
                throw;
            }
        }
        public bool UpdateUser(User User)
        {
            try
            {
                db.Update(User);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }
        public bool DeleteUser(User user)
        {
            try
            {
                db.Delete(user);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }
    }
}
