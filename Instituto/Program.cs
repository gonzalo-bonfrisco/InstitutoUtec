using Instituto.Controladores;
using System;

namespace Instituto
{
    class Program
    {
        private static string _opcion = string.Empty;

        static void Main(string[] args)
        {

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
                    default:
                        Console.Write("Opción inválida.");
                        _opcion = Console.ReadLine();
                        break;
                }

            }

            Environment.Exit(0);

        }
        public static string GetAlumnos()
        {

            InstitutoController controller = new InstitutoController();

            var alumnos = controller.GetAlumnos();
            string resultado = string.Empty;

            alumnos.ForEach(a =>
            {
                resultado += $"\n {a.ToString()}";
            });

            return resultado;
        }
        private static string GetMaterias()
        {
            InstitutoController controller = new InstitutoController();

            var materias = controller.GetMaterias();
            string resultado = string.Empty;

            materias.ForEach(a =>
            {
                resultado += $"\n {a.ToString()}";
            });

            return resultado;
        }
        private static void GoToMenu()
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1 - Listado de Alumnos");
            Console.WriteLine("2 - Listado de Materias");
            Console.WriteLine("");
            Console.WriteLine("Ingrese una opción:");
            _opcion = Console.ReadLine();
        }
    }
}
