using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ImageViewerWPF
{
    class Transformer : INotifyPropertyChanged
    {
        double scale;

        public double Scale
        {
            get { return scale; }

            set
            {
                scale = value;
                OnPropertyChanged("Scale");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
