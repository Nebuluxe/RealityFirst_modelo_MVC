namespace RealityFirst.Models
{
    public class NoticiaModel
    {
        public int id_noticia { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public string fecha_noticia { get; set; }
        public string escritor { get; set; }
        public string editor { get; set; }
        public string foto_noticia { get; set; }
        public int id_artista { get; set; }

        public NoticiaModel()
        {

        }
    }
}
