//using System.Data.Entity;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Roman_DB_CURSED.AddEditEntity;

namespace Roman_DB_CURSED
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly CalcEntities db = new CalcEntities();


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            db = new CalcEntities();
            StorageCB.SelectedIndex = 0;
        }


        public storage currentStorage { get; set; }

        public List<storagecontains> CurrentStoragecontainsList
        {
            get { return currentStorage.storagecontains.ToList(); }
        }


        private void StorageCB_Selected(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedItem = comboBox.SelectedItem as storage;
            currentStorage = selectedItem;
            StorageContainsGrid.ItemsSource = CurrentStoragecontainsList;
            Trace.WriteLine("storege selected");
        }


        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ((sender as TabControl).SelectedValue as TabItem).UpdateLayout();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }


        #region tables

        public BindingList<storage> Storages
        {
            get
            {
                db.storage.Load();

                return db.storage.Local.ToBindingList();
            }
        }

        public BindingList<nom> Noms
        {
            get
            {
                db.nom.Load();

                return db.nom.Local.ToBindingList();
            }
        }

        public BindingList<resspec> Resspecs
        {
            get
            {
                db.resspec.Load();

                return db.resspec.Local.ToBindingList();
            }
        }

        public BindingList<resspecnoms> Resspecnoms
        {
            get
            {
                db.resspecnoms.Load();

                return db.resspecnoms.Local.ToBindingList();
            }
        }

        public BindingList<subdivision> Subdivisions
        {
            get
            {
                db.subdivision.Load();

                return db.subdivision.Local.ToBindingList();
            }
        }

        public BindingList<storagecontains> Storagecontains
        {
            get
            {
                db.storagecontains.Load();

                return db.storagecontains.Local.ToBindingList();
            }
        }

        public BindingList<measure> Measures
        {
            get
            {
                db.measure.Load();

                return db.measure.Local.ToBindingList();
            }
        }

        public BindingList<order> Orders
        {
            get
            {
                db.order.Load();

                return db.order.Local.ToBindingList();
            }
        }

        public BindingList<orderstatus> Orderstatus
        {
            get
            {
                db.orderstatus.Load();

                return db.orderstatus.Local.ToBindingList();
            }
        }

        public BindingList<prodstage> Prodstages
        {
            get
            {
                db.prodstage.Load();

                return db.prodstage.Local.ToBindingList();
            }
        }

        public BindingList<techmap> Techmaps
        {
            get
            {
                db.techmap.Load();

                return db.techmap.Local.ToBindingList();
            }
        }

        #endregion


        #region Measure

        private void AddMeasure(object sender, RoutedEventArgs e)
        {
            var measureEdit = new MeasureEdit(new measure());
            if (measureEdit.ShowDialog() == true)
            {
                var measure = measureEdit.Measure;
                db.measure.Add(measure);
                db.SaveChanges();
            }
        }


        private void EditMeasure(object sender, RoutedEventArgs e)
        {
            if (MeasureGrid.SelectedItem == null)
            {
                return;
            }

            var M = MeasureGrid.SelectedItem as measure;
            var measureEdit = new MeasureEdit(M);
            if (measureEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }


        private void DelMeasure(object sender, RoutedEventArgs e)
        {
            if (MeasureGrid.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var result = MessageBox.Show("Вы действительно хотите удалить текущую запись?", "", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var measure = MeasureGrid.SelectedItem as measure;
                db.measure.Remove(measure);
                db.SaveChanges();
            }
        }

        #endregion


        #region Nom

        private void AddNom(object sender, RoutedEventArgs e)
        {
            var nomEdit = new NomEdit(new nom(), db);
            if (nomEdit.ShowDialog() == true)
            {
                var nom = nomEdit.Nom;
                db.nom.Add(nom);
                db.SaveChanges();
            }
        }


        private void EditNom(object sender, RoutedEventArgs e)
        {
            if (NomGrid.SelectedItem == null)
            {
                return;
            }

            var N = NomGrid.SelectedItem as nom;
            var nomEdit = new NomEdit(N, db);
            if (nomEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }


        private void DelNom(object sender, RoutedEventArgs e)
        {
            if (NomGrid.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var result = MessageBox.Show("Вы действительно хотите удалить текущую запись?", "", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var nom = NomGrid.SelectedItem as nom;
                db.nom.Remove(nom);
                db.SaveChanges();
            }
        }

        #endregion


        #region Order

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            var orderEdit = new OrderEdit(new order(), db);
            if (orderEdit.ShowDialog() == true)
            {
                var order = orderEdit.Order;
                db.order.Add(order);
                db.SaveChanges();
            }
        }


        private void EditOrder(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem == null)
            {
                return;
            }

            var O = OrderGrid.SelectedItem as order;
            var orderEdit = new OrderEdit(O, db);
            if (orderEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }


        private void DelOrder(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var result = MessageBox.Show("Вы действительно хотите удалить текущую запись?", "", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var order = OrderGrid.SelectedItem as order;
                db.order.Remove(order);
                db.SaveChanges();
            }
        }


        private void OpenConsuptionLog(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem == null)
            {
                return;
            }

            var O = OrderGrid.SelectedItem as order;
            var consumptionLogEdit = new ConsumptionLogEdit(O, db);
            if (consumptionLogEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }


        private void OpenProductionLog(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem == null)
            {
                return;
            }

            var O = OrderGrid.SelectedItem as order;
            var productionLogEdit = new ProductionLogEdit(O, db);
            if (productionLogEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }

        #endregion


        #region OrderStatus

        private void AddOrderStatus(object sender, RoutedEventArgs e)
        {
            var orderStatusEdit = new OrderStatusEdit(new orderstatus());
            if (orderStatusEdit.ShowDialog() == true)
            {
                var orderstatus = orderStatusEdit.OrderStatus;
                db.orderstatus.Add(orderstatus);
                db.SaveChanges();
            }
        }


        private void EditOrderStatus(object sender, RoutedEventArgs e)
        {
            if (OrderStausGrid.SelectedItem == null)
            {
                return;
            }

            var OS = OrderStausGrid.SelectedItem as orderstatus;
            var orderStatusEdit = new OrderStatusEdit(OS);
            if (orderStatusEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }


        private void DelOrderStatus(object sender, RoutedEventArgs e)
        {
            if (OrderStausGrid.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var result = MessageBox.Show("Вы действительно хотите удалить текущую запись?", "", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var orderstatus = OrderStausGrid.SelectedItem as orderstatus;
                db.orderstatus.Remove(orderstatus);
                db.SaveChanges();
            }
        }

        #endregion


        /*
        #region ProdStage

        private void AddProdStage(object sender, RoutedEventArgs e)
        {
            ProdStageEdit prodStage = new ProdStageEdit(new prodstage(), db);
            if (prodStage.ShowDialog() == true)
            {
                prodstage prodstage = prodStage.Prodstage;
                db.prodstage.Add(prodstage);
                db.SaveChanges();
            }
        }


        private void EditProdStage(object sender, RoutedEventArgs e)
        {
            if (ProdStageGrid.SelectedItem == null)
            {
                return;
            }

            var ps = ProdStageGrid.SelectedItem as prodstage;
            var prodStageEdit = new ProdStageEdit(ps, db);
            if (prodStageEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }


        private void DelProdStage(object sender, RoutedEventArgs e)
        {
            if (ProdStageGrid.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var result = MessageBox.Show("Вы действительно хотите удалить текущую запись?", "", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var prodstage = ProdStageGrid.SelectedItem as prodstage;
                db.prodstage.Remove(prodstage);
                db.SaveChanges();
            }
        }

        #endregion
        */


        #region ResSpec

        private void AddResSpec(object sender, RoutedEventArgs e)
        {
            var resSpecEdit = new ResSpecEdit(new resspec(), db);
            if (resSpecEdit.ShowDialog() == true)
            {
                var resspec = resSpecEdit.Resspec;
                db.resspec.Add(resspec);
                db.SaveChanges();
            }
        }


        private void EditResSpec(object sender, RoutedEventArgs e)
        {
            if (ResSpecGrid.SelectedItem == null)
            {
                return;
            }

            var RS = ResSpecGrid.SelectedItem as resspec;
            var resSpecEdit = new ResSpecEdit(RS, db);
            if (resSpecEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }


        private void DelResSpec(object sender, RoutedEventArgs e)
        {
            if (ResSpecGrid.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var result = MessageBox.Show("Вы действительно хотите удалить текущую запись?", "", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var resspec = ResSpecGrid.SelectedItem as resspec;
                db.resspec.Remove(resspec);
                db.SaveChanges();
            }
        }

        #endregion


        #region ResSpecNoms

        private void AddResSpecNoms(object sender, RoutedEventArgs e)
        {
        }


        private void EditResSpecNoms(object sender, RoutedEventArgs e)
        {
        }


        private void DelResSpecNoms(object sender, RoutedEventArgs e)
        {
        }

        #endregion


        #region Storage

        private void AddStorage(object sender, RoutedEventArgs e)
        {
            var storageEdit = new StorageEdit(new storage());
            if (storageEdit.ShowDialog() == true)
            {
                var storage = storageEdit.Storage;
                db.storage.Add(storage);
                db.SaveChanges();
            }
        }


        private void EditStorage(object sender, RoutedEventArgs e)
        {
            if (StorageGrid.SelectedItem == null)
            {
                return;
            }

            var S = StorageGrid.SelectedItem as storage;
            var storageEdit = new StorageEdit(S);
            if (storageEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }


        private void DelStorage(object sender, RoutedEventArgs e)
        {
            if (StorageGrid.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var result = MessageBox.Show("Вы действительно хотите удалить текущую запись?", "", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var storage = StorageGrid.SelectedItem as storage;
                db.storage.Remove(storage);
                db.SaveChanges();
            }
        }

        #endregion


        #region StorageContains

        private void AddStorageContains(object sender, RoutedEventArgs e)
        {
            if (currentStorage == null)
            {
                return;
            }

            var storageEdit =
                new StorageContainsEdit(new storagecontains {storage = currentStorage}, db);
            if (storageEdit.ShowDialog() == true)
            {
                var storagecontains = storageEdit.Storagecontains;
                db.storagecontains.Add(storagecontains);
                db.SaveChanges();
                StorageContainsGrid.ItemsSource = CurrentStoragecontainsList;
            }
        }


        private void EditStorageContains(object sender, RoutedEventArgs e)
        {
            if (StorageContainsGrid.SelectedItem == null)
            {
                return;
            }

            var SC = StorageContainsGrid.SelectedItem as storagecontains;
            var storageContainsEdit = new StorageContainsEdit(SC, db);
            if (storageContainsEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }


        private void DelStorageContains(object sender, RoutedEventArgs e)
        {
            if (StorageContainsGrid.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var result = MessageBox.Show("Вы действительно хотите удалить текущую запись?", "", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var storagecontains = StorageContainsGrid.SelectedItem as storagecontains;
                db.storagecontains.Remove(storagecontains);
                db.SaveChanges();
            }
        }

        #endregion


        #region SubDivision

        private void AddSubDivision(object sender, RoutedEventArgs e)
        {
            var subdivisionEdit = new SubdivisionEdit(new subdivision());
            if (subdivisionEdit.ShowDialog() == true)
            {
                var subdivision = subdivisionEdit.Subdivision;
                db.subdivision.Add(subdivision);
                db.SaveChanges();
            }
        }


        private void EditSubDivision(object sender, RoutedEventArgs e)
        {
            if (SubdivisionGrid.SelectedItem == null)
            {
                return;
            }

            var S = SubdivisionGrid.SelectedItem as subdivision;
            var subdivisionEdit = new SubdivisionEdit(S);
            if (subdivisionEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }


        private void DelSubDivision(object sender, RoutedEventArgs e)
        {
            if (SubdivisionGrid.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var result = MessageBox.Show("Вы действительно хотите удалить текущую запись?", "", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var subdivision = SubdivisionGrid.SelectedItem as subdivision;
                db.subdivision.Remove(subdivision);
                db.SaveChanges();
            }
        }

        #endregion


        #region TechMap

        private void AddTechMap(object sender, RoutedEventArgs e)
        {
            var techMapEdit = new TechMapEdit(new techmap(), db);
            if (techMapEdit.ShowDialog() == true)
            {
                var techmap = techMapEdit.Techmap;
                db.techmap.Add(techmap);
                db.SaveChanges();
            }
        }


        private void EditTechMap(object sender, RoutedEventArgs e)
        {
            if (TechMapGrid.SelectedItem == null)
            {
                return;
            }

            var TM = TechMapGrid.SelectedItem as techmap;
            var techMapEdit = new TechMapEdit(TM, db);
            if (techMapEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }


        private void DelTechMap(object sender, RoutedEventArgs e)
        {
            if (TechMapGrid.SelectedItem == null)
            {
                return;
            }

            // получаем выделенный объект
            var result = MessageBox.Show("Вы действительно хотите удалить текущую запись?", "", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var techmap = TechMapGrid.SelectedItem as techmap;
                db.techmap.Remove(techmap);
                db.SaveChanges();
            }
        }

        #endregion
    }
}