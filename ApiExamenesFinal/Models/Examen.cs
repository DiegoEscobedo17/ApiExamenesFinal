namespace ApiExamenesFinal.Models
{
    public class Examen
    {
        public string? id { get; set; }
        public string Texto { get; set; }
        public string Porcentaje { get; set; }
        public string Curso { get; set; }
        public int Precio { get; set; }
        public byte[] Imagen { get; set; }
    }

}
