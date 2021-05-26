using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для SubdivisionEdit.xaml
    /// </summary>
    public partial class SubdivisionEdit : Window
    {
        public SubdivisionEdit(subdivision s)
        {
            InitializeComponent();
            Subdivision = s;
            DataContext = Subdivision;
        }


        public subdivision Subdivision { get; }


        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}