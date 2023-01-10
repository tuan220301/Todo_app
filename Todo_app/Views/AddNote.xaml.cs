using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_app.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Todo_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNote : ContentPage
    {
        Notes _note;
        public AddNote()
        {
            InitializeComponent();
            ShowTitle.Text = "New Note";

        }
        public static string DateFormat = "dd-MM-yyyy";
        public static string Today => DateTime.Now.ToString(DateFormat);


        public AddNote(Notes note)
        {
            InitializeComponent();
            String myDate = DateTime.Now.ToString(Today);
            ShowTitle.Text = myDate;
            _note = note;
            Title = "Add Note";
            NoteTitle.Text = note.NoteTitle;
            /* CityImg.Text = city.CityImageUrl;*/
            NoteContent.Text = note.NoteContent;


        }
        
        /*public void AddEntry()
        {
            var name = "entry ";
            var entry = new Entry();
            myLayout.Children.Add(entry);
            entries.Add(name, entry);
        }*/
        private async void AddNewNote(object sender, EventArgs e)
        {
            var coloNote = CreateRandomColor();
            var selectedDate = datePicker.Date.ToString();
            var selectedTime = timePicker.Time.ToString();


            if (string.IsNullOrWhiteSpace(NoteTitle.Text) || string.IsNullOrWhiteSpace(NoteContent.Text))
            {
                await DisplayAlert("Thông báo", "Vui lòng điền đầy đủ thông tin!", "OK");
            }
            else if (_note != null)
            {

                _note.NoteTitle = NoteTitle.Text;
                _note.NoteContent = NoteContent.Text;
                _note.NoteColor = coloNote.ToString();
                _note.NoteDateDone = selectedDate;
                _note.NoteTimeDone = selectedTime;
                App.NoteController.UpdateNote(_note);
                await Navigation.PopAsync();
            }
            else
            {

                Notes note = new Notes
                {
                    NoteTitle = NoteTitle.Text,
                    NoteContent = NoteContent.Text,
                    NoteColor = coloNote.ToString(),
                    NoteDateDone = selectedDate,
                    NoteTimeDone = selectedTime
                };

                if (App.NoteController.CreateNote(note))
                {
                    await DisplayAlert("Thông báo", "Thêm mới thành công!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Lỗi", "Thêm mới thất bại!", "OK");
                }
            }
        }
        private string CreateRandomColor()
        {
            var result = "#" + Guid.NewGuid().ToString().Substring(0, 6);
            return result;

        }
        private double TotalSeconds()
        {
            return 1;
        }

    }
}