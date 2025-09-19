// 代码生成时间: 2025-09-19 16:32:53
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

// MainWindow.xaml.cs 是 WPF 应用的主窗口代码文件
namespace ProcessManagerApp
{
    // MainWindow 是主窗口类
    public partial class MainWindow : Window
    {
        private List<Process> processList = new List<Process>();
        private ListView processListView;

        // MainWindow 的构造函数
        public MainWindow()
        {
            InitializeComponent();
            InitializeProcessListView();
        }

        // 初始化进程列表视图
        private void InitializeProcessListView()
        {
            processListView = new ListView
            {
                Height = 300,
                Width = 400
            };
            processListView.View.AddColumn(new GridViewColumn { Header = "Process ID", DisplayMemberBinding = new Binding("Id") });
            processListView.View.AddColumn(new GridViewColumn { Header = "Process Name", DisplayMemberBinding = new Binding("ProcessName\) });

            // 将进程信息绑定到 ListView
            processListView.ItemsSource = processList;

            // 将 ListView 添加到 Grid 控件中
            Grid.SetColumn(processListView, 1);
            Grid.SetRow(processListView, 1);
            this.Content as Grid.Children.Add(processListView);
        }

        // 刷新进程列表的方法
        public void RefreshProcessList()
        {
            try
            {
                processList.Clear();
                foreach (var process in Process.GetProcesses())
                {
                    processList.Add(process);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while refreshing the process list: {ex.Message}");
            }
        }

        // 当窗口加载时，刷新进程列表
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshProcessList();
        }

        // 结束选定进程的方法
        private void EndProcess(object sender, RoutedEventArgs e)
        {
            if (processListView.SelectedItem is Process process)
            {
                try
                {
                    process.Kill();
                    MessageBox.Show($"Process {process.ProcessName} with ID {process.Id} has been terminated.");
                    RefreshProcessList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while terminating the process: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a process to terminate.");
            }
        }

        // 主窗口的 XAML 部分需要相应的按钮和事件绑定
    }
}