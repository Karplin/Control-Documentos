
CREATE TABLE DEPARTAMENTO(
IdDepartamento INT IDENTITY PRIMARY KEY,
Nombre VARCHAR(30),
Siglas VARCHAR(20)
)

CREATE TABLE USUARIOS(
IdUsuario INT IDENTITY PRIMARY KEY,
Cedula  VARCHAR(30),
Nombre  VARCHAR(30),
Apellido  VARCHAR(30),
Correo VARCHAR(30),
Contrasena VARCHAR(30),
Departamento VARCHAR(30),
Cargo VARCHAR(30),
Edad INT
)
INSERT INTO USUARIOS (Nombre,Apellido,Apellido,Correo,Contrasena,Departamento,Cargo,Edad) VALUES ('Leonal','Perez','leonal2305@gmail.com','leo123','Recursos Humanos', 'Gerente', 23)

CREATE TABLE DOCUMENTOS(
IdDocumento INT IDENTITY PRIMARY KEY,
Cedulaempleado Varchar(30),
TipoDocumento VARCHAR(30),
OrigenDepartamento VARCHAR(50),
DestinoDepartamento VARCHAR(50),
Fecha VARCHAR(30),
Codigo VARCHAR(30)
)


INSERT INTO DOCUMENTOS (IdDocumento,Cedulaempleado,TipoDocumento,OrigenDepartamento,DestinoDepartamento,FechaCodigo) VALUES ('Leonal','leonal2305@gmail.com','leo123','Recursos Humanos', 'Gerente', 23)


CREATE PROCEDURE docu_empleado
@empleado VARCHAR(30)
AS 
SELECT  Cedulaempleado, codigo, TipoDocumento  FROM DOCUMENTOS WHERE Cedulaempleado = @empleado


CREATE PROCEDURE docu_origen
@departaorigen VARCHAR(50)
AS 
SELECT OrigenDepartamento, codigo FROM DOCUMENTOS WHERE OrigenDepartamento = @departaorigen


CREATE PROCEDURE docu_destino
@departadestino VARCHAR(50)
AS 
SELECT  DestinoDepartamento, codigo FROM DOCUMENTOS WHERE DestinoDepartamento = @departadestino


CREATE PROCEDURE docu_fecha
@fechaini VARCHAR(30),
@fechafi VARCHAR(30)
AS 
SELECT  * FROM DOCUMENTOS WHERE  fecha BETWEEN @fechaini AND @fechafi 

use documentobd


select * from DEPARTAMENTO
select * from DOCUMENTOS
select * from USUARIOS

INSERT INTO USUARIOS (Cedulaempleado,TipoDocumento,OrigenDepartamento,DestinoDepartamento,Fecha,Codigo) VALUES ('Leonal','leonal2305@gmail.com','leo123','Recursos Humanos', 'Gerente', 23)

INSERT INTO DOCUMENTOS (IdDocumento,IdDocumento,OrigenDepartamento,DestinoDepartamento,Fecha,Codigo) VALUES ('Leonal','leonal2305@gmail.com','leo123','Recursos Humanos', 'Gerente', 23)



GO  
SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY];  
GO  


truncate table USUARIOS;
truncate table DEPARTAMENTO;
truncate table DOCUMENTOS;

