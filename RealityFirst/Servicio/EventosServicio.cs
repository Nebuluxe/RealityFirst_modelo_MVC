using RealityFirst.Models;
using RealityFirst.Servicio.ServicioEstructura;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace RealityFirst.Servicio
{
    public class EventosServicio
    {
        private string Connection;

        public EventosServicio(string ConectionString)
        {
            this.Connection = ConectionString;
        }

        public IList<EventosModel> GetAll(int id)
        {
            IList<EventosModel> lista = new List<EventosModel>();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("SELECT id_evento, nombre_ev, lugar_evento, fecha_evento, id_artista FROM eventos WHERE id_artista = {0};", id);
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EventosModel()
                            {
                                id_evento = reader.GetInt32(0),
                                nombre_ev = reader.GetString(1),
                                lugar_evento = reader.GetString(2),
                                fecha_evento = reader.GetString(3),
                                id_artista = reader.GetInt32(4),
                                imagen_evento = reader.GetString(5)
                            });
                        }
                    }
                }
                server.Close();
            }
            return lista;
        }

        public EventosModel Get(int id)
        {
            EventosModel evento = new EventosModel();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();
                string query = string.Format("SELECT id_evento, nombre_ev, lugar_evento, fecha_evento, id_artista FROM eventos WHERE id_artista = {0};", id);
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            evento = new EventosModel()
                            {
                                id_evento = reader.GetInt32(0),
                                nombre_ev = reader.GetString(1),
                                lugar_evento = reader.GetString(2),
                                fecha_evento = reader.GetString(3),
                                id_artista = reader.GetInt32(4),
                                imagen_evento = reader.GetString(5)
                            };
                        }
                    }
                }
                server.Close();
            }
            return evento;
        }

        public void Create(EventosModel obj)
        {

        }

        public void Update(EventosModel obj)
        {

        }

        public void Delete(int id)
        {

        }

    }
}