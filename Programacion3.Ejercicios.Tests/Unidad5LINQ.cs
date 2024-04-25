using Programacion3.Ejercicios.Entidades;
using Programacion3.Ejercicios.Entidades.Interfaces;
using System.Linq;

namespace Programacion3.Ejercicios.Tests
{
    /// <summary>
    /// Unidad 5
    /// 
    /// </summary>
    public class Unidad5LINQ

    {
        private object equipos;

        [Fact]
        public void unidad5_test1_numerospares_utilizacion_any()
        {
            var numeros = new List<int> { 1, 3, 5, 7, 9 };

            //Utilizar el metodo Any de LINQ para determinar si la lista contiene algún número par
         
            bool contieneNumerosPares = (from e in numeros where e % 2 == 0 select e).Any();
            Assert.False(contieneNumerosPares);

        }


        [Fact]
        public void unidad5_test2_numerosmaximo_utilizacion_max()
        {
            var numeros = new List<int> { 1, 3, 5, 7, 9, 37 };

            //Utilizar el metodo Max de LINQ
            int maximoNumero = (from e in numeros select e).Max();

            Assert.Equal(37, maximoNumero);

        }


        [Fact]
        public void unidad5_test3_contarpalabrasquecomiencenconletraa_utilizacion_startWith()
        {
            var palabras = new List<string> { "Manzana", "Banana", "Pera", "Anana" };

            // Utilizar el método Count de LINQ junto con StartsWith para contar las palabras que comienzan con "A"

            int cantidadPalabrasComienzanConA =( from e in palabras where e.StartsWith("A") select e).Count();
            Assert.Equal(1, cantidadPalabrasComienzanConA);

        }


        [Fact]
        public void unidad5_test4_obtenernumerosimpares_filtro_y_obtener_lista()
        {
            var numeros = new List<int> { 1, 2, 3, 4, 5 };

            // Se utiliza el método Where de LINQ para filtrar los números impares
            var numerosImpares = (from e in numeros where e % 2 != 0 select e).ToList();

            Assert.Equal(new List<int> { 1, 3, 5 }, numerosImpares);

        }


        [Fact]
        public void unidad5_test5_preguntasitodaslaspalabrasterminancona_utilizacion_all()
        {
            var palabras = new List<string> { "Manzana", "Banana", "Pera", "Anana" };
            bool todasTerminanConA = (from e in palabras where e.EndsWith("a") select e).All(palabra => palabra.EndsWith("a"));
            Assert.True(todasTerminanConA);

        }


        [Fact]
        public void unidad5_test6_sumarl()
        {
            var numeros = new List<int> { 1, 2, 3, 4, 5 };

            //utilizar LINQ para sumar todos los números de la lista
            var suma = (from e in numeros select e).Sum(); 
            Assert.Equal(15, suma);
        }


        [Fact]
        public void unidad5_test7_obtenerlapalabramaslarga()
        {
            var palabras = new List<string> { "Kiwi", "Manzana", "Banana", "Pera", "Anana" };


            ////(NOTA: string tiene una propiedad Length para comparar, TIP. Se puede ordenar descendentemente)
            // Utilizar LINQ para obtener la palabra más larga
            var palabraMasLarga = (from e in palabras
                                   orderby e.Length descending
                                   select e).First();

            Assert.Equal("Manzana", palabraMasLarga);

        }


        [Fact]
        public void unidad5_test8_ordenarlistaalfabeticamente()
        {

            var letras = new List<string> { "z", "a", "d", "c" };

            //Utilizar LINQ para ordenar la lista alfabéticamente

            //var letrasOrdenadas = letras.OrderBy(x => x).ToList();

            var letrasOrdenadas = from l in letras
                                  orderby l
                                  select l;


            Assert.Equal(new List<string> { "a", "c", "d", "z" }, letrasOrdenadas);
        }


        //       [Fact]
        //       public void unidad5_test9_ordenarlistaalfabeticamente()
        //       {

        //           var letras = new List<string> { "z", "a", "d", "c" };

        //           //Utilizar LINQ para ordenar la lista alfabéticamente
        //           var letrasOrdenadas =


        //           Assert.Equal(new List<string> { "a", "c", "d", "z" }, letrasOrdenadas);
        //       }



        [Fact]
        public void unidad5_test8_equipos()
        {
            var equipos = GenerarEquipos();


            //Obtener los nombres de equipos con el jugador con el nombre "J 1"
            var equiposConJ1 = from e in equipos
                               where e.Jugadores.Any(x => x.Nombre == "J 1")
                               select e.Nombre;

            Assert.Equal(new List<string> { "Equipo 1" }, equiposConJ1);
        }


        [Fact]
        public void unidad5_test9_golestotales()
        {
            var equipos = GenerarEquipos();


            //Obtener la cantidad de goles totales realizados

            //Version 1
            var demo1 = equipos.Sum(x => x.Jugadores.Sum(j => j.Goles));


            //Version 2
            var golesTotales = (from e in equipos
                                select e.Jugadores.Sum(x => x.Goles)).Sum();


            //Version 3
            var demo2_parte1 = from e in equipos
                               select e.Jugadores.Sum(x => x.Goles);

            var demo2_parte2 = demo2_parte1.Sum();



            Assert.Equal(22, demo1);
            Assert.Equal(22, golesTotales);
        }


        private List<Equipo> GenerarEquipos()
        {


            var equipos = new List<Equipo> {
                        new Equipo() { Nombre = "Equipo 1", Ranking = 3 },
                        new Equipo() { Nombre = "Equipo 2",  Ranking = 1},
                        new Equipo() { Nombre = "Equipo 3",  Ranking = 2},
            };

            var jugadoresEquipo1 = new List<Jugador> {
                        new Jugador("J 1", "A 1"){
                            Goles  = 3
                        },
                        new Jugador("J 2", "A 2"){
                            Goles = 2
                        }
            };

            var jugadoresEquipo2 = new List<Jugador> {
                        new Jugador("J 1 E2", "A 1 E2"){
                            Goles  = 4
                        },
                        new Jugador("J 2 E2", "A 2 E2"){
                            Goles = 0
                        }
            };

            var jugadoresEquipo3 = new List<Jugador> {
                        new Jugador("J 1 E3", "A 1 E3"){
                            Goles  = 4
                        },
                        new Jugador("J 2 E3", "A 2 E3"){
                            Goles = 0
                        },
                        new Jugador("J 3 E3", "A 3 E3"){
                            Goles = 8
                        },
                        new Jugador("Juan de los Palotes", "A 3 E3"){
                            Goles = 1
                        }
            };

            //equipos[0].Jugadores = jugadoresEquipo1;
            equipos[0].Jugadores.AddRange(jugadoresEquipo1);
            equipos[1].Jugadores.AddRange(jugadoresEquipo2);
            equipos[2].Jugadores.AddRange(jugadoresEquipo3);

            return equipos;
        }


        //10: Cuantos jugadores tiene el equipo que esta segundo en el ranking >> 2 jugadores

        //11: Cual es el Ranking del equipo con mas jugadores >> 2do ranking
        //12: Cual es el promedio de goles de jugadores que parte del nombre sea "J 1"

        //13: Cual de los equipos posee el nombre de jugador mas largo
        [Fact]
        public void unidad5_test10_jugadoresEquipoSegundoRanking()
        {
            var equipos = GenerarEquipos();

            // Obtener el equipo que está segundo en el ranking
            var equipoSegundoRanking = (from e in equipos
                                        orderby e.Ranking
                                        select e).Skip(1).FirstOrDefault();

            // Verificar que tiene 2 jugadores
            Assert.Equal(4, equipoSegundoRanking.Jugadores.Count);
        }

        [Fact]
        public void unidad5_test11_rankingEquipoMasJugadores()
        {
            var equipos = GenerarEquipos();

            // Obtener el ranking del equipo con más jugadores
            var rankingEquipoMasJugadores = (from e in equipos
                                             orderby e.Jugadores.Count descending
                                             select e).FirstOrDefault().Ranking;

            // Verificar que es el segundo ranking
            Assert.Equal(2, rankingEquipoMasJugadores);
        }

        [Fact]
        public void unidad5_test12_promedioGolesJugadoresNombreJ1()
        {
            var equipos = GenerarEquipos();

            // Calcular el promedio de goles de jugadores cuyo nombre comience con "J 1"
            var promedioGolesJ1 = (from e in equipos
                                   from j in e.Jugadores
                                   where j.Nombre.StartsWith("J 1")
                                   select j.Goles).Average();

            // Verificar que el promedio es 3.5
            Assert.Equal(3.6666666666666665, promedioGolesJ1);
        }

        [Fact]
        public void unidad5_test13_equipoNombreJugadorMasLargo()
        {
            var equipos = GenerarEquipos();

            // Obtener el nombre del equipo que tiene el jugador con el nombre más largo
            var equipoNombreJugadorMasLargo = (from e in equipos
                                               orderby e.Jugadores.Max(j => j.Nombre.Length) descending
                                               select e).FirstOrDefault().Nombre;

            // Verificar que es "Equipo 3"
            Assert.Equal("Equipo 3", equipoNombreJugadorMasLargo);
        }



    }
}
//10: Cuantos jugadores tiene el equipo que esta segundo en el ranking >> 2 jugadores
/*[Fact]
public void unidad5_test10_jugadoresEquipoSegundo()
{
    var equipos = GenerarEquipos();

    IEnumerable<int> jugadores =
        from e in equipos
        where e.Ranking == 2
        select e.Jugadores.Count;

    Assert.Equal(4, jugadores.Sum());
}

//11: Cual es el Ranking del equipo con mas jugadores >> 2do ranking

[Fact]
public void unidad5_test11_EquipoConMasJugadores_Ranking()
{
    var equipos = GenerarEquipos();
    IEnumerable<int> jugadores =
       from e in equipos
       orderby e.Jugadores.Count descending
       select e.Ranking;


    // Encontramos el equipo con más jugadores y obtenemos su ranking
    var rankingEquipoMasJugadores =
        (from e in equipos
         orderby e.Jugadores.Count descending
         select e.Ranking)
        .First();

    Assert.Equal(2, rankingEquipoMasJugadores);
    Assert.Equal(2, jugadores.First());// Esperamos que tenga el segundo ranking
}

//12: Cual es el promedio de goles de jugadores que parte del nombre sea "J 1"
[Fact]
public void unidad5_test12_PromedioGoles_JugadoresNombreJ1()
{
    var equipos = GenerarEquipos();

    IEnumerable<int> jugadores =
        from e in equipos
        from jugador in e.Jugadores
        where jugador.Nombre.StartsWith("J 1")
        select jugador.Goles;



    Assert.Equal(3.6666666666666665, jugadores.Average());

}




//13: Cual de los equipos posee el nombre de jugador mas largo

[Fact]
public void unidad5_test13_EquipoNombreMasLargo()
{
    var equipos = GenerarEquipos();

    IEnumerable<int> jugadores =
        from e in equipos
        from jugador in e.Jugadores
        select jugador.Nombre.Length;
    // Encontramos el nombre de jugador más largo entre todos los equipos
    var nombreMasLargo = jugadores.Max();


    IEnumerable<String> jugadoresEquipo =
      from e in equipos
      from jugador in e.Jugadores
      where jugador.Nombre.Length == nombreMasLargo
      select e.Nombre;

    // Buscamos el equipo que tenga un jugador con ese nombre más largo
    var equipoNombreMasLargo = jugadoresEquipo.First();


    Assert.Equal("Equipo 3", equipoNombreMasLargo); // Esperamos que sea el Equipo 3
}*/