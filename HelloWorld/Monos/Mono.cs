using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using HelloWorld.Utils;

namespace HelloWorld.Mono
{
    class Mono
    {
        Utils.LogDisplay log = new LogDisplay();
        DbConnection dbConn = new DbConnection();

        private AppSettingsReader reader;
        private int monoID { get; set;}
        private string type { get; set; }
        private string itemCode { get; set; }
        private string mono { get; set; }
        private DateTime lastUpdate { get; set; }

        public string Tag;
        public string DbConnKcms { get; private set; }
        public string DbConnCustom { get; private set; }
        public string sql { get; set; }

        private SqlConnection _dbconnConnection;
        private Exception lastError;
        private bool disposed;
         
        public Mono()
        {
            reader = new AppSettingsReader();
            Tag = this.GetType().Name;
        }

        public void GetMonoDatas()
        {
            try
            {
                string connectionString = dbConn._KIMSCustom;
                string sql = reader.GetValue("SelectMonoInfo", typeof(string)).ToString();

                log.Trace(Tag, "KIMS(KCMS) Database Connecting..", "");
                log.Trace(Tag, "sql", sql);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    log.Trace(Tag, "ok", "");

                    log.Trace(Tag, "KIMS Database Reading..", "");
                    using (SqlCommand command = new SqlCommand(sql, con))
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        log.Trace(Tag, "Reading OK", "");
                        while (dataReader.Read())
                        {
                            Console.WriteLine("{0} {1} {2}",
                                dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2));
                        }
                    }
                }

            }
            catch (InvalidOperationException e)
            {
                //: 인스턴스 오류
                log.Trace(Tag, "\n-----------------------------------","");
                log.Trace(Tag, "error", "Please check database name...");
                Console.WriteLine(e.ToString()); 
            }
            catch(Exception e)
            {
                log.Trace(Tag, "error", e.ToString());
            }
        }

    }
}
