using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace Projas.WinServices
{
    [RunInstaller(true)]
    public partial class ProjasInstaller : System.Configuration.Install.Installer
    {
        public ProjasInstaller()
        {
            InitializeComponent();
        }
    }
}
