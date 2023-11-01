using System.Collections;
using System.Data;
using Microsoft.Data.SqlClient;

namespace dotnetcaching.Utils
{
    public class CustomDataTable
    {
        public bool ErrorStatus { get; private set; }
        public string? ErrorMsg { get; private set; }


        public async Task<DataTable> ExecuteAsync(string name, Hashtable hashtable)
        {
            var configFile = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var settings = configFile.GetValue<string>("ConnectionStrings:DefaultConnection");

            DataTable resp = new();
            await using (var conn = new SqlConnection(settings))
            {
                SqlDataAdapter da = new(name, conn);

                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                IDictionaryEnumerator? el = hashtable.GetEnumerator();

                while (el.MoveNext())
                {
                    if (el.Value == null)
                    {
                        da.SelectCommand.Parameters.AddWithValue(el.Key.ToString(), DBNull.Value);
                    }
                    else
                    {
                        da.SelectCommand.Parameters.AddWithValue(el.Key.ToString(), el.Value);
                    }
                }

                try
                {
                    da.Fill(resp);
                    ErrorStatus = true;
                    ErrorMsg = "";
                }
                catch (SqlException ex)
                {
                    ErrorStatus = false;
                    ErrorMsg = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }

            return resp;
        }
    }
}