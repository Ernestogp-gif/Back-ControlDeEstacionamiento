/*
Chain of Responsibility es un patrón de diseño de comportamiento que te permite 
pasar solicitudes a lo largo de una cadena de manejadores. Al recibir una solicitud, 
cada manejador decide si la procesa o si la pasa al siguiente manejador de la cadena.
*/

using System;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Comportamiento.ChainofResponsability
{
    // Solicitud base: SolicitudMantenimiento
    class SolicitudMantenimiento
    {
        public string Tipo { get; }

        public SolicitudMantenimiento(string tipo)
        {
            Tipo = tipo;
        }
    }

    // Interfaz de Manejador: ManejadorMantenimiento
    interface IManejadorMantenimiento
    {
        void ManejarSolicitud(SolicitudMantenimiento solicitud);
    }

    // Implementación concreta del Manejador: MecanicoMotor
    class MecanicoMotor : IManejadorMantenimiento
    {
        public void ManejarSolicitud(SolicitudMantenimiento solicitud)
        {
            if (solicitud.Tipo == "Motor")
            {
                Console.WriteLine("Mecánico de motor maneja la solicitud de mantenimiento del motor.");
            }
            else
            {
                Console.WriteLine("Mecánico de motor pasa la solicitud al siguiente en la cadena.");
            }
        }
    }

    // Implementación concreta del Manejador: MecanicoFrenos
    class MecanicoFrenos : IManejadorMantenimiento
    {
        private IManejadorMantenimiento siguienteManejador;

        public void EstablecerSiguiente(IManejadorMantenimiento siguienteManejador)
        {
            this.siguienteManejador = siguienteManejador;
        }

        public void ManejarSolicitud(SolicitudMantenimiento solicitud)
        {
            if (solicitud.Tipo == "Frenos")
            {
                Console.WriteLine("Mecánico de frenos maneja la solicitud de mantenimiento de frenos.");
            }
            else if (siguienteManejador != null)
            {
                Console.WriteLine("Mecánico de frenos pasa la solicitud al siguiente en la cadena.");
                siguienteManejador.ManejarSolicitud(solicitud);
            }
            else
            {
                Console.WriteLine("No hay más manejadores en la cadena. La solicitud no puede ser manejada.");
            }
        }
    }

    // Cliente que inicia la cadena de responsabilidad
    class Program
    {
        static void Main()
        {
            // Crear instancias de manejadores
            IManejadorMantenimiento mecanicoMotor = new MecanicoMotor();
            IManejadorMantenimiento mecanicoFrenos = new MecanicoFrenos();

            // Establecer la cadena de responsabilidad
            ((MecanicoFrenos)mecanicoFrenos).EstablecerSiguiente(mecanicoMotor);

            // Iniciar la cadena de responsabilidad con una solicitud
            SolicitudMantenimiento solicitudMotor = new SolicitudMantenimiento("Motor");
            mecanicoFrenos.ManejarSolicitud(solicitudMotor);

            Console.WriteLine();

            SolicitudMantenimiento solicitudFrenos = new SolicitudMantenimiento("Frenos");
            mecanicoFrenos.ManejarSolicitud(solicitudFrenos);

            Console.WriteLine();

            SolicitudMantenimiento solicitudAceite = new SolicitudMantenimiento("Cambio de aceite");
            mecanicoFrenos.ManejarSolicitud(solicitudAceite);
        }
    }

}