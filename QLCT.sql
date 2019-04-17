create database Expenditure
create table Quanlichitieu(
	id int primary key identity(1,1),
	Date date not null,
	Total int not null,
	Detail nvarchar(200) null
)