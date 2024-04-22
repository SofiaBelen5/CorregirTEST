using Programacion3.Ejercicios.Entidades;
using Programacion3.Ejercicios.Entidades.Interfaces;

namespace Programacion3.Ejercicios.Tests
{
    /// <summary>
    /// Unidad 3
    /// C# Introduccion. Visual Studio y Visual Studio Code. Estructuras de control/Arreglos. Cadenas
    /// </summary>
    public class Unidad3Test

	{
		[Fact]
		public void unidad3_test1_array_debe_contener_5_elementos()
		{
            int[] array = new int[] {1, 2, 3, 4, 5 };

            Assert.Equal(5, array.Length);

        }

        [Fact]
        public void unidad3_test2_array_debe_contener_y_no_contener_elementos()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };

            Assert.Contains(3, array);
            Assert.Contains(5, array);
            Assert.DoesNotContain(6, array);
        }


        [Fact]
        public void unidad3_test3_array_string_completar_bucle_for()
        {
            string[] array = new string[5];

            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    array[0] = "Value " + (i + 1);
                }
                if (i > 0)
                {
                    array[i] = "Value " + (i * 10);
                }
            }

            Assert.Contains("Value 1", array);
            Assert.Contains("Value 10", array);
            Assert.Contains("Value 20", array);
            Assert.Contains("Value 30", array);
            Assert.DoesNotContain("Value 51", array);
        }


        [Fact]
        public void unidad3_test4_array_string_completar_con_while()
        {
            string[] array = new string[5];
            int i = 1;
            int value = 1;

            array[0] = "Value " + 1;
            while (i < 5)
            {
                array[i] = "Value " + (i * 10);
                i++;
            }



            Assert.Contains("Value 1", array);
            Assert.Contains("Value 10", array);
            Assert.Contains("Value 20", array);
            Assert.Contains("Value 30", array);
            Assert.DoesNotContain("Value 51", array);
        }

    }
}