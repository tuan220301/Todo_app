using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using Todo_app.Models;
using System.Diagnostics;
namespace Todo_app
{
    public class NoteController
    {
        private readonly SQLiteConnection db;
        public NoteController()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            db = new SQLiteConnection(System.IO.Path.Combine(folder, "NotesDatabase.db3"));
            db.CreateTable<Notes>();
        }
        public bool CreateNote(Notes list_note)
        {
            try
            {
                db.Insert(list_note);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }
        public List<Notes> ReadNotes()
        {
            try
            {
                return db.Table<Notes>().ToList();
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return null;
                throw;
            }
        }
        public bool UpdateNote(Notes Notes)
        {
            try
            {
                db.Update(Notes);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }
        public bool DeleteNote(Notes note)
        {
            try
            {
                db.Delete(note);
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
