using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для NomTypeEdit.xaml
    /// </summary>
    public partial class NomTypeEdit : Window
    {
        public NomTypeEdit(nomtype nt)
        {
            InitializeComponent();
            Nomtype = nt;
            DataContext = Nomtype;
        }

        public nomtype Nomtype { get; }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            //Measure.MeasureName = namebox.Text;
            DialogResult = true;
        }
    }
}