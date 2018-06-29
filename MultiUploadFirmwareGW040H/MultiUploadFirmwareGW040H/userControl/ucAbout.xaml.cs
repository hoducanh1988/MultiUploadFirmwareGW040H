﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiUploadFirmwareGW040H.userControl {
    /// <summary>
    /// Interaction logic for ucAbout.xaml
    /// </summary>
    public partial class ucAbout : UserControl {
        List<history> listHist = new List<history>();


        public ucAbout() {
            InitializeComponent();


            listHist.Add(new history() {
                ID = "1", VERSION = "1.0.0.0",
                CONTENT = "- Thay đổi giao diện phần mềm",
                DATE = "27/06/2018",
                CHANGETYPE = "Chỉnh sửa",
                PERSON = "Hồ Đức Anh"
            });

            this.GridAbout.ItemsSource = listHist;
        }

        private class history {
            public string ID { get; set; }
            public string VERSION { get; set; }
            public string CONTENT { get; set; }
            public string DATE { get; set; }
            public string CHANGETYPE { get; set; }
            public string PERSON { get; set; }
        }

    }
}
