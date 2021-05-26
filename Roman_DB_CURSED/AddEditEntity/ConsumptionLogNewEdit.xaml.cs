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
    /// Логика взаимодействия для ConsumptionLogNewEdit.xaml
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
