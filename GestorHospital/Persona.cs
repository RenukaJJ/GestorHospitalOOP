using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorHospital
{
    internal class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string DNI { get; set; }

        public Persona(string nombre, int edad, string dNI)
        {
            Nombre = nombre;
            Edad = edad;
            DNI = dNI;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Edad: {Edad}, DNI: {DNI}";
        }
    }
}
