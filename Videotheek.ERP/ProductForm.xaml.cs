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
using System.Xaml;

namespace Videotheek.ERP
{
    /// <summary>
    /// Interaction logic for ProductForm.xaml
    /// </summary>
    public partial class ProductForm : UserControl
    {

        public delegate void ModelSavedEventHandler(Product model);

        public event ModelSavedEventHandler OnModelSaved;

        public Product Model { get; private set; }

        public ProductForm() : this(new Product()) { }


        public ProductForm(Product model)
        {
            InitializeComponent();

            this.Model = model;

            grdAddProduct.DataContext = this;

            SetTitle();

        }

        private void SetTitle()
        {
            if (Model.IsNew())
            {
                lblTitle.Content = "New product";
            }
            else
            {
                lblTitle.Content = "Edit product";
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BL_Products.Save(Model))
                {
                    if (OnModelSaved != null)
                    {
                        OnModelSaved(Model);
                    }
                        
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
