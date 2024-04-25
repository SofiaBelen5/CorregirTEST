using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion3.Ejercicios.Entidades
{
    public class Equipo
    {
        public string Nombre { get; set; }
        public int Ranking { get; set; }
        public List<Jugador> Jugadores { get; set; } //= new List<Jugador>();

        public Equipo()
        {
            Jugadores = new List<Jugador>();
        }
    }
}