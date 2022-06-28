namespace RealityFirst.Models
{
    public class ArtistaModel
    { 
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string genero { get; set; }
        public string foto { get; set; }
        public string fecha_nacimiento { get; set; }
        public int id_noticia { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public string fecha_noticia { get; set; }
        public string escritor { get; set; }
        public string editor { get; set; }
        public string foto_noticia { get; set; }
        public ArtistaModel()
        {

        }
    }
}
