using RealityFirst.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;


namespace RealityFirst.Servicio
{
    public class EventoServicio 
    { 
        private string Connection;

        public EventoServicio(string ConectionString)
        {
            this.Connection = ConectionString;
        }

        public EventoModel Get(int id)
        {
            EventoModel evento = new EventoModel();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("SELECT ev.id_evento, ev.nombre_ev, ev.lugar_evento, ev.fecha_evento,ev.imagen_evento, ar.nombre, ar.genero_musical, ar.id_artista FROM eventos AS ev JOIN Artista AS ar ON(ev.id_artista = ar.id_artista) where ev.id_artista = {0};", id);
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            evento = new EventoModel()
                            {
                                id_evento = reader.GetInt32(0),
                                nombre_evento = reader.GetString(1),
                                lugar_evento = reader.GetString(2),
                                fecha_evento = reader.GetString(3),
                                imagen_evento = reader.GetString(4),
                                nombre_artista = reader.GetString(5),
                                genero_musical = reader.GetString(6),
                                id_artista = reader.GetInt32(7)
                            };
                        }
                    }
                }
                server.Close();
            }
            return evento;
        }

        public IList<EventoModel> GetAll()
        {
            IList<EventoModel> lista = new List<EventoModel>();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("SELECT ev.id_evento, ev.nombre_ev, ev.lugar_evento, ev.fecha_evento,ev.imagen_evento, ar.nombre, ar.genero_musical, ar.id_artista FROM eventos AS ev JOIN Artista AS ar ON(ev.id_artista = ar.id_artista)");
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EventoModel()
                            {
                                id_evento = reader.GetInt32(0),
                                nombre_evento = reader.GetString(1),
                                lugar_evento = reader.GetString(2),
                                fecha_evento = reader.GetString(3),
                                imagen_evento = reader.GetString(4),
                                nombre_artista = reader.GetString(5),
                                genero_musical = reader.GetString(6),
                                id_artista = reader.GetInt32(7)
                            });
                        }
                    }
                }
                server.Close();
            }
            return lista;
        }

        public IList<EventoModel> DireccionarEventoArtista(int ID)
        {
            IList<EventoModel> lista = this.GetAll();

            return lista.Where(x => x.id_artista == ID).ToList();
        }


    }


}
