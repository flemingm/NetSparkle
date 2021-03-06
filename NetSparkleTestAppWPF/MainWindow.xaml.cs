﻿using System.Windows;
using AppLimit.NetSparkle;

namespace NetSparkleTestAppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Sparkle _sparkle;

        public MainWindow()
        {           
            InitializeComponent();

            // remove the netsparkle key from registry 
            try
            {
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\NetSparkleTestAppWPF");
            }
            catch { }

            _sparkle = new Sparkle("http://update.applimit.com/netsparkle/versioninfo.xml")
                {ShowDiagnosticWindow = true}; //, "NetSparkleTestApp.exe");
            _sparkle.StartLoop(true, true);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            _sparkle.StopLoop();
            Close();
        }
    }
}
