using System;
using Todo_app.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetail : ContentPage
    {
        User _user;
        public UserDetail()
        {
            InitializeComponent();
        }
        public UserDetail(User user)
        {
            InitializeComponent();
            _user = user;
            Title = "User Detail";
            Username.Text = user.Username;
            Password.Text = user.Password;
            Age.Text = user.Age;
            Birthday.Date = user.Birthday;
            Gender.Text = user.Gender;
        }
        private async void UpdateUser(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username.Text) || string.IsNullOrWhiteSpace(Password.Text) || string.IsNullOrWhiteSpace(Age.Text) || string.IsNullOrWhiteSpace(Gender.Text))
            {
                await DisplayAlert("Thông báo", "Vui lòng điền đầy đủ thông tin!", "OK");
            }
            else if (_user != null)
            {
                _user.Username = Username.Text;
                _user.Password = Password.Text;
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
                    Password = Password.Text,
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
    }
}