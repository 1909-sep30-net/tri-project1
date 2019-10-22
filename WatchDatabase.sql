--Where I'll store my tables and data for my watch store for project 0
--Last edit 10-15-19
CREATE TABLE Customer 
(
  CID INT IDENTITY(1,1),
  Names VARCHAR(30)		NOT NULL,
  Addresses VARCHAR(50)	NOT NULL,
  Phone VARCHAR(15)		NOT NULL,
  PRIMARY KEY (CID)
);

CREATE TABLE Orders
(
  OID INT IDENTITY(1,1),
  CID INT,
  LID INT,
  Order_Time DATE,
  PRIMARY KEY (OID),
  FOREIGN KEY (CID) REFERENCES Customer(CID),
  FOREIGN KEY(LID) REFERENCES Locations(LID)
);

CREATE TABLE Product
(
  PID INT IDENTITY(1,1),
  Names VARCHAR(30)			NOT NULL,
  Price INT					NOT NULL,
  Model VARCHAR(30)			NOT NULL,
  PRIMARY KEY (PID)
);

CREATE TABLE Customer_Order
(
  OID INT,
  PID INT,
  Amount INT			NOT NULL,
  FOREIGN KEY (OID) REFERENCES Orders(OID),
  FOREIGN KEY (PID) REFERENCES Product(PID),
  CONSTRAINT CompKey_OP PRIMARY KEY (OID, PID)
);

CREATE TABLE Locations
(
  LID INT IDENTITY(1,1),
  Located VARCHAR(30)	NOT NULL,
  PRIMARY KEY (LID)
);

CREATE TABLE Inventory
(
  LID INT,
  PID INT,
  Quantity INT			NOT NULL,
  FOREIGN KEY (LID) REFERENCES Locations(LID),
  FOREIGN KEY (PID) REFERENCES Product(PID),
  CONSTRAINT CompKey_LP PRIMARY KEY(LID, PID)
);

--Drop Table Customer;  --6


--Drop Table Orders; --3


--Drop Table Product; --4

--Drop Table dbo.Customer_Order; --1
 

--Drop Table Locations; --5


--Drop Table Inventory; --2



--Insert Into Customer(Names, Addresses, Phone) Values('Rotty Tops', 'Sequin Land', 8675309);
--Insert Into Customer(Names, Addresses, Phone) Values('Cloud Strife', 'Midgar', 4548787);
--Delete From Customer Where Customer.CID = 1;
--Delete From Customer Where Customer.CID = 2;

--Insert Into Product(Names, Price, Model) Values('Omega', 4500, 'Seamaster');
--Insert Into Product(Names, Price, Model) Values('Rolex', 5700, 'Datejust');
--Insert Into Product(Names, Price, Model) Values('Grand Seiko', 5500, 'Snowflake');
--Insert Into Product(Names, Price, Model) Values('IWC', 1200, 'Flieger');
--Insert Into Product(Names, Price, Model) Values('Timex', 200, 'Marlin');
--Insert Into Product(Names, Price, Model) Values('Cartier', 2500, 'Tank');

--Insert Into Locations(Located) Values('Geneva'); 
--Insert Into Locations(Located) Values('Brooklyn'); 
--Insert Into Locations(Located) Values('Anaheim'); 

--Insert Into Inventory(LID, PID, Quantity) Values(1,1,100);
--Insert Into Inventory(LID, PID, Quantity) Values(1,2,150);
--Insert Into Inventory(LID, PID, Quantity) Values(1,6,150);
--Insert Into Inventory(LID, PID, Quantity) Values(2,3,200);
--Insert Into Inventory(LID, PID, Quantity) Values(2,4,100);
--Insert Into Inventory(LID, PID, Quantity) Values(2,5,300);
--Insert Into Inventory(LID, PID, Quantity) Values(3,3,300);
--Insert Into Inventory(LID, PID, Quantity) Values(3,1,350);
--Insert Into Inventory(LID, PID, Quantity) Values(3,6,400);

--Insert Into Orders(OID, CID, LID, Order_Type, Order_Time) Values(1, 2, 1, 'Stainless steel', '2019-10-15');

Insert Into Orders(CID, LID, Order_Time) Values(1, 1, '2019-10-15');

Insert Into Customer_Order(OID, PID, Amount) Values(1, 1, 1 );

--Insert Into Customer_Order(OID, PID, Amount) Values(1, 1, 2);

--Update Customer
--Set Names = 'Rotty Tops', Addresses = 'Sequin Land', Phone = 8675309
--Where CID = 3;

--Update Customer
--Set Names = 'Albert Wesker', Addresses = 'STARS HQ', Phone = 188855544
--Where CID = 13;

--Update Locations
--Set Inventory = 300
--Where Located = 'Geneva';

--Select*
--From Orders
--Where CID = 2;

--Select*
--From Customer, Orders, Product
--Where Customer.CID = Orders.CID; 

--Select* From Customer; --3
--Select* From Orders; --1
--Select* From Product; --6
--Select* From Customer_Order; --1
--Select* From Locations; --3
--Select* From Inventory; --9

--Display Order of customer based on product and locations
--Doesn't work T_T
--Select Customer.CID, Customer.Names, Orders.OID, Locations.Located, Product.Names, Product.Model, Product.Price, Customer_Order.Amount
--From Orders Inner Join Customer_Order 
--On Orders.OID = Customer_Order.OID Inner Join Product
--ON Product.PID = Customer_Order.PID Inner Join Locations
--On Orders.LID = Locations.LID;

--Displays Locations and the stock of the watches they carry
Select Locations.LID, Locations.Located, Inventory.Quantity, Product.PID, Product.Names, Product.Model, Product.Price
From Product Inner Join Inventory
On Product.PID = Inventory.PID Inner Join Locations
On Locations.LID = Inventory.LID;