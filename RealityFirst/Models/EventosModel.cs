namespace RealityFirst.Models
{
    public class EventosModel
    {
        public int id_evento { get; set; }
        public string nombre_ev { get; set; }
        public string lugar_evento { get; set; }
        public string fecha_evento { get; set; }
        public int id_artista { get; set; }
        public string imagen_evento { get; set; }
        public EventosModel()
        {

        }
    }
}
