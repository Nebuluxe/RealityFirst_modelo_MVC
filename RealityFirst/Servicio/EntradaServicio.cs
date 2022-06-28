using RealityFirst.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;


namespace RealityFirst.Servicio
{ 
    public class EntradaServicio
    {
        private string Connection;

        public EntradaServicio(string ConectionString)
        {
            this.Connection = ConectionString;
        }

        public IList<EntradaModel> GetAll()
        {
            IList<EntradaModel> lista = new List<EntradaModel>();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("Select id_entrada, tipo_entrada, valor_entrada FROM entrada");
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EntradaModel()
                            {
                                id_entrada = reader.GetInt32(0),
                                tipo_entrada = reader.GetString(1),
                                valor_entrada = reader.GetInt32(2)
                            });
                        }
                    }
                }
                server.Close();
            }
            return lista;
        }
    }
}
