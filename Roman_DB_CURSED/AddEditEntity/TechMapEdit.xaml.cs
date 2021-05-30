using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для TechMapEdit.xaml
    /// </summary>
    public partial class TechMapEdit : Window
    {
        private readonly CalcEntities db;


        public TechMapEdit(techmap tm, CalcEntities db)
        {
            InitializeComponent();
            this.db = db;
            Techmap = tm;
            DataContext = this;
        }


        public techmap Techmap { get; }


        public List<prodstage> Prodstages
        {
            get { return Techmap.prodstage.OrderBy(x => x.ProdStageIndex).ToList(); }
        }


        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }


        private void AddClick(object sender, RoutedEventArgs e)
        {
            var prodStageEdit = new ProdStageEdit(new prodstage {techmap = Techmap}, db);
            if (prodStageEdit.ShowDialog() == true)
            {
                var prodstage = prodStageEdit.Prodstage;
                Techmap.prodstage.Add(prodstage);
                PSGrid.ItemsSource = Prodstages;
            }
        }


        private void EditClick(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (PSGrid.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var PS = PSGrid.SelectedItem as prodstage;

            var prodStageEdit = new ProdStageEdit(PS, db);
            /*var prodStageEdit = new ProdStageEdit(
                new prodstage
                {
                    productionlog = PS.productionlog, techmap = PS.techmap, ProdStageNextStage = PS.ProdStageNextStage,
                    subdivision = PS.subdivision, ProdStageIndex = PS.ProdStageIndex, ProdStagId = PS.ProdStagId,
                    ProdStageDuration = PS.ProdStageDuration, ProdStageName = PS.ProdStageName,
                    SubDivisionId = PS.SubDivisionId, TechMapId = PS.TechMapId, prodstage1 = PS.prodstage1,
                    prodstage2 = PS.prodstage2
                }, db); //todo чекнуть работу именно тут
            */
            if (prodStageEdit.ShowDialog() == true)
            {
                //PS = prodStageEdit.Prodstage;
            }

            PSGrid.ItemsSource = Prodstages;
        }


        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (PSGrid.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var PS = PSGrid.SelectedItem as prodstage;
            Techmap.prodstage.Remove(PS);
            PSGrid.ItemsSource = Prodstages;
        }
    }
}