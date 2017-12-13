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

namespace Videotheek.ERP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        private const string TITLE = "Videotheek ERP";

        public MainWindow()
        {
            InitializeComponent();

            setTitle();

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
    }
}
