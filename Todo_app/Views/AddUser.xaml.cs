using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Todo_app.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUser : ContentPage
    {
        private readonly User _user;

        public AddUser()
        {
            InitializeComponent();
            Title = "Create";
            Nametab.Text = "Add New";
        }
        public AddUser(User user)
        {
            InitializeComponent();
            _user = user;
            Title = "Update";
            Nametab.Text = "Update";
            name.Text = user.Username;
            age.Text = user.Age;
            gender.Text = user.Gender;

        }
        private async void AddNewUser(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(age.Text) || string.IsNullOrWhiteSpace(gender.Text))
            {
                await DisplayAlert("Thông báo", "Vui lòng điền đầy đủ thông tin!", "OK");
            }
            else if (_user != null)
            {
                _user.Username = name.Text;
                _user.Age = age.Text;
                _user.Birthday = birthdaySelect;
                _user.Gender = gender.Text;
                App.UserController.UpdateUser(_user);
                await Navigation.PopAsync();
                /* await DisplayAlert("Thong bao", "! null", "oke");*/
            }
            else
            {
                /*await DisplayAlert("Thong bao", "Thêm mới thất bại!", "OK");*/
                User user = new User
                {
                    Username = name.Text,
                    Birthday = birthdaySelect,
                    Gender = gender.Text,
                    Age = age.Text,
                };

                if (App.UserController.CreateUer(user))
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