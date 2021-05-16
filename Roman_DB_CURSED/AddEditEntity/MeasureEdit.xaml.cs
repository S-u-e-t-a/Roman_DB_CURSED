using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для MeasureEdit.xaml
    /// </summary>
    public partial class MeasureEdit : Window
    {
        public MeasureEdit(measure m)
        {
            InitializeComponent();
            Measure = m;
            DataContext = Measure;
        }

        public measure Measure { get; }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            //Measure.MeasureName = namebox.Text;
            DialogResult = true;
        }
    }
}