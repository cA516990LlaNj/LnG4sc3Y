// 代码生成时间: 2025-09-21 13:45:43
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DocumentConverterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取用户选择的文件路径
                var openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = "Supported Formats|*.txt;*.docx;*.pdf;*.xlsx|All Files|*.*"
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    // 转换文档格式
                    ConvertDocumentFormat(selectedFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Converts the document format based on the file extension.
        /// </summary>
        /// <param name="filePath">The path to the document file.</param>
        private void ConvertDocumentFormat(string filePath)
        {
            // Implement the actual conversion logic based on file extension
            // For example:
            string newFilePath = Path.ChangeExtension(filePath, ".txt");
            File.Copy(filePath, newFilePath);
            MessageBox.Show($"Converted file saved to: {newFilePath}", "Conversion Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}