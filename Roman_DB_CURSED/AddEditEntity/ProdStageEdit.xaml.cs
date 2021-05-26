using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для ProdStageEdit.xaml
    /// </summary>
    public partial class ProdStageEdit : Window
    {
        public ProdStageEdit(prodstage ps, CalcEntities db)
        {
            InitializeComponent();
            
            db.techmap.Load();
            Techmaps = db.techmap.Local.ToList();
            db.resspec.Load();
            Resspecs = db.resspec.Local.ToList();
            db.subdivision.Load();
            Subdivisions = db.subdivision.Local.ToList();
            Prodstage = ps;
            DataContext = this;
            /*nextstagebox.ItemsSource = Prodstages;
            nextstagebox.SelectedValue = Prodstage.ProdStageNextStage;*/
        }

        public prodstage Prodstage { get; }
        public List<techmap> Techmaps { get; }

        public List<resspec> Resspecs { get; }

        public List<prodstage> Prodstages
        {
            get
            {
                return Prodstage.techmap.prodstage.ToList();
            }
        }

        public List<subdivision> Subdivisions { get; }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            //Measure.MeasureName = namebox.Text;
            DialogResult = true;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {/*
            Prodstage.ProdStageNextStage = null;*/
            nextstagebox.ItemsSource = Prodstages;
            Prodstage.ProdStageNextStage = null;
        }
    }
}
