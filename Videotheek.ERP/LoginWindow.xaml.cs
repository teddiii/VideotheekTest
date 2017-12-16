using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Videotheek.BL;
using Videotheek.ERP.Extensions;

namespace Videotheek.ERP
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public bool ShowPassword { get; set; }

        public LoginWindow()
        {
            InitializeComponent();

            ShowPassword = false;
            TogglePassword();

            txtUsername.Focus();

            if (BL_Users.Any())
                txtUsername.Focus();
            else
            {
                var _initUserWindow = new Initialuserwindow();
                _initUserWindow.OnUserCreated += InitialUserWindow_OnUserCreated;

                _initUserWindow.Show();
            }

        }

        private void InitialUserWindow_OnUserCreated(string username, string pwd)
        {
            txtUsername.Text = username;
            txtPassword.Password = pwd;

            txtPassword.Focus();
            txtPassword.SetCursorOnEnd();
        }

        private void TogglePassword()
        {
            txtPassword.Visibility = btnShowPwd.Visibility = !ShowPassword ? Visibility.Visible : Visibility.Collapsed;
            txtPasswordPlain.Visibility = btnHidePwd.Visibility = ShowPassword ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to close the application?", "Close application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Authenticate();
        }

        private void Authenticate()
        {
            string _username = txtUsername.Text.ToLower();
            string _pass = txtPassword.Password;

            bool Validation = false;

            lblUsernameError.Content = "";
            lblPasswordError.Content = "";

            if (_username == "admin" && _pass == "admin")
            {
                Validation = true;
            }

            if (Validation == true)
            {
                new MainWindow().Show();
                this.Close();
            }

            switch (_username)
            {
                case null: lblUsernameError.Content = "The username is required to login.";
                    break;
                case "": lblUsernameError.Content = "The username is required to login.";
                    break;
            }

            switch (_pass)
            {
                case null: lblPasswordError.Content = "The password is required to login.";
                    break;
                case "": lblPasswordError.Content = "The password is required to login.";
                    break;
            }

            if (_username != "admin" && !string.IsNullOrWhiteSpace(_username))
            {
                lblUsernameError.Content = "The username is invalid.";
                
            }

            if (_pass != "admin" && !string.IsNullOrWhiteSpace(_pass))
            {
                lblPasswordError.Content = "the password you gave is invalid.";
                
            }


                
        }

        private void btnHidePwd_Click(object sender, RoutedEventArgs e)
        {
            ShowPassword = false;
            TogglePassword();
        }

        private void btnShowPwd_Click(object sender, RoutedEventArgs e)
        {
            ShowPassword = true;
            TogglePassword();
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                txtPassword.Focus();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Authenticate();
        }

        private void txtPasswordPlain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Authenticate();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPasswordPlain.Text = txtPassword.Password;
            txtPassword.SetCursorOnEnd();
        }

        private void txtPasswordPlain_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPassword.Password = txtPasswordPlain.Text;
            txtPassword.Focus();
        }
    }
}
