using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

using Roman_DB_CURSED.AddEditEntity;

namespace Roman_DB_CURSED
{
    /// <summary>
    ///     Логика взаимодействия для ConsumptionLogProdEdit.xaml
    /// </summary>
    public partial class ConsumptionLogProdEdit : Window
    {
        private readonly CalcEntities db;


        public ConsumptionLogProdEdit(productionlog prl, CalcEntities db)
        {
            InitializeComponent();
            this.db = db;
            Measures = db.measure.Local.ToList();
            db.techmap.Load();
            Techmaps = db.techmap.Local.ToList();
            db.resspec.Load();
            Resspecs = db.resspec.Local.ToList();

            Productionlog = prl;
            //Order = o;
            DataContext = this;
        }


        public order Order { get; }
        public productionlog Productionlog { get; }

        public List<consumptionlog> Consumptionlogs
        {
            get { return Productionlog.consumptionlog.ToList(); }
        }

        public List<measure> Measures { get; }
        public List<techmap> Techmaps { get; }
        public List<resspec> Resspecs { get; }


        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }


        private void EditClick(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (CL.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var consumptionlog = CL.SelectedItem as consumptionlog;

            var resSpecNomsEdit = new ConsumptionLogNewEdit(consumptionlog, db); //todo чекнуть работу именно тут

            if (resSpecNomsEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }


        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (CL.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var consumptionlog = CL.SelectedItem as consumptionlog;
            Consumptionlogs.Remove(consumptionlog);
            CL.ItemsSource = Consumptionlogs;
        }


        private void AddConsumptionLog(object sender, RoutedEventArgs e)
        {
            var consumptionLogNewEdit =
                new ConsumptionLogNewEdit(new consumptionlog {productionlog = Productionlog}, db);
            if (consumptionLogNewEdit.ShowDialog() == true)
            {
                var consumptionlog = consumptionLogNewEdit.Consumptionlog;
                Productionlog.consumptionlog.Add(consumptionlog);
                CL.ItemsSource = Consumptionlogs;
            }
        }
    }
}