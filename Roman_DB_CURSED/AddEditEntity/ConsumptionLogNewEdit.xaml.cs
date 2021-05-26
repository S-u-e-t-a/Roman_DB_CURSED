using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для ConsumptionLogNewEdit.xaml
    /// </summary>
    public partial class ConsumptionLogNewEdit : Window
    {
        private readonly CalcEntities db;

        public ConsumptionLogNewEdit(consumptionlog cl, CalcEntities db)
        {
            InitializeComponent();
            db.nom.Load();
            Noms = db.nom.Local.ToList();
            Consumptionlog = cl;
            DataContext = this;
        }

        public consumptionlog Consumptionlog { get; }
        public List<nom> Noms { get; }

        public List<productionlog> Productionlogs => db.productionlog.Local
            .Where(x => x.OrderId == Consumptionlog.productionlog.OrderId).ToList();

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            //Measure.MeasureName = namebox.Text;
            DialogResult = true;
        }
    }
}