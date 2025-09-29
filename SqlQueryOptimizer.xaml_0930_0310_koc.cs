// 代码生成时间: 2025-09-30 03:10:24
using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace SqlQueryOptimizerApp
{
    /// <summary>
    /// Interaction logic for SqlQueryOptimizer.xaml
    /// </summary>
    public partial class SqlQueryOptimizer : Window
    {
        private string connectionString;
        private SqlConnection connection;
        private SqlCommand command;

        public SqlQueryOptimizer()
        {
            InitializeComponent();
            InitializeConnection();
        }

        private void InitializeConnection()
        {
            connectionString = "your_connection_string_here";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        /// <summary>
        /// Handles the button click event to optimize the SQL query.
        /// </summary>
        private void OptimizeQueryButton_Click(object sender, RoutedEventArgs e)
        {
            string userQuery = QueryTextBox.Text;
            try
            {
                // Here you would add logic to analyze and optimize the query.
                // For demonstration purposes, we're just executing the user query.
                command = new SqlCommand(userQuery, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                MessageBox.Show("Query executed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Cleans up resources and closes the connection.
        /// </summary>
        private void SqlQueryOptimizer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (command != null)
            {
                command.Dispose();
            }
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}