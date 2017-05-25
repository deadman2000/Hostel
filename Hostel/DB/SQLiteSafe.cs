using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading;

namespace Hostel.DB
{
    public class SQLiteSafe
    {
        private SQLiteFactory factory;
        private string _fileName;
        private const int maxConnections = 5;
        private bool _wal;
        public static bool Log = true;

        public SQLiteSafe(string fileName, bool wal = false)
        {
            _fileName = fileName;
            _wal = wal;
            factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
            InitPool(maxConnections);
        }

        private SQLiteConnection PrepareConn(SQLiteConnection conn)
        {
            if ((conn.State & ConnectionState.Open) == 0)
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    conn = CreateConnection();
                    conn.Open();
                }

                if (_wal)
                {
                    new SQLiteCommand("PRAGMA journal_mode=WAL", conn).ExecuteNonQuery();
                    new SQLiteCommand("PRAGMA synchronous=NORMAL", conn).ExecuteNonQuery();
                }
            }

            return conn;
        }

        public void Close()
        {
            lock (connPool)
            {
                foreach (var c in allConnections)
                {
                    c.Close();
                }
                connPool.Clear();
                connPool.AddRange(allConnections);
            }
        }

        private SQLiteConnection CreateConnection()
        {
            SQLiteConnection conn = (SQLiteConnection)factory.CreateConnection();
            conn.ConnectionString = "Data Source = " + _fileName;
            return conn;
        }

        #region Pool

        private List<SQLiteConnection> connPool;
        private List<SQLiteConnection> allConnections;

        private void InitPool(int maxConnections)
        {
            connPool = new List<SQLiteConnection>(maxConnections);
            allConnections = new List<SQLiteConnection>(maxConnections);
            for (int i = 0; i < maxConnections; i++)
            {
                SQLiteConnection conn = CreateConnection();
                connPool.Add(conn);
                allConnections.Add(conn);
            }
        }

        private SQLiteConnection GetConnection()
        {
            while (true)
            {
                lock (connPool)
                {
                    if (connPool.Count > 0)
                    {
                        var conn = connPool[connPool.Count - 1];
                        connPool.RemoveAt(connPool.Count - 1);
                        return conn;
                    }
                }

                Thread.Sleep(1);
            }
        }

        /// <summary>Захватывает подключение из пула, позволяя клиенту использовать его напрямую</summary>
        /// <remarks>После завершения операции необходимо вернуть подключение в пул методом <see cref="ReleaseConnection"/></remarks>
        public SQLiteConnection TakeConnection()
        {
            return PrepareConn(GetConnection());
        }

        /// <summary>Возвращает подключение в пул</summary>
        public void ReleaseConnection(SQLiteConnection conn)
        {
            lock (connPool)
            {
                if (!connPool.Contains(conn))
                    connPool.Add(conn);
            }
        }

        #endregion

        public void ExecuteNonQuery(string sql)
        {
            ExecuteNonQuery(new SQLiteCommand(sql));
        }

        public void ExecuteNonQuery(SQLiteCommand command)
        {
            if (Log) Console.WriteLine(command.CommandText);

            var conn = TakeConnection();
            try
            {
                command.Connection = conn;
                command.ExecuteNonQuery();
            }
            finally
            {
                ReleaseConnection(conn);
            }
        }

        public object ExecuteScalar(SQLiteCommand command)
        {
            if (Log) Console.WriteLine(command.CommandText);

            var conn = TakeConnection();
            try
            {
                command.Connection = conn;
                return command.ExecuteScalar();
            }
            finally
            {
                ReleaseConnection(conn);
            }
        }

        public DataTable ExecuteTable(string sql)
        {
            return ExecuteTable(new SQLiteCommand(sql));
        }

        public DataTable ExecuteTable(SQLiteCommand command)
        {
            if (Log) Console.WriteLine(command.CommandText);
            var conn = TakeConnection();
            try
            {
                var dataAdapter = new SQLiteDataAdapter(command);
                command.Connection = conn;
                var table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                return table;
            }
            finally
            {
                ReleaseConnection(conn);
            }
        }
    }
}
