using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для ConsumptionLogEdit.xaml
    /// </summary>
    public partial class ConsumptionLogEdit : Window
    {
        private readonly CalcEntities db;

        public ConsumptionLogEdit(order o, CalcEntities db)
        {
            InitializeComponent();
            this.db = db;
            Measures = db.measure.Local.ToList();
            db.techmap.Load();
            Techmaps = db.techmap.Local.ToList();
            db.resspec.Load();
            Resspecs = db.resspec.Local.ToList();
            Order = o;
            DataContext = this;
        }

        public order Order { get; }

        public List<consumptionlog> Consumptionlogs => Order.productionlog.SelectMany(x => x.consumptionlog).ToList();

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
            if (CL.SelectedItem == null) return;
            // получаем выделенный объект
            var consumptionlog = CL.SelectedItem as consumptionlog;

            var resSpecNomsEdit = new ConsumptionLogNewEdit(consumptionlog, db); //todo чекнуть работу именно тут

            if (resSpecNomsEdit.ShowDialog() == true) db.SaveChanges();
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (CL.SelectedItem == null) return;
            // получаем выделенный объект
            var consumptionlog = CL.SelectedItem as consumptionlog;
            Order.productionlog.Single(x => x == consumptionlog.productionlog).consumptionlog.Remove(consumptionlog);
            CL.ItemsSource = Consumptionlogs;
        }
    }
}