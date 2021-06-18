using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfApplication7
{
    /// <summary>
    /// Логика взаимодействия для TowarList.xaml
    /// </summary>
    public partial class TowarList : Window
    {
        DatabaseEntities DB;
        public TowarList()
        {
            InitializeComponent();
            DB = new DatabaseEntities();
            DB.Tovari.Load();
            TovarBox.ItemsSource = DB.Tovari.Local.ToBindingList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (TovarBox.SelectedItem != null)
            {
                try
                {
                    DB.Tovari.Remove(TovarBox.SelectedItem as Tovari);
                    DB.SaveChanges();
                    DB.Tovari.Load();
                    TovarBox.ItemsSource = DB.Tovari.Local.ToBindingList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (TovarBox.SelectedItem != null)
            {

                TovarEDIT pedit = new TovarEDIT(TovarBox.SelectedItem as Tovari);

                pedit.Owner = this;
                pedit.ShowDialog();
            }
        }
        public void Window_Closing(DatabaseEntities DBS)
        {
            DB = DBS;
            try
            {
                TovarBox.ItemsSource = DB.Tovari.Local.ToBindingList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TovarADD tadd = new TovarADD();
            tadd.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DB.Tovari.Load();
            TovarBox.ItemsSource = DB.Tovari.Local.ToBindingList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
