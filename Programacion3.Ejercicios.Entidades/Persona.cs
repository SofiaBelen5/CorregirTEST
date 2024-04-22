using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programacion3.Ejercicios.Entidades.Interfaces;

namespace Programacion3.Ejercicios.Entidades
{
    public abstract class Persona : INombreCompleto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        protected Persona(string Nombre, string Apellido)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
        }

        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}
