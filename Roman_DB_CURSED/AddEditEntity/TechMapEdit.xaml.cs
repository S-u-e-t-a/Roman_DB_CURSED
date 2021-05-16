using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для TechMapEdit.xaml
    /// </summary>
    public partial class TechMapEdit : Window
    {
        public TechMapEdit(techmap tm)
        {
            InitializeComponent();
            Techmap = tm;
            DataContext = Techmap;
        }

        public techmap Techmap { get; }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}