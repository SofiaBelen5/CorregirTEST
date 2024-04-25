using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Programacion3.Ejercicios.Entidades
{
	public class Jugador : Persona
	{
        public int Goles { get; set; }
        public Jugador(string nombre, string apellido)
			: base(nombre, apellido)
		{

		}

    }
}
