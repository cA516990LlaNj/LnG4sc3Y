// 代码生成时间: 2025-09-22 05:41:41
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace UrlValidatorApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 点击按钮时触发的方法，用于验证URL
        private void ValidateUrlButton_Click(object sender, RoutedEventArgs e)
        {
            // 获取文本框中的URL
            string url = urlTextBox.Text;

            // 清空状态栏消息
            statusLabel.Content = string.Empty;

            if(string.IsNullOrEmpty(url))
            {
                statusLabel.Content = "Please enter a URL.";
                return;
            }

            try
            {
                Uri uriResult;
                // 尝试解析URL，检查格式是否正确
                bool isUrlValid = Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                                  (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if(isUrlValid)
                {
                    // 检查URL是否可达
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriResult);
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            statusLabel.Content = "The URL is valid and reachable.";
                        }
                        else
                        {
                            statusLabel.Content = "The URL is valid but not reachable.";
                        }
                    }
                }
                else
                {
                    statusLabel.Content = "The URL is not valid.";
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                statusLabel.Content = $"An error occurred: {ex.Message}";
            }
        }
    }
}