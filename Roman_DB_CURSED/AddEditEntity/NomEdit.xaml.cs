using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для NomEdit.xaml
    /// </summary>
    public partial class NomEdit : Window
    {
        public NomEdit(nom n, CalcEntities db)
        {
            InitializeComponent();
            db.nomtype.Load();
            Nomtypes = db.nomtype.Local.ToList();
            db.nomtype.Load();
            Measures = db.measure.Local.ToList();
            db.techmap.Load();
            Techmaps = db.techmap.Local.ToList();
            db.resspec.Load();
            Resspecs = db.resspec.Local.ToList();
            Nom = n;
            DataContext = this;
        }

        public nom Nom { get; }
        public List<nomtype> Nomtypes { get; }
        public List<measure> Measures { get; }
        public List<techmap> Techmaps { get; }
        public List<resspec> Resspecs { get; }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            //Measure.MeasureName = namebox.Text;
            DialogResult = true;
        }
    }
}