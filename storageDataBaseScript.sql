IF DB_ID('Storage') IS NULL
CREATE DATABASE Storage
GO
USE Storage;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblProduct')
drop table tblProduct;

Create table tblProduct (
ID int identity (1,1) primary key,
ProductName varchar(10) not null,
Code varchar(30) unique not null,
Amount int not null,
Price int not null,
Stored bit not null
)