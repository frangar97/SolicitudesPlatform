namespace Core.Features.Usuario.DTO
{
    public class CreateUsuarioDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Codigo { get; set; }
        public string Password { get; set; }
        public string Genero { get; set; }
        public string TipoUsuario { get; set; }
    }
}
