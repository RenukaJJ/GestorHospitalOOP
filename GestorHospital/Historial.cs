using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorHospital
{
    internal class Historial
    {
        public List<string> Diagnosticos { get; set; }
        public List<string> Tratamientos { get; set; }
        public List<Cita> Citas { get; set; }

        public Historial() 
        { 
            Diagnosticos = new List<string>();
            Tratamientos = new List<string>();
            Citas = new List<Cita>();
        }

        public void AddCita(Cita c)
        {
            Citas.Add(c);
        }
    }
}
