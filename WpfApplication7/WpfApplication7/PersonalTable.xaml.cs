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
    /// Логика взаимодействия для PersonalTable.xaml
    /// </summary>
    public partial class PersonalTable : Window
    {
        DatabaseEntities DB;
        public PersonalTable()
        {
            InitializeComponent();
            DB = new DatabaseEntities();
            DB.Personal.Load();
            Gridus.ItemsSource = DB.Personal.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PersonalADD padd = new PersonalADD();
            padd.Show();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if(Gridus.SelectedItem != null)
            {
                
                PersonalEDIT pedit = new PersonalEDIT(Gridus.SelectedItem as Personal);

                pedit.Owner = this;
                pedit.ShowDialog();
            }
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(Gridus.SelectedItem != null)
            {
                try
                {
                    DB.Personal.Remove(Gridus.SelectedItem as Personal);
                    DB.SaveChanges();
                    DB.Personal.Load();
                    Gridus.ItemsSource = DB.Personal.Local.ToBindingList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DB.Personal.Load();
            Gridus.ItemsSource = DB.Personal.Local.ToBindingList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
        public void Window_Closing(DatabaseEntities DBS)
        {
            DB = DBS;
            try
            {
                Gridus.ItemsSource = DB.Personal.Local.ToBindingList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Gridus.ItemsSource = DB.Personal.Where(predicate => predicate.Name.Contains(SearchBox.Text) || predicate.Surname.Contains(SearchBox.Text)).ToList();
        }
    }
}
