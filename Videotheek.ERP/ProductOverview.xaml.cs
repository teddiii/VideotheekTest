using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace Videotheek.ERP
{
    /// <summary>
    /// Interaction logic for ProductOverview.xaml
    /// </summary>
    public partial class ProductOverview : UserControl
    {
        public delegate void UpdateProduct(Product model);
        public event UpdateProduct OnUpdateProduct;

        public ObservableCollection<Product> DataSource { get; set; }


        public ProductOverview()
        {
            InitializeComponent();

            BindData();
        }

        private void BindData()
        {
            DataSource = new ObservableCollection<Product>(BL_Products.GetAll());
            DataSource.CollectionChanged += DataSourceChanged;
            grdProducts.ItemsSource = DataSource;
            grdProducts.DataContext = DataSource;
        }

        private void DataSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Product p in e.NewItems)
                        BL_Products.Save(p);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (Product p in e.OldItems)
                        BL_Products.Delete(p);
                    break;
            }
        }

        private void grdProducts_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            DataGridRow _dgrow = e.Row;
            var _edited = _dgrow.DataContext as Product;
            

            BL_Products.Save(_edited);

            BindData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as Product;

            if (OnUpdateProduct != null)
                OnUpdateProduct(obj);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as Product;

            if (MessageBox.Show("Are you sure you want to delete this product?"
                                    , "Delete product", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                DataSource.Remove(obj);
        }

       
        private void btnToggleReservation_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as Product;
            obj.IsReserved = !obj.IsReserved;
            BL_Products.Save(obj);
            BindData();
        }
    }
}
