using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для ProductionLogNewEdit.xaml
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