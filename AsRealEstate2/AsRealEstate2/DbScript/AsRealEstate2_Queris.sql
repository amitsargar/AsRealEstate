--Drop Database AsRealEstate2;
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
	ContactNo decimal(10,0) NOT NULL,
	EmailId nvarchar(50) NOT NULL,
	Gender int FOREIGN KEY REFERENCES Genders (GenderId),
	ImagePath varchar(100) NULL,
	RoleId int FOREIGN KEY REFERENCES Roles (RoleId),
	Password varchar(100) NULL,
	IsActive bit NOT NULL default 1,
	CreatedBy int NOT null default 1,
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int,
	ModifiedDate datetime NULL
	);

insert into Members(MemberName,DOB,ContactNo,EmailId,Gender,ImagePath,RoleId) values('Shirish','09-05-1989',7776834574,'teleshri@gmail.com',1,'',1);
insert into Members(MemberName,DOB,ContactNo,EmailId,Gender,ImagePath,RoleId,Password) values('Amit','09-05-1989',7776834574,'amit@gmail.com',1,'',1,'123456');



CREATE TABLE PropertyModes(
	PropertyModeId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	IsActive bit NOT NULL default 1,
	CreatedBy int FOREIGN KEY REFERENCES Members (MemberId),
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int NULL,
	ModifiedDate datetime NOT NULL
	);

CREATE TABLE Categories(
	CategoryId int primary key IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	IsActive bit NOT NULL default 1,
	CreatedBy int FOREIGN KEY REFERENCES Members (MemberId),
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int,
	ModifiedDate datetime NULL,
	PropertyModeId int FOREIGN KEY REFERENCES PropertyModes (PropertyModeId)
	);

CREATE TABLE Countries(
	CountryId int primary key IDENTITY(1,1) NOT NULL,
	Name nvarchar(max) NULL,
	IsActive bit NOT NULL default 1,
	CreatedBy int FOREIGN KEY REFERENCES Members (MemberId),
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int NULL,
	ModifiedDate datetime NOT NULL);

CREATE TABLE States(
	StateId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	IsActive bit NOT NULL default 1,
	CreatedBy int FOREIGN KEY REFERENCES Members (MemberId),
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int,
	ModifiedDate datetime NULL,
	CountryId int FOREIGN KEY REFERENCES Countries (CountryId));
	
CREATE TABLE Cities(
	CityId int primary key  IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	IsActive bit NOT NULL default 1,
	CreatedBy int FOREIGN KEY REFERENCES Members (MemberId),
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int,
	ModifiedDate datetime NULL,
	StateId int FOREIGN KEY REFERENCES States (StateId)
	);
	
CREATE TABLE Locations(
	LocationId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	IsActive bit NOT NULL default 1,
	CreatedBy int FOREIGN KEY REFERENCES Members (MemberId),
	CreatedDate datetime NOT NULL DEFAULT getdate(),
	ModifiedBy int,
	ModifiedDate datetime NULL,
	CityId int FOREIGN KEY REFERENCES Cities (CityId)
);


create Table ListedProperties
(
	ListedPropertyId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PropertyModeID int  FOREIGN KEY REFERENCES PropertyModes (PropertyModeID),	
	Size  decimal(10,2) NOT NULL,
	OwnerID int NOT NULL,
	Prize decimal(11,2) NOT NULL,
	Bedroom int,
	Bathroom int,
	PropertyCompletedOn Datetime,  
	Lift bit,
	Balcony int,
	Backyard bit,
	SwimingPool bit,
	Parking int,
	Comment varchar(500),
	Rating int,
	CountryId int FOREIGN KEY REFERENCES Countries (CountryId),
	StateId int FOREIGN KEY REFERENCES States (StateId),
	CityId int FOREIGN KEY REFERENCES Cities (CityId),
	LocationId int FOREIGN KEY REFERENCES Locations (LocationId),
	PropertyAddress varchar(100) NOT NULL,
	PinCode decimal(6,0),
	CreatedBy int,
	CreatedDate DateTime,
	ModifiedBy int,
	ModifiedDate DateTime
);