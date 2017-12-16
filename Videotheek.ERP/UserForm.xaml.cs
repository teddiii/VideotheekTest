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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Videotheek.BL;
using Videotheek.Entities;
using Videotheek.ERP.Extensions;

namespace Videotheek.ERP
{
    /// <summary>
    /// Interaction logic for UserForm.xaml
    /// </summary>
    public partial class UserForm : UserControl
    {
        public delegate void OnConfirm(Users user, string pwd);
        public event OnConfirm Confirming;

        public Users Model { get; set; }

        public delegate void ModelSavedEventHandler(Users model);
        public event ModelSavedEventHandler OnModelSaved;

        public UserForm() : this(new Users()) { }

        public bool ShowPassword { get; set; }

        public UserForm(Users model)
        {
            InitializeComponent();

            this.ShowPassword = false;

            ToggleShowpassword();

            this.Model = model;

            grdForm.DataContext = this;
        }

        private void ToggleShowpassword()
        {
            txtPassword.Visibility = btnShowPwd.Visibility = !ShowPassword ? Visibility.Visible : Visibility.Collapsed;
            txtPasswordplain.Visibility = btnHidePwd.Visibility = ShowPassword ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Confirming?.Invoke(Model, txtPassword.Password);

            try
            {
                if (BL_Users.Save(Model))
                    if (OnModelSaved != null)
                        OnModelSaved(Model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnShowPwd_Click(object sender, RoutedEventArgs e)
        {
            ShowPassword = true;
            ToggleShowpassword();
        }

        private void btnHidePwd_Click(object sender, RoutedEventArgs e)
        {
            ShowPassword = false;
            ToggleShowpassword();
        }

        private void txtPasswordplain_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPassword.Password = txtPasswordplain.Text;
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPasswordplain.Text = txtPassword.Password;
            txtPassword.SetCursorOnEnd();
        }
    }
}
