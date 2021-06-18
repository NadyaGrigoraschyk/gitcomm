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
    /// Логика взаимодействия для TovarEDIT.xaml
    /// </summary>
    public partial class TovarEDIT : Window
    {
        DatabaseEntities DB;
        public TovarEDIT(Tovari TBT)
        {
            InitializeComponent();
            DB = new DatabaseEntities();
        }

    private void Edit_Click(object sender, RoutedEventArgs e)
    {
        int Ids = Convert.ToInt32(TId.Text);
        DB.Tovari.Load();
        var DBEM = DB.Tovari.Local.Where(predicate => predicate.Id == Ids).FirstOrDefault();

        DBEM.Id = Ids;
        DBEM.TovarName = TTovarName.Text;
        DBEM.Description = TDescription.Text;
        DBEM.Image = TImage.Text;

        DB.SaveChanges();

        (this.Owner as TowarList).Window_Closing(DB);
        this.Close();
    }
}
}
