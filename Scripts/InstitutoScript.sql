

--DROP TABLE IF EXISTS Materias ;

CREATE TABLE alumnos (
    Id bigint PRIMARY KEY,
    Nombre VARCHAR(250),
	FechaNacimiento date
);

CREATE TABLE materias (
    Id bigint PRIMARY KEY,
    Nombre VARCHAR(250),
	Alumnos VARCHAR(250)
);