using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorHospital
{
    internal class Paciente : Persona
    {
        public Medico MedicoAsignado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Historial Historial { get; set; }

        public Paciente(string nombre, int edad, string dni, Medico medico) : base(nombre, edad, dni)
        {
            MedicoAsignado = medico;
            FechaIngreso = DateTime.Now;
            medico.AgregarPaciente(this);
            Historial = new Historial();
        }

        public override string ToString()
        {
            return $"PACIENTE - {base.ToString()}, Médico Asignado: {MedicoAsignado.Nombre}, Fecha Ingreso: {FechaIngreso.ToShortDateString()}";
        }

        public void AddCita(Cita c)
        {
            Historial.AddCita(c);
        }
    }
}
