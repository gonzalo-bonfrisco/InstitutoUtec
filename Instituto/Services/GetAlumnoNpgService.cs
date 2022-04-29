using Instituto.Entidades;
using Instituto.Providers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto.Services
{
    public class GetAlumnoNpgService : IGetAlumnoService
    {
        private readonly INpgSqlProvider npgSqlProvider;

        public GetAlumnoNpgService(INpgSqlProvider npgSqlProvider)
        {
            this.npgSqlProvider = npgSqlProvider;
        }

        public List<Alumno> GetAlumnos()
        {
            using var connection = npgSqlProvider.GetConection();
            connection.Open();

            var sql = "SELECT * FROM alumnos";

            using var cmd = new NpgsqlCommand(sql, connection);

            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            var lstAlumno = new List<Alumno>();

            while (rdr.Read())
            {
                lstAlumno.Add(new Alumno()
                {
                    Id = rdr.GetInt64(0),
                    Nombre = rdr.GetString(1),
                    FechaNacimiento = rdr.GetDateTime(2)
                });
            }

            return lstAlumno;
        }

    }
}
