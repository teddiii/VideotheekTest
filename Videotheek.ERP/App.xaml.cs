﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Videotheek.Data;

namespace Videotheek.ERP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        AppDbContext ctx = AppDbContext.Instance(ConfigurationManager.ConnectionStrings["AppDbCS"].ConnectionString);
    }
}
