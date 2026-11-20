-- Script de creación de la base de datos Comercial.accdb
-- Se ejecuta automáticamente cuando el programa no encuentra la base.
-- Cada sentencia debe terminar en punto y coma (;)

CREATE TABLE Categorias (
    IdCategoria COUNTER PRIMARY KEY,
    Nombre TEXT(100) NOT NULL
);

CREATE TABLE Productos (
    IdProducto COUNTER PRIMARY KEY,
    Codigo TEXT(50) NOT NULL,
    Descripcion TEXT(255) NOT NULL,
    Precio CURRENCY NOT NULL,
    Stock INTEGER NOT NULL,
    StockMinimo INTEGER NOT NULL,
    IdCategoria INTEGER,
    Activo YESNO NOT NULL
);

CREATE TABLE Clientes (
    IdCliente COUNTER PRIMARY KEY,
    Documento TEXT(30) NOT NULL,
    Nombre TEXT(100) NOT NULL,
    Apellido TEXT(100) NOT NULL,
    Telefono TEXT(30),
    Email TEXT(150),
    Direccion TEXT(200),
    Activo YESNO NOT NULL
);

CREATE TABLE Ventas (
    IdVenta COUNTER PRIMARY KEY,
    Fecha DATETIME NOT NULL,
    IdCliente INTEGER,
    Total CURRENCY NOT NULL,
    FormaPago TEXT(50),

);

CREATE TABLE DetalleVentas (
    IdDetalle COUNTER PRIMARY KEY,
    IdVenta INTEGER NOT NULL,
    IdProducto INTEGER NOT NULL,
    Cantidad INTEGER NOT NULL,
    PrecioUnitario CURRENCY NOT NULL,
    Subtotal CURRENCY NOT NULL
);

CREATE TABLE Temp (
    ID COUNTER PRIMARY KEY,
    IdVenta INTEGER NOT NULL,
    IdProducto INTEGER NOT NULL,
    Descripcion TEXT(50),
    Cantidad INTEGER NOT NULL,
    PrecioUnita CURRENCY NOT NULL,
    Subtotal CURRENCY NOT NULL
);