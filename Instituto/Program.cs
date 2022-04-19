using Instituto.Controladores;
using System.Collections.Generic;
using System;
using Instituto.Entidades;

namespace Instituto
{
    class Program
    {
        private static string _opcion = string.Empty;

        static void Main(string[] args)
        {

            // string IdMateria = string.Empty;

            Console.WriteLine("Bienvenidos al Instituto!");
            GoToMenu();

            while (_opcion != "exit")
            {

                switch (_opcion)
                {
                    case "0":

                        GoToMenu();

                        break;
                    case "1":

                        Console.WriteLine(GetAlumnos());
                        _opcion = Console.ReadLine();

                        break;
                    case "2":

                        Console.WriteLine(GetMaterias());
                        _opcion = Console.ReadLine();

                        break;
                    case "3":
                        Console.WriteLine("Ingrese Id de Materia:");

                        _opcion = Console.ReadLine();
                        long id = long.Parse(_opcion);

                        Console.WriteLine($"Listado de Alumnos de la Materia: {id}");

                        Console.WriteLine(GetAlumnos(id));
                        _opcion = Console.ReadLine();

                        break;


                    case "4":
                        Console.WriteLine("Ingrese Id de Alumno:");

                        _opcion = Console.ReadLine();
                        long idAlumno = long.Parse(_opcion);

                        Console.WriteLine($"Listado de Materias del Alumno: {idAlumno}");

                        Console.WriteLine(GetMaterias(idAlumno));
                        _opcion = Console.ReadLine();

                        break;
                    case "5":
                        CreateAlumno();
                        break;
                    case "6":
                        InstitutoXMLController controller = new InstitutoXMLController();
                        controller.RemoveAlumno(89);
                        GoToMenu();
                        break;
                    default:

                        Console.Write("Opción inválida.");
                        _opcion = Console.ReadLine();

                        break;
                }

            }

            Environment.Exit(0);

        }

        public static void CreateAlumno()
        {
            InstitutoXMLController controller = new InstitutoXMLController();
            controller.CreateAlumno(new Alumno()
            {
                Id = 89,
                Nombre = "Prueba",
                FechaNacimiento = DateTime.Now
            });
            GoToMenu();
        }

        public static string GetAlumnos()
        {

            //InstitutoController controller = new InstitutoController();
            InstitutoXMLController controller = new InstitutoXMLController();

            var alumnos = controller.GetAlumnos();

            return PrintAlumnos(alumnos);
        }
        public static string GetAlumnos(long id)
        {

            // InstitutoController controller = new InstitutoController();
            InstitutoXMLController controller = new InstitutoXMLController();

            var alumnos = controller.GetAlumnos(id);

            return PrintAlumnos(alumnos);
        }


        private static string GetMaterias()
        {
            // InstitutoController controller = new InstitutoController();
            InstitutoXMLController controller = new InstitutoXMLController();

            var materias = controller.GetMaterias();
            string resultado = string.Empty;

            materias.ForEach(a =>
            {
                resultado += $"\n {a.ToString()}";
            });

            return resultado;
        }
        public static string GetMaterias(long idAlumno)
        {

            //InstitutoController controller = new InstitutoController();
            InstitutoXMLController controller = new InstitutoXMLController();

            var materias = controller.GetMaterias(idAlumno);

            return PrintMaterias(materias);
        }


        public static string PrintMaterias(List<Materia> materias)
        {
            string resultado = string.Empty;

            materias.ForEach(a =>
            {
                resultado += $"\n {a.ToString()}";
            });

            return resultado;
        }
        public static string PrintAlumnos(List<Alumno> alumnos)
        {
            string resultado = string.Empty;

            if (alumnos != null)
            {
                alumnos.ForEach(a =>
                {
                    resultado += $"\n {a.ToString()}";
                });
            }
            else
            {
                resultado = "No se encontraron alumnos.";
            }

            return resultado;
        }


        private static void GoToMenu()
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1 - Listado de Alumnos");
            Console.WriteLine("2 - Listado de Materias");
            Console.WriteLine("3 - Listado de Alumnos por Materia");
            Console.WriteLine("4 - Listado de Materias por Alumno");
            Console.WriteLine("5 - Nuevo Alumno");
            Console.WriteLine("6 - Remove Alumno");
            Console.WriteLine("");
            Console.WriteLine("Ingrese una opción:");
            _opcion = Console.ReadLine();
        }
    }
}
