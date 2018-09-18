using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrukturProjectMVC.Model.Repository
{
    public interface IDbContext : IDisposable
    {
        OleDbConnection Conn { get; }
    }

    public class DbContext : IDbContext
    {
        private OleDbConnection _conn;
        private string _connectionString;

        public DbContext()
        {
            var dbName = Directory.GetCurrentDirectory() + "\\Database\\DemoMVCProject.mdb";
            _connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", dbName);
        }

        public OleDbConnection Conn
        {            
            get { return _conn ?? (_conn = GetOpenConnection(_connectionString)); }
        }

        private OleDbConnection GetOpenConnection(string connectionString)
        {
            OleDbConnection conn = null;

            try
            {
                conn = new OleDbConnection(connectionString);
                conn.Open();
            }
            catch { }

            return conn;
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }
    }
}
