using System;
using Todo_app.Models;
using Xamarin.Forms;
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
        }
        public static string DateFormat = "dd-MM-yyyy";
        public static string Today => DateTime.Now.ToString(DateFormat);



        public AddNote(Notes note)
        {
            InitializeComponent();
            _note = note;
            Title = "Add Note";
            NoteTitle.Text = note.NoteTitle;
            NoteContent.Text = note.NoteContent;
            timePicker.Time = note.NoteTimeDone;
            datePicker.Date = note.NoteDateDone;
            // NoteContent.TextColor = System.Drawing.Color.FromName(note.NoteColor);
            // NoteTitle.TextColor = System.Drawing.Color.FromName(note.NoteTitleColor);
            // Console.WriteLine("note.NoteColor" + note.NoteColor);
            // Console.WriteLine("note.NoteTitleColor" + note.NoteColor);
        }
        private async void AddNewNote(object sender, EventArgs e)
        {
            // var ColorContent = NoteContent.TextColor.ToString();
            // var colorTitle = NoteTitle.TextColor.ToString();
            var selectedDate = datePicker.Date;
            var selectedTime = timePicker.Time;


            if (string.IsNullOrWhiteSpace(NoteTitle.Text) || string.IsNullOrWhiteSpace(NoteContent.Text))
            {
                await DisplayAlert("Thông báo", "Vui lòng điền đầy đủ thông tin!", "OK");
            }
            else if (_note != null)
            {

                _note.NoteTitle = NoteTitle.Text;
                _note.NoteContent = NoteContent.Text;
                // _note.NoteColor = ColorContent;
                // _note.NoteTitleColor = colorTitle;
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
                    // NoteColor = ColorContent,
                    // NoteTitleColor = colorTitle,
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

    }
}