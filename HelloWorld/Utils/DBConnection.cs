using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HelloWorld.Utils
{
    public class DbConnection : IDisposable
    {
        Utils.LogDisplay log = new LogDisplay();
        public AppSettingsReader reader = new AppSettingsReader();

        public string Tag;
        public string DbConnKcms { get; private set; }
        public string _KIMSCustom { get; private set; }
        public string _KIMSDIDB { get; private set; }
        public string sql { get; set; }

        private SqlConnection _dbconnConnection;
        private Exception lastError;
        private bool disposed;

        public DbConnection()
        {
            Tag = this.GetType().Name;
            DbConnKcms = reader.GetValue("_DBConnKCMS", typeof(string)).ToString();
            _KIMSCustom = reader.GetValue("_KIMSCustom", typeof(string)).ToString();
            _KIMSDIDB = reader.GetValue("_KIMSDIDB", typeof(string)).ToString();

            log.Trace(Tag, "DbConnKcms", DbConnKcms);
            log.Trace(Tag, "DbConnCustom", _KIMSCustom);
        }

        public bool Open(string connStr)
        {   
            _dbconnConnection = new SqlConnection(connStr);
            try
            {
                _dbconnConnection.Open();
            }
            catch (SqlException e)
            {
                lastError = e;
                _dbconnConnection.Dispose();
                _dbconnConnection = null;
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    
 }
