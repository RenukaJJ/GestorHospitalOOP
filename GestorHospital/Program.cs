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
8. Crear Cita
9. Salir");

            while (true)
            {
                int opt = ConvertStringInt("Indica la opcion del menu: ");

                switch (opt) 
                {
                    case 1:
                        Hospital.CrearAdmin();
                        break;
                    case 2:
                        Hospital.CrearMedico();
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
                        Hospital.CrearPaciente();
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
                        Hospital.CrearCita();
                        break;
                    case 9:
                        return;
                    default:
                        break;
                }
            }
        }

        public static int ConvertStringInt(string pregunta)
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
