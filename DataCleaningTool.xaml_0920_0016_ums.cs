// 代码生成时间: 2025-09-20 00:16:24
// DataCleaningTool.xaml.cs
// 这是一个WPF应用程序，用于数据清洗和预处理。

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DataProcessingApp
{
    /// <summary>
    /// Interaction logic for DataCleaningTool.xaml
    /// </summary>
    public partial class DataCleaningTool : Window
    {
        public DataCleaningTool()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            // 在这里初始化数据，例如加载数据源
        }

        private void Button_LoadData_Click(object sender, RoutedEventArgs e)
        {
            // 加载数据按钮点击事件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    // 读取CSV文件
                    string[] lines = File.ReadAllLines(filePath);
                    // 进行数据清洗和预处理
                    List<string> cleanedData = CleanData(lines);
                    // 将清洗后的数据显示在界面上
                    TextBox_Results.Text = string.Join("
", cleanedData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading file: " + ex.Message);
                }
            }
        }

        private List<string> CleanData(string[] lines)
        {
            // 数据清洗逻辑
            List<string> cleanedData = new List<string>();
            foreach (var line in lines)
            {
                // 假设我们只是简单地移除空行和多余的空格
                if (!string.IsNullOrWhiteSpace(line))
                {
                    cleanedData.Add(line.Trim());
                }
            }
            return cleanedData;
        }

        private void Button_SaveData_Click(object sender, RoutedEventArgs e)
        {
            // 保存数据按钮点击事件
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    // 将TextBox中的文本保存到文件
                    File.WriteAllText(filePath, TextBox_Results.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving file: " + ex.Message);
                }
            }
        }
    }
}