namespace Core.Features.Usuario.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Codigo { get; set; }
        public string Genero { get; set; }
        public string TipoUsuario { get; set; }
        public string UrlImagen { get; set; }
    }
}
