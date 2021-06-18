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
    /// Логика взаимодействия для PersonalEDIT.xaml
    /// </summary>
    public partial class PersonalEDIT : Window
    {
        DatabaseEntities DB;
        public PersonalEDIT(Personal 
            
            \\\\4)
        {
            InitializeComponent();
            DB = new DatabaseEntities();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int Ids = Convert.ToInt32(TId.Text);
            int Ages = Convert.ToInt32(TAge.Text);
            DB.Personal.Load();
            var DBEM = DB.Personal.Local.Where(predicate => predicate.Id == Ids).FirstOrDefault();

            DBEM.Id = Ids;
            DBEM.Name = TName.Text;
            DBEM.Surname = TSurname.Text;
            DBEM.Age = Ages;
            DBEM.Doljnost = TDoljnost.Text;

            DB.SaveChanges();

            (this.Owner as PersonalTable).Window_Closing(DB);
            this.Close();
        }
    }
}
