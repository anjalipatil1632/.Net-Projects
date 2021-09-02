create database Sprint2db

use sprint2db

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

insert into TravelRequests(FromLocation,ToLocation,Medium,UserId,ManagerId) values('Mumbai','Pune','AiroPlane',2,'manager')
insert into TravelRequests(FromLocation,ToLocation,Medium,UserId,ManagerId) values('Mumbai','Pune','Train',2,'manager')
insert into TravelRequests(FromLocation,ToLocation,Medium,UserId,ManagerId) values('Mumbai','Pune','Taxy',3,'manager')
insert into TravelRequests(FromLocation,ToLocation,Medium,UserId,ManagerId) values('Mumbai','Pune','Train',3,'manager')
insert into TravelRequests(FromLocation,ToLocation,Medium,UserId,ManagerId) values('Mumbai','Pune','Airoplane',3,'manager')
insert into TravelRequests(FromLocation,ToLocation,FromDate,ToDate,Medium,UserId,ManagerId,CurrentStatus,ManagerStatus) values('Mumbai','Pune',10-01-2020,11-01-2020,'Airoplane',3,'manager','Pending','Approved')
insert into TravelRequests(FromLocation,ToLocation,FromDate,ToDate,Medium,UserId,ManagerId,CurrentStatus,ManagerStatus) values('Mumbai','Pune',10-01-2020,11-01-2020,'Airoplane',3,'manager','Pending','Approved')
insert into TravelRequests(FromLocation,ToLocation,FromDate,ToDate,Medium,UserId,ManagerId,CurrentStatus,ManagerStatus) values('Mumbai','Pune',10-01-2020,11-01-2020,'Airoplane',3,'manager','Pending','Approved')
insert into TravelRequests(FromLocation,ToLocation,FromDate,ToDate,Medium,UserId,ManagerId,CurrentStatus,ManagerStatus) values('Mumbai','Pune',10-01-2020,11-01-2020,'Airoplane',19,20,'Pending','Approved')
insert into TravelRequests(FromLocation,ToLocation,FromDate,ToDate,Medium,UserId,ManagerId,CurrentStatus,ManagerStatus) values('Mumbai','Pune',10-01-2020,11-01-2020,'Airoplane',19,20,'Pending','Approved')
insert into TravelRequests(FromLocation,ToLocation,FromDate,ToDate,Medium,UserId,ManagerId,CurrentStatus,ManagerStatus) values('Mumbai','Pune',10-01-2020,11-01-2020,'Airoplane',19,20,'Pending','Approved')
insert into TravelRequests(FromLocation,ToLocation,FromDate,ToDate,Medium,UserId,ManagerId,CurrentStatus,ManagerStatus) values('Mumbai','Pune',10-01-2020,11-01-2020,'Airoplane',19,20,'Pending','Approved')
insert into TravelRequests(FromLocation,ToLocation,FromDate,ToDate,Medium,UserId,ManagerId,CurrentStatus,ManagerStatus) values('Mumbai','Pune',10-01-2020,11-01-2020,'Airoplane',19,20,'Pending','Approved')
insert into TravelRequests(FromLocation,ToLocation,FromDate,ToDate,Medium,UserId,ManagerId,CurrentStatus,ManagerStatus) values('Mumbai','Pune',10-01-2020,11-01-2020,'Airoplane',19,20,'Pending','Approved')
insert into TravelRequests(FromLocation,ToLocation,FromDate,ToDate,Medium,UserId,ManagerId,CurrentStatus,ManagerStatus) values('Mumbai','Pune',10-01-2020,11-01-2020,'Airoplane',19,20,'Pending','-')
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
  ManagerUserId  INt,
  Ticket_Count int DEFAULT '-'
)

insert into Users(LoginId,Password,UserTypeId,Name,ManagerUserId,Ticket_Count) values('travelagent','travel111',3,'Holly Pol','100',10)
insert into Users(LoginId,Password,UserTypeId,Name,ManagerUserId) values('anjalip','anjali11',1,'Anjali Patil','100')
insert into Users(LoginId,Password,UserTypeId,Name,ManagerUserId) values('snehalb','snehal11',1,'Snehal Barge','100')
insert into USers(LoginId,Password,UserTypeId,Name,ManagerUserId) values ('admin','admin111',4,'Kamal Pratabh','101')
insert into USers(LoginId,Password,UserTypeId,Name,ManagerUserId) values ('manager','manager111',2,'Sangana Singh','-')
insert into Users(LoginId,Password,UserTypeId,Name,ManagerUserId) values('dikshar','diksha11',1,'Diksha Rambaad','10')
insert into Users(LoginId,Password,UserTypeId,Name,ManagerUserId) values('tanvi','tanvi111',1,'Sai Rambaad',5)
insert into Users(LoginId,Password,UserTypeId,Name,ManagerUserId,Ticket_Count) values('travelagent','travel111',3,'Hol Pol','100',10)
truncate table Users

select * from users

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

ALTER TABLE TravelRequests 
ADD Constraint FK_userID_TravelRequests_Users
FOREiGN KEY(UserId) REFERENCES Users(UserId)
on update CASCADE
on delete CASCADE

ALTER TABLE Users 
ADD Constraint FK_userTypeID_Users_UserType
FOREiGN KEY(UserTypeId) REFERENCES UserType(UserTypeId)
on update CASCADE
on delete CASCADE

EXEC SP_HELP Users


alter table TravelRequests alter column  ManagerId nvarchar(50)
--------------------------------------------------Manager procedure-----------------------------------------------

create proc spGetNewRequests
@managerid nvarchar(50)
as
begin   declare @managerid1 varchar(10)
        select @managerid1=Userid from users where LoginId=@managerid
        select * from TravelRequests where ManagerId=@managerid1 and ManagerStatus='-'
end
--drop proc spGetNewRequests
exec spGetNewRequests 'manager'
select * from Users
select * from TravelRequests

--sp for manager to get new request
create proc spGetNewRequest
@managerid nvarchar(50)
as
select * from TravelRequests where ManagerId=@managerid and ManagerStatus='-'

--drop proc spGetNewRequest
exec spGetNewRequest 'manager'



--sp for updating manager status //UpdateToApprove httpput
create proc spUpdateApproveRequest
@RequestId int,
@ManagerStatus varchar(10)
as
update TravelRequests set ManagerStatus=@ManagerStatus where RequestId=@RequestId

--drop proc spUpdateApproveRequest
exec spUpdateApproveRequest 1
Select * from TravelRequests

-- sp for rejecting manager request  //UpdateToReject httpput
create proc spUpdateRejectRequest
@RequestId int
as
update TravelRequests set ManagerStatus='Rejected' where RequestId=@RequestId

exec spUpdateRejectRequest 2

-- sp retrieve Approved Request  //Approve action httpget
create proc spApprovedRequest
as
select * from TravelRequests where ManagerStatus='Approved'

exec spApprovedRequest


-- sp retrieve Rejected request  // Reject action httpget
create proc spRejectedRequest
as
select * from TravelRequests where ManagerStatus='Rejected'

exec spRejectedRequest

--sp to retrieved value based on id
create proc spGetRecordsById
@RequestId int
as
select * from TravelRequests where RequestId=@RequestId

exec spGetRecordsById 2

select * from TravelRequests

--sp for history records
create proc spHistoryRecords
as
select * from TravelRequests where ManagerStatus='Approved' or ManagerStatus='Rejected'

drop proc spHistoryRecords
exec spHistoryRecords


-----------------------------------------------------------------------Employees stored procedure---------------------------------------------------------------------------------------
create procedure spEmpCheckLoginDetails
(
 @loginid varchar(40),
 @password varchar(70)
)
as
begin

select COUNT(*) from Users where LoginId=@loginid and Password=HASHBYTES('SHA2_512',@password+CAST(Salt AS nvarchar(36))) and UserTypeId=1
end

--drop procedure spEmpCheckLoginDetails
exec spEmpCheckLoginDetails 'urmilac','urmila111'

--sp for manager login
create procedure spManagerCheckLoginDetails
(
 @loginid varchar(40),
 @password varchar(70)
)
as
begin

select COUNT(*) from Users where LoginId=@loginid and Password=HASHBYTES('SHA2_512',@password+CAST(Salt AS nvarchar(36))) and UserTypeId=2
end

--drop procedure spManagerCheckLoginDetails

exec spManagerCheckLoginDetails 'manager','manager111'

--sp for travel agent login
create procedure spTravelAgentCheckLoginDetails
(
 @loginid varchar(40),
 @password varchar(70)
)
as
begin

select COUNT(*) from Users where LoginId=@loginid and Password=HASHBYTES('SHA2_512',@password+CAST(Salt AS nvarchar(36))) and UserTypeId=3
end
--drop procedure spTravelAgentCheckLoginDetails

--sp for admin login
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

-- sp to get travel requests for employee
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
		PRINT 'Cannot insert employee details. Invalid Id'
	END
END

Drop procedure spGetTravelRequestDetails

exec spGetTravelRequestDetails snehalb

-- sp to add request for employee
create procedure AddTravelRequest
(
--@requestedate DateTime,
	@fromlocation varchar(20),
	@tolocation varchar(20),
	@fromdate DateTime,
	@todate DateTime, 
	@medium varchar(20),
	@userid int
)
as
begin   declare @managerid varchar(10)
        select @managerid=ManagerUserId from users where UserId=@userid
		INSERT INTO TravelRequests(fromlocation,tolocation,fromdate,todate,medium,userid,ManagerId) values(@fromlocation,@tolocation,@fromdate,@todate,@medium,@userid,@managerid)
end

drop procedure AddTravelRequest
select * from TravelRequests
exec AddTravelRequest 'Mumbai','Pune','2020/01/11','2020/01/11','car',7
exec AddTravelRequest 'Mumbai','Pune','2020/01/11','2020/01/11','car',7
select * from users

-- sp to cancel ticket
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

exec spCancelTicket 31

use Sprint2db
--------------------------------
create procedure viewCancel
(
  @loginid varchar(20)
)
as
begin
  DECLARE @userid int
  SELECT @userid=UserId From Users  WHERE LoginId=@loginid
  IF @userid IS NOT NULL
	BEGIN
		select * from TravelRequests where Userid=@userid and CurrentStatus='Pending'
	END
  ELSE
	BEGIN 
		PRINT 'Cannot insert employee details. Invalid Id'
	END
END

drop proc viewCancel
exec viewCancel 'employee'
select * from TravelRequests
truncate table TravelRequests
----------------------------------------------------Admin procedures-------------------------------------------------------------------
select * from Users
--------------------sp for Add employee 
create procedure AddEmployee
(
	@loginid varchar(40),
	@password varchar(70),
	@name varchar(20)
)
as 
begin
 
  DECLARE @salt UNIQUEIDENTIFIER=NEWID()
  
	INSERT INTO Users(LoginId,Password,Salt,UserTypeId,Name,ManagerUserId) values(@loginid,HASHBYTES('SHA2_512',@password+CAST(@salt AS nvarchar(36))),@salt,1,@name,'-')
  END

drop procedure AddEmployee

exec AddEmployee 'tan','tan111','Tan D'

------------------ sp of add emp of encryption
create procedure AddEmployee1
(
	@loginid varchar(40),
	@password varchar(70),
	
	@name varchar(20)
	
)
as 
begin
 
  DECLARE @salt UNIQUEIDENTIFIER=NEWID()
  
	INSERT INTO Users(loginid,password,usertypeid,name,ManagerUserId) values(@loginid,CONVERT([varchar](256), HASHBYTES('SHA2_256', @password), 2) ,1,@name,'-')
  END

drop proc AddEmployee1
  exec AddEmployee1 'nandini','nandini111',1,'Nandini Patil',0
    exec AddEmployee1 'nandini123','nandini123','Nandini '
------------------------------------

create procedure MyUser
(
	@loginid varchar(40),
	@password varchar(70),
	@usertypeid varchar(70),
	@name varchar(20)
	
)
as 
begin
 
  DECLARE @salt UNIQUEIDENTIFIER=NEWID()
  
	INSERT INTO Users(loginid,password,usertypeid,name,ManagerUserId) values(@loginid,CONVERT([varchar](256), HASHBYTES('SHA2_256', @password), 2) ,@usertypeid,@name,'-')
  END

exec MyUser 'admin1','admin111','4','Admin'
select * from Users
---------------- sp for view employee details
create procedure ViewEmpDetails
as 
begin
	select UserId,LoginId,Password,UserTypeId,Name,ManagerUserId from Users where UserTypeId=1 
end

drop procedure ViewEmpDetails

exec ViewEmpDetails

--------------- sp for update employee 
create procedure UpdateEmp
(
	@userid int,
	@loginid varchar(40),
	@password varchar(70),
	@name varchar(20)
)
as
begin
	DECLARE @salt UNIQUEIDENTIFIER=NEWID()
		
		UPDATE Users set LoginId=@loginid, Password=CONVERT([varchar](256), HASHBYTES('SHA2_256', @password), 2), Name=@name where UserId=@userid
  
end

drop procedure UpdateEmp

exec UpdateEmp 30,'ratan','ratan111','Shlok Bhatnagar'

------------------- sp for delete employee
create procedure DeleteEmp
(
	@userid int
)
as
begin
	DELETE from Users where UserId=@userid
end

exec DeleteEmp 12

-------------------- sp for get employee details
create procedure GetEmpDetails
(
	@userid int
)
as 
begin
	select UserId,LoginId,Password,Name from Users where UserId=@userid
end

drop procedure GetEmpDetails

exec GetEmpDetails 30

-------------------- sp for assign manager
create procedure AssignManager
(
	@userid int,
	@manageruserid int
)
as
begin
		update Users set ManagerUserId=@manageruserid where UserId=@userid
end

exec AssignManager 14,28

------------------- sp for change manager
create procedure ChangeManager
(
	@userid int,
	@manageruserid int
)
as
begin
		update Users set ManagerUserId=@manageruserid where UserId=@userid
end

exec ChangeManager 15,28

------------------- sp for view manager details
create procedure ViewManagerDetails
as
begin
	select UserId,LoginId,Password,UserTypeId,Name,ManagerUserId from Users where UserTypeId=2
end

drop procedure ViewManagerDetails

exec ViewManagerDetails 

------------------- sp for add manager details
create procedure addmanager
(
	@loginid varchar(40),
	@password varchar(70),
	@name varchar(20)
)
as
begin
	DECLARE @salt UNIQUEIDENTIFIER=NEWID()

	INSERT INTO Users(LoginId,Password,UserTypeId,Name,ManagerUserId) values(@loginid,CONVERT([varchar](256), HASHBYTES('SHA2_256', @password), 2),2,@name,'-')
		
end

drop procedure addmanager

exec addmanager 'abc','abc111','ABC'

--------------------- sp for update manager
create procedure UpdateManager
(
	@userid int,
	@loginid varchar(40),
	@password varchar(70),
	@name varchar(20)
)
as
begin
	DECLARE @salt UNIQUEIDENTIFIER=NEWID()

		UPDATE Users SET LoginId=@loginid, Password=CONVERT([varchar](256), HASHBYTES('SHA2_256', @password), 2), Name=@name where UserId=@userid 
end

drop proc UpdateManager
exec UpdateManager 30,'shlokB','sb','Shlok Bhatnagar'

------------------------- sp for get manager details
create procedure GetManager
(
	@userid int
)
as 
begin
	select UserId,LoginId,Password,Name from Users where UserId=@userid
end

exec GetManager 30

------------------------ sp for get user details
create procedure GetUser
(
	@userid int
)
as 
begin
	select UserId,ManagerUserId from Users where UserId=@userid
end

exec GetUser 30

------------------------ sp for delete manager 
create procedure DeleteManager
(
	@userid int
)
as
begin
	DELETE from Users where UserId=@userid
end

exec DeleteManager 27

----------------------- sp for userdetails
create procedure UserDetails
as 
begin
	select UserId,LoginId,Password,UserTypeId,Name,ManagerUserId from Users 
end

exec UserDetails

---------------------- sp for getuser1
create procedure GetUser1
(
	@userid int
)
as 
begin
	select UserId,LoginId,Password,UserTypeId,Name,ManagerUserId from Users where UserId=@userid
end

exec GetUser1 14

-------------------- sp for view travel agent details
create procedure ViewTravelAgentDetails
as
begin
	select UserId,LoginId,Password,UserTypeId,Name,ManagerUserId from Users where UserTypeId=3
end

exec ViewTravelAgentDetails


--------------------------- sp for add travel agent
create procedure addtravelagent
(
	@loginid varchar(40),
	@password varchar(70),
	@name varchar(20)
)
as
begin
	DECLARE @salt UNIQUEIDENTIFIER=NEWID()

	INSERT INTO Users(LoginId,Password,UserTypeId,Name,ManagerUserId,Ticket_Count) values(@loginid,CONVERT([varchar](256), HASHBYTES('SHA2_256', @password), 2),3,@name,'-',10)
		
end

drop proc addtravelagent
exec addtravelagent 'travel','travel111','Travel Agent'

-------------- sp to get travel agent details
create procedure GetTravelAgent
(
	@userid int
)
as 
begin
	select UserId,LoginId,Password,Name from Users where UserId=@userid
end

exec GetTravelAgent 42

------------------ spp for update travel agent
create procedure UpdateTravelAgent
(
	@userid int,
	@loginid varchar(40),
	@password varchar(70),
	@name varchar(20)
)
as
begin
	DECLARE @salt UNIQUEIDENTIFIER=NEWID()

		UPDATE Users SET LoginId=@loginid, Password=CONVERT([varchar](256), HASHBYTES('SHA2_256', @password), 2), Name=@name where UserId=@userid 
end

drop proc UpdateTravelAgent
exec UpdateTravelAgent 42,'travel123','travel111','T Agent'

----------------------- sp for delete travel agent
create procedure DeleteTravelAgent
(
	@userid int
)
as
begin
	DELETE from Users where UserId=@userid
end

exec DeleteTravelAgent 42
----------------------------------------------------Travel agent procedure---------------------------------------------------------------
-------------------- sp for get travel request details
Create procedure usp_TravelRequests_Travelagent    
as
 select * from TravelRequests where ManagerStatus='Approved' AND CurrentStatus='Pending' OR CurrentStatus='Not Available'
go
drop procedure usp_TravelRequests_Travelagent 

----------------- sp for  get confirm ticket
create procedure ConfirmedTicket
as
select * from TravelRequests where CurrentStatus='Ticket Confirmed'

exec usp_TravelRequests_Travelagent
exec ConfirmedTicket
exec getConfirmedRequest

------------- sp for change status  UpdateEmp
create procedure ChangeTravelStatus
(
 @RequestId int,
 @CurrentStatus varchar(40)
)
as
	begin
		UPDATE TravelRequests set CurrentStatus=@CurrentStatus where RequestId=@RequestId
	end
-----------------------

create procedure ChangeTravelStatus1
(
 @RequestId int,
 @CurrentStatus varchar(40),
 @LoginId nvarchar(50)
)
as
	begin
		UPDATE TravelRequests set CurrentStatus=@CurrentStatus where RequestId=@RequestId
		if(@CurrentStatus='Ticket Confirmed')
		begin 
		    Update Users set Ticket_Count=(Ticket_Count-1) where LoginId=@LoginId 
		end
	end

select * from Users
exec ChangeTravelStatus1 27,'Not Available','travelagent'
-------------------sp for get details of requests
create procedure GetDetails
(
@RequestId int
)
as
begin
	Select * from TravelRequests where RequestId=@RequestId
end

exec GetDetails 1
select * from TravelRequests

----------------- sp to reduce count 


create proc countTicket
@LoinId nvarchar(50)
as
begin
Declare @count int
Declare @count1 int
Declare @result int
    select @count=Ticket_Count from Users where LoginId=@LoinId
	select @count1=COUNT(CurrentStatus) from TravelRequests where CurrentStatus='Ticket Confirmed'
	if(@count>0  )
	begin
	   update Users set Ticket_Count=(@count-1) where LoginId=@LoinId 
	end
	else
	begin
	   print 'No tickets availabel'
	end
end

drop proc countTicket
exec countTicket 'travelagent'
select * from Users


--------------------- sp get count form user
create proc getCount
@LoginId nvarchar(50)
as
select * from Users where LoginId=@LoginId

drop proc getCount
exec getCount 'travelagent'

---------------
create proc getCount1
@LoginId nvarchar(50)
as
select Ticket_Count from Users where LoginId=@LoginId

drop proc getCount1
exec getCount1 'travel'

--------------------
