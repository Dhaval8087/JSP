using DAL.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace JSP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            Log4Net.WriteInfo("============================" + DateTime.Today.Date.ToShortDateString() + "============");
            Log4Net.WriteInfo("Process Start");
        }
        
    }
}
