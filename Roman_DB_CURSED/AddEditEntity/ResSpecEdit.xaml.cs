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
        private readonly CalcEntities db;


        public ResSpecEdit(resspec rs, CalcEntities db)
        {
            InitializeComponent();
            this.db = db;
            Measures = db.measure.Local.ToList();
            db.techmap.Load();
            Techmaps = db.techmap.Local.ToList();
            db.resspec.Load();
            Resspecs = db.resspec.Local.ToList();
            Resspec = rs;
            DataContext = this;
        }


        public resspec Resspec { get; }

        public List<resspecnoms> Resspecnoms
        {
            get { return Resspec.resspecnoms.ToList(); }
        }

        public List<measure> Measures { get; }
        public List<techmap> Techmaps { get; }
        public List<resspec> Resspecs { get; }


        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }


        private void AddClick(object sender, RoutedEventArgs e)
        {
            ResSpecNomsEdit resSpecNomsEdit = new ResSpecNomsEdit(new resspecnoms {resspec = Resspec}, db);
            if (resSpecNomsEdit.ShowDialog() == true)
            {
                resspecnoms resspecnoms = resSpecNomsEdit.Resspecnoms;
                Resspec.resspecnoms.Add(resspecnoms);
                RSNGrid.ItemsSource = Resspecnoms;
            }
        }


        private void EditClick(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (RSNGrid.SelectedItem == null) return;
            // получаем выделенный объект
            var RSN = RSNGrid.SelectedItem as resspecnoms;

            var resSpecNomsEdit = new ResSpecNomsEdit(RSN, db); //todo чекнуть работу именно тут

            if (resSpecNomsEdit.ShowDialog() == true) db.SaveChanges();
        }


        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (RSNGrid.SelectedItem == null) return;
            // получаем выделенный объект
            var RSN = RSNGrid.SelectedItem as resspecnoms;
            Resspec.resspecnoms.Remove(RSN);
            RSNGrid.ItemsSource = Resspecnoms;
        }
    }
}