using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Threading;

namespace Boosty.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für RestoreView.xaml
    /// </summary>
    public partial class RestoreView : UserControl
    {
        public string RA1;
        public string RA2;
        public string RA3;
        public string RA4;
        public string RA5;
        
        public string[] points;
        public RestoreView()
        {
            InitializeComponent();

            Dispatcher.Invoke(() =>
            {
                GetRestorePoints();
                SetRestorePoint();
            });
            
          
        }
        private void GetRestorePoints()
        {
            try
            {
                string a = RunScript("Get-ComputerRestorePoint | sort CreationTime -Descending | Select Description, @{Label='Date'; Expression={$_.ConvertToDateTime($_.CreationTime)}}, SequenceNumber | ft -HideTableHeaders").Remove(0, 1);
                
                string json = JsonConvert.SerializeObject(a);
                string[] b = json.Remove(json.Length - 13).Remove(0, 3).Split(new string[] { @"\r\n" }, StringSplitOptions.None);
                
                var D = new[] { D1, D2, D3, D4, D5 };
                var R = new[] { R1, R2, R3, R4, R5 };
                for (int i = 0; i < b.Length; i++)
                {
                    D[i].Text = b[i];
                    R[i].Visibility = System.Windows.Visibility.Visible;
                }
            }
            catch
            {

            }
            
            
        }
        private void SetRestorePoint()
        {
            try
            {
                string a = RunScript("Get-ComputerRestorePoint | sort CreationTime -Descending | Select SequenceNumber | ft -HideTableHeaders").Remove(0, 1);
                string json = JsonConvert.SerializeObject(a);
                string[] b = json.Remove(json.Length - 13).Remove(0, 3).Split(new string[] { @"\r\n" }, StringSplitOptions.None);
                points = b;

                var RA = new[] { RA1, RA2, RA3, RA4, RA5 };
                for (int i = 0; i < b.Length; i++)
                {
                    RA[i] = b[i].Trim();

                }
            }
            catch
            {

            }
           
        }
        private string RunScript(string script)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(script);
            pipeline.Commands.Add("out-string");
            Collection<PSObject> results = pipeline.Invoke();
            runspace.Close();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject pSObject in results)
                stringBuilder.Append(pSObject.ToString());
            return stringBuilder.ToString();

        }

        private void R1_clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GetAccept(RA1))
            {
                AdminRunScript($"Restore-Computer -RestorePoint {points[0].Trim()}");
            }

        }

        private void R2_clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GetAccept(RA2))
            {
                AdminRunScript($"Restore-Computer -RestorePoint {points[1].Trim()}");
            }
        }
        private void R3_clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GetAccept(RA3))
            {
                AdminRunScript($"Restore-Computer -RestorePoint {points[2].Trim()}");
            }
        }
        private void R4_clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GetAccept(RA4))
            {
                AdminRunScript($"Restore-Computer -RestorePoint {points[3].Trim()}");
            }
        }
        private void R5_clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GetAccept(RA5))
            {
                AdminRunScript($"Restore-Computer -RestorePoint {points[4].Trim()}");
            }
        }
        private void AdminRunScript(string script)
        {
            try
            {
                var newProcessInfo = new System.Diagnostics.ProcessStartInfo();
                newProcessInfo.FileName = @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe";
                newProcessInfo.Verb = "runas";
                newProcessInfo.Arguments = script;
                newProcessInfo.UseShellExecute = false;
                newProcessInfo.RedirectStandardOutput = true;
                newProcessInfo.RedirectStandardError = true;
                Process proces = System.Diagnostics.Process.Start(newProcessInfo);
                proces.WaitForExit();
            }
            catch (Exception) { }

        }

        public Boolean GetAccept(string point)
        {
            MessageBoxButton btns = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to go back to restore point: {point}?", "Restore Point", btns, icon: MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                return true;

            }
            else { return false; }

        }
    }
}
