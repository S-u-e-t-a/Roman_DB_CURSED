//using System.Data.Entity;

using System.ComponentModel;
using System.Data.Entity;
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
            /*CalcEntities db = new CalcEntities();
            db.storage.Load();
            var storages = db.storage.Local.ToBindingList();
            foreach (var VARIABLE in storages)
            {
                Trace.WriteLine($"{VARIABLE.StorageId} {VARIABLE.StorageName}");
            */
        }


        #region properties

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

        public BindingList<nomtype> Nomtypes
        {
            get
            {
                db.nomtype.Load();
                return db.nomtype.Local.ToBindingList();
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

        private void AddMeasure(object sender, System.Windows.RoutedEventArgs e)
        {
            MeasureEdit measureEdit = new MeasureEdit(new measure());
            if (measureEdit.ShowDialog() == true)
            {
                measure measure = measureEdit.Measure;
                db.measure.Add(measure);
                db.SaveChanges();
            }
        }
        private void EditMeasure(object sender, System.Windows.RoutedEventArgs e)
        {
            if (MeasureGrid.SelectedItem == null) return;
            var M = MeasureGrid.SelectedItem as measure;
            var measureEdit = new MeasureEdit(M);
            if (measureEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }
        private void DelMeasure(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        #endregion

        #region Nom

        private void AddNom(object sender, System.Windows.RoutedEventArgs e)
        {
            NomEdit nomEdit = new NomEdit(new nom(), db);
            if (nomEdit.ShowDialog() == true)
            {
                nom nom = nomEdit.Nom;
                db.nom.Add(nom);
                db.SaveChanges();
            }
        }
        private void EditNom(object sender, System.Windows.RoutedEventArgs e)
        {
            if (NomGrid.SelectedItem == null) return;
            var N = NomGrid.SelectedItem as nom;
            var nomEdit = new NomEdit(N,db);
            if (nomEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }
        private void DelNom(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        #endregion

        #region NomType

        private void AddNomType(object sender, System.Windows.RoutedEventArgs e)
        {
            NomTypeEdit nomTypeEdit = new NomTypeEdit(new nomtype());
            if (nomTypeEdit.ShowDialog() == true)
            {
                nomtype nomtype = nomTypeEdit.Nomtype;
                db.nomtype.Add(nomtype);
                db.SaveChanges();
            }
        }
        private void EditNomType(object sender, System.Windows.RoutedEventArgs e)
        {
            if (NomTypeGrid.SelectedItem == null) return;
            var NT = NomTypeGrid.SelectedItem as nomtype;
            var nomTypeEdit = new NomTypeEdit(NT);
            if (nomTypeEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }
        private void DelNomType(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        #endregion

        #region Order

        private void AddOrder(object sender, System.Windows.RoutedEventArgs e)
        {
            OrderEdit orderEdit = new OrderEdit(new order(), db);
            if (orderEdit.ShowDialog() == true)
            {
                order order = orderEdit.Order;
                db.order.Add(order);
                db.SaveChanges();
            }
        }
        private void EditOrder(object sender, System.Windows.RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem == null) return;
            var O = OrderGrid.SelectedItem as order;
            var orderEdit = new OrderEdit(O,db);
            if (orderEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }
        private void DelOrder(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        #endregion

        #region OrderStatus

        private void AddOrderStatus(object sender, System.Windows.RoutedEventArgs e)
        {
            OrderStatusEdit orderStatusEdit = new OrderStatusEdit(new orderstatus());
            if (orderStatusEdit.ShowDialog() == true)
            {
                orderstatus orderstatus = orderStatusEdit.OrderStatus;
                db.orderstatus.Add(orderstatus);
                db.SaveChanges();
            }
        }
        private void EditOrderStatus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (OrderStausGrid.SelectedItem == null) return;
            var OS = OrderStausGrid.SelectedItem as orderstatus;
            var orderStatusEdit = new OrderStatusEdit(OS);
            if (orderStatusEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }
        private void DelOrderStatus(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        #endregion

        #region ProdStage

        private void AddProdStage(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void EditProdStage(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void DelProdStage(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        #endregion

        #region ResSpec

        private void AddResSpec(object sender, System.Windows.RoutedEventArgs e)
        {
            ResSpecEdit resSpecEdit = new ResSpecEdit(new resspec(), db);
            if (resSpecEdit.ShowDialog() == true)
            {
                resspec resspec = resSpecEdit.Resspec;
                db.resspec.Add(resspec);
                db.SaveChanges();
            }
        }
        private void EditResSpec(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ResSpecGrid.SelectedItem == null) return;
            var RS = ResSpecGrid.SelectedItem as resspec;
            var resSpecEdit = new ResSpecEdit(RS,db);
            if (resSpecEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }
        private void DelResSpec(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        #endregion

        #region ResSpecNoms

        private void AddResSpecNoms(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void EditResSpecNoms(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void DelResSpecNoms(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        #endregion

        #region Storage

        private void AddStorage(object sender, System.Windows.RoutedEventArgs e)
        {
            StorageEdit storageEdit = new StorageEdit(new storage());
            if (storageEdit.ShowDialog() == true)
            {
                storage storage = storageEdit.Storage;
                db.storage.Add(storage);
                db.SaveChanges();
            }
        }
        private void EditStorage(object sender, System.Windows.RoutedEventArgs e)
        {
            if (StorageGrid.SelectedItem == null) return;
            var S = StorageGrid.SelectedItem as storage;
            var storageEdit = new StorageEdit(S);
            if (storageEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }
        private void DelStorage(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        #endregion

        #region StorageContains

        private void AddStorageContains(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void EditStorageContains(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void DelStorageContains(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        #endregion

        #region SubDivision

        private void AddSubDivision(object sender, System.Windows.RoutedEventArgs e)
        {
            SubdivisionEdit subdivisionEdit = new SubdivisionEdit(new subdivision());
            if (subdivisionEdit.ShowDialog() == true)
            {
                subdivision subdivision = subdivisionEdit.Subdivision;
                db.subdivision.Add(subdivision);
                db.SaveChanges();
            }
        }
        private void EditSubDivision(object sender, System.Windows.RoutedEventArgs e)
        {
            if (SubdivisionGrid.SelectedItem == null) return;
            var S = SubdivisionGrid.SelectedItem as subdivision;
            var subdivisionEdit = new SubdivisionEdit(S);
            if (subdivisionEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }
        private void DelSubDivision(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        #endregion

        #region TechMap

        private void AddTechMap(object sender, System.Windows.RoutedEventArgs e)
        {
            TechMapEdit techMapEdit = new TechMapEdit(new techmap());
            if (techMapEdit.ShowDialog() == true)
            {
                techmap techmap = techMapEdit.Techmap;
                db.techmap.Add(techmap);
                db.SaveChanges();
            }
        }
        private void EditTechMap(object sender, System.Windows.RoutedEventArgs e)
        {
            if (TechMapGrid.SelectedItem == null) return;
            var TM = TechMapGrid.SelectedItem as techmap;
            var techMapEdit = new TechMapEdit(TM);
            if (techMapEdit.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }
        private void DelTechMap(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        #endregion
    }
}