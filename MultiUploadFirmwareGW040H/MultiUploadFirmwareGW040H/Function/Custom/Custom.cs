using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiUploadFirmwareGW040H.Function {

    public class mainwindowinfo : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        string _wtitle = "";
        public string WINDOWTITLE {
            get { return _wtitle; }
            set {
                _wtitle = value;
                OnPropertyChanged(nameof(WINDOWTITLE));
            }
        }

        public mainwindowinfo() {
            WINDOWTITLE = "Tool Multi Upload Firmware For GW040H";
        }
    }

}
