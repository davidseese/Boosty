using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace Boosty.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private static System.Timers.Timer timer;
        public HomeView()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(200);
            timer.Elapsed += Timer_Tick;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();

        }
        private void Timer_Tick(Object source, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() => TimerLabelRam.Text = ((App)Application.Current).ramUsage.ToString()));
            Dispatcher.Invoke(new Action(() => ramBar.Progress = ((App)Application.Current).ramUsage));
            Dispatcher.Invoke(new Action(() => TimerLabelCpu.Text = ((App)Application.Current).cpuUsage.ToString()));
            Dispatcher.Invoke(new Action(() => cpuBar.Progress = ((App)Application.Current).cpuUsage));
            Dispatcher.Invoke(new Action(() => TimerLabelGpu.Text = ((App)Application.Current).gpuUsage.ToString()));
            Dispatcher.Invoke(new Action(() => gpuBar.Progress = ((App)Application.Current).gpuUsage));
            Dispatcher.Invoke(new Action(() => Clock.Text = ((App)Application.Current).cpuClocks + " MHz"));
            Dispatcher.Invoke(new Action(() => cpuTemp.Text = ((App)Application.Current).cpuTemp + " °C"));
            Dispatcher.Invoke(new Action(() => gpuClock.Text = ((App)Application.Current).gpuClock + " MHz"));
            Dispatcher.Invoke(new Action(() => Fan.Text = ((App)Application.Current).fanSpeed +" RPM"));
            Dispatcher.Invoke(new Action(() => gpuTemp.Text = ((App)Application.Current).GPUTemp + " °C"));
            Dispatcher.Invoke(new Action(() => Power.Text = ((App)Application.Current).cpuPower + " W"));
            Dispatcher.Invoke(new Action(() => ramUsed.Text = ((App)Application.Current).ramUsed + " GB"));
            
        }
       
    }
}
