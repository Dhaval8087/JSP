using DAL.Impl;
using JSP.ViewModels;
using System;
using System.Windows;

namespace JSP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ContainerViewModel ContainerVM { get; set; }
        public App()
        {
            Log4Net.WriteInfo("============================" + DateTime.Today.Date.ToShortDateString() + "============");
            Log4Net.WriteInfo("Process Start");

        }

    }
}
