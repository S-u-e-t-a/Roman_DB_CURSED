using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для ResSpecNomsEdit.xaml
    /// </summary>
    public partial class ResSpecNomsEdit : Window
    {
        public ResSpecNomsEdit(resspecnoms rsn, CalcEntities db)
        {
            InitializeComponent();
            db.nom.Load();
            Noms = db.nom.Local.ToList();
            Resspecnoms = rsn;
            DataContext = this;
        }


        public resspecnoms Resspecnoms { get; }
        public List<nom> Noms { get; }


        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            //Measure.MeasureName = namebox.Text;
            DialogResult = true;
        }
    }
}