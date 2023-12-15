namespace ControlDeEstacionamiento.Model
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public byte[] HashClave { get; set; }
        public byte[] Sal { get; set; }
    }
}
