using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Videotheek.BL;
using Videotheek.Entities;
using Videotheek.Utilities;

namespace Videotheek.ERP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        private const string TITLE = "Videotheek ERP";
        private Users currentUser;

        public MainWindow()
        {
            InitializeComponent();

            setTitle();

            currentUser = BL_Users.GetCurrentUser();
        }

        private void setTitle(string label = null)
        {
            try
            {
                string _title = "";

                if (!string.IsNullOrWhiteSpace(label))
                {
                    _title += _title + label + " - ";
                }

                //_title += TITLE + " " + currentUser.Fullname;

                this.Title = _title;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetTitleByRibbonButton(object sender)
        {
            try
            {
                setTitle(((RibbonButton)sender).Label);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ramiExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Mainscreen_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = MessageBox.Show("Are you sure you want to exit the application?", "Exit application", MessageBoxButton.YesNo) == MessageBoxResult.No;
        }

        private void btnProductOverview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTitleByRibbonButton(sender);

                mainContent.Content = new ProductOverview();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnProductAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTitleByRibbonButton(sender);

                var _form = new ProductForm();
                _form.OnModelSaved += ProductOnModelSaved;

                mainContent.Content = _form;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ProductOnModelSaved(Entities.Product model)
        {
            btnProductOverview_Click(btnProductOverview, null);
        }

        private void ramiManageCurrentAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                setTitle("Manage my account");

                var _accountform = new UserForm(currentUser);
                _accountform.Confirming += Accountform_Confirming;

                mainContent.Content = _accountform;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Accountform_Confirming(Users user, string pwd)
        {
            try
            {
                BL_Users.Update(user, pwd);

                mainContent.Content = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnUserOverview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTitleByRibbonButton(sender);

                var _overview = new UserOverview();
                _overview.OnUpdateUser += UserOverview_OnUpdateUser;

                mainContent.Content = _overview;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UserOverview_OnUpdateUser(Users model)
        {
            try
            {
                setTitle("Edit users");

                UserForm _form = new UserForm(model);
                _form.OnModelSaved += Users_OnModelSaved;
                _form.Confirming += Accountform_Confirming;

                mainContent.Content = _form;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Users_OnModelSaved(Users model)
        {
            btnUserOverview_Click(btnUserOverview, null);
        }

        private void btnUserAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTitleByRibbonButton(sender);

                var _form = new UserForm();
                _form.Confirming += NewUserForm_Confirming;

                mainContent.Content = _form;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void NewUserForm_Confirming(Users user, string pwd)
        {
            try
            {
                if (string.IsNullOrEmpty(pwd))
                    pwd = StringExtensions.GetRandomString();

                user = BL_Users.ChangePassword(user, pwd);
                BL_Users.Create(user);

                btnUserOverview_Click(btnUserOverview, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
