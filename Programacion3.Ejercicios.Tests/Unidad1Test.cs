using Programacion3.Ejercicios.Entidades;
using Programacion3.Ejercicios.Entidades.Interfaces;

namespace Programacion3.Ejercicios.Tests
{
	/// <summary>
	/// Unidad 1/Unidad 2
	/// Repaso POO (Clases, Objetos, Colaboracion). Intro .NET/C# (Entorno, Framework, Clase, C#. Proyectos, Soluciones). 
	/// Repaso POO (Encapsulamiento, Herencia). Intro NET/C# (Tipos, Generalidades POO. Tipos de Proyectos). Proyectos de Test
	/// </summary>
	public class Unidad1Test

	{
		[Fact]
		public void unidad1_test1_deberia_crear_un_jugador()
		{
			var jugador1 = new Jugador(nombre: "Lionel", apellido: "Messi");

			Assert.Equal("Lionel", jugador1.Nombre);
			Assert.Equal("Messi", jugador1.Apellido);
			Assert.Equal("Lionel Messi", jugador1.NombreCompleto);

		}


		[Fact]
		public void unidad1_test2_deberia_crear_un_jugador_castearlo_en_persona()
		{
			var jugador1 = new Jugador(nombre: "Lionel", apellido: "Messi");

			var persona1 = (Persona)jugador1;

			Assert.Equal("Lionel", persona1.Nombre);
			Assert.Equal("Messi", persona1.Apellido);
			Assert.Equal("Lionel Messi", persona1.NombreCompleto);

		}

		[Fact]
		public void unidad1_test2_deberia_crear_un_jugador_castearlo_en_interfaz_inombrecompleto()
		{
			var jugador1 = new Jugador(nombre: "Lionel", apellido: "Messi");

			var personaConNombreCompleto = (INombreCompleto)jugador1;

			Assert.Equal("Lionel Messi", personaConNombreCompleto.NombreCompleto);

		}
	}
}