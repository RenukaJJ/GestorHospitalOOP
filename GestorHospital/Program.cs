using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorHospital
{
    internal class Program
    {
        static Hospital Hospital = new Hospital();
        static void Main(string[] args)
        {
            Menu();
                        
        }

        static void Menu()
        {
            Console.WriteLine(@"Opciones menu:
1. Crear personal administrativo
2. Alta medico
3. Mostrar medicos
4. Mostrar pacientes de un medico
5. Alta paciente
6. Baja paciente
7. Lista todas las personas
8. Salir");

            while (true)
            {
                int opt = ConvertStringInt("Indica la opcion del menu: ");

                switch (opt) 
                {
                    case 1:
                        CrearAdmin();
                        break;
                    case 2:
                        CrearMedico();
                        break;
                    case 3:
                        Hospital.ListarMedicos();
                        break;
                    case 4:
                        Console.WriteLine("Indica DNI del medico: ");
                        string dniMedico = Console.ReadLine();
                        Hospital.ListarPacientesDeMedico(dniMedico);
                        break;
                    case 5:
                        CrearPaciente();
                        break;
                    case 6:
                        Console.WriteLine("Indica DNI del paciente a borrar: ");
                        string dniPaciente = Console.ReadLine();
                        Hospital.EliminarPaciente(dniPaciente);
                        break;
                    case 7:
                        Hospital.ListarPersonas();
                        break;
                    case 8:
                        return;
                        break;
                    case 9:
                        break;
                    default:
                        break;
                }
            }
        }

        static void CrearAdmin()
        {
            Persona p = CrearPersona();
            Console.WriteLine("Departamento: ");
            string departa = Console.ReadLine();
            Console.WriteLine("Puesto: ");
            string puesto = Console.ReadLine();
            Administrativo admin = new Administrativo(p.Nombre, p.Edad, p.DNI, departa, puesto);
            Hospital.AddPersona(admin);
        }

        static void CrearMedico()
        {
            Persona p = CrearPersona();
            Console.WriteLine("Especialidad: ");
            string espe = Console.ReadLine();
            Console.WriteLine("Numero de Colegiado: ");
            string numCole = Console.ReadLine();
            Medico med = new Medico(p.Nombre, p.Edad, p.DNI, espe, numCole);
            Hospital.AddPersona(med);
        }

        static void CrearPaciente()
        {
            Persona p = CrearPersona();
            Console.WriteLine("Historial clinico: ");
            string histo = Console.ReadLine();

            //selecciona medico
            Console.WriteLine("Selecciona el medico de la siguiente lista: ");
            Hospital.ListarMedicos();
            Console.WriteLine("Especifica DNI del medico: ");
            string dniMed = Console.ReadLine();

            Hospital.AddPaciente(p, histo, dniMed);
        }

        static Persona CrearPersona()
        {
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine();
            int edad = ConvertStringInt("Edad: ");
            Console.WriteLine("DNI:");
            string dni = Console.ReadLine();
            return new Persona(nombre, edad, dni);
        }

        static int ConvertStringInt(string pregunta) 
        {
            while (true)
            {
                Console.Write(pregunta);
                if (!int.TryParse(Console.ReadLine(), out int number))
                    Console.WriteLine("Convertion failed. Introduce un numero valido.");
                else
                    return number;
            }
        }
    }
}
