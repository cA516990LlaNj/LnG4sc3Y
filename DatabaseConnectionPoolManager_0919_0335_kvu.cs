// 代码生成时间: 2025-09-19 03:35:21
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

// DatabaseConnectionPoolManager 负责管理数据库连接池。
public class DatabaseConnectionPoolManager
{
    // 连接池的最大大小
    private const int MaxPoolSize = 10;
    // 连接池的最小空闲连接数
    private const int MinIdleConnections = 3;
    // 连接池的连接超时时间（秒）
    private const int ConnectionTimeout = 30;

    // 私有的连接池列表
    private List<DbConnection> _connectionPool = new List<DbConnection>();

    // 数据库连接字符串
    private readonly string _connectionString;

    // 构造函数，初始化连接池
    public DatabaseConnectionPoolManager(string connectionString)
    {
        _connectionString = connectionString;
        // 初始化连接池
        InitializePool();
    }

    // 初始化连接池
    private void InitializePool()
    {
        for (int i = 0; i < MinIdleConnections; i++)
        {
            // 创建新的数据库连接并添加到连接池
            DbConnection connection = CreateDbConnection();
            _connectionPool.Add(connection);
        }
    }

    // 创建新的数据库连接
    private DbConnection CreateDbConnection()
    {
        var connection = new SqlConnection(_connectionString);
        // 设置连接超时时间
        connection.ConnectionTimeout = ConnectionTimeout;
        return connection;
    }

    // 获取连接池中的可用连接
    public DbConnection GetConnection()
    {
        lock (_connectionPool)
        {
            if (_connectionPool.Count == 0)
            {
                // 如果连接池为空，则创建新的连接
                return CreateDbConnection();
            }
            else
            {
                // 从连接池中获取一个已打开的连接
                var connection = _connectionPool.FirstOrDefault(c => c.State != ConnectionState.Closed);
                if (connection != null)
                {
                    // 从连接池中移除已获取的连接
                    _connectionPool.Remove(connection);
                    return connection;
                }
                else
                {
                    // 如果所有连接都关闭，则创建新的连接
                    return CreateDbConnection();
                }
            }
        }
    }

    // 释放连接到连接池
    public void ReleaseConnection(DbConnection connection)
    {
        lock (_connectionPool)
        {
            try
            {
                // 确保连接没有被关闭
                if (connection.State != ConnectionState.Closed)
                {
                    // 关闭连接
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // 处理关闭连接时可能出现的异常
                Console.WriteLine($"Error closing connection: {ex.Message}");
            }
            finally
            {
                // 将连接重新添加到连接池
                if (_connectionPool.Count < MaxPoolSize)
                {
                    _connectionPool.Add(connection);
                }
                else
                {
                    // 如果连接池达到最大大小，则丢弃该连接
                    connection.Dispose();
                }
            }
        }
    }
}
