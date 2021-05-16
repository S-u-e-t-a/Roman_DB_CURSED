using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для StorageEdit.xaml
    /// </summary>
    public partial class StorageEdit : Window
    {
        public StorageEdit(storage s)
        {
            InitializeComponent();
            Storage = s;
            DataContext = Storage;
        }

        public storage Storage { get; }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}