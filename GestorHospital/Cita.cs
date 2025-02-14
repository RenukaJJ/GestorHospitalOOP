using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorHospital
{
    internal class Cita
    {
        //assigns year, month, day, hour, min, seconds
        //DateTime dt3 = new DateTime(2015, 12, 31, 5, 10, 20);

        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public DateTime Fecha { get; set; }


       
        public Cita(Paciente p, Medico m, DateTime f) 
        { 
            this.Paciente = p;
            this.Medico = m;
            this.Fecha = f;

            //añadir fecha al historial clinico del paciente
            p.AddCita(this);
        }
    }
}
