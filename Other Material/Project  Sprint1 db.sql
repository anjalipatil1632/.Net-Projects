create database Sprintdb
use Sprintdb
create table TravelRequests
(
  RequestId int not null primary Key identity(1,1),
  RequestDate DateTime Default CURRENT_TIMESTAMP,
  FromLocation varchar(100) NOT NULL,
  ToLocation varchar(100) NOT NULL, 
  FromDate DateTime,
  ToDate DateTime,
  Medium varchar(50) not null,
  UserId int NOT NULL, 
  CurrentStatus varchar(30) DEFAULT 'Pending',
  ManagerStatus varchar(10) DEFAULT '-'
)

select CURRENT_TIMESTAMP
insert into TravelRequests(FromLocation,ToLocation,Medium,UserId) values('Mumbai','Pune','AiroPlane',1)

drop table TravelRequests
select * from TravelRequests


create table Users
(
  UserId int primary key identity(1,1),
  LoginId nvarchar(40),
  Password varchar(70) NOT NULL,
  Salt nvarchar(70),
  UserTypeId INT,
  Name VARCHAR(30) NOT NULL,
  ManagerUserId  INT 
)

drop table Users
insert into Users(LoginId,Password,UserTypeId,Name,ManagerUserId) values('travelagent','travel111',3,'Holly Pol','100')
insert into Users(LoginId,Password,UserTypeId,Name,ManagerUserId) values('anjalip','anjali11',1,'Anjali Patil','100')
insert into Users(LoginId,Password,UserTypeId,Name,ManagerUserId) values('snehalb','snehal11',1,'Snehal Barge','100')
insert into USers(LoginId,Password,UserTypeId,Name,ManagerUserId) values ('admin','admin111',1,'Kamal Pratabh','101')
insert into USers(LoginId,Password,UserTypeId,Name,ManagerUserId) values ('manager','manager111',2,'Sangana Singh','-')
select * from users

update  users set UserTypeId=4 where UserId=3

update  users set Password='admin111' where UserId=3
update  users set Password='manager1' where UserId=13
truncate table users
drop table users
CREATE TABLE UserType
(
	UserTypeId INT PRIMARY KEY identity(1,1), 
	Description VARCHAR(30) NOT NULL
)

insert into UserType values('Employee')
insert into UserType values('Manager')
insert into UserType values('Travel Agent')
insert into UserType values('Admin')

select * from UserType
insert 
 
ALTER TABLE TravelRequests 
ADD Constraint FK_userID
FOREiGN KEY(UserId) REFERENCES Users(UserId)

ALTER TABLE Users 
ADD Constraint FK_userTypeID_Users_UserType
FOREiGN KEY(UserTypeId) REFERENCES UserType(UserTypeId)
on update CASCADE
on delete CASCADE

alter table Users drop Constraint FK_userTypeID

create table Managerdetails
(
  ManagerUserId int primary key identity(100,1),
  ManagerName varchar(30) 
)

ALTER TABLE Users 
ADD Constraint FK_ManagerUserId_Users_Managerdetails
FOREiGN KEY(ManagerUserId) REFERENCES Managerdetails(ManagerUserId)
on update CASCADE
on delete CASCADE

alter table Users drop Constraint FK_ManagerUserId

EXEC SP_HELP Users
-----------------------------------------------------------------------Employees stored procedure---------------------------------------------------------------------------------------
	--create procedure spEmpCheckLoginDetails
	--(
	--@loginid varchar(20),
	--@password varchar(20)
	--)
	--as
	--begin
	--select COUNT(*) from Users where LoginId=@loginid and Password=@password and UserTypeId=1
	--end

create procedure spEmpCheckLoginDetails
(
 @loginid varchar(40),
 @password varchar(70)
)
as
begin

select COUNT(*) from Users where LoginId=@loginid and Password=HASHBYTES('SHA2_512',@password+CAST(Salt AS nvarchar(36))) and UserTypeId=1
end

drop procedure spEmpCheckLoginDetails
exec spEmpCheckLoginDetails1 'urmilac','urmila111'

create procedure spManagerCheckLoginDetails
(
 @loginid varchar(40),
 @password varchar(70)
)
as
begin

select COUNT(*) from Users where LoginId=@loginid and Password=HASHBYTES('SHA2_512',@password+CAST(Salt AS nvarchar(36))) and UserTypeId=2
end

drop procedure spManagerCheckLoginDetails

exec spManagerCheckLoginDetails 'manager','manager111'
create procedure spTravelAgentCheckLoginDetails
(
 @loginid varchar(40),
 @password varchar(70)
)
as
begin

select COUNT(*) from Users where LoginId=@loginid and Password=HASHBYTES('SHA2_512',@password+CAST(Salt AS nvarchar(36))) and UserTypeId=3
end
drop procedure spTravelAgentCheckLoginDetails

create procedure spAdminCheckLoginDetails
(
 @loginid varchar(40),
 @password varchar(70)
)
as
begin

select COUNT(*) from Users where LoginId=@loginid and Password=HASHBYTES('SHA2_512',@password+CAST(Salt AS nvarchar(36))) and UserTypeId=4
end

drop procedure spAdminCheckLoginDetails
drop procedure spEmpCheckLoginDetails
exec spManagerCheckLoginDetails 'manager','manager'

select * from users

create procedure spGetTravelRequestDetails
(
  @loginid varchar(20)
)
as
begin
  DECLARE @userid int
  SELECT @userid=UserId From Users  WHERE LoginId=@loginid
  IF @userid IS NOT NULL
	BEGIN
		select * from TravelRequests where Userid=@userid
	END
  ELSE
	BEGIN 
		PRINT 'Cannot insert employee details. Invalid department Id'
	END
END

Drop procedure spGetTravelRequestDetails

exec spGetTravelRequestDetails anjalip

create procedure AddTravelRequest
(
    @requestedate DateTime,
	@fromlocation varchar(20),
	@tolocation varchar(20),
	@fromdate DateTime,
	@todate DateTime, 
	@medium varchar(20),
	@userid int,
	@currentstatus varchar(20),
	@managerstatus varchar(20)
)
as
begin   
		INSERT INTO TravelRequests values(@requestedate,@fromlocation,@tolocation,@fromdate,@todate,@medium,@userid,@currentstatus,@managerstatus)
end

go
drop procedure AddTravelRequest
select * from TravelRequests
exec AddTravelRequest '2020/01/11','pune','ssa','2020/01/11','2020/01/11','car',6,'Pending','-'

--create procedure spCancelTicket1
--(
--  @requestid int
--)
--as
--begin
-- delete from TravelRequests where Requestid=@requestid
--end
--go

create procedure spCancelTicket
(
  @requestid int
)
as
begin
 declare @currentstatus varchar(10)
 select @currentstatus=CurrentStatus from TravelRequests where Requestid=@requestid
 if(@currentstatus='Pending')
 begin
	delete from TravelRequests where Requestid=@requestid
 end 
end
go

select * from TravelRequests
drop procedure spCancelTicket

exec spCancelTicket 16
-----------------------------------------------------------------------Manager stored procedure---------------------------------------------------------------------------------------
create procedure usp_TravelRequests
as
select * from TravelRequests where ManagerStatus='Approved'
go


create procedure getNewRequest
as
select * from TravelRequests where CurrentStatus='Pending' AND ManagerStatus='-'
go

exec getNewRequest
select * from TravelRequests
--approved request procedure
create proc getApprovedRequest
as
select * from TravelRequests where ManagerStatus ='Approved'

exec getApprovedRequest

--rejected request procedure
create proc getRejectedRequest
as
select * from TravelRequests where ManagerStatus ='Rejected'

exec getRejectedRequest

--history
create proc getHistoryRequest
as
select * from TravelRequests where ManagerStatus ='Approved' OR ManagerStatus ='Rejected' 

exec getHistoryRequest

-----------------------------------------------------------------------travel agent stored procedure---------------------------------------------------------------------------------------
Create procedure usp_TravelRequests_Travelagent    
as
 select * from TravelRequests where ManagerStatus ='Approved'
go

create procedure ConfirmedTicket
as
select * from TravelRequests where CurrentStatus='Ticket Confirmed'

exec ConfirmedTicket

create procedure countTicket
as
begin
select count(CurrentStatus) as TotalConfirmed from TravelRequests where CurrentStatus='Ticket Confirmed'
end

exec countTicket

-----------------------------------------------------------------------Admin stored procedure---------------------------------------------------------------------------------------
--create procedure AddEmployee
--(
--	@loginid varchar(20),
--	@password varchar(20),
--	@usertype int,
--	@name varchar(20),
--	@manageruserid int
--)
--as 
--begin
--	INSERT INTO Users values(@loginid,@password,@usertype,@name,@manageruserid)
--end
--go

create procedure AddEmployee
(
	@loginid varchar(40),
	@password varchar(70),
	@usertype int,
	@name varchar(20),
	@manageruserid int
)
as 
begin
 
  DECLARE @salt UNIQUEIDENTIFIER=NEWID()
  
	INSERT INTO Users values(@loginid,HASHBYTES('SHA2_512',@password+CAST(@salt AS nvarchar(36))),@salt,@usertype,@name,@manageruserid)
  END

drop procedure AddEmployee
EXEC AddEmployee 'dikshar','diksha111',1,'Diksha','-'

EXEC AddEmployee 'urmilac','urmila111',1,'Urmila Chaudhri','-'
drop procedure AddEmployee1

create procedure ViewEmpDetails
as
begin
	select * from Users
end
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
create procedure ViewManagerDetails
as
begin
	select * from Users where UserTypeId=2
end
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
create procedure ViewTravelAgentDetails
as
begin
	select * from Users where UserTypeId=3
end
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
exec ViewEmpDetails

---------------------------------------------------------------------------------------------------------------------------------------------------------------------

create procedure getEmployeeDetailsOnly
as
begin
	select * from Users where UserTypeId=1
end

exec getEmployeeDetailsOnly
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
create procedure AssignManager
(
	@userid int,
	@manageruserid int
)
as
begin
	--select @userid=UserId from Users
	--IF @userid IS NOT NULL
	--begin
		update Users set ManagerUserId=@manageruserid where UserId=@userid
	--end
	--ELSE
	--begin
	--	PRINT 'Cannot Assign Manager. Invaild User ID'
	--end
end
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
drop procedure addTravelAgent
create procedure addTravelAgent
(
	@loginid varchar(40),
	@password varchar(70),
	@usertype int,
	@name varchar(20),
	@manageruserid int
)
as 
begin
 
  DECLARE @salt UNIQUEIDENTIFIER=NEWID()
  
	INSERT INTO Users values(@loginid,HASHBYTES('SHA2_512',@password+CAST(@salt AS nvarchar(36))),@salt,@usertype,@name,@manageruserid)
  END

  create procedure addmyusers
(
	@loginid varchar(40),
	@password varchar(70),
	@usertype int,
	@name varchar(20),
	@manageruserid int
)
as 
begin
 
  DECLARE @salt UNIQUEIDENTIFIER=NEWID()
  
	INSERT INTO Users values(@loginid,HASHBYTES('SHA2_512',@password+CAST(@salt AS nvarchar(36))),@salt,@usertype,@name,@manageruserid)
  END
drop procedure addadmin
EXEC addmyusers 'admin','admin111',4,'Admin','-'
EXEC addmyusers 'manager','manager111',2,'Manager','-'
EXEC addmyusers 'travelagent','travel111',3,'Travel Agent','-'
select * from users