namespace Core.Features.Solicitud.DTO
{
    public class SolicitudDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Usuario { get; set; }
        public string EstadoSolicitud { get; set; }
        public string TipoSolicitud { get; set; }
        public string Zona { get; set; }
    }
}
