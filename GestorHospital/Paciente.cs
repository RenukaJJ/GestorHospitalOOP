using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorHospital
{
    internal class Paciente : Persona
    {
        public string HistoriaClinica { get; set; }
        public Medico MedicoAsignado { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Paciente(string nombre, int edad, string dni, string historial, Medico medico) : base(nombre, edad, dni)
        {
            HistoriaClinica = historial;
            MedicoAsignado = medico;
            FechaIngreso = DateTime.Now;           
        }

        public override string ToString()
        {
            return $"PACIENTE - {base.ToString()}, Historia Clínica: {HistoriaClinica}, Médico Asignado: {MedicoAsignado.Nombre}, Fecha Ingreso: {FechaIngreso.ToShortDateString()}";
        }
    }
}
