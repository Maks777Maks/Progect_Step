using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task_Manager;

namespace Task_Manager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public ObservableCollection<ProcessInfo> Processes = new ObservableCollection<ProcessInfo>();
        int speed = 3000;
        string order = "";

        public MainWindow()
        {
            InitializeComponent();
            Thread th = new Thread(Refresh);
            th.IsBackground = true;
            th.Start();
        }

        public void Refresh()
        {
            while(true)
            {
                var list = Process.GetProcesses().ToList();

                this.Dispatcher.Invoke(() =>
                {
                    Processes.Clear();
                    foreach (var proc in list)
                    {
                        ProcessInfo p = new ProcessInfo(proc);
                        Processes.Add(p);
                    }
                    if (order == "")
                    {
                        listBox.ItemsSource = Processes.ToList();
                    }
                    else if (order == "name")
                    {
                        listBox.ItemsSource = Processes.OrderBy(x => x.Name).ToList();
                    }
                    else if (order == "memory")
                    {
                        listBox.ItemsSource = Processes.OrderBy(x => x.Memory).ToList();
                    }
                    listBox.SelectedIndex = selind;
                });

                Thread.Sleep(speed);
            }
        }

        private void Run_new_Task(object sender, RoutedEventArgs e)
        {
            New_Task new_task = new New_Task();
            new_task.ShowDialog();
        }

        private void Order_by_name(object sender, RoutedEventArgs e)
        {
            order = "name";
        }

        private void Order_by_memory(object sender, RoutedEventArgs e)
        {
            order = "memory";
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            var selected = listBox.SelectedItem as ProcessInfo;
            Process.GetProcessById(selected.ID).Kill();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            speed = 500;
        }

        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            speed = 1500;
        }

        private void MenuItem_Click2(object sender, RoutedEventArgs e)
        {
            speed = 3000;
        }
        public int selind = 0;
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listBox.SelectedIndex !=-1)
            selind = listBox.SelectedIndex;
        }
    }
}
