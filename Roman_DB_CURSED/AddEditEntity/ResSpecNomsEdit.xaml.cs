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
    /// Логика взаимодействия для ResSpecNomsEdit.xaml
    /// </summary>
    public partial class ResSpecNomsEdit : Window
    {
        public ResSpecNomsEdit(resspecnoms rsn)
        {
            InitializeComponent();
            var db = new CalcEntities();
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
