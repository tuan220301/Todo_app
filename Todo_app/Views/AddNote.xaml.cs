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
        }
        public static string DateFormat = "dd-MM-yyyy";
        public static string Today => DateTime.Now.ToString(DateFormat);



        public AddNote(Notes note)
        {
            InitializeComponent();
            _note = note;
            Title = "Add Note";
            NoteTitle.Text = note.NoteTitle;
            /* CityImg.Text = city.CityImageUrl;*/
            NoteContent.Text = note.NoteContent;
            timePicker.Time = note.NoteTimeDone;
            datePicker.Date = note.NoteDateDone;
            NoteContent.TextColor = System.Drawing.Color.FromName(note.NoteColor);
            NoteTitle.TextColor = System.Drawing.Color.FromName(note.NoteTitleColor);
            Console.WriteLine("note.NoteColor" + note.NoteColor);
            Console.WriteLine("note.NoteTitleColor" + note.NoteColor);
        }
        private async void AddNewNote(object sender, EventArgs e)
        {
            var ColorContent = NoteContent.TextColor.ToString();
            var colorTitle = NoteTitle.TextColor.ToString();
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
                _note.NoteColor = ColorContent;
                _note.NoteTitleColor = colorTitle;  
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
                    NoteColor = ColorContent,
                    NoteTitleColor = colorTitle,
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
        /*private string CreateRandomColor()
        {
            var result = "#" + Guid.NewGuid().ToString().Substring(0, 6);
            return result;

        }*/
/*        TitleColor*/
        private void TitleBlueSelected(object sender, EventArgs args)
        {
           NoteTitle.TextColor= Color.FromHex("#0000FF");
            Console.WriteLine(Color.FromHex("#0000FF"));
        }
        private void TitleRedSelected(object sender, EventArgs args)
        {
            NoteTitle.TextColor = Color.Red;
        }
        private void TitleYellowSelected(object sender, EventArgs args)
        {
            NoteTitle.TextColor = Color.Yellow;
        }
        private void TitleWhiteSelected(object sender, EventArgs args)
        {
            NoteTitle.TextColor = Color.White;
        }
        private void TitleOrangeSelected(object sender, EventArgs args)
        {
            NoteTitle.TextColor = Color.Orange;
        }

        /*ContentColor*/
        private void ContentBlueSelected(object sender, EventArgs args)
        {
            NoteContent.TextColor = Color.Blue;
        }
        private void ContentRedSelected(object sender, EventArgs args)
        {
            NoteContent.TextColor = Color.Red;
        }
        private void ContentYellowSelected(object sender, EventArgs args)
        {
            NoteContent.TextColor = Color.Yellow;
        }
        private void ContentWhiteSelected(object sender, EventArgs args)
        {
            NoteContent.TextColor = Color.White;
        }
        private void ContentOrangeSelected(object sender, EventArgs args)
        {
            NoteContent.TextColor = Color.Orange;
        }
        /* private double TotalSeconds()
         {
             return 1;
         }
 */
    }
}