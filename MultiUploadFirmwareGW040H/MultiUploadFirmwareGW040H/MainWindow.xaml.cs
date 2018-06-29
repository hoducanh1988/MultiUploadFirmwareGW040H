﻿using MultiUploadFirmwareGW040H.Function;
using System;
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

namespace MultiUploadFirmwareGW040H {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
 
        private void setStartupLocation() {
            double scaleX = 1;
            double scaleY = 1;
            //double scaleX = 0.75;
            //double scaleY = 0.8;
            this.Height = SystemParameters.WorkArea.Height * scaleY;
            this.Width = SystemParameters.WorkArea.Width * scaleX;
            this.Top = (SystemParameters.WorkArea.Height * (1 - scaleY)) / 2;
            this.Left = (SystemParameters.WorkArea.Width * (1 - scaleX)) / 2;
        }

        private void bringUCtoFront(int index) {
            List<Control> list = new List<Control>() { ucTesting, ucStep, ucSetting, ucLog, ucHelp, ucAbout, ucLogin };

            switch (index) {
                case 2: {
                        //disable all
                        for (int i = 0; i < list.Count; i++) {
                            list[i].Visibility = Visibility.Collapsed;
                            Canvas.SetZIndex(list[i], 0);
                        }
                        Login li = new Login();
                        li.ShowDialog();
                        //visible login
                        if (GlobalData.loginUser == "admin" && GlobalData.loginPass == "vnpt") {
                            ucSetting.Visibility = Visibility.Visible;
                            Canvas.SetZIndex(ucSetting, 1);
                            GlobalData.loginUser = "";
                            GlobalData.loginPass = "";
                        }
                        else {
                            ucLogin.Visibility = Visibility.Visible;
                            Canvas.SetZIndex(ucLogin, 1);
                        }
                        break;
                    }
                default: {
                        for (int i = 0; i < list.Count; i++) {
                            if (i == index) {
                                list[i].Visibility = Visibility.Visible;
                                Canvas.SetZIndex(list[i], 1);
                            }
                            else {
                                list[i].Visibility = Visibility.Collapsed;
                                Canvas.SetZIndex(list[i], 0);
                            }
                        }
                        break;
                    }
            }
        }

        public MainWindow() {
            InitializeComponent();
            this.DataContext = GlobalData.mainW;

            this.setStartupLocation();
            bringUCtoFront(0);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {

        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e) {
            Label l = sender as Label;
            switch (l.Content.ToString()) {
                case "X": {
                        this.Close();
                        break;
                    }
                default: {
                        Dictionary<string, int> dictionary = new Dictionary<string, int>() { { "TEST ALL", 0 }, { "MANUAL", 1 }, { "SETTING", 2 }, { "DATALOG", 3 }, { "HELP", 4 }, { "ABOUT", 5 } };
                        int t;
                        bool ret = dictionary.TryGetValue(l.Content.ToString(), out t);
                        this.lblMinus.Margin = new Thickness(t * 100, 0, 0, 0);
                        this.bringUCtoFront(t);
                        break;
                    }
            }
        }

        private void lblMin_MouseDown(object sender, MouseButtonEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }
    }
}
