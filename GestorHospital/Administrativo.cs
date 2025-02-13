using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GestorHospital
{
    internal class Administrativo : Persona
    {
        public string Departamento { get; set; }
        public string Puesto { get; set; }

        public Administrativo(string nombre, int edad, string dni, string departamento, string puesto) : base(nombre, edad, dni)
        {
            Departamento = departamento;
            Puesto = puesto;
        }

        public override string ToString()
        {
            return $"ADMINISTRATIVO - {base.ToString()}, Departamento: {Departamento}, Puesto: {Puesto}";
        }
    }
}
