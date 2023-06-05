﻿create database Concesionario_final

create table Concesionario
(
	NITC varchar(7),
	Nombre varchar(30) not null,
	Direccion varchar(50) not null,
	Telefono varchar(8) not null

	constraint PK_NITC primary key(NITC)
);

CREATE TABLE ServicioOf
(
	NITSO varchar(7),
	Nombre varchar(20) not null,
	Direccion varchar(50) not null,
	Telefono varchar(15) not null,
	NITC varchar(7) NOT NULL

	constraint PK_NITSO primary key(NITSO),
	constraint FK_NITC foreign key (NITC) references Concesionario
);

create table Equipamiento 
(
	CodEquipo char(7),
	Precio money,
	Descripcion varchar(100) not null
	
	constraint PK_Equip primary key(CodEquipo)
);
drop table Equipamiento
alter table Equipamiento
	add Equipamiento varchar(15) not null;

create table Vendedores
(
	CI char(7),
	Nombre varchar(20) not null,
	Direccion varchar(50) not null,
	Telefono varchar(15) not null,
	NITC varchar(7) default null,
	NITSO varchar(7) default null

	constraint PK_Vend primary key(CI),
	constraint FK_VendC foreign key(NITC) references Concesionario,
	constraint FK_VendSO foreign key(NITSO) references ServicioOf
);

create table Modelos
(
	CodModelo char(7),
	Precio money not null,
	Marca varchar(50) not null,
	Descripcion varchar(100) not null,
	
	constraint PK_Modelos primary key(CodModelo),
);

create table Automoviles
(
	NumChaciz varchar(7),
	Color varchar(15) not null,
	FechaFab date not null,
	CodModelo char(7) not null,
	NITC varchar(7) not null,
	Precio money not null,
	Descuento float default null,

	constraint PK_Automoviles primary key (NumChaciz),
	constraint FK_AUTCONC foreign key (NITC) references Concesionario,
	constraint FK_AutoModelo foreign key (CodModelo) references Modelos,
);

create table Auto_equipo
(
	CodEquipo char(7) not null,
	NumChaciz varchar(7) not null,
	NroSerie varchar(10) not null

	constraint PK_Incluye primary key (NroSerie, CodEquipo, NumChaciz)
	constraint FK_IncluyeEquipo foreign key(CodEquipo) references Equipamiento,
	constraint FK_InlcuyeAuto foreign key(NumChaciz) references Automoviles
);

create table Modelo_Equipo
(
	CodEquipo char(7) not null,
	CodModelo char(7) not null,
	Tipo varchar(20) default 'de fabrica'

	constraint PK_ME primary key (Tipo, CodEquipo, CodModelo),
	constraint FK_Equipo foreign key(CodEquipo) references Equipamiento,
	constraint FK_Modelo foreign key(CodModelo) references Modelos,
);

create table Venta
(
	NroVenta char(7),
	CI char(7) not null,
	NumChaciz varchar(7) not null,
	Precio money not null,
	ModoPago varchar(10) not null,
	FechaVenta date not null,
	FechaEntrega date not null,
	CodModelo char(7) default null,
	CIcli char(7) not null

	constraint PK_Venta primary key(NroVenta, NumChaciz),
	constraint FK_VentaChaciz foreign key(NumChaciz) references Automoviles,
	constraint FK_VentaVendedor foreign key(CI) references Vendedores,
	constraint FK_VentaModelo foreign key(CodModelo) references Modelos,
	constraint FK_VentaCli foreign key(CIcli) references Clientes,
);

create table Clientes
(
	CI char(7),
	Nombre varchar(20) not null,
	ApellidoPaterno varchar(20) not null,
	ApellidoMaterno varchar(20) not null,
	Direccion varchar(50) not null,
	Telefono varchar(8) not null

	constraint PK_Cli primary key(CI)
);

create table AutoExterno
(
	NumChacizExt varchar(7),
	Color varchar(15) not null,
	CodModelo char(7) not null,
	CI char(7) not null,
	constraint PK_AutoExt primary key(NumChacizExt),
	constraint FK_AutoCli foreign key (CI) references Clientes
);

create table Repuestos
(
	CodRepuesto varchar(7),
	Nombre varchar(20),
	Precio money not null

	constraint PK_rep primary key(CodRepuesto)
);

create table Mecanicos
(
	CIMecanico char(7),
	Nombre varchar(20),
	NITSO varchar(7) not null,

	constraint PK_Mec primary key (CIMecanico),
	constraint FK_SO foreign key(NITSO) references ServicioOf
);

create table RegistroTaller
(	
	CodReparacion char(7),
	FechaEntrada date not null,
	FechaSalida date not null,
	CI char(7) not null,
	NumChacizExt varchar(7) not null

	constraint PK_RT primary key(CodReparacion),
	constraint FK_RTC foreign key(CI) references Clientes,
	constraint FK_RTA foreign key(NumChacizExt) references AutoExterno,
);

create table RepuestoRegistro
(
	CodReparacion char(7) not null,
	CodRepuesto varchar(7)

	constraint FK_Reparacion foreign key(CodReparacion) references RegistroTaller,
	constraint FK_Repuesto foreign key(CodRepuesto) references Repuestos,
);

create table RepuestoMecanico
(
	CodReparacion char(7) not null,
	CIMecanico char(7) not null,

	constraint FK_RepMec foreign key(CodReparacion) references RegistroTaller,
	constraint FK_Mec foreign key(CIMecanico) references Mecanicos 
);

insert into Concesionario values('conce1', 'Imcruz', 'Av Cristobal de Mendoza', '76646049');
insert into Concesionario values('conce2', 'Nibol', 'Av Alemana', '78459678');
insert into Concesionario values('conce3', 'Bolivian Auto Motors', 'Av Banzer 5to anillo', '7789654');
insert into Concesionario values('conce4', 'Autopia', 'Av Beni', '70046898');
insert into Concesionario values('conce5', 'Creyland', 'Av Busch', '79988644');

insert into Clientes values('7787850', 'Maria Teresa', 'Cossio', 'Villena', 'Av Doble Via la Guardia 5to anillo', '78452032');
insert into Clientes values('6342758', 'Juan Diego', 'Chalup', 'Roca', 'Av Oviedo Barbery', '77789644');
insert into Clientes values('8964234', 'Nicolas', 'Alvarez', 'Ardaya', 'Av Uruguay', '78965423');
insert into Clientes values('7777777', 'Sheyla', 'Arce', 'Vallejos', 'Av Radial 26', '76896545');

insert into Equipamiento values('eq1', '500', 'airbag conductor', 'airbag');
insert into Equipamiento values('eq2', '1000', 'aire condicionado', 'aire');
insert into Equipamiento values('eq3', '700', 'pintura metalizada', 'pintura');

insert into ServicioOf values('servof1', 'Nibol1', 'Av La Salle', '33356894', 'conce2');
insert into ServicioOf values('servof2', 'Imcruz1', 'Av Doble Via la Guardia', '33389642', 'conce1');

alter table Modelos
	add Modelo varchar(15) not null;
insert into Modelos values('mod1', '85000', 'Audi', 'Derivado del Q7', 'Q8');
insert into Modelos values('mod2', '30400', 'BMW', 'BMW Serie1', 'Serie1');

insert into Mecanicos values('6529478', 'Fernando Vaca Hortiz', 'servof1'); 
insert into Mecanicos values('7865982', 'Jose Atanacio Villa', 'servof2'); 
insert into Mecanicos values('9867577', 'Sergio Diaz Lozano', 'servof1'); 
insert into Mecanicos values('8735987', 'Alberto Suarez Perez', 'servof2'); 
insert into Mecanicos values('5784623', 'Carlos Urioste Llano', 'servof1');

insert into Automoviles values('chaciz1', 'negro', '2022-12-12', 'mod1', 'conce3', '85700', '0.1');
insert into Automoviles values('chaciz2', 'rojo', '2023-02-14', 'mod2', 'conce5', '30400', null);
insert into Automoviles values('chaciz3', 'gris', '2023-03-08', 'mod1', 'conce4', '85000', null);
insert into Automoviles values('chaciz4', 'blanco', '2022-12-23', 'mod2', 'conce3', '30400', '0.05');
insert into Automoviles values('chaciz5', 'azul', '2023-04-27', 'mod2', 'conce5', '31000', '0.2');

select * from Equipamiento



