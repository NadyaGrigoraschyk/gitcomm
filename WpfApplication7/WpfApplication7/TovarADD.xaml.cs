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
    /// Логика взаимодействия для TovarADD.xaml
    /// </summary>
    public partial class TovarADD : Window
    {
        DatabaseEntities DB;
        public TovarADD()
        {
            InitializeComponent();
            DB = new DatabaseEntities();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int Ids = Convert.ToInt32(TId.Text);
            DB.Tovari.Load();
            DB.Tovari.Add(new Tovari { Id = Ids, TovarName = TTovarName.Text , Description = TDescription.Text , Image = TImage.Text });
            DB.SaveChanges();

            this.Close();
        }
    }
}
