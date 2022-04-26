using Instituto.Controladores;
using Instituto.Entidades;
using Instituto.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto
{
    public class Application : IApplication
    {

        public ILogger Logger { get; set; }
        private readonly IAlumnoService alumnoService;
        private readonly IMateriaService materiaService;


        public Application(ILoggerFactory loggerFactory, IAlumnoService alumnoService, IMateriaService materiaService)
        {
            Logger = loggerFactory?.CreateLogger<Application>();
            Logger.LogInformation("Application created successfully.");

            this.alumnoService = alumnoService;
            this.materiaService = materiaService;
        }

        private static string _opcion = string.Empty;

        public void Inicio()
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
                        RemoveAlumno();
                        break;
                    case "7":
                        UpdateAlumno();
                        break;
                    default:

                        Console.Write("Opción inválida.");
                        _opcion = Console.ReadLine();

                        break;
                }

            }

            Environment.Exit(0);

        }

        public void CreateAlumno()
        {
            this.alumnoService.CreateAlumno(new Alumno()
            {
                Id = 89,
                Nombre = "Prueba",
                FechaNacimiento = DateTime.Now
            });
            GoToMenu();
        }

        public void RemoveAlumno()
        {
            this.alumnoService.RemoveAlumno(89);
            GoToMenu();
        }

        public void UpdateAlumno()
        {

            this.alumnoService.UpdateAlumno(new Alumno()
            {
                Id = 89,
                Nombre = "Prueba Modificacion",
                FechaNacimiento = DateTime.Parse("2022-01-01")
            });
            GoToMenu();
        }

        public string GetAlumnos()
        {

            var alumnos = alumnoService.GetAlumnos();

            return PrintAlumnos(alumnos);
        }
        public string GetAlumnos(long id)
        {

            var alumnos = alumnoService.GetAlumnos(id);

            return PrintAlumnos(alumnos);
        }


        private string GetMaterias()
        {

            var materias = materiaService.GetMaterias();
            string resultado = string.Empty;

            materias.ForEach(a =>
            {
                resultado += $"\n {a.ToString()}";
            });

            return resultado;
        }
        public string GetMaterias(long idAlumno)
        {

            var materias = materiaService.GetMaterias(idAlumno);

            return PrintMaterias(materias);
        }


        public string PrintMaterias(List<Materia> materias)
        {
            string resultado = string.Empty;

            materias.ForEach(a =>
            {
                resultado += $"\n {a.ToString()}";
            });

            return resultado;
        }
        public string PrintAlumnos(List<Alumno> alumnos)
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


        private void GoToMenu()
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1 - Listado de Alumnos");
            Console.WriteLine("2 - Listado de Materias");
            Console.WriteLine("3 - Listado de Alumnos por Materia");
            Console.WriteLine("4 - Listado de Materias por Alumno");
            Console.WriteLine("5 - Nuevo Alumno");
            Console.WriteLine("6 - Remove Alumno");
            Console.WriteLine("7 - Update Alumno");
            Console.WriteLine("");
            Console.WriteLine("Ingrese una opción:");
            _opcion = Console.ReadLine();
        }
    }




}

