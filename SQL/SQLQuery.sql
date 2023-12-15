CREATE TABLE Cliente
(
  DNI VARCHAR(8) NOT NULL,
  Nombre VARCHAR(40) NOT NULL,
  Apellido VARCHAR(40) NOT NULL,
  Telefono VARCHAR(12) NOT NULL,
  PRIMARY KEY (DNI)
);

CREATE TABLE TipoSuscrip
(
  CodTipo VARCHAR(3) NOT NULL,
  Tipo VARCHAR(20) NOT NULL,
  Descripcion VARCHAR(200) NOT NULL,
  precio FLOAT NOT NULL,
  PRIMARY KEY (CodTipo)
);

CREATE TABLE Suscripcion
(
  Estado VARCHAR(20) NOT NULL,
  FecIni DATETIME NOT NULL,
  Fecfin DATETIME NOT NULL,
  DNI VARCHAR(8) NOT NULL,
  CodTipo VARCHAR(3) NOT NULL,
  PRIMARY KEY (DNI, CodTipo),
  FOREIGN KEY (DNI) REFERENCES Cliente(DNI),
  FOREIGN KEY (CodTipo) REFERENCES TipoSuscrip(CodTipo)
);

CREATE TABLE Plaza
(
  CodPlaza VARCHAR(6) NOT NULL,
  estado VARCHAR(20) NOT NULL,
  PRIMARY KEY (CodPlaza)
);

CREATE TABLE Vehiculo
(
  Placa VARCHAR(7) NOT NULL,
  Modelo VARCHAR(30) NOT NULL,
  Color VARCHAR(20) NOT NULL,
  Marca VARCHAR(30) NOT NULL,
  DNI VARCHAR(8) NOT NULL,
  PRIMARY KEY (Placa),
  FOREIGN KEY (DNI) REFERENCES Cliente(DNI)
);

CREATE TABLE Reservacion
(
  Fecha DATETIME NOT NULL,
  DNI VARCHAR(8) NOT NULL,
  CodPlaza VARCHAR(6) NOT NULL,
  PRIMARY KEY (DNI, CodPlaza),
  FOREIGN KEY (DNI) REFERENCES Cliente(DNI),
  FOREIGN KEY (CodPlaza) REFERENCES Plaza(CodPlaza)
);

CREATE TABLE Estacionado
(
  Fecini DATETIME NOT NULL,
  Fecfin DATETIME NOT NULL,
  Fecrevocado DATETIME NULL,
  Placa VARCHAR(7) NOT NULL,
  CodPlaza VARCHAR(6) NOT NULL,
  PRIMARY KEY (Placa, CodPlaza),
  FOREIGN KEY (Placa) REFERENCES Vehiculo(Placa),
  FOREIGN KEY (CodPlaza) REFERENCES Plaza(CodPlaza)
);

CREATE TABLE Usuario
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario NVARCHAR(50) NOT NULL UNIQUE,
    HashClave VARBINARY(64) NOT NULL,
    Sal VARBINARY(16) NOT NULL
);

insert into Cliente
values 
('48517975','Ernesto','Galván','952973936'),
('46859531','Roberto','Suarez','656846215'),
('68465135','Carlos','Rodriguez','864822345'),
('32884788','Pedro','Lopez','546846284'),
('25464806','Juan','Savedra','468465218'),
('98865321','Angel','Perez','542684654')

insert into Vehiculo
values
('FTD-448','Forester','Indigo','Subaru','48517975'),
('KZQ-550','MDX','Violet','Acura','48517975'),
('PQZ-700','240','Indigo','Volvo','46859531'),
('IAK-170','Yukon','Fuscia','GMC','46859531'),
('WSO-223','Sonic','Crimson','Chevrolet','46859531'),
('CCU-863','M','Turquoise','Infiniti','68465135'),
('DZE-559','Freelander','Khaki','Land Rover','68465135'),
('YGC-612','G-Series G30','Blue','Chevrolet','32884788'),
('JFP-646','Grand Caravan','Red','Dodge','32884788'),
('DAV-643','Montero Sport','Indigo','Mitsubishi','32884788'),
('GZG-636','911','Red','Porsche','32884788'),
('EBT-146','Impala','Maroon','Chevrolet','25464806'),
('JSD-104','Navigator L','Puce','Lincoln','25464806'),
('PQX-887','911','Goldenrod','Porsche','25464806'),
('YAD-847','MX-5','Mauv','Mazda','98865321')


insert into Plaza
values 
('000111','Asignado'),
('000112','Asignado'),
('000113','Asignado'),
('000114','Asignado'),
('000115','Asignado'),
('000116','Libre'),
('000117','Libre'),
('000118','Libre'),
('000119','Libre'),
('000120','Libre'),
('000121','Libre'),
('000122','Libre'),
('000123','Libre')


insert into Reservacion
values
(GETDATE(),'48517975','000111'),
(GETDATE(),'48517975','000112'),
(GETDATE(),'46859531','000113'),
(GETDATE(),'46859531','000114'),
(GETDATE(),'46859531','000115')


INSERT INTO Usuario (NombreUsuario, HashClave, Sal)
VALUES ('usuario_prueba', 
        0x9A44A7923C550C7B30E35960ACB2A693E422C1CBC675AEB494435C8E3B8266393A838C70E1A6061004C78D3BF60C0ED8B2A3ECBDC034AC86203FD08948C00DB7,
        0xCCE39363F649BE61EB7B7868B22EFE1B);