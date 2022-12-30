namespace Vuelos.DTOs
{
    public class VueloDTO
    {
        public int IdVuelo { get; set; }
        public DateTime Hora { get; set; }
        public string Destino { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string ClaveVuelo { get; set; } = null!;
        
    }
}
