--CREATE DATABASE AsRealEstate2;
--USE AsRealEstate2;

CREATE TABLE Roles(
	RoleId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	RoleName nvarchar(50) NOT NULL,	
	IsActive bit NOT NULL default 1	
);

insert into Roles(RoleName) values('Admin'),('Owner'),('Customer');

CREATE TABLE Genders(
	GenderId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	GenderName nvarchar(50) NOT NULL,	
	IsActive bit NOT NULL default 1	
);

insert into Genders(GenderName) values('male'),('female'),('other');

CREATE TABLE Members(
	MemberId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	MemberName nvarchar(50) NOT NULL,
	DOB date NOT NULL,
	ContactNo nvarchar(15) NOT NULL,
	EmailId nvarchar(50) NOT NULL,
	Gender int FOREIGN KEY REFERENCES Genders (GenderId),
	Image varchar(100) NULL,
	RoleId int FOREIGN KEY REFERENCES Roles (RoleId),
	IsActive bit NOT NULL default 1,
	CreatedBy int NOT null default 1,
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int,
	ModifiedDate datetime NULL
	);

insert into Members(MemberName,DOB,ContactNo,EmailId,Gender,Image,RoleId) values('Shirish','09-05-1989',7776834574,'teleshri@gmail.com',1,'',1);


CREATE TABLE PropertyModes(
	Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	IsActive bit NOT NULL default 1,
	CreatedBy int FOREIGN KEY REFERENCES Members (MemberId),
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int NULL,
	ModifiedDate datetime NOT NULL
	);

CREATE TABLE Categories(
	Id int primary key IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	IsActive bit NOT NULL default 1,
	CreatedBy int FOREIGN KEY REFERENCES Members (MemberId),
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int,
	ModifiedDate datetime NULL,
	ProperyModeId int FOREIGN KEY REFERENCES PropertyModes (Id)
	);

CREATE TABLE Countries(
	Id int primary key IDENTITY(1,1) NOT NULL,
	Name nvarchar(max) NULL,
	IsActive bit NOT NULL default 1,
	CreatedBy int FOREIGN KEY REFERENCES Members (MemberId),
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int NULL,
	ModifiedDate datetime NOT NULL);

CREATE TABLE States(
	Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	IsActive bit NOT NULL default 1,
	CreatedBy int FOREIGN KEY REFERENCES Members (MemberId),
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int,
	ModifiedDate datetime NULL,
	CountryId int FOREIGN KEY REFERENCES Countries (Id));
	
CREATE TABLE Cities(
	Id int primary key  IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	IsActive bit NOT NULL default 1,
	CreatedBy int FOREIGN KEY REFERENCES Members (MemberId),
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int,
	ModifiedDate datetime NULL,
	StateId int FOREIGN KEY REFERENCES States (Id)
	);
	
CREATE TABLE Locations(
	Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	IsActive bit NOT NULL default 1,
	CreatedBy int FOREIGN KEY REFERENCES Members (MemberId),
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int,
	ModifiedDate datetime NULL,
	CityId int FOREIGN KEY REFERENCES Cities (Id)
);