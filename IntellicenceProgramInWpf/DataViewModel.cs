using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntellicenceProgramInWpf
{
    public class DataViewModel : BaseViewModel
    {
        private ObservableCollection<Data> allDatas;
        public ObservableCollection<Data> AllDatas
        {
            get
            {
                return allDatas;

            }
            set
            {
                allDatas = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(AllDatas)));

            }
        }
    }
}
