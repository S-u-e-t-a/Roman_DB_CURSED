using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для ResSpecEdit.xaml
    /// </summary>
    public partial class ResSpecEdit : Window
    {
        private CalcEntities db;
        public ResSpecEdit(resspec rs, CalcEntities db)
        {
            InitializeComponent();
            this.db = db;
            db.nomtype.Load();
            Resspecnoms = db.resspecnoms.Local.Where(x => x.ResSpecId == rs.ResSpecId).ToList();
            db.nomtype.Load();
            Measures = db.measure.Local.ToList();
            db.techmap.Load();
            Techmaps = db.techmap.Local.ToList();
            db.resspec.Load();
            Resspecs = db.resspec.Local.ToList();
            Resspec = rs;
            DataContext = this;
        }

        public resspec Resspec { get; }
        public List<resspecnoms> Resspecnoms { get; }
        public List<measure> Measures { get; }
        public List<techmap> Techmaps { get; }
        public List<resspec> Resspecs { get; }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CalcEntities db = new CalcEntities();
            ResSpecNomsEdit resSpecNomsEdit = new ResSpecNomsEdit(new resspecnoms(){resspec = Resspec});
            if (resSpecNomsEdit.ShowDialog() == true)
            {
                resspecnoms resspecnoms = resSpecNomsEdit.Resspecnoms;
                db.resspecnoms.Add(resspecnoms);
                db.SaveChanges();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (RSNGrid.SelectedItem == null) return;
            // получаем выделенный объект
            var RSN = RSNGrid.SelectedItem as resspecnoms;

            var resSpecNomsEdit = new ResSpecNomsEdit(RSN); //todo чекнуть работу именно тут

            if (resSpecNomsEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (RSNGrid.SelectedItem == null) return;
            // получаем выделенный объект
            var RSN = RSNGrid.SelectedItem as resspecnoms;
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                db.resspecnoms.Remove(RSN);
                db.SaveChanges();
            }
        }
    }
}