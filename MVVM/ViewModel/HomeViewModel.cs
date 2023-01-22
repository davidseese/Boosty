using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Boosty.MVVM.ViewModel
{
    public class HomeViewModel
    {
        public string winInfo { get; set; }
        public string cpuInfo { get; set; }
        public string mbInfo { get; set; }
        public string gpuInfo { get; set; }
        public string hdInfo { get; set; }
        public string ramName { get; set; }
        public string ramUsage { get; set; }
        public string ramClock { get; set; }
        public string ramVolt { get; set; }

        public HomeViewModel()
        {
            
            winInfo = ((App)Application.Current).winInfo;
            cpuInfo = ((App)Application.Current).cpuInfos;
            ramName = ((App)Application.Current).ramNames;
            mbInfo = ((App)Application.Current).mbInfos;
            gpuInfo = ((App)Application.Current).gpuInfos;
            hdInfo = ((App)Application.Current).hdInfos;
            ramVolt = ((App)Application.Current).ramVols.Substring(0, 1) + "." + ((App)Application.Current).ramVols.Substring(1,2) + " V";
            ramClock = ((App)Application.Current).ramSpeed.Substring(0, 4) + " MHz";



        }

        
    }
}
