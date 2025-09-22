// 代码生成时间: 2025-09-22 14:53:28
using System;
using System.Net.Sockets;
using System.Windows; // 引入WPF命名空间

namespace NetworkStatusCheckerWPFApp
{
    // NetworkStatusCheckerWPFApp类封装了检查网络状态的功能
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 检查网络连接状态的方法
        private async void CheckNetworkStatus()
        {
            try
            {
                // 使用Ping类来检查网络连接
                Ping ping = new Ping();
                PingReply reply = await ping.SendPingAsync("www.google.com");

                // 根据PingReply的状态来判断网络是否连接
                if (reply.Status == IPStatus.Success)
                {
                    MessageBox.Show("Network is connected.", "Connection Status");
                }
                else
                {
                    MessageBox.Show("Network is not connected.", "Connection Status");
                }
            }
            catch (PingException ex)
            {
                // 处理Ping异常
                MessageBox.Show("Error: " + ex.Message, "Connection Error");
            }
            catch (Exception ex)
            {
                // 处理其他异常
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }
    }
}
