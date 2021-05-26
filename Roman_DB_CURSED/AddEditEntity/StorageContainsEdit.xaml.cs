using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для StorageContainsEdit.xaml
    /// </summary>
    public partial class StorageContainsEdit : Window
    {
        public StorageContainsEdit(storagecontains s, CalcEntities db)
        {
            InitializeComponent();
            db.nom.Load();
            Noms = db.nom.Local.ToList();
            Storagecontains = s;
            DataContext = this;
        }


        public List<nom> Noms { get; }
        public storagecontains Storagecontains { get; set; }


        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            //Measure.MeasureName = namebox.Text;
            DialogResult = true;
        }
    }
}