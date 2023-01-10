using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
namespace Todo_app.Models
{
    public class Notes
    {
        [PrimaryKey, AutoIncrement]
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        public string NoteImage { get; set; }
        public string NoteColor { get; set; }
        public string ImgTitleNote { get; set; }
        public string ImgContentNote { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime TimeUp { get; set; }
    }
}
