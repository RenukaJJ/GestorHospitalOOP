using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
            if (p == null)
                Personas.Add(persona);
            else
                Console.WriteLine("Este dni ya existe");
        }
        
        public void AddPaciente(Persona p, string histo, string dniMed)
        {
            if (Personas.Find(r => r.DNI == p.DNI) == null)
            {
                Medico med = (Medico)Personas.Find(r => r.DNI == dniMed);
                if (med == null)
                {
                    Console.WriteLine("NO SE ENCONTRO MEDICO");
                    return;
                }
                else
                {
                    Paciente paciente = new Paciente(p.Nombre, p.Edad, p.DNI, med);
                    Personas.Add(paciente);
                }
            }
            else
                Console.WriteLine("Este dni ya existe");
        }

        public bool ListarPacientesDeMedico(string dniMedico)
        {
            Medico medico = (Medico)(Personas.Find(m => m.DNI == dniMedico));
            if (medico != null)
            {
                foreach (var paciente in medico.Pacientes)
                    Console.WriteLine(paciente.ToString());
                return true;
            }
            return false;
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
                Console.WriteLine(persona.ToString());            
        }

        public void CrearAdmin()
        {
            Persona p = CrearPersona();
            Console.WriteLine("Departamento: ");
            string departa = Console.ReadLine();
            Console.WriteLine("Puesto: ");
            string puesto = Console.ReadLine();
            Administrativo admin = new Administrativo(p.Nombre, p.Edad, p.DNI, departa, puesto);
            AddPersona(admin);
        }

        public void CrearMedico()
        {
            Persona p = CrearPersona();
            Console.WriteLine("Especialidad: ");
            string espe = Console.ReadLine();
            Console.WriteLine("Numero de Colegiado: ");
            string numCole = Console.ReadLine();
            Medico med = new Medico(p.Nombre, p.Edad, p.DNI, espe, numCole);
            AddPersona(med);
        }

        public void CrearPaciente()
        {
            Persona p = CrearPersona();
            Console.WriteLine("Historial clinico: ");
            string histo = Console.ReadLine();

            //selecciona medico
            Console.WriteLine("Selecciona el medico de la siguiente lista: ");
            ListarMedicos();
            Console.WriteLine("Especifica DNI del medico: ");
            string dniMed = Console.ReadLine();

            AddPaciente(p, histo, dniMed);
        }

        public Persona CrearPersona()
        {
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine();
            int edad = Program.ConvertStringInt("Edad: ");
            Console.WriteLine("DNI:");
            string dni = Console.ReadLine();
            return new Persona(nombre, edad, dni);
        }

        public void ListarMedicos()
        {
            Console.WriteLine("Lista de medicos:");
            foreach (var medico in Personas)
            {
                if (medico is Medico)
                    Console.WriteLine(medico.ToString());
            }
        }

        public void CrearCita()
        {
            Console.WriteLine("Vamos a crear una cita nueva");
            ListarMedicos();
            Console.WriteLine("Introduce el DNI del medico");
            string dniMed = Console.ReadLine();
            Medico med = (Medico)Personas.Find(r => r.DNI == dniMed);
            if (ListarPacientesDeMedico(dniMed))
            {
                Console.WriteLine("Indica el dni del paciente: ");
                string dniPaci = Console.ReadLine();
                Paciente p = (Paciente)Personas.Find(r => r.DNI == dniPaci);
                if (p != null)
                {
                    int year = Program.ConvertStringInt("Indica el año de la fecha");


                }
            }
        }
    }

}
