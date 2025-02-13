using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorHospital
{
    internal class Hospital
    {
        public List<Persona> Personas { get; set; }
        

        public Hospital()
        {
            Personas = new List<Persona>();
        }

        public void AddPersona(Persona persona)
        {
            Persona p = Personas.Find(r => r.DNI == persona.DNI);
            if (p != null)
                Personas.Add(persona);
            else
                Console.WriteLine("este dni ya existe");
        }

        public void AddPaciente(Persona p, string histo, string dniMed)
        {
            Medico med = (Medico)Personas.Find(r => r.DNI == dniMed);
            if (med == null)
            {
                Console.WriteLine("NO SE ENCONTRO MEDICO");
                return;
            }
            else
            {
                Paciente paciente = new Paciente(p.Nombre, p.Edad, p.DNI, histo, med);
                Personas.Add(paciente);
                med.AgregarPaciente(paciente);
            }
        }

        public void ListarMedicos()
        {
            foreach (var medico in Personas)
            {
                if (medico is Medico)
                    Console.WriteLine(medico.ToString());
            }
        }

        public void ListarPacientesDeMedico(string dniMedico)
        {
            Medico medico = (Medico)(Personas.Find(m => m.DNI == dniMedico));
            if (medico != null)
            {
                foreach (var paciente in medico.Pacientes)
                {
                    Console.WriteLine(paciente.ToString());
                }
            }
        }

        public void EliminarPaciente(string dniPaciente)
        {
            Paciente paciente = (Paciente)(Personas.Find(m => m.DNI == dniPaciente));
            if (paciente == null)
            {
                Console.WriteLine("NO SE ENCONTRO MEDICO");
                return;
            }
            else
            {
                //borra de la lsita de pacientes del medico
                Medico m = paciente.MedicoAsignado;
                m.EliminarPaciente(paciente);

                //elimina de la lista de personas del hospital
                Personas.Remove(paciente);
            }
        }

        public void ListarPersonas()
        {
            foreach (Persona persona in Personas)
            {
                Console.WriteLine(persona.ToString());
            }
            
        }
    }

}
