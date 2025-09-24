// 代码生成时间: 2025-09-24 10:00:15
using System;
using System.Windows;

namespace MessageNotificationSystem
{
    // ViewModel class for the message notification system
    public class NotificationViewModel : INotifyPropertyChanged
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Main window for the message notification system
    public partial class MainWindow : Window
    {
        private NotificationViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new NotificationViewModel();
            this.DataContext = _viewModel;
        }

        // Method to send a message notification
        private void SendNotification(string message)
        {
            try
            {
                if (string.IsNullOrEmpty(message))
                {
                    throw new ArgumentException("Message cannot be null or empty.");
                }

                _viewModel.Message = message;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending notification: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for the send button click
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;
            SendNotification(message);
        }
    }
}
