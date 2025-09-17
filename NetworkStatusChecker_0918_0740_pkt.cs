// 代码生成时间: 2025-09-18 07:40:24
// NetworkStatusChecker.cs
// 这个WPF应用程序用于检查计算机的网络连接状态。

using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows;

namespace NetworkStatusCheckerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckNetworkStatusButton_Click(object sender, RoutedEventArgs e)
        {
            // 尝试检查网络状态
            try
            {
                if (IsNetworkAvailable())
                {
                    MessageBox.Show("网络连接正常。");
                }
                else
                {
                    MessageBox.Show("网络连接不可用。");
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                MessageBox.Show($"检查网络状态时发生错误：{ex.Message}");
            }
        }

        // 检查网络是否可用
        private bool IsNetworkAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
    }
}
