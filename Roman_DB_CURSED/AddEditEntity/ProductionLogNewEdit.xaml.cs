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

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    /// Логика взаимодействия для ProductionLogNewEdit.xaml
    /// </summary>
    public partial class ProductionLogNewEdit : Window
    {
        private readonly CalcEntities db;
        public ProductionLogNewEdit(productionlog n, CalcEntities db)
        {
            InitializeComponent();
            //db.techmap.Load();
            //Techmaps = db.techmap.Local.ToList();
            db.resspec.Load();
            Prodstages = db.prodstage.Local.ToList();
            Productionlog = n;
            DataContext = this;
        }

        public productionlog Productionlog { get; }
        //public List<techmap> Techmaps { get; }
        public List<prodstage> Prodstages { get; }


        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            //Measure.MeasureName = namebox.Text;
            DialogResult = true;
        }
    }
}
