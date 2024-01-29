using ControlDeEstacionamiento.Interfaces.Prototype;

namespace ControlDeEstacionamiento.Implementacion.Prototype
{
    public class UsuarioConcreto : IPrototype
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public UsuarioConcreto(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        // Método para clonar el objeto
        public IPrototype ClonePrototype()
        {
            // Se realiza una copia superficial del objeto
            return (IPrototype)this.MemberwiseClone();
        }
    }
}
