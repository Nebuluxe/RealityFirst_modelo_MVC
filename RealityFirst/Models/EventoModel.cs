namespace RealityFirst.Models
{
    public class EventoModel
    { 
        public int id_evento { get; set; }
        public string nombre_evento { get; set; }
        public string lugar_evento { get; set; }
        public string fecha_evento { get; set; }
        public string imagen_evento { get; set; }
        public string nombre_artista { get; set; }
        public string genero_musical { get; set; }
        public int id_artista { get; set; }
        public EventoModel()
        {

        }
    }
}
