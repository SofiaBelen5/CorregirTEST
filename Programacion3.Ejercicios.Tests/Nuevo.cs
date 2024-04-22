using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion3.Ejercicios.Tests
{
   public class Nuevo
    {
        [Fact]
        public void DebeSerHoy()
        {


            var fechaHoy = new DateTime(2024, 4, 21);
            var hoy = DateTime.Now.Date;


            Assert.Equal(fechaHoy, hoy);

        }

        [Fact]
        public void DeberiaDarMiEdadEnAnios()
        {


            var fechaNacimiento = new DateTime(2001, 03, 21);
            var hoy = DateTime.Now;

            //guardo el intervalo de tiempo entre una fecha y la otra
            TimeSpan diferenciaDias = hoy - fechaNacimiento;

            //convierto en dias unicamente
            int dias = diferenciaDias.Days;

            //convierto en anios y lo comparo con mi edad actual
            int anios = dias / 365;
            Assert.Equal(23, anios);

        }
        [Fact]
        public void DeberiaMostrarIgual()
        {

            var f1 = new DateTime(2012, 8, 20, 17, 52, 0, 0);
            //"ddd" = abreviatura 'lun'
            //"dd" = 20
            //"yyyy" = 2012
            //"HH" = 17
            //"mm" = 52
            //"MMMM"=Agosto
            Assert.Equal("lun. 20 de agosto de 2012 a las 17:52", f1.ToString("ddd dd 'de' MMMM 'de' yyyy 'a las' HH:mm"));

        }
        [Fact]
        public void Test4_DateTime_Formatting()
        {


            var finalWorldCupMatch = new DateTime(2022, 12, 18, 15, 30, 23);


            Assert.Equal("18/12/22 15:30:23", finalWorldCupMatch.ToString("dd/MM/yy HH:mm:ss"));
            Assert.Equal("18/12/22 03:30 p. m.", finalWorldCupMatch.ToString("dd/MM/yy hh:mm tt"));
            Assert.Equal("18 de diciembre de 2022", finalWorldCupMatch.ToString("dd 'de' MMMM 'de' yyyy"));


        }
        [Fact]
        public void Test5_DateTime_Days()
        {


            var finalWorldCupMatch = new DateTime(2022, 12, 18, 15, 30, 23);
            var today = new DateTime(2023, 5, 9, 15, 00, 00);

            int Dias = 141;
            var result = $"{Dias} Días totales desde la final del mundo";

            Assert.Equal("141 Días totales desde la final del mundo", result);

        }
    }
}
