using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
namespace Boosty.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für AdvancedView.xaml
    /// </summary>
    public partial class AdvancedView : UserControl
    {
          
        public AdvancedView()
        {
            InitializeComponent();
            GetTurnOffEnhancePointerPrecision();
            GetAdjustMouseProperties();
            GetEnableSimpleAltTab();
            GetDisableDynamictick();
            Gethpet();
            GetUseplatformtick();
            GetEnableExclusiveFullScreenMode();
            GetDisableGameBar();
            GetEnableGameMode();
            GetEnableHardwareAccelerated();
            GetDisableAppCapture();
            GetUseNexus();
            GetDriverSearch();
            GetMaintenanceDisabled();
            GetDisableBackgroundApps();
            GetDisableAutoMaps();
            GetDisableWindowsMemoryCompression();
            GetSetSystemResponsiveness();
            GetDisableHibernate();
            GetDisablePowerThrottling();
            GetSetPowerPlan();
            GetEnableVideoQuality();
            GetNetworkAdvanced();
            GetNetworkThrottling();
            GetMinimalFX();
            GetDarkTheme();
            GetPowerSavingFeatures();
            GetWindowsDefender();
            GetCortana();
            GetEnableMSI();
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
        private void run(string script)
        {

            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(script);
            Collection<PSObject> results = pipeline.Invoke();
            runspace.Close();

        }


        private void GetTurnOffEnhancePointerPrecision()
        {
            
            string TurnOffEnhancePointerPrecisionV = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Mouse", "MouseSpeed", "");
            string TurnOffEnhancePointerPrecisionV1 = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Mouse", "MouseThreshold1", "");
            string TurnOffEnhancePointerPrecisionV2 = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Mouse", "MouseThreshold2", "");
            

            if (TurnOffEnhancePointerPrecisionV.Equals("0") && TurnOffEnhancePointerPrecisionV1.Equals("0") && TurnOffEnhancePointerPrecisionV2.Equals("0"))
            {
                TurnOffEnhancePointerPrecision.IsChecked = true;
               
            }
            else
            {
                TurnOffEnhancePointerPrecision.IsChecked = false;
            }

        }
        private void GetAdjustMouseProperties()
        {
            string stan = @"0000000000000000156E000000000000004001000000000029DC0300000000000000280000000000";
            string GetAdjustMousePropertiesV1 = BitConverter.ToString((byte[])Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Mouse", "SmoothMouseXCurve", ""));
            if (GetAdjustMousePropertiesV1.Replace("-", "").Equals(stan.Trim()))
            {
                AdjustMouseProperties.IsChecked = false;
                
            }
            else
            {
                AdjustMouseProperties.IsChecked = true;
                
            }
        }
        private void GetEnableSimpleAltTab()
        {
            string GetEnableSimpleAltTabV = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer", "AltTabSettings", "false").ToString();
            if (GetEnableSimpleAltTabV.Equals("1")){
                EnableSimpleAltTab.IsChecked = true;
            }
            else
            {
                EnableSimpleAltTab.IsChecked = false;
            }
        }
        private void GetEnableExclusiveFullScreenMode()
        {
            string GetEnableExclusiveFullScreenModeV = Registry.GetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_FSEBehaviorMode", "").ToString();
            if (GetEnableExclusiveFullScreenModeV.Equals("0")) { 
                EnableExclusiveFullScreenMode.IsChecked = true;
            }
            else
            {
                EnableExclusiveFullScreenMode.IsChecked = false;
            }
        }
        private void GetDisableDynamictick()
        {
            Thread t = new Thread(new ThreadStart(GetDisabledynamictick));
            t.Start();
        }
        private void GetUseplatformtick()
        {
            Thread t = new Thread(new ThreadStart(Getuseplatformtick));
            t.Start();
        }
        private void Gethpet()
        {
            Thread t = new Thread(new ThreadStart(GetDisableHPET));
            t.Start();
        }
        private void GetDisableGameBar()
        {
            string DisableGameBarV = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR", "AppCaptureEnabled", "").ToString();
            if (DisableGameBarV.Equals("1"))
            {
                DisableGameBar.IsChecked = false;
            }
            else
            {
                DisableGameBar.IsChecked = true;
            }
        }
        private void GetEnableGameMode()
        {
            string EnableGameModeV = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "AllowAutoGameMode", "").ToString();
            string EnableModeV1 = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "AutoGameModeEnabled", "").ToString();
            if (EnableGameModeV.Equals("1") && EnableModeV1.Equals("1")){
                EnableGameMode.IsChecked = true;
            }
            else
            {
                EnableGameMode.IsChecked = false;
            }
           
        }
        private void GetEnableHardwareAccelerated()
        {
            string EnableHardwareAcceleratedV = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GraphicsDrivers", "HwSchMode", "").ToString();
            if (EnableHardwareAcceleratedV.Equals("2"))
            {
                EnableHardwareAccelerated.IsChecked = true;
            }
            else
            {
                EnableHardwareAccelerated.IsChecked = false;
            }
        
            }
        private void GetDisableAppCapture()
        {
            string DisableAppCaptureV = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\GameDVR", "AppCaptureEnabled", "").ToString();
            if (DisableAppCaptureV.Equals("0"))
            {
                DisableAppCapture.IsChecked = true;
            }
            else
            {
                DisableAppCapture.IsChecked = false;
            }

        }
        private void GetUseNexus()
        {
            string UseNexusV = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "UseNexusForGameBarEnabled", "").ToString();
            if (UseNexusV.Equals("0"))
            {
                UseNexus.IsChecked = true;
            }
            else
            {
                UseNexus.IsChecked = false;
            }
        }
        private void GetDriverSearch()
        {
            string DriverSearchV = RunScript(@"Get-ItemPropertyValue -Path HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\DriverSearching -Name SearchOrderConfig").Trim();
            if(DriverSearchV.Equals("0"))
            {
                DriverSearch.IsChecked = true;
            }else
            {
                DriverSearch.IsChecked = false;
            }
        }
        private void GetMaintenanceDisabled()
        {
            string MaintenanceDisabledV = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\Maintenance", "MaintenanceDisabled", "").ToString();
            if (MaintenanceDisabledV.Equals("1"))
            {
                MaintenanceDisabled.IsChecked = true;
            }
            else
            {
                MaintenanceDisabled.IsChecked = false;

            }
        }
        private void GetDisableBackgroundApps()
        {
            string DisableBackgroundAppsV = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", "GlobalUserDisabled", "").ToString();
            if (DisableBackgroundAppsV.Equals("1"))
            {
                DisableBackgroundApps.IsChecked = true;
            }
            else
            {
                DisableBackgroundApps.IsChecked = false;
            }
        }
        private void GetDisableAutoMaps()
        {
            string DisableAutoMapsV = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\Maps", "AutoUpdateEnabled", "").ToString();
            if (DisableAutoMapsV.Equals("0"))
            {
                DisableAutoMaps.IsChecked = true;

            }
            else
            {
                DisableAutoMaps.IsChecked = false;
            }
        }
        public void GetDisableWindowsMemoryCompression()
        {
            string DisableWindowsMemoryCompressionV = RunScript(@"Get-MMagent |Select MemoryCompression | ft -HideTableHeaders").Trim().Replace("\n", "").Replace("\r", "");
            if (DisableWindowsMemoryCompressionV.Equals("False")){
                DisableWindowsMemoryCompression.IsChecked = true;
            }
            else
            {
                DisableWindowsMemoryCompression.IsChecked = false;

            }
        }
        private void GetSetSystemResponsiveness()
        {
            string SetSystemResponsivenessV = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "SystemResponsiveness", "").ToString();
            if (SetSystemResponsivenessV.Equals("0"))
            {
                SetSystemResponsiveness.IsChecked = true;
            }
            else
            {
                SetSystemResponsiveness.IsChecked = false;
            }
        }
        private void GetDisableHibernate()
        {
            string DisableHibernateV = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power", "HibernateEnabled", "").ToString();
            if(DisableHibernateV.Equals("0"))
            {
                DisableHibernate.IsChecked = true;
            }
            else
            {
                DisableHibernate.IsChecked = false;
            }
        }
        private void GetDisablePowerThrottling()
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling", "PowerThrottlingOff", 0, RegistryValueKind.DWord);
            string DisablePowerThrottlingV = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling", "PowerThrottlingOff", "").ToString();
            if (DisablePowerThrottlingV.Equals("1")){
                DisablePowerThrottling.IsChecked = true;
            }
            else
            {
                DisablePowerThrottling.IsChecked = false;

            }
        }
        private void GetSetPowerPlan()
        {
            string SetPowerPlanV = RunScript(@"powercfg /GetActiveScheme");
            if (SetPowerPlanV.Contains("77777777-7777-7777-7777-777777777777"))
            {
                SetPowerPlan.IsChecked = true;
            }
            else
            {
                SetPowerPlan.IsChecked = false;
            }

        }
        private void GetEnableVideoQuality()
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\VideoSettings", "VideoQualityOnBattery", 0, RegistryValueKind.DWord);
            string EnableVideoQualityV = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\VideoSettings", "VideoQualityOnBattery", "").ToString();
            if (EnableVideoQualityV.Equals("1"))
            {
                EnableVideoQuality.IsChecked = true;
            }
            else
            {
                EnableVideoQuality.IsChecked = false;

            }
        }
        private void GetNetworkAdvanced()
        {
         string NetworkAdvancedV = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}", "Opt", "").ToString();
            if (NetworkAdvancedV.Equals("1")) {
                NetworkAdvanced.IsChecked = true;
            }
            else
            {
                NetworkAdvanced.IsChecked = false;
            }
        }
        private void GetNetworkThrottling()
        {
            string NetworkThrottlingV = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "NetworkThrottlingIndex", "").ToString();
            
            if (NetworkThrottlingV.Equals("10"))
            {
                
                NetworkThrottling.IsChecked = false;
            }
            else
            {
                NetworkThrottling.IsChecked = true;
            }
        }
        private void GetMinimalFX()
        {
            string MinimalFXV = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", "VisualFXSetting", "").ToString();
            if (MinimalFXV.Equals("3"))
            {
                MinimalFX.IsChecked = true;
            }
            else
            {
                MinimalFX.IsChecked = false;
            }
        }
        private void GetDarkTheme()
        {
            string DarkThemeV = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", "").ToString();
            if (DarkThemeV.Equals("0"))
            {
                DarkTheme.IsChecked = true;
            }
            else
            {
                DarkTheme.IsChecked = false;
            }
        }
        private void GetPowerSavingFeatures()
        {

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software", true).CreateSubKey("Boosty");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Boosty", "Adjust", 0, RegistryValueKind.DWord);
            string p = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Boosty", "Adjust", "").ToString();
            if (p.Equals("1"))
            {
                DisablePowerSavingFeatures.IsChecked = true;
            }
            else { 
                DisablePowerSavingFeatures.IsChecked = false;
            }
        }
        private void GetWindowsDefender()
        {
            string WindowsDefenderV = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", "").ToString();
            if (WindowsDefenderV.Equals("1"))
            {
                WindowsDefender.IsChecked = true;
            }
            else
            {
                WindowsDefender.IsChecked = false;
            }
        }
        private void GetEnableMSI()
        {
            string InstanceId = RunScript("get-pnpdevice | Where-object {$_.Class -Match 'Display' -and $_.FriendlyName -like '*nvidia*'} |select InstanceID | ft -HideTableHeaders").Trim();
            RegistryKey winLogonKey = Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\Enum\{InstanceId}\Device Parameters\Interrupt Management\MessageSignaledInterruptProperties", true);
           
            if (winLogonKey == null)

            {
                Registry.SetValue($@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\{InstanceId}\Device Parameters\Interrupt Management\MessageSignaledInterruptProperties", "MSISupported", 0, RegistryValueKind.DWord);
               
            }
            
            string EnableMSIV = Registry.GetValue($@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\{InstanceId}\Device Parameters\Interrupt Management\MessageSignaledInterruptProperties", "MSISupported", "").ToString();
            
            if (EnableMSIV.Equals("1"))
            {
                EnableMSI.IsChecked = true;
            }
            else
            {
                EnableMSI.IsChecked = false;
            }
        }
        public void GetDisabledynamictick()
        {
            string a = "";
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = @"CMD.EXE";
            p.StartInfo.Arguments = @"/C bcdedit";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            // parse the output
            var lines = output.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Where(l => l.Length > 24); ;

            foreach (var line in lines)
            {
                if (line.Contains("disabledynamictick"))
                {

                    var value = line.Substring(24).Replace(" ", string.Empty);
                    a = value;
                }

            }
            if (a.Equals("Yes"))
            {
                Dispatcher.Invoke(new Action(() => DisableDynamictick.IsChecked = true));

            }
            else
            {
                Dispatcher.Invoke(new Action(() => DisableDynamictick.IsChecked = false));


            }

        }
        public void Getuseplatformtick()
        {
            string a = "";
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = @"CMD.EXE";
            p.StartInfo.Arguments = @"/C bcdedit";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            // parse the output
            var lines = output.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Where(l => l.Length > 24); ;

            foreach (var line in lines)
            {
                if (line.Contains("useplatformtick"))
                {

                    var value = line.Substring(24).Replace(" ", string.Empty);
                    a = value;
                }

            }
            if (a.Equals("Yes"))
            {
                Dispatcher.Invoke(new Action(() => EnablePlatformtick.IsChecked = true));

            }
            else
            {
                Dispatcher.Invoke(new Action(() => EnablePlatformtick.IsChecked = false));


            }

        }
        public void GetDisableHPET()
        {
            string a = "already";
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = @"CMD.EXE";
            p.StartInfo.Arguments = @"/C bcdedit";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            // parse the output
            var lines = output.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Where(l => l.Length > 24); ;

            foreach (var line in lines)
            {
                if (line.Contains("useplatformclock"))
                {
                    var value = line.Substring(24).Replace(" ", string.Empty);
                    a = value;
                }

            }
            if (a.Equals("already"))
            {
                Dispatcher.Invoke(new Action(() => DisableHPET.IsChecked = true));
            }
            else
            {
                Dispatcher.Invoke(new Action(() => DisableHPET.IsChecked = false));
            }

        }
        public void GetCortana()
        {

            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCortana", 0, RegistryValueKind.DWord);

            string CortanaV = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCortana", "").ToString();
            
            if (CortanaV.Equals("0"))
            {
                DisableCortana.IsChecked = true;
            }
            else
            {
                DisableCortana.IsChecked = false;
            }
        }
        private void TurnOffEnhancePointerPrecision_Click(object sender, RoutedEventArgs e)
        {
            
            if (!(bool)TurnOffEnhancePointerPrecision.IsChecked)
            {
                string script = @"New-ItemProperty -LiteralPath 'HKCU:\Control Panel\Mouse' -Name 'MouseSpeed' -Value '1' -PropertyType String -Force -ea SilentlyContinue;
New-ItemProperty -LiteralPath 'HKCU:\Control Panel\Mouse' -Name 'MouseThreshold1' -Value '6' -PropertyType String -Force -ea SilentlyContinue;
New-ItemProperty -LiteralPath 'HKCU:\Control Panel\Mouse' -Name 'MouseThreshold2' -Value '10' -PropertyType String -Force -ea SilentlyContinue;";
                run(script);
            }
            else
            {
                string script = @"New-ItemProperty -LiteralPath 'HKCU:\Control Panel\Mouse' -Name 'MouseSpeed' -Value '0' -PropertyType String -Force -ea SilentlyContinue;
New-ItemProperty -LiteralPath 'HKCU:\Control Panel\Mouse' -Name 'MouseThreshold1' -Value '0' -PropertyType String -Force -ea SilentlyContinue;
New-ItemProperty -LiteralPath 'HKCU:\Control Panel\Mouse' -Name 'MouseThreshold2' -Value '0' -PropertyType String -Force -ea SilentlyContinue;";
                run(script);
            }
        }
        private void AdjustMouseProperties_Click(object sender, RoutedEventArgs e)
        {
            if (!(bool)AdjustMouseProperties.IsChecked)
            {
                string a = @"New-ItemProperty -LiteralPath 'HKCU:\Control Panel\Mouse' -Name 'SmoothMouseXCurve' -Value ([byte[]](0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x15,0x6e,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x40,0x01,0x00,0x00,0x00,0x00,0x00,0x29,0xdc,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x28,0x00,0x00,0x00,0x00,0x00)) -PropertyType Binary -Force -ea SilentlyContinue;
New-ItemProperty -LiteralPath 'HKCU:\Control Panel\Mouse' -Name 'SmoothMouseYCurve' -Value ([byte[]](0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xfd,0x11,0x01,0x00,0x00,0x00,0x00,0x00,0x00,0x24,0x04,0x00,0x00,0x00,0x00,0x00,0x00,0xfc,0x12,0x00,0x00,0x00,0x00,0x00,0x00,0xc0,0xbb,0x01,0x00,0x00,0x00,0x00)) -PropertyType Binary -Force -ea SilentlyContinue;
new-ItemProperty -LiteralPath 'HKCU:\Control Panel\Desktop' -Name 'LogPixels' -Value 96 -PropertyType DWord -Force -ea SilentlyContinue;";
                run(a);
            }
            else
            {
                
                string a = @"New-ItemProperty -LiteralPath 'HKCU:\Control Panel\Mouse' -Name 'MouseSensitivity' -Value '10' -PropertyType String -Force -ea SilentlyContinue;
New-ItemProperty -LiteralPath 'HKCU:\Control Panel\Mouse' -Name 'SmoothMouseXCurve' -Value ([byte[]](0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xC0,0xCC,0x0C,0x00,0x00,0x00,0x00,0x00,0x80,0x99,0x19,0x00,0x00,0x00,0x00,0x00,0x40,0x66,0x26,0x00,0x00,0x00,0x00,0x00,0x00,0x33,0x33,0x00,0x00,0x00,0x00,0x00)) -PropertyType Binary -Force -ea SilentlyContinue;
New-ItemProperty -LiteralPath 'HKCU:\Control Panel\Mouse' -Name 'SmoothMouseYCurve' -Value ([byte[]](0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x38,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x70,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xA8,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xE0,0x00,0x00,0x00,0x00,0x00)) -PropertyType Binary -Force -ea SilentlyContinue;
new-ItemProperty -LiteralPath 'HKCU:\Control Panel\Desktop' -Name 'LogPixels' -Value 96 -PropertyType DWord -Force -ea SilentlyContinue;";
                
                run(a);
            }
        }
        private void EnableSimpleAltTab_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)EnableSimpleAltTab.IsChecked)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer", "AltTabSettings", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer", "AltTabSettings", 0, RegistryValueKind.DWord);
            }
        }
        private void EnableExclusiveFullScreenMode_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)EnableExclusiveFullScreenMode.IsChecked)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_FSEBehaviorMode", 0, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_FSEBehaviorMode", 2, RegistryValueKind.DWord);
            }
        }
        private void DisableDynamictick_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DisableDynamictick.IsChecked)
            {
                run("bcdedit /set disabledynamictick yes");
            }
            else
            {
                run("bcdedit /set disabledynamictick no");

            }
        }
        private void DisableGameBar_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DisableGameBar.IsChecked)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR", "AppCaptureEnabled", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_Enabled", 0, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR", "AppCaptureEnabled", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_Enabled", 1, RegistryValueKind.DWord);
            }
        }
        private void EnableGameMode_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)EnableGameMode.IsChecked)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "AllowAutoGameMode", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "AutoGameModeEnabled", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "AllowAutoGameMode", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "AutoGameModeEnabled", 0, RegistryValueKind.DWord);
            }
        }
        private void EnableHardwareAccelerated_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)EnableHardwareAccelerated.IsChecked)
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GraphicsDrivers", "HwSchMode", 2, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GraphicsDrivers", "HwSchMode", 1, RegistryValueKind.DWord);
            }
        }
        private void DisableAppCapture_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DisableAppCapture.IsChecked)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\GameDVR", "AllowgameDVR", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\GameDVR", "AppCaptureEnabled", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\GameDVR", "AudioCaptureEnabled", 0, RegistryValueKind.DWord);

            }
            else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\GameDVR", "AllowgameDVR", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\GameDVR", "AudioCaptureEnabled", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\GameDVR", "AppCaptureEnabled", 1, RegistryValueKind.DWord);


            }
        }
        private void UseNexus_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)UseNexus.IsChecked)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "UseNexusForGameBarEnabled", 0, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "UseNexusForGameBarEnabled", 1, RegistryValueKind.DWord);

            }
        }
        private void DriverSearch_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DriverSearch.IsChecked)
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\DriverSearching", "SearchOrderConfig", 0, RegistryValueKind.DWord);
               
            }
            else
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\DriverSearching", "SearchOrderConfig", 1, RegistryValueKind.DWord);

            }
        }
        private void MaintenanceDisabled_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)MaintenanceDisabled.IsChecked)
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\Maintenance", "MaintenanceDisabled", 0, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\Maintenance", "MaintenanceDisabled", 1, RegistryValueKind.DWord);

            }
        }
        private void DisableBackgroundApps_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DisableBackgroundApps.IsChecked)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", "GlobalUserDisabled", 1, RegistryValueKind.DWord);

            }
            else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", "GlobalUserDisabled", 0, RegistryValueKind.DWord);

            }
        }
        private void DisableAutoMaps_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DisableAutoMaps.IsChecked)
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\Maps", "AutoUpdateEnabled", 0, RegistryValueKind.DWord);

            }
            else
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\Maps", "AutoUpdateEnabled", 1, RegistryValueKind.DWord);

            }
        }
        private void DisableWindowsMemoryCompression_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DisableWindowsMemoryCompression.IsChecked)
            {
                run(@"Disable-MMagent -mc");
            }
            else
            {
                run(@"Enable-MMagent -mc");

            }
        }
        private void SetSystemResponsiveness_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)SetSystemResponsiveness.IsChecked)
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "SystemResponsiveness", 0, RegistryValueKind.DWord);

            }
            else
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "SystemResponsiveness", "20", RegistryValueKind.DWord);

            }
        }
        private void DisableHibernate_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DisableHibernate.IsChecked) { 
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power", "HibernateEnabled", 0, RegistryValueKind.DWord);

            }
            else
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power", "HibernateEnabled", 1, RegistryValueKind.DWord);

            }
        }
        private void DisablePowerThrottling_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DisablePowerThrottling.IsChecked)
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Power",true).CreateSubKey("PowerThrottling");
               
                
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling", "PowerThrottlingOff", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling", "PowerThrottlingOff", 0, RegistryValueKind.DWord);

            }
        }
        private void USBPower_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void EnablePlatformtick_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)EnablePlatformtick.IsChecked)
            {
                run("bcdedit /set useplatformtick yes");
            }
            else
            {
                run("bcdedit /set useplatformtick no");

            }
        }
        private void DisableHPET_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DisableHPET.IsChecked)
            {
                run("bcdedit /deletevalue useplatformclock");
            }
            else
            {
                run("bcdedit /set useplatformclock true");

            }
        }
        private void DisablePowerSavingFeatures_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software", true).CreateSubKey("Boosty");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Boosty", "Adjust", 1, RegistryValueKind.DWord);

            run(@"$hubs = Get-WmiObject Win32_USBHub
$powerMgmt = Get-WmiObject MSPower_DeviceEnable -Namespace root\wmi
foreach ($p in $powerMgmt)
{
	$IN = $p.InstanceName.ToUpper()
	foreach ($h in $hubs)
	{
		$PNPDI = $h.PNPDeviceID
                $p.enable = $False
                     $p.psbase.put()
        }
    }");
            run(@" $adapters = Get-NetAdapter -Physical | Get-NetAdapterPowerManagement
    foreach ($adapter in $adapters)
        {
        $adapter.AllowComputerToTurnOffDevice = 'Disabled'
        $adapter | Set-NetAdapterPowerManagement
        };exit;");


        }

        private void SetPowerPlan_Click(object sender, RoutedEventArgs e)
        {
            if ((bool) SetPowerPlan.IsChecked){
                if(!RunScript("powercfg -list").Contains("77777777-7777-7777-7777-777777777777")){
                    string path = Directory.GetCurrentDirectory();
                    run($"powercfg -import \"{path}\\Files\\PP.pow\" \"77777777-7777-7777-7777-777777777777\"");
                }
                
                run("powercfg -SETACTIVE \"77777777-7777-7777-7777-777777777777\"");
            }
            else
            {
                run("powercfg -SETACTIVE \"a1841308-3541-4fab-bc81-f71556f20b4a\"");
            }
            
        }

        private void EnableVideoQuality_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)EnableVideoQuality.IsChecked)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\VideoSettings", "VideoQualityOnBattery", 1, RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\VideoSettings", "VideoQualityOnBattery", 0, RegistryValueKind.DWord);

            }
        }

        private void NetworkAdvanced_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)NetworkAdvanced.IsChecked)
            {
                run(@"Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*FlowControl' -RegistryValue '0' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*InterruptModeration' -RegistryValue '0' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*LsoV2IPv4' -RegistryValue '0' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*LsoV2IPv6' -RegistryValue '0' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*IPChecksumOffloadIPv4' -RegistryValue '0' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*TCPChecksumOffloadIPv4' -RegistryValue '0' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*TCPChecksumOffloadIPv6' -RegistryValue '0' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*UDPChecksumOffloadIPv4' -RegistryValue '0' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*UDPChecksumOffloadIPv6' -RegistryValue '0' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*WakeOnMagicPacket' -RegistryValue '0' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*WakeOnPattern' -RegistryValue '0' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*NumRssQueues' -RegistryValue '3' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*RSS' -RegistryValue '1' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword 'EEELinkAdvertisement' -RegistryValue '0' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword 'EnablePME' -RegistryValue '0' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*JumboPacket' -RegistryValue '1514' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*TransmitBuffers' -RegistryValue '2048' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*ReceiveBuffers' -RegistryValue '2048' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*RSSProfile' -RegistryValue '3' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword 'AutoPowerSaveModeEnabled' -RegistryValue '0' -NoRestart;");
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}", "Opt", 1, RegistryValueKind.DWord);
            }
            else
            {
                run(@"
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*FlowControl' -RegistryValue '3' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*InterruptModeration' -RegistryValue '1' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*LsoV2IPv4' -RegistryValue '1' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*LsoV2IPv6' -RegistryValue '1' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*IPChecksumOffloadIPv4' -RegistryValue '3' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*TCPChecksumOffloadIPv4' -RegistryValue '3' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*TCPChecksumOffloadIPv6' -RegistryValue '3' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*UDPChecksumOffloadIPv4' -RegistryValue '3' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*UDPChecksumOffloadIPv6' -RegistryValue '3' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*WakeOnMagicPacket' -RegistryValue '1' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*WakeOnPattern' -RegistryValue '1' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*NumRssQueues' -RegistryValue '2' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*RSS' -RegistryValue '1' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword 'EEELinkAdvertisement' -RegistryValue '1' -NoRestart; 
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword 'EnablePME' -RegistryValue '1' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*JumboPacket' -RegistryValue '1514' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*TransmitBuffers' -RegistryValue '256' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*ReceiveBuffers' -RegistryValue '256' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword '*RSSProfile' -RegistryValue '1' -NoRestart;
Set-NetAdapterAdvancedProperty -Name '*' -RegistryKeyword 'AutoPowerSaveModeEnabled' -RegistryValue '1' -NoRestart;");
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}", "Opt", 0, RegistryValueKind.DWord);
            }

        }

        private void NetworkThrottling_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)NetworkThrottling.IsChecked)
            {
                //Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "NetworkThrottlingIndex", "4294967295", RegistryValueKind.DWord);
                run(@"New-ItemProperty -Path 'hklm:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile' -Name 'NetworkThrottlingIndex' -Value 4294967295 -PropertyType DWORD -Force");
            }
            else
            {
                //Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "NetworkThrottlingIndex", "10", RegistryValueKind.DWord);
                run(@"New-ItemProperty -Path 'hklm:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile' -Name 'NetworkThrottlingIndex' -Value 10 -PropertyType DWORD -Force");

            }
        }

        private void MinimalFX_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)MinimalFX.IsChecked)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", "VisualFXSetting", 3,RegistryValueKind.DWord) ;
                Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "UserPreferencesMask", new byte[] { 0x90, 0x12, 0x03, 0x80, 0x10, 0x00, 0x00, 0x00 }, RegistryValueKind.Binary);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", "VisualFXSetting", 3, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics", "MinAnimate", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAnimations", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "EnableAeroPeek", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "AlwaysHibernateThumbnails", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ListviewShadow", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\PriorityControl", "Win32PrioritySeparation",38, RegistryValueKind.DWord);



            }
            else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", "VisualFXSetting", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "UserPreferencesMask", new byte[] { 0x9E, 0x1E, 0x07, 0x80, 0x12, 0x00,0x00,0x00 }, RegistryValueKind.Binary);
                //9E 1E 07 80 12 00 00 00
                Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics", "MinAnimate", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAnimations", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "EnableAeroPeek", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "AlwaysHibernateThumbnails", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ListviewShadow", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\PriorityControl", "Win32PrioritySeparation", 2, RegistryValueKind.DWord);

            }
        }

        private void DarkTheme_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DarkTheme.IsChecked){
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 0,RegistryValueKind.DWord);
            }else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1, RegistryValueKind.DWord);

            }
        }

        private void DisableCortana_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DisableCortana.IsChecked)
            {
                
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCortana", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "DisableWebSearch", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCloudSearch", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "ConnectedSearchUseWeb", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "ConnectedSearchUseWebOverMeteredConnections", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowSearchToUseLocation", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCortanaAboveLock", 0, RegistryValueKind.DWord);


            }
            else
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "DisableWebSearch", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCortana", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCloudSearch", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "ConnectedSearchUseWeb", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "ConnectedSearchUseWebOverMeteredConnections", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowSearchToUseLocation", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCortanaAboveLock", 1, RegistryValueKind.DWord);
            }
        }

        private void WindowsDefender_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)WindowsDefender.IsChecked) {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", 1, RegistryValueKind.DWord);

            }
            else
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", 0, RegistryValueKind.DWord);

            }
        }

        private void EnableMSI_Click(object sender, RoutedEventArgs e)
        {
            string InstanceId = RunScript("get-pnpdevice | Where-object {$_.Class -Match 'Display' -and $_.FriendlyName -like '*nvidia*'} |select InstanceID | ft -HideTableHeaders").Trim();
            if ((bool)EnableMSI.IsChecked) {
                Registry.SetValue($@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\{InstanceId}\Device Parameters\Interrupt Management\MessageSignaledInterruptProperties", "MSISupported", 1,RegistryValueKind.DWord);
            }
            else
            {
                Registry.SetValue($@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\{InstanceId}\Device Parameters\Interrupt Management\MessageSignaledInterruptProperties", "MSISupported", 0,RegistryValueKind.DWord);

            }
        }
    }

}
