using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Roman_DB_CURSED.AddEditEntity
{
    /// <summary>
    ///     Логика взаимодействия для OrderEdit.xaml
    /// </summary>
    public partial class OrderEdit : Window
    {
        public OrderEdit(order o, CalcEntities db)
        {
            InitializeComponent();
            Order = o;
            db.orderstatus.Load();
            Orderstatuses = db.orderstatus.Local.ToList();
            db.nom.Load();
            Noms = db.nom.Local.ToList();
            DataContext = this;
        }

        public List<nom> Noms { get; set; }
        public List<orderstatus> Orderstatuses { get; set; }
        public order Order { get; set; }

        private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}