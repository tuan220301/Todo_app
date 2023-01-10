using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Todo_app.Models;

namespace Todo_app.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListNote : ContentPage
	{
		public ListNote ()
		{
			InitializeComponent ();
           

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowList.ItemsSource = (App.NoteController.ReadNotes()).OrderByDescending(i => (i.NoteId)).ToList();
            ShowList.EmptyView = new ContentView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Image{Source="image_notebook" ,HeightRequest=350},
                        new Label{Text="Create your first note !", TextColor=Color.White, HorizontalTextAlignment=TextAlignment.Center}
                    }
                }
            };
        }
        private void Edit(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var note = swipeItem.CommandParameter as Notes;
            /*Navigation.PushAsync(new AddNote(note));*/
        }

        private async void Delete(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var notes = swipeItem.CommandParameter as Notes;

            bool answer = await DisplayAlert("Thông báo", $"Bạn có muốn xóa {notes.NoteTitle} không?", "CÓ", "KHÔNG");
            if (answer)
            {
                App.NoteController.DeleteNote(notes);
                ShowList.ItemsSource = (App.NoteController.ReadNotes()).OrderByDescending(i => (i.NoteId)).ToList();
            }
        }
        private void AddNewNote(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddNote());
        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Notes noteSelected = (Notes)ShowList.SelectedItem;
            Navigation.PushAsync(new AddNote(noteSelected));
        }

    }
}