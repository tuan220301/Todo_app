using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Todo_app.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Todo_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetail : ContentPage
    {
        private readonly User _user;
        public UserDetail()
        {
            InitializeComponent();
            var isEmpty = (App.UserController.ReadUser()).ToArray();
            if (isEmpty.Length == 0)
            {
                Navigation.PushAsync(new AddUser());
            }
        }
        /*public UserDetail(User user)
        {
            InitializeComponent();
            _user = user;
            Title = "User Detail";
            Username.Text = user.Username;
           
            Age.Text = user.Age;
            Birthday.Date = user.Birthday;
            Gender.Text = user.Gender;
            
        }*/
         protected override void OnAppearing()
		{
			base.OnAppearing();
            showUser.ItemsSource = (App.UserController.ReadUser()).OrderByDescending(i => (i.UserId)).ToList();
        }
        private void EditUser(object sender, EventArgs e)
        {

            User user = (User)showUser.SelectedItem;
            Navigation.PushAsync(new AddUser(user));
        }
        private async void Delete(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var user = swipeItem.CommandParameter as User;

            bool answer = await DisplayAlert("Thông báo", $"Bạn có muốn xóa {user.Username} không?", "CÓ", "KHÔNG");
            if (answer)
            {
                App.UserController.DeleteUser(user);
                showUser.ItemsSource = (App.UserController.ReadUser()).OrderByDescending(i => (i.UserId)).ToList();
            }
        }
        private void AddUser(object sender, EventArgs e)
        {
            User userSelect = (User)showUser.SelectedItem;
            Navigation.PushAsync(new AddUser(userSelect));

        }

    }
    /*private async void UpdateUser(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Username.Text) || string.IsNullOrWhiteSpace(Age.Text) || string.IsNullOrWhiteSpace(Gender.Text))
        {
            await DisplayAlert("Thông báo", "Vui lòng điền đầy đủ thông tin!", "OK");
        }
        else if (_user != null)
        {
            _user.Username = Username.Text;

            _user.Age = Age.Text;
            _user.Birthday = Birthday.Date;
            _user.Gender = Gender.Text;
            App.UserController.UpdateUser(_user);
            await Navigation.PopAsync();
        }
        else
        {
            var user = new User()
            {
                Username = Username.Text,

                Age = Age.Text,
                Birthday = Birthday.Date,
                Gender = Gender.Text
            };

            if (App.UserController.CreateUer(user))
            {
                await DisplayAlert("Thông báo", "Thêm mới thành công!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Thông báo", "Thêm mới thất bại!", "OK");
            }
        }
    }
}*/
}