create database Concesionario_final

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
	Equipamiento varchar(15) not null,
	Descripcion varchar(100) not null
	
	constraint PK_Equip primary key(CodEquipo, Precio)
);

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

create table Modelo_Equipo
(
	CodEquipo char(7) not null,
	CodModelo char(7) not null,
	Tipo varchar(20) default 'de fabrica', 
	Precio money not null,

	constraint PK_ME primary key (Tipo, CodEquipo, CodModelo, Precio),
	constraint FK_Equipo foreign key(CodEquipo, Precio) references Equipamiento,
	constraint FK_Modelo foreign key(CodModelo) references Modelos,
);

create table Automoviles
(
	NumChaciz varchar(7),
	Color varchar(15) not null,
	FechaFab date not null,
	CodModelo char(7) not null,
	NITC varchar(7) not null,
	Precio money not null, --precio modelo + precio equipamiento
	Descuento float default null,

	constraint PK_Automoviles primary key (NumChaciz),
	constraint FK_AUTCONC foreign key (NITC) references Concesionario,
	constraint FK_AutoModelo foreign key (CodModelo) references Modelos,
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

create table AutoExterno
(
	NumChacizExt varchar(7),
	Color varchar(15) not null,
	Modelo varchar(20) not null,
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

create table ReparacionMecanico
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

insert into Equipamiento values('eq1', '500','airbag' , 'airbag conductor');
insert into Equipamiento values('eq2', '1000', 'aire', 'aire condicionado');
insert into Equipamiento values('eq3', '700', 'pintura', 'pintura metalizada');

select * from Equipamiento

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

insert into AutoExterno values('cext1', 'gris', '7787850', 'pathfinder');
insert into AutoExterno values('cext2', 'blanco', '6342758', 'grand vitara');
insert into AutoExterno values('cext3', 'gris', '8964234', 'kicks');

insert into Repuestos values('Rep1', 'Retrovisor', '200');
insert into Repuestos values('Rep2', 'Freno ABS', '1600');
insert into Repuestos values('Rep3', 'Suspencion', '275');
insert into Repuestos values('Rep4', 'Freno de disco', '75000');
insert into Repuestos values('Rep5', 'Parabrisas', '5000');

insert into Vendedores values('3257632', 'Teresa Villena', 'Av Doble Via la Guardia 5to anillo', '69236886', 'conce3', default);
insert into Vendedores values('2633532', 'Carlos Cossio', 'Av Doble Via la Guardia 5to anillo', '77614146', 'conce5', default);
insert into Vendedores values('3257633', 'Jorge Villena', 'Av La Barranca', '78965321', default, 'servof1');
insert into Vendedores values('7787851', 'Carlos Daniel Cossio', 'Av Las Americas', '78560967', default, 'servof2');
insert into Vendedores values('8697459', 'Jose Daniel Anez', 'Av Beni', '78135172',  'conce1', default );
insert into Vendedores values('7795642', 'Valentina Suarez', 'Av Pirai', '76361763',  'conce2', default );

insert into Venta values('venta1', '3257632', 'chaciz3', '85000', 'efectivo', '2023-05-01', '2023-05-28', 'mod1', '7787850');
insert into Venta values('venta2', '2633532', 'chaciz5', '31000', 'cuotas', '2023-02-14', '2023-02-28', 'mod2', '7777777');
insert into Venta values('venta3', '7787851', 'chaciz4', '30400', 'transf', '2022-12-25', '2023-01-14', 'mod2', '6342758');
insert into Venta values('venta4', '3257633', 'chaciz2', '85000', 'efectivo', '2023-05-15', '2023-05-31', 'mod2', '8964234');

insert into Modelo_Equipo values('eq1', 'mod1', default, '500');
insert into Modelo_Equipo values('eq2', 'mod1', 'Extra', '1000');
insert into Modelo_Equipo values('eq3', 'mod1', default, '700');
insert into Modelo_Equipo values('eq1', 'mod2', default, '500');
insert into Modelo_Equipo values('eq2', 'mod2', default, '1000');
insert into Modelo_Equipo values('eq3', 'mod2', 'Extra', '700');

insert into RegistroTaller values('Repar1', '2023-01-10', '2023-01-20', '7787850', 'cext1');
insert into RegistroTaller values('Repar2', '2023-02-18', '2023-02-25', '6342758', 'cext2');
insert into RegistroTaller values('Repar3', '2023-02-15', '2023-03-07', '8964234', 'cext3');
insert into RegistroTaller values('Repar4', '2023-05-20', '2023-05-31', '6342758', 'cext2');

select * from RegistroTaller
select * from Venta
select * from Modelo_Equipo
select * from Equipamiento
select * from AutoExterno
select * from Modelos

create procedure InsercionAutos
	@AColor varchar(15),
	@AFechaFab date,
	@ACodModelo char(7),
	@ANITC varchar(7),
	@ADescuento float
	AS
BEGIN
	declare @ANumChaciz varchar(7);
	declare @contchaciz int; SELECT @contchaciz = COUNT(*) FROM Automoviles; set @contchaciz=@contchaciz+1;
	set @ANumChaciz = 'chaciz'+CONVERT(varchar(3), @contchaciz);
	
	declare @APrecio money; select @APrecio = Precio from Modelos where CodModelo = @ACodModelo;
	declare @PrecioEquipo money; select @PrecioEquipo = Precio from Modelo_Equipo where CodModelo = @ACodModelo;
	set @APrecio = @APrecio + @PrecioEquipo;

	INSERT INTO Automoviles(NumChaciz, Color, FechaFab, CodModelo, NITC, Precio, Descuento)
	values(@ANumChaciz, @AColor, @AFechaFab, @ACodModelo, @ANITC, @APrecio, @ADescuento)
END

drop procedure InsercionAutos;

EXEC InsercionAutos
@AColor = 'blanco',
@AFechaFab =  '2023-06-02',
@ACodModelo = 'mod1',
@ANITC = 'conce5',
@ADescuento = 0.05;

select * from Automoviles

create procedure InsercionVentas
	@PCI char(7),
	@PNumChaciz varchar(7),
	@PModoPago varchar(10),
	@PFechaEntrega date,
	@PCodModelo char(7),
	@PCIcli char(7)
	AS
BEGIN
	declare @PVenta varchar(8);
	declare @contventa int; SELECT @contventa = COUNT(*) FROM Venta; set @contventa=@contventa+1;
	set @PVenta = 'venta'+CONVERT(varchar(3), @contventa);

	declare @PPrecio money; SELECT @PPrecio = Precio from Automoviles where NumChaciz = @PNumChaciz;
	declare @PDescuento float; select @PDescuento = Descuento from Automoviles where NumChaciz = @PNumChaciz;
	set @PDescuento =  @PDescuento*@PPrecio;
	set @PPrecio = @PPrecio - @PDescuento;

	declare @PFechaVenta date;
	set @PFechaVenta = GETDATE();

	INSERT INTO Venta (NroVenta, CI, NumChaciz, Precio, ModoPago, FechaVenta, FechaEntrega, CodModelo, CIcli)
	VALUES (@PVenta, @PCI, @PNumChaciz, @PPrecio, @PModoPago, @PFechaVenta, @PFechaEntrega, @PCodModelo, @PCIcli);
END

drop procedure InsercionVentas;

EXEC InsercionVentas
@PNumChaciz = 'chaciz6',
@PCI = '2633532',
@PModoPago = 'efectivo',
@PFechaEntrega = '2023-06-25',
@PCodModelo = 'mod2',
@PCIcli = '7787850';

select * from Venta;