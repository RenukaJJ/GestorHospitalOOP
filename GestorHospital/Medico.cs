using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorHospital
{
    internal class Medico : Persona
    {
        public string Especialidad { get; set; }
        public string NumColegiado { get; set; }
        public List<Paciente> Pacientes { get; set; }



        public Medico(string nombre, int edad, string dni, string especialidad, string numColegiado) : base(nombre,edad,dni)
        {
            Especialidad = especialidad;
            NumColegiado = numColegiado;
            Pacientes = new List<Paciente>();
        }

        public void AgregarPaciente(Paciente paciente)
        {
            Pacientes.Add(paciente);
        }

        public void EliminarPaciente(Paciente p)
        {
            Pacientes.Remove(p);
        }

        public override string ToString()
        {
            return $"MEDICO - {base.ToString()}, Especialidad: {Especialidad}, Nº Colegiado: {NumColegiado}, Pacientes: {Pacientes.Count}";
        }
    }
}
