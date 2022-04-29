using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto.Providers
{
    public class NpgSqlProvider : INpgSqlProvider
    {
        public NpgsqlConnection GetConection()
        {
            var conectionString = ConfigurationManager.AppSettings["NpgSqlConection"];
            return new NpgsqlConnection(conectionString);
        }
    }
}
