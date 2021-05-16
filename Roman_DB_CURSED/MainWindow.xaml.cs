//using System.Data.Entity;

namespace Roman_DB_CURSED
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();

            /*CalcEntities db = new CalcEntities();
            db.storage.Load();
            var storages = db.storage.Local.ToBindingList();
            foreach (var VARIABLE in storages)
            {
                Trace.WriteLine($"{VARIABLE.StorageId} {VARIABLE.StorageName}");
            */
        }
    }
}