using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Roman_DB_CURSED.Entities
{
    public class Measure: INotifyPropertyChanged
    {
        private int measure_id;

        public int Measure_id
        {
            get => measure_id;
            set => measure_id = value;
        }
        
        private string measure_name;

        public string Measure_name
        {
            get => measure_name;
            set => measure_name = value;
        }
        
        
        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }
}