USE [JoolServer]
GO 
/***************************TABLE DROPS****************************************/
DROP TABLE [dbo].[tblPropertyValue]
GO
DROP TABLE [dbo].[tblTypeFilter]
GO
DROP TABLE [dbo].[tblTechSpecFilter]
GO
DROP TABLE [dbo].[tblProperty]
GO
Drop Table [dbo].tblProjToProd
Go
Drop Table [dbo].tblFeedBack
Go
DROP TABLE [dbo].[tblDepartment]
Go
Drop Table [dbo].tblProduct
Go
DROP TABLE [dbo].[tblDocument]
GO
DROP TABLE [dbo].[tblSubCategory]
GO
Drop Table [dbo].tblCategory
Go
DROP TABLE [dbo].[tblSales]
GO
DROP TABLE [dbo].[tblProject]
GO
DROP TABLE [dbo].[tblManufacturer]
GO
DROP TABLE [dbo].[tblUser]
GO
DROP TABLE [dbo].[tblCredential]
GO
DROP TABLE [dbo].[tblCity]
GO
DROP TABLE [dbo].[tblState]
GO



/***************************TABLE CREATE****************************************/
Create Table [dbo].[tblCategory]
(
Category_ID int Primary Key,
Category_Name varchar(50)
)
GO
INSERT [dbo].[tblCategory]([Category_ID],[Category_Name]) VALUES(1,'Electronics')
INSERT [dbo].[tblCategory]([Category_ID],[Category_Name]) VALUES(2,'Fashion')
INSERT [dbo].[tblCategory]([Category_ID],[Category_Name]) VALUES(3,'Motor Parts')
GO
CREATE TABLE [dbo].[tblDocument](
	[Document_ID] [int] IDENTITY(1,1) NOT NULL,
	[Document_Folder_Path] [varchar](100) NOT NULL,
	PRIMARY KEY (Document_ID),
)
GO
SET IDENTITY_INSERT [dbo].[tblDocument] ON
INSERT [dbo].[tblDocument]([Document_ID],[Document_Folder_Path]) VALUES(1, 'JoolServerApp\Item_Docs\Item1_Doc.txt')
SET IDENTITY_INSERT [dbo].[tblDocument] OFF
GO

CREATE TABLE [dbo].[tblSubCategory](
	[SubCategory_ID] [int] IDENTITY(1,1) NOT NULL,
	[Category_ID] [int] NOT NULL,
	[SubCategory_Name] [varchar](100) NOT NULL,
	PRIMARY KEY (SubCategory_ID),
	FOREIGN KEY (Category_ID) REFERENCES dbo.tblCategory(Category_ID) --(Uncomment on merge)
)
GO
SET IDENTITY_INSERT [dbo].[tblSubCategory] ON
INSERT [dbo].[tblSubCategory]([SubCategory_ID],[Category_ID],[SubCategory_Name]) VALUES(1,1, 'PC Part')
INSERT [dbo].[tblSubCategory]([SubCategory_ID],[Category_ID],[SubCategory_Name]) VALUES(2,2, 'Motor Jacket')
INSERT [dbo].[tblSubCategory]([SubCategory_ID],[Category_ID],[SubCategory_Name]) VALUES(3,3, 'Muffler')
SET IDENTITY_INSERT [dbo].[tblSubCategory] OFF


GO
CREATE TABLE [dbo].[tblCredential]
(
[Credential_ID][int] NOT NULL,
[User_Type][varchar](50)NULL
PRIMARY KEY(Credential_ID)
)
GO
INSERT [dbo].[tblCredential] ([Credential_ID],[User_Type]) VALUES(1,'user')
INSERT [dbo].[tblCredential] ([Credential_ID],[User_Type]) VALUES(2,'admin')
INSERT [dbo].[tblCredential] ([Credential_ID],[User_Type]) VALUES(3,'king')



GO

CREATE TABLE [dbo].[tblUser]
([User_ID][int] NOT NULL,
[User_Name][varchar](100) NOT NULL,
[User_Email][varchar](100) NOT NULL,
[User_Image][image] NULL,
[user_Password] [varchar](100) NOT NULL,
[Credential_ID] [int] NOT NULL,
PRIMARY KEY (User_ID),
FOREIGN KEY (Credential_ID) REFERENCES [dbo].[tblCredential](Credential_ID)
)
GO
INSERT [dbo].[tblUser] ([User_ID],[User_Name],[User_Email],[User_Image],[User_Password],[Credential_ID]) VALUES(1,'XavierR','test1@gmail.com',null,'password',1)
INSERT [dbo].[tblUser] ([User_ID],[User_Name],[User_Email],[User_Image],[User_Password],[Credential_ID]) VALUES(2,'JoseM','test2@gmail.com',null,'password',2)
INSERT [dbo].[tblUser] ([User_ID],[User_Name],[User_Email],[User_Image],[User_Password],[Credential_ID]) VALUES(3,'BenW','test3@gmail.com',null,'password',1)
INSERT [dbo].[tblUser] ([User_ID],[User_Name],[User_Email],[User_Image],[User_Password],[Credential_ID]) VALUES(4,'KelvinA','test3@gmail.com',null,'password',3)

GO

CREATE TABLE [dbo].[tblManufacturer]
(
[Manufacturer_ID][int] NOT NULL,
[Manufacturer_Name][varchar](100) NOT NULL,
[Manufacturer_Department][varchar](100) NOT NULL,
[Manufacturer_Web][varchar] NULL, 
[User_ID][int] NOT NULL,
PRIMARY KEY (Manufacturer_ID),
FOREIGN KEY(User_ID) REFERENCES [dbo].[tblUser](User_ID)
)
GO

INSERT [dbo].[tblManufacturer] ([Manufacturer_ID],[Manufacturer_Name],[Manufacturer_Department],[Manufacturer_Web],[User_ID]) VALUES(1,'Sony','Customer Service',null,1)
INSERT [dbo].[tblManufacturer] ([Manufacturer_ID],[Manufacturer_Name],[Manufacturer_Department],[Manufacturer_Web],[User_ID]) VALUES(2,'Ducati','Transportation Service',null,2)
INSERT [dbo].[tblManufacturer] ([Manufacturer_ID],[Manufacturer_Name],[Manufacturer_Department],[Manufacturer_Web],[User_ID]) VALUES(3,'Apple','Customer Service',null,3)
INSERT [dbo].[tblManufacturer] ([Manufacturer_ID],[Manufacturer_Name],[Manufacturer_Department],[Manufacturer_Web],[User_ID]) VALUES(4,'Netflix','Entertainment Service',null,4)

GO
CREATE TABLE [dbo].[tblSales]
(
[Sales_ID][int] NOT NULL,
[Sales_Name][varchar] (50) NOT NULL,
[Sales_Phone][varchar] (50) NOT NULL,
[Sales_Email][nvarchar] (50) NOT NULL,
[Sales_Web][varchar] (50) NULL
PRIMARY KEY (Sales_ID)
)
GO
INSERT [dbo].[tblSales] ([Sales_ID],[Sales_Name],[Sales_Phone],[Sales_Email],[Sales_Web]) VALUES(1,'purchasedItem','8565428075','test1@gmail.com',null)
INSERT [dbo].[tblSales] ([Sales_ID],[Sales_Name],[Sales_Phone],[Sales_Email],[Sales_Web]) VALUES(2,'purchasedItem','8565428075','test1@gmail.com',null)
INSERT [dbo].[tblSales] ([Sales_ID],[Sales_Name],[Sales_Phone],[Sales_Email],[Sales_Web]) VALUES(3,'purchasedItem','8565428075','test1@gmail.com',null)
GO
CREATE TABLE [dbo].[tblDepartment]
(
[Department_ID][int] NOT NULL,
[Manufacturer_ID][int] NOT NULL,
[Department_Name][varchar] (100) NOT NULL,
[Department_Phone][varchar](50) NOT NULL,
[Department_Email][varchar] (100) NOT NULL,
PRIMARY KEY (Department_ID),
FOREIGN KEY (Manufacturer_ID) REFERENCES [dbo].[tblManufacturer](Manufacturer_ID)
 )
GO
INSERT [dbo].[tblDepartment] ([Department_ID], [Manufacturer_ID],[Department_Name],[Department_Phone],[Department_Email]) VALUES(1,1,'MobileCenter','8568568567','test1@department.com')
INSERT [dbo].[tblDepartment] ([Department_ID], [Manufacturer_ID],[Department_Name],[Department_Phone],[Department_Email]) VALUES(2,1,'PC Center','8568568567','test2@department.com')
INSERT [dbo].[tblDepartment] ([Department_ID], [Manufacturer_ID],[Department_Name],[Department_Phone],[Department_Email]) VALUES(3,2,'MotorBike','8568568567','test3@department.com')
INSERT [dbo].[tblDepartment] ([Department_ID], [Manufacturer_ID],[Department_Name],[Department_Phone],[Department_Email]) VALUES(4,2,'Fashion','8568568567','test4@department.com')
INSERT [dbo].[tblDepartment] ([Department_ID], [Manufacturer_ID],[Department_Name],[Department_Phone],[Department_Email]) VALUES(5,3,'MobileCenter','8568568567','test5@department.com')
INSERT [dbo].[tblDepartment] ([Department_ID], [Manufacturer_ID],[Department_Name],[Department_Phone],[Department_Email]) VALUES(6,3,'PC Center','8568568567','test6@department.com')
INSERT [dbo].[tblDepartment] ([Department_ID], [Manufacturer_ID],[Department_Name],[Department_Phone],[Department_Email]) VALUES(7,4,'Entertainment','8568568567','test7@department.com')
INSERT [dbo].[tblDepartment] ([Department_ID], [Manufacturer_ID],[Department_Name],[Department_Phone],[Department_Email]) VALUES(8,4,'Subscription','8568568567','test8@department.com')


 GO
CREATE TABLE [dbo].[tblProperty](
Property_ID INT NOT NULL,
Property_Name VARCHAR(50) NOT NULL,
IsType INT,
IsTechSpec INT,
PRIMARY KEY (Property_ID),
CONSTRAINT IsTypeCorrect_ck  CHECK (IsType in (0,1)),
CONSTRAINT IsTechSpecCorrect_ck  CHECK (IsTechSpec in (0,1))
)
GO
Insert [dbo].[tblProperty]([Property_ID],[Property_Name],[IsType],[IsTechSpec]) Values (1,'Product Type',0,0)
Insert [dbo].[tblProperty]([Property_ID],[Property_Name],[IsType],[IsTechSpec]) Values (2,'Model Year',0,0)
Insert [dbo].[tblProperty]([Property_ID],[Property_Name],[IsType],[IsTechSpec]) Values (3,'Technicial Spec',0,0)
CREATE TABLE 	[dbo].tblProduct
(
Product_ID int Not Null,
Manufacturer_ID int Not Null,
Sales_ID int Not Null,
SubCategory_ID int Not Null,
Product_Name varchar(50) Not Null,
Product_Image image Null,
Series varchar(50) Not Null,
Model varchar(50) Not Null,
Model_Year int Not Null,
Series_Info varchar(50) Not Null,
Document_ID int Not Null,
Featured varchar(50) Null,

Primary Key (Product_ID),
Foreign Key (Manufacturer_ID) References dbo.tblManufacturer(Manufacturer_ID),
Foreign Key (Sales_ID) References dbo.tblSales(Sales_ID),
Foreign Key (SubCategory_ID) References dbo.tblSubCategory(SubCategory_ID),
Foreign Key (Document_ID) References dbo.tblDocument(Document_ID),

)
GO
Insert [dbo].tblProduct([Product_ID], [Manufacturer_ID], [Sales_ID],[SubCategory_ID],[Product_Name], [Product_Image], [Series], [Model], [Model_Year], [Series_Info], [Document_ID], [Featured])
values(1,1,1,1, 'PS5', null, 'Gaming','5',2020, 'Playstation by Sony',1, 'Yes')


Insert [dbo].tblProduct([Product_ID], [Manufacturer_ID], [Sales_ID],[SubCategory_ID],[Product_Name], [Product_Image], [Series], [Model], [Model_Year], [Series_Info], [Document_ID], [Featured])
values(2,2,1,2, 'Ducatti 2021', null, 'X','2-Wheel',2021, 'Motorcycle top tier',1, 'Yes')

Insert [dbo].tblProduct([Product_ID], [Manufacturer_ID], [Sales_ID],[SubCategory_ID],[Product_Name], [Product_Image], [Series], [Model], [Model_Year], [Series_Info], [Document_ID], [Featured])
values(3,2,1,3, 'Ducatti 2021', null,'X', '2-Wheel',2021, 'Motorcycle top tier',1, 'Yes')
GO
CREATE TABLE [dbo].[tblPropertyValue](
Property_ID INT NOT NULL,
Product_ID INT NOT NULL,
[Value] INT,
PRIMARY KEY (Property_ID,Product_ID),
FOREIGN KEY (Product_ID) REFERENCES [dbo].[tblProduct](Product_ID),
FOREIGN KEY (Property_ID) REFERENCES [dbo].[tblProperty](Property_ID)
)
GO
--is used for search functionality must defaulted to 0 or none at all
Insert [dbo].[tblPropertyValue]([Property_ID],[Product_ID],[Value]) Values (1,1,null)
Insert [dbo].[tblPropertyValue]([Property_ID],[Product_ID],[Value]) Values (2,1,null)
Insert [dbo].[tblPropertyValue]([Property_ID],[Product_ID],[Value]) Values (3,1,null)
GO
CREATE TABLE [dbo].[tblTypeFilter](
Property_ID INT NOT NULL,
SubCategory_ID INT NOT NULL,
[Type_Name] VARCHAR(50),
Type_Options VARCHAR(50),
PRIMARY KEY (Property_ID,SubCategory_ID),
FOREIGN KEY (SubCategory_ID) REFERENCES [dbo].[tblSubCategory](SubCategory_ID),
Foreign KEY (Property_ID) REFERENCES [dbo].[tblProperty](Property_ID)
)
GO
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (2,2,'Reliability','Useless')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (2,2,'Reliability','Decent')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (2,2,'Reliability','Reliable')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (2,2,'Model Type','Old')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (2,2,'Model Type','Modern')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (2,2,'Model Type','New')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (1,1,'Reliability','Useless')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (1,1,'Reliability','Decent')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (1,1,'Reliability','Reliable')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (1,1,'Model Type','Old')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (1,1,'Model Type','Modern')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (1,1,'Model Type','New')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (3,3,'Reliability','Useless')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (3,3,'Reliability','Decent')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (3,3,'Reliability','Reliable')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (3,3,'Model Type','Old')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (3,3,'Model Type','Modern')
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (3,3,'Model Type','New')



GO
CREATE TABLE [dbo].[tblTechSpecFilter](
Property_ID INT NOT NULL,
SubCategory_ID INT NOT NULL,
Min_Value INT,
Max_Value INT,
PRIMARY KEY (Property_ID,SubCategory_ID),
FOREIGN KEY (SubCategory_ID) REFERENCES [dbo].[tblSubCategory](SubCategory_ID),
FOREIGN KEY (Property_ID) REFERENCES [dbo].[tblProperty](Property_ID),
CONSTRAINT IsTechSpecMaxMinCor_ck  CHECK (Min_Value<=Max_Value)
)
GO
Insert [dbo].[tblTechSpecFilter]([Property_ID],[SubCategory_ID],[Min_Value],[Max_Value]) Values (1,1,0,100)

Go
Create Table [dbo].tblFeedBack
(
Feeback_ID int Primary Key,
User_ID int, 
Product_ID int,
Feedback_Time time,
Feedback_Score decimal,
Feedback_Content varchar(50),

Foreign Key (User_ID) References dbo.tblUser(User_ID),
Foreign Key (Product_ID) References dbo.tblProduct(Product_ID),
)														
GO
						--Create Tables(For Now) and fill with Data(Not yet though)
CREATE TABLE [dbo].[tblState](
	[State_ID] [int] IDENTITY(1,1) NOT NULL,
	[State_Name] [varchar](50) NOT NULL,
	PRIMARY KEY (State_ID)
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblState] ON
INSERT [dbo].[tblState] ([State_ID],[State_Name]) VALUES(1,'California')
INSERT [dbo].[tblState] ([State_ID],[State_Name]) VALUES(2,'Texas')
INSERT [dbo].[tblState] ([State_ID],[State_Name]) VALUES(3,'New Jersey')
INSERT [dbo].[tblState] ([State_ID],[State_Name]) VALUES(4,'Florida')
INSERT [dbo].[tblState] ([State_ID],[State_Name]) VALUES(5,'New York')
SET IDENTITY_INSERT [dbo].[tblState] OFF
GO
CREATE TABLE [dbo].[tblCity](
	[City_ID] [int] IDENTITY(1,1) NOT NULL,
	[City_Name] [varchar](50) NOT NULL,
	[State_ID] [int] NOT NULL,
	PRIMARY KEY (City_ID),
	FOREIGN KEY (State_ID) REFERENCES dbo.tblState(State_ID)
)
GO
SET IDENTITY_INSERT [dbo].[tblCity] ON
INSERT [dbo].[tblCity] ([City_ID],[City_Name],[State_ID]) VALUES(1,'Los Angeles',1)
INSERT [dbo].[tblCity] ([City_ID],[City_Name],[State_ID]) VALUES(2, 'San Francisco', 1)
INSERT [dbo].[tblCity] ([City_ID],[City_Name],[State_ID]) VALUES(3, 'Austin', 2)
INSERT [dbo].[tblCity] ([City_ID],[City_Name],[State_ID]) VALUES(4, ' Houston', 2)
INSERT [dbo].[tblCity] ([City_ID],[City_Name],[State_ID]) VALUES(5, 'Trenton', 3)
INSERT [dbo].[tblCity] ([City_ID],[City_Name],[State_ID]) VALUES(6, 'Newark', 3)
INSERT [dbo].[tblCity] ([City_ID],[City_Name],[State_ID]) VALUES(7, 'Miami', 4)
INSERT [dbo].[tblCity] ([City_ID],[City_Name],[State_ID]) VALUES(8, 'Orlando', 4)
INSERT [dbo].[tblCity] ([City_ID],[City_Name],[State_ID]) VALUES(9, 'Buffalo', 5)
INSERT [dbo].[tblCity] ([City_ID],[City_Name],[State_ID]) VALUES(10, 'New York', 5)
SET IDENTITY_INSERT [dbo].[tblCity] OFF




GO

CREATE TABLE [dbo].[tblProject](
	[Project_ID] [int] IDENTITY(1,1) NOT NULL,
	[Project_Name] [varchar](50) NOT NULL,
	[User_Id] [int] NOT NULL,
	[Project_Address1] [varchar](100) NOT NULL,
	[Project_Address2] [varchar](100) NULL,
	[Project_City] [int]  NOT NULL,
	[Project_State] [int] NOT NULL,
	[Project_Size] [int] NOT NULL,
	[Client_Name] [varchar](100) NOT NULL,
	PRIMARY KEY (Project_ID),
	FOREIGN KEY (User_Id) REFERENCES dbo.tblUser(User_ID),  --(Table is not implemented by me) Uncomment on merge
	FOREIGN KEY (Project_City) REFERENCES dbo.tblCity(City_ID),
	FOREIGN KEY (Project_State) REFERENCES dbo.tblState(State_ID)
)
Go
SET IDENTITY_INSERT [dbo].[tblProject] ON
INSERT [dbo].[tblProject] ([Project_ID],[Project_Name],[User_Id],[Project_Address1],[Project_Address2],[Project_City],[Project_State],[Project_Size],[Client_Name]) VALUES(1,'Computer',1,'Home St.', null, 3, 3, 1, 'Random Client') 
SET IDENTITY_INSERT [dbo].[tblProject] OFF

GO
Create Table [dbo].tblProjToProd
(
Project_ID int,
Product_ID int,
Quantity int,

Foreign Key (Project_ID) References dbo.tblProject(Project_ID),
Foreign Key (Product_ID) References dbo.tblProduct(Product_ID)
)
GO
Insert [dbo].tblProjToProd([Project_ID], [Product_ID], [Quantity]) values(1, 1, 33)
Insert [dbo].tblProjToProd([Project_ID], [Product_ID], [Quantity]) values(1, 2, 27)
Insert [dbo].tblProjToProd([Project_ID], [Product_ID], [Quantity]) values(1, 3, 303)

/***************************TABLE INSERTS****************************************/



/*
Insert [dbo].tblCategory([Category_ID], [Category_Name]) Values()*/
/*SET IDENTITY_INSERT [dbo].[tblCredential] ON
INSERT [dbo].[tblCredential] ([Credential_ID],[User_Type]) VALUES()
SET IDENTITY_INSERT [dbo].[tblUser] OFF
--SET IDENTITY_INSERT dbo.tblName ON; <-- this will allow explicit values to be entered into primary key value, otherwise autosets key value on insert
SET IDENTITY_INSERT [dbo].[tblUser] ON
--INSERT [dbo].[tblUser] ([User_ID],[User_Name],[User_Email],[User_Image],[User_Password],[Credential_ID]) VALUES()
SET IDENTITY_INSERT [dbo].[tblUser] OFF
GO*/
/*
Insert [dbo].tblFeedBack([Feeback_ID], [User_ID], [Product_ID], [Feedback_Time], [Feedback_Score], [Feedback_Content] 
values()
*/
/*will be used when values need to be made DO NOT DELETE*/
/*
GO
Insert [dbo].[tblPropertyValue]([Property_ID],[Product_ID],[Value]) Values (1,1,1)
GO
Insert [dbo].[tblPropertyValue]([Property_ID],[Product_ID],[Value]) Values (1,2,2)
GO
Insert [dbo].[tblTypeFilter]([Property_ID],[SubCategory_ID],[Type_Name],[Type_Options]) Values (1,1,'blower','set,delete')
GO
Insert [dbo].[tblTechSpecFilter]([Property_ID],[SubCategory_ID],[Min_Value],[Max_Value]) Values (1,2,4,5)*/
/*
Insert [dbo].tblProduct([Product_ID], [Manufacturer_ID], [Sales_ID],[SubCategory_ID],[Product_Name], [Product_Image], [Series], [Model], [Model_Year], [Series_Info], [Document_ID], [Featured])
values()*/
 /*
INSERT [dbo].[tblDepartment] ([Department_ID], [Manufacturer_ID],[Department_Name],[Department_Phone],[Department_Email]) VALUES()
SET IDENTITY_INSERT [dbo].[tblDepartment] OFF
GO*/
/*SET IDENTITY_INSERT [dbo].[tblSales] ON
INSERT [dbo].[tblSales] ([Sales_ID],[Sales_Name],[Sales_Phone],[Sales_Email],[Sales_Web]) VALUES()
SET IDENTITY_INSERT [dbo].[tblSales] OFF
GO*/
/*SET IDENTITY_INSERT [dbo].[tblManufacturer] ON
INSERT [dbo].[tblManufacturer] ([Manufacturer_ID],[Manufacturer_Name],[Manufacturer_Department],[Manufacturer_Web]) VALUES()
SET IDENTITY_INSERT [dbo].[tblManufacturer] OFF
Insert [dbo].tblProjToProd([Project_ID], [Product_ID], [Quantity]) values()
GO
*/
