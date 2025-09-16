// 代码生成时间: 2025-09-16 21:45:13
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

// 定义WPF应用的主窗口类
public partial class MainWindow : Window
{
    private readonly HttpClient _httpClient;

    // 构造函数
    public MainWindow()
    {
        InitializeComponent();
        _httpClient = new HttpClient();
    }

    // 发送GET请求到RESTful API
    private async void GetButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://api.example.com/data");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            // 处理响应数据
            ProcessResponse(responseBody);
        }
        catch (HttpRequestException httpEx)
        {
            MessageBox.Show("Error reaching the server: " + httpEx.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    // 发送POST请求到RESTful API
    private async void PostButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string jsonData = "{"key": "value"}";
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("https://api.example.com/data", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            // 处理响应数据
            ProcessResponse(responseBody);
        }
        catch (HttpRequestException httpEx)
        {
            MessageBox.Show("Error reaching the server: " + httpEx.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    // 处理API响应数据
    private void ProcessResponse(string responseBody)
    {
        // 这里可以添加代码来处理响应数据，例如更新UI等
        MessageBox.Show("Response received: " + responseBody);
    }
}
