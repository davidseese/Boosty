using Microsoft.VisualBasic;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading;
using System.Windows;
using OpenHardwareMonitor.Hardware;
using System.Timers;

namespace Boosty
{
    

    public partial class App : Application
    {
        public string cpuInfos;
        public string mbInfos;
        public string gpuInfos;
        public string hdInfos;
        public string winInfoCap;
        public string winInfoId;
        public string winInfoBuild;
        public string ramNames;
        public string ramBLs;
        public string ramSpeed;
        public string ramVols;
        public string ramCaps;
        public string cpuClocks;
        public string cpuCore;
        public string cpuPro;
        public double ramUsage;
        public double cpuUsage;
        public string winInfo;
        public string fanSpeed;
        public double gpuUsage;
        public string cpuTemp;
        public string gpuClock;
        public string GPUTemp;
        public string cpuPower;
        public string ramUsed;
        private static System.Timers.Timer timer;

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQyOTE1QDMyMzAyZTMxMmUzMGFmK0dNSWZtdjR3ODVVUFRmWmJTZytCaFlnY0h2VmN0c0FKVkU2Qk5LWm89");
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {

            timer = new System.Timers.Timer(2000);
            timer.Elapsed += Timer_Tick;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();

            Thread[] threads = new Thread[16];

            threads[0] = new Thread(new ThreadStart(GetWinInfoCap));
            threads[1] = new Thread(new ThreadStart(GetCpuInfo));
            threads[2] = new Thread(new ThreadStart(GetRamSpeed));
            threads[3] = new Thread(new ThreadStart(GetMbInfo));
            threads[4] = new Thread(new ThreadStart(GetGpuInfo));
            threads[5] = new Thread(new ThreadStart(GetHdInfo));
            threads[6] = new Thread(new ThreadStart(GetWinId));
            threads[7] = new Thread(new ThreadStart(GetWinBuild));
            threads[8] = new Thread(new ThreadStart(GetRamName));
            threads[9] = new Thread(new ThreadStart(GetRamVoltage));
            threads[10] = new Thread(new ThreadStart(GetRamCapacity));
            threads[11] = new Thread(new ThreadStart(GetRamBL));
            threads[12] = new Thread(new ThreadStart(GetProcClock));
            threads[13] = new Thread(new ThreadStart(GetProcCores));
            threads[14] = new Thread(new ThreadStart(GetProcProz));
            threads[15] = new Thread(new ThreadStart(SystemRestorePoint));

            foreach (Thread t in threads)
                t.Start();
            
            
            foreach (Thread t in threads)
            {
                t.Join();   
            }
            winInfo = winInfoCap + " " + winInfoId;
        }

        private void Timer_Tick(Object source, ElapsedEventArgs e)
        {
            ramUsage = getRamUsage();
            GatherHardwareInfo();
        }
        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer)
            {
                computer.Traverse(this);
            }
            public void VisitHardware(IHardware hardware)
            {
                hardware.Update();
                foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
            }
            public void VisitSensor(ISensor sensor) { }
            public void VisitParameter(IParameter parameter) { }
        }
        private void GatherHardwareInfo()
        {
            UpdateVisitor updateVisitor = new UpdateVisitor();
          
            Computer computer = new Computer()
            {
                CPUEnabled = true,
                GPUEnabled = true,
                RAMEnabled = true
            }; 
            computer.Open();
            
            computer.Accept(updateVisitor);



            for (int i = 0; i < computer.Hardware.Length; i++)
            {
                if (computer.Hardware[i].HardwareType == HardwareType.GpuNvidia)
                {
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Clock && computer.Hardware[i].Sensors[j].Name.Contains("GPU Core"))
                            gpuClock = computer.Hardware[i].Sensors[j].Value.ToString();
                            if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                                GPUTemp = computer.Hardware[i].Sensors[j].Value.ToString();
                                if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Load && computer.Hardware[i].Sensors[j].Name.Contains("GPU Core"))
                                    gpuUsage = (double)computer.Hardware[i].Sensors[j].Value;
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Fan)
                            fanSpeed = computer.Hardware[i].Sensors[j].Value.ToString();
                    }
                }
                if (computer.Hardware[i].HardwareType == HardwareType.CPU)
                {
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Load && computer.Hardware[i].Sensors[j].Name.Contains("CPU Total"))
                            cpuUsage = Math.Round((double)computer.Hardware[i].Sensors[j].Value.GetValueOrDefault());

                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature && computer.Hardware[i].Sensors[j].Name.Contains("CPU Package"))
                            cpuTemp = computer.Hardware[i].Sensors[j].Value.ToString();
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Clock && computer.Hardware[i].Sensors[j].Name.Contains("CPU Core #1"))
                            {
                                cpuClocks = ((int)computer.Hardware[i].Sensors[j].Value).ToString();
                            
                        }
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Power && computer.Hardware[i].Sensors[j].Name.Contains("CPU Package"))
                        {
                            cpuPower = ((int)computer.Hardware[i].Sensors[j].Value).ToString();
                        }

                    }
                }
                if (computer.Hardware[i].HardwareType == HardwareType.RAM)
                {
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Data && computer.Hardware[i].Sensors[j].Name.Contains("Used Memory"))
                            ramUsed = Math.Round((double)computer.Hardware[i].Sensors[j].Value).ToString();



                    }
                }


            }
            computer.Close();
        }
        private void SystemRestorePoint()
        {
            MessageBoxButton btns = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show("Do you want to create a system restore point?\nWhy?: You can reset all the changes made if something does not work.", "Create System Restore Point", btns, icon: MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Thread t = new Thread(new ThreadStart(CreateRestorePoint));
                MessageBox.Show("This may take a moment, the program will start automatically after completion.\nPlease press \"OK\"...", "Create System Restore Point");
                t.Start();
                t.Join();
            }
        }

        public void CreateRestorePoint()
        {
            try
            {
                ManagementScope oScope = new ManagementScope("\\\\localhost\\root\\default");
                ManagementPath oPath = new ManagementPath("SystemRestore");
                ObjectGetOptions oGetOp = new ObjectGetOptions();
                ManagementClass oProcess = new ManagementClass(oScope, oPath, oGetOp);

                ManagementBaseObject oInParams =
                     oProcess.GetMethodParameters("CreateRestorePoint");
                oInParams["Description"] = "Boosty Restore Point";
                oInParams["RestorePointType"] = 12; // MODIFY_SETTINGS
                oInParams["EventType"] = 100;

                ManagementBaseObject oOutParams =
                     oProcess.InvokeMethod("CreateRestorePoint", oInParams, null);
            }
            catch
            {
                Console.WriteLine("error");
            }
        }
        
        public void GetWinInfoCap()
        {
            winInfoCap = RunScript("(Get-WmiObject -class Win32_OperatingSystem).Caption").Trim();
        }
        public void GetWinId()
        {
            winInfoId = RunScript("(Get-ItemProperty 'HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion').ReleaseId").Trim();
        }
       
        public void GetWinBuild()
        {
            //winInfoBuild = RunScript("[System.Environment]::OSVersion.Version | ft -HideTableHeaders").Trim();
        }
        public void GetCpuInfo()
        {
            cpuInfos = RunScript("Get-WmiObject Win32_Processor | Select Name | ft -HideTableHeaders").Trim();
        }
        public void GetRamName()
        {
            ramNames = RunScript("Get-WmiObject win32_physicalmemory | select PartNumber | ft -HideTableHeaders").Trim().Replace("    ", "");
        }
        public void GetRamSpeed()
        {
            ramSpeed = RunScript("Get-WmiObject win32_physicalmemory | Select ConfiguredClockSpeed  | ft -HideTableHeaders").Replace("\r\n", "").Replace(" ", "");
        }
        public void GetRamVoltage()
        {
            ramVols = RunScript("Get-WmiObject win32_physicalmemory | Select ConfiguredVoltage  | ft -HideTableHeaders").Replace("\r\n", "").Replace(" ", "");
        }
        public void GetRamBL()
        {
            ramBLs = RunScript("Get-WmiObject win32_physicalmemory | Select Banklabel  | ft -HideTableHeaders");
        }
        public void GetRamCapacity()
        {
            string ramTempt = RunScript("Get-WmiObject win32_physicalmemory | Select @{Name='GB';Expression={$_.capacity[0]/1GB}} |Format-Wide | ft -HideTableHeaders");
            ramCaps = ramTempt.Remove(ramTempt.Length - 13).Remove(0, 10);
        }
        public void GetMbInfo()
        {
            mbInfos = RunScript("get-CimInstance -Class Win32_BaseBoard | Select Product  | ft -HideTableHeaders").Trim();
        }
        public void GetGpuInfo()
        {
            gpuInfos = RunScript("get-CimInstance -Class Win32_VideoController | Select Caption  | ft -HideTableHeaders").Trim();
        }
        public void GetHdInfo()
        {
            hdInfos = RunScript("wmic diskdrive get model | ft -HideTableHeaders").Replace("Model", "").Trim().Trim().Replace("\n\r", "");

        }
        public void GetProcClock()
        {
            cpuClocks = RunScript("Get-WmiObject -class win32_processor | Select MaxClockSpeed | ft -HideTableHeaders").Trim();
        }
        public void GetProcCores()
        {
            cpuCore = RunScript("Get-WmiObject -class win32_processor | Select NumberOfCores | ft -HideTableHeaders").Trim();
        }
        public void GetProcProz()
        {
            cpuPro = RunScript("Get-WmiObject -class win32_processor | Select NumberOfLogicalProcessors | ft -HideTableHeaders").Trim();
        }

        public double getRamUsage()
        {
            //Need to add System.Management Quotation


            //Get the total physical memory size
            ManagementClass cimobject1 = new ManagementClass("Win32_PhysicalMemory");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            double available = 0, capacity = 0;
            foreach (ManagementObject mo1 in moc1)
            {
                capacity += ((Math.Round(Int64.Parse(mo1.Properties["Capacity"].Value.ToString()) / 1024 / 1024 / 1024.0, 1)));
            }
            moc1.Dispose();
            cimobject1.Dispose();


            //Get the size of memory available
            ManagementClass cimobject2 = new ManagementClass("Win32_PerfFormattedData_PerfOS_Memory");
            ManagementObjectCollection moc2 = cimobject2.GetInstances();
            foreach (ManagementObject mo2 in moc2)
            {
                available += ((Math.Round(Int64.Parse(mo2.Properties["AvailableMBytes"].Value.ToString()) / 1024.0, 1)));

            }
            moc2.Dispose();
            cimobject2.Dispose();

            return (Math.Round((capacity - available) / capacity * 100, 0));



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
        private void AdminRunScript(string script)
        {
            var newProcessInfo = new System.Diagnostics.ProcessStartInfo();
            string path = System.IO.Path.GetPathRoot(Environment.SystemDirectory);
            newProcessInfo.FileName = $@"{path}Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe";
            newProcessInfo.Verb = "runas";
            newProcessInfo.Arguments = script;
            newProcessInfo.UseShellExecute = false;
            //newProcessInfo.RedirectStandardOutput = true; // This will enable to read Powershell run output
            newProcessInfo.RedirectStandardError = true;
            Process proces = System.Diagnostics.Process.Start(newProcessInfo);
            proces.WaitForExit();

        }
    }
}
