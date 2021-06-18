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
    /// Логика взаимодействия для PersonalADD.xaml
    /// </summary>
    public partial class PersonalADD : Window
    {
        DatabaseEntities DB;
        public PersonalADD()
        {
            InitializeComponent();
            DB = new DatabaseEntities();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int Ids = Convert.ToInt32(TId.Text);
            int Ages = Convert.ToInt32(TAge.Text);
            DB.Personal.Load();
            DB.Personal.Add(new Personal { Id = Ids, Name = TName.Text, Surname = TSurname.Text, Age = Ages, Doljnost = TDoljnost.Text });
            DB.SaveChanges();

            this.Close();
        }
    }
}
