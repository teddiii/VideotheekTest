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
using Videotheek.Utilities;

namespace Videotheek.ERP
{
    /// <summary>
    /// Interaction logic for UserOverview.xaml
    /// </summary>
    public partial class UserOverview : UserControl
    {
        public delegate void UpdateUser(Users model);
        public event UpdateUser OnUpdateUser;

        public ObservableCollection<Users> DataSource { get; set; }

        public UserOverview()
        {
            InitializeComponent();

            BindData();
        }

        private void BindData()
        {
            DataSource = new ObservableCollection<Users>(BL_Users.GetAll());
            DataSource.CollectionChanged += DataSource_CollectionChanged;
            grdUserOverview.ItemsSource = DataSource;
            grdUserOverview.DataContext = DataSource;
        }

        private void DataSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Users item in e.NewItems)
                        BL_Users.Save(item);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (Users item in e.OldItems)
                        BL_Users.Delete(item);
                    break;
            }
        }

        private void grdUserOverview_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            DataGridRow _dgRow = e.Row;
            var _changedValue = _dgRow.DataContext as Users;

            BL_Users.Save(_changedValue);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as Users;

            if (MessageBox.Show("Are you sure you want to delete this User?"
                                    , "Delete User", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                DataSource.Remove(obj);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as Users;

            if (OnUpdateUser != null)
                OnUpdateUser(obj);
        }
    }
}
