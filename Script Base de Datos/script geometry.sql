CREATE TABLE Docente (
  IdDocente INTEGER NOT NULL,
  NombresDocente VARCHAR(80) NULL,
  ApellidosDocente VARCHAR(80) NULL,
  EmailDocente VARCHAR(60) NULL,
  ContrasenaDocente VARCHAR(25) NULL,
  Rango  INTEGER NULL,
  PRIMARY KEY(IdDocente)
);

CREATE TABLE Grado (
  IdGrado INTEGER  NOT NULL ,
  DocenteIdDocente INTEGER  NULL,
  NombreGrado VARCHAR(15) NULL,
  DescripcionGrado VARCHAR(150) NULL,
  PRIMARY KEY (IdGrado),
  FOREIGN KEY (DocenteIdDocente) REFERENCES Docente(IdDocente)
);

CREATE TABLE Estudiante (
  IdEstudiante INTEGER  NOT NULL ,
  GradoIdGrado INTEGER NOT NULL,
  NombresEstudiante VARCHAR(80) NULL,
  ApellidosEstudiante VARCHAR(80) NULL,
  EmailEstudiante VARCHAR(60) NULL,
  ContrasenaEstudiante VARCHAR(25) NULL,
  EstadoEstudiante boolean NULL,
   PRIMARY KEY (IdEstudiante),
   FOREIGN KEY (GradoIdGrado) REFERENCES  Grado(IdGrado)
);



CREATE TABLE Tema (
  IdTematica INTEGER NOT NULL,
  PeriodoIdPeriodo INTEGER  NOT NULL,
  TemaGradoIdGrado INTEGER  NOT NULL,
  NombreTematica VARCHAR(50) NULL,
  DescripcionTematicas VARCHAR(150) NULL,
  PRIMARY KEY(IdTematica),
  FOREIGN KEY (TemaGradoIdGrado) REFERENCES  Grado(idGrado)
);



CREATE TABLE EstudianteTema (
  EstudianteIdEstudiante INTEGER  NOT NULL,
  TemaIdTematica INTEGER NOT NULL,
  Nota DOUBLE NULL,
  PRIMARY KEY(EstudianteIdEstudiante, TemaIdTematica),
  FOREIGN KEY (EstudianteIdEstudiante) REFERENCES  Estudiante(IdEstudiante),
  FOREIGN KEY (TemaIdTematica) REFERENCES  Tema(IdTematica)
);











