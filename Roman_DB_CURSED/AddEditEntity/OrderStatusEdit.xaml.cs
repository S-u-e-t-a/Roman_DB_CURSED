using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для OrderStatus.xaml
    /// </summary>
    public partial class OrderStatusEdit : Window
    {
        public OrderStatusEdit(orderstatus os)
        {
            InitializeComponent();
            OrderStatus = os;
            DataContext = OrderStatus;
        }


        public orderstatus OrderStatus { get; }


        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            //Measure.MeasureName = namebox.Text;
            DialogResult = true;
        }
    }
}