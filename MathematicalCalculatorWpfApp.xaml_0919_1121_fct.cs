// 代码生成时间: 2025-09-19 11:21:23
using System;
using System.Windows;

namespace WPFMathematicalCalculator
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TryPerformCalculation("+");
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            TryPerformCalculation("-");
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            TryPerformCalculation("*");
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            TryPerformCalculation("/");
        }

        private void TryPerformCalculation(string operation)
        {
            // Get the numbers from the input fields
            string number1 = Number1TextBox.Text;
            string number2 = Number2TextBox.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(number1) || string.IsNullOrWhiteSpace(number2))
            {
                MessageBox.Show("Both numbers must be provided.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(number1, out double num1) || !double.TryParse(number2, out double num2))
            {
                MessageBox.Show("Please enter valid numbers.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Perform the calculation
            double result;
            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        MessageBox.Show("Cannot divide by zero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    result = num1 / num2;
                    break;
                default:
                    MessageBox.Show("Invalid operation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }

            // Display the result
            ResultTextBox.Text = result.ToString();
        }
    }
}