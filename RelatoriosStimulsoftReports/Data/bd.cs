using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RelatoriosStimulsoftReports.Data
{
    public class bd
    {

        private string _connectionString = @"Integrated Security=False; Data Source=.\SQLEXPRESS;
Initial Catalog=ControleFinanceiroPessoal; User ID=sa; Password=zaxx34;";               

        public DataTable retornaDataTable<T>(string query) where T : IDbConnection, new()
        {
            using (var conn = new T())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection.ConnectionString = _connectionString;
                    cmd.Connection.Open();
                    var table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    return table;
                }
            }
        }

    }
}
