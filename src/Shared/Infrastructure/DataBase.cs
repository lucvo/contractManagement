/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>
namespace Infrastructure
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using Contracts;
    
    public class DataBase 
    {
        private readonly string connectionString;
        private IDbConnection connection;

        protected DataBase(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected DataBase(IDbConnection connection)
            : this(connection.ConnectionString)
        {
            this.connection = connection;
        }
        private IDbTransaction transaction { get; set; }

        /// <summary>
        ///     Get the current connection, or open a new connection
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                if (connection == null)
                    connection = new SqlConnection(this.connectionString);

                if (string.IsNullOrWhiteSpace(connection.ConnectionString))
                    connection.ConnectionString = this.connectionString;

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                return connection;
            }
        }

        /// <summary>
        ///     Start a new transaction if one is not already available
        /// </summary>
        public IDbTransaction BeginTransaction()
        {
            if (transaction == null || transaction.Connection == null)
                transaction = Connection.BeginTransaction();

            return transaction;
        }

        /// <summary>
        ///     Perform a transactionless query
        /// </summary>
        public T Transaction<T>(Func<IDbTransaction, T> query)
        {
            try
            {
                var transaction = BeginTransaction();
                var result = query(transaction);
                transaction.Commit();

                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        /// <summary>
        ///     Commit and dispose of the transaction
        /// </summary>
        public void Commit()
        {
            try
            {
                transaction.Commit();
                transaction.Dispose();
                transaction = null;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.Connection != null)
                    Rollback();

                throw new NullReferenceException("Tried Commit on closed Transaction", ex);
            }
        }

        /// <summary>
        ///     Rollback and dispose of the transaction
        /// </summary>
        public void Rollback()
        {
            try
            {
                transaction.Rollback();
                transaction.Dispose();
                transaction = null;
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Tried Rollback on closed Transaction", ex);
            }
        }

        /// <summary>
        ///     Dispose of the transaction and close the connection
        /// </summary>
        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }

            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }
    }
}
