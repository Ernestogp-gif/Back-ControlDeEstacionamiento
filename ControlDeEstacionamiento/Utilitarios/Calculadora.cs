namespace ControlDeEstacionamiento.Utilitarios
{
    public class Calculadora
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; } 

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }
    }
}
