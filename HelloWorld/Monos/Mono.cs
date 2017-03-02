using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using HelloWorld.Utils;

namespace HelloWorld.Monos
{
    class Mono
    {
        private readonly AppSettingsReader _reader = new AppSettingsReader();

        public string Sql { get; set; }
        public Encoding Encoding;
        private string ConnectionString { get; set; }
        private int MaxByteSize { get; set; }
        private readonly LogDisplay _log;

        public Mono()
        {

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("\t\tResizing String Program :)");
            Console.WriteLine("------------------------------------------------------");
            
            _log = new LogDisplay(this.GetType().Name);

            ConnectionString = _reader.GetValue("DbConnString", typeof(string)).ToString();
            MaxByteSize = (int)_reader.GetValue("MaxByteSize", typeof(int));
            string encodingType = _reader.GetValue("Encoding", typeof(string)).ToString();
            Encoding = Encoding.GetEncoding(encodingType);
        }

        public void GetMonoDatas()
        {
            try
            {
                Sql = _reader.GetValue("SelectMonoInfo", typeof(string)).ToString() + MaxByteSize;

                _log.Trace("Database Connecting..", "");
                _log.Trace(Sql, "");

                string monoData = string.Empty;
                ConvertBytes cs = new ConvertBytes(Encoding, MaxByteSize);
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();

                    _log.Trace("Database Connection Success.", "");
                    _log.Trace("Database Reading..", "");

                    using (SqlCommand command = new SqlCommand(Sql, con))
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            monoData = dataReader.GetString(0);
                            int byteSize = cs.GetByteSize(monoData);
                            _log.PrintResult(Encoding, monoData, byteSize);
                        }
                    }
                }
                cs.ResizeMonoData(monoData);
                _log.Trace("All process complete.", "");
            }
            catch (Exception e)
            {
                _log.Trace("error", e.ToString());
            }
        }

    }
}
