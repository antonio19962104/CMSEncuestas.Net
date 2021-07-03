--jamurillo
--carteldesanta5.7
create database CmsEncuestas;
use CmsEncuestas;
create table Estatus(
	IdEstatus int identity,
	Estatus varchar(50),
	primary key(IdEstatus)
);
create table TipoControl(
	IdTipoControl int identity,
	Nombre varchar(100),
	primary key(IdTipoControl)
);
create table TipoEncuesta(
	IdTipoEncuesta int identity,
	Nombre varchar(100),
	primary key(IdTipoEncuesta)
);
create table Administrador(
	IdAdministrador int identity,
	Nombre varchar(100),
	ApellidoPaterno varchar(100),
	ApellidoMaterno varchar(100),
	Username varchar(50),
	Password varchar(12),
	IdEstatus int,
	primary key(IdAdministrador),
	constraint FK_Administrador_Estatus foreign key (IdEstatus) references Estatus(IdEstatus)
);
create table Encuesta(
	IdEncuesta int identity,
	Nombre varchar(100),
	FechaInicio datetime,
	FechaFin datetime,
	Instrucciones varchar(500),
	Agradecimiento varchar(500),
	IdEstatus int,
	IdAdministrador int,
	IdTipoEncuesta int,
	primary key(IdEncuesta),
	constraint FK_Encuesta_Estatus foreign key (IdEstatus) references Estatus(IdEstatus),
	constraint FK_Encuesta_Administrador foreign key (IdAdministrador) references Administrador(IdAdministrador),
	constraint FK_Encuesta_TipoEncuesta foreign key (IdTipoEncuesta) references TipoEncuesta(IdTipoEncuesta)
);
create table Preguntas(
	IdPregunta int identity,
	Pregunta varchar(200),
	IdEncuesta int,
	IdEstatus int,
	IdTipoControl int,
	primary key(IdPregunta),
	constraint FK_Preguntas_Estatus foreign key (IdEstatus) references Estatus(IdEstatus),
	constraint FK_Preguntas_Encuesta foreign key (IdEncuesta) references Encuesta(IdEncuesta),
	constraint FK_Preguntas_TipoControl foreign key(IdTipoControl) references TipoControl(IdTipoControl)
);
create table Respuestas(
	IdRespuesta int identity,
	Respuesta varchar(500),
	IdPregunta int,
	IdEstatus int,
	primary key(IdRespuesta),
	constraint FK_Respuestas_Estatus foreign key (IdEstatus) references Estatus(IdEstatus),
	constraint FK_Respuestas_Pregunta foreign key (IdPregunta) references Preguntas(IdPregunta)
);
create table BaseDeDatos(
	IdBaseDeDatos int identity,
	IdEstatus int,
	IdAdministrador int,
	primary key(IdBaseDeDatos),
	constraint FK_BaseDeDatos_Estatus foreign key (IdEstatus) references Estatus(IdEstatus),
	constraint FK_BaseDeDatos_Administrador foreign key (IdAdministrador) references Administrador(IdAdministrador)
);
create table Usuario(
	IdUsuario int identity,
	Nombre varchar(100),
	ApellidoPaterno varchar(100),
	ApellidoMaterno varchar(100),
	FechaNacimiento date,
	FechaIngreso date,
	Sexo varchar(50),
	IdEstatus int,
	primary key(IdUsuario),
	constraint FK_Usuario_Estatus foreign key (IdEstatus) references Estatus(IdEstatus)
);
create table EstatusEncuesta(
	IdEstatusEncuesta int identity,
	EstatusEncuesta varchar(50)
);
alter table EstatusEncuesta add primary key (IdEstatusEncuesta)
create table Usuario_EstatusEncuesta(
	IdUsuario_EstatusEncuesta int identity,
	IdUsuario int,
	IdEncuesta int,
	IdEstatusEncuesta int,
	primary key(IdUsuario_EstatusEncuesta),
	constraint FK_Usuario_EstatusEncuesta_Usuario foreign key(IdUsuario) references Usuario(IdUsuario),
	constraint FK_Usuario_EstatusEncuesta_Encuesta foreign key(IdEncuesta) references Encuesta(IdEncuesta),
	constraint FK_Usuario_EstatusEncuesta_EstatusEncuesta foreign key(IdEstatusEncuesta) references EstatusEncuesta(IdEstatusEncuesta),
);
create table WorkSpace(
	IdWorkSpace int identity,
	Nombre varchar(100),
	Descripcion varchar(500),
	IdEstatus int,
	primary key(IdWorkSpace),
	constraint FK_Empresa_Estatus foreign key(IdEstatus) references Estatus(IdEstatus)
);
create table Administrador_WorkSpace(
	IdAdministrador_WorkSpace int identity,
	IdAdministrador int,
	IdWorkSpace int,
	IdEstatus int,
	primary key(IdAdministrador_WorkSpace),
	constraint FK_Administrador_WorkSpace_Administrador foreign key(IdAdministrador) references Administrador(IdAdministrador),
	constraint FK_Administrador_WorkSpace_WorkSpace foreign key(IdWorkSpace) references WorkSpace(IdWorkSpace),
	constraint FK_Administrador_WorkSpace_Estatus foreign key(IdEstatus) references Estatus(IdEstatus)
);
create table UsuarioRespuestas(
	IdusuarioRespuestas int identity,
	IdEncuesta int,
	IdUsuario int,
	IdPregunta int,
	IdRespuesta int,
	primary key(IdusuarioRespuestas),
	constraint FK_UsuarioRespuestas_Encuesta foreign key(IdEncuesta) references Encuesta(IdEncuesta),
	constraint FK_UsuarioRespuestas_Usuario foreign key(IdUsuario) references Usuario(IdUsuario),
	constraint FK_UsuarioRespuestas_Pregunta foreign key(IdPregunta) references Preguntas(IdPregunta),
	constraint FK_UsuarioRespuestas_Respuesta foreign key(IdRespuesta) references Respuestas(IdRespuesta)
);
--Plantillas
--Reportes