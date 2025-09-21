// 代码生成时间: 2025-09-21 20:49:15
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

// 定义日志文件解析工具的主要界面
public partial class LogParserWpfApp : Window
{
    // 构造函数
    public LogParserWpfApp()
    {
        InitializeComponent();
    }

    // 解析日志文件的方法
    private void ParseLogFile(string filePath)
    {
        try
        {
            // 检查文件路径是否有效
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Invalid log file path.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // 读取日志文件内容
            string logContent = File.ReadAllText(filePath);

            // 使用正则表达式解析日志内容
            var matches = Regex.Matches(logContent, @"(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}) (ERROR|INFO|WARNING) (.*)");

            // 处理每个匹配项
            foreach (Match match in matches)
            {
                var timestamp = match.Groups[1].Value;
                var level = match.Groups[2].Value;
                var message = match.Groups[3].Value;
                // 将解析的数据输出到界面上
                // 这里需要将解析的数据添加到界面的某个部分，例如列表或者文本框
                // 例如：LogItemsList.Items.Add(new LogItem { Timestamp = timestamp, Level = level, Message = message });
            }
        }
        catch (Exception ex)
        {
            // 处理解析过程中的异常
            MessageBox.Show($"Error parsing log file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // 选择日志文件按钮的点击事件处理
    private void SelectLogFileButton_Click(object sender, RoutedEventArgs e)
    {
        // 打开文件对话框，选择日志文件
        var openFileDialog = new Microsoft.Win32.OpenFileDialog
        {
            Filter = "Log files (*.log)|*.log"
        };
        if (openFileDialog.ShowDialog() == true)
        {
            // 获取选中的文件路径
            var filePath = openFileDialog.FileName;
            // 调用解析日志文件的方法
            ParseLogFile(filePath);
        }
    }
}
