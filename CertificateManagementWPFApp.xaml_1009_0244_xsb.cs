// 代码生成时间: 2025-10-09 02:44:21
using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace CertificateManagementWPFApp
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

        private void LoadCertificatesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Open a file dialog to select a certificate file
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = "Certificate files (*.pfx)|*.pfx";
                if (openFileDialog.ShowDialog() == true)
                {
                    // Load the certificate from the selected file
                    X509Certificate2 certificate = new X509Certificate2(openFileDialog.FileName);

                    // Display the certificate information in the UI
                    CertificateInfoTextBox.Text = $"Subject: {certificate.Subject}
Issuer: {certificate.Issuer}
Expiration: {certificate.NotAfter}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveCertificateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Open a file dialog to save a certificate file
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                saveFileDialog.Filter = "Certificate files (*.pfx)|*.pfx";
                if (saveFileDialog.ShowDialog() == true)
                {
                    // Load the certificate from the selected file
                    X509Certificate2 certificate = new X509Certificate2(CertificateInfoTextBox.Text);

                    // Save the certificate to the selected file
                    certificate.Export(X509ContentType.Pfx, "password").Save(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
