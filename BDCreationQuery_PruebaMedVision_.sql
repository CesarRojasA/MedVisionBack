 create database PruebaMedVisionDB
 use PruebaMedVisionDB

 create table persona(
  id_persona int identity,
  nombre varchar(30) not null,
  apellido varchar(30) not null,
  identificacion varchar(30) not null,
  edad int not null,
  PRIMARY KEY (id_persona)
);

 create table cita(
  id_cita int identity,
  id_persona int,
  titulo varchar(30) not null,
  fecha DateTime not null,
  descripcion varchar(100) not null,
  profesional_Encargado varchar(30) not null,
  PRIMARY KEY (id_cita),
  FOREIGN KEY (id_persona) REFERENCES persona(id_persona)
);
 create table motivoCita(
  id_motivoCita int identity,
  titulo varchar(30) not null,
  descripcion DateTime not null,
  PRIMARY KEY (id_motivoCita)
);
create table detalle_MotivoCita_Cita(
  id_motivoCita_Cita int identity,
  id_motivoCita int,
  id_cita int,
  PRIMARY KEY (id_motivoCita_Cita),
  FOREIGN KEY (id_motivoCita) REFERENCES motivoCita(id_motivoCita),
  FOREIGN KEY (id_cita) REFERENCES cita(id_cita)
)