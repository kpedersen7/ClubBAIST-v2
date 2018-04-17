CREATE DATABASE ClubBAIST
GO
USE ClubBAIST
GO
CREATE TABLE [MembershipLevel](
	MembershipLevelID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Description varchar(20) NOT NULL,
	Active int NOT NULL
)
GO
CREATE TABLE [User](
	UserID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	UserEmail varchar(50) NOT NULL UNIQUE,
	Password varchar(50) NOT NULL,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Phone varchar(10),
	Salt varchar(255) NOT NULL,
	MembershipLevelID int NOT NULL FOREIGN KEY REFERENCES MembershipLevel(MembershipLevelID),
	Active int NOT NULL
)
GO
CREATE TABLE [Course](
	CourseID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	CourseName varchar(50) NOT NULL,
	ParHole1 int NOT NULL,
	ParHole2 int NOT NULL,
	ParHole3 int NOT NULL,
	ParHole4 int NOT NULL,
	ParHole5 int NOT NULL,
	ParHole6 int NOT NULL,
	ParHole7 int NOT NULL,
	ParHole8 int NOT NULL,
	ParHole9 int NOT NULL,
	ParHole10 int NOT NULL,
	ParHole11 int NOT NULL,
	ParHole12 int NOT NULL,
	ParHole13 int NOT NULL,
	ParHole14 int NOT NULL,
	ParHole15 int NOT NULL,
	ParHole16 int NOT NULL,
	ParHole17 int NOT NULL,
	ParHole18 int NOT NULL,
	CourseRating decimal(5,2) NOT NULL,
	SlopeRating decimal(5,2) NOT NULL,
)
GO
CREATE TABLE [Reservation](
	ReservationID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	UserID int NOT NULL FOREIGN KEY REFERENCES [User](UserID),
	CourseID int NOT NULL FOREIGN KEY REFERENCES [Course](CourseID),
	ReservedTime DateTime NOT NULL,
	NumberHoles int NOT NULL,
	NumberCarts int NOT NULL,
	Player2 varchar(255) NULL,
	Player3 varchar(255) NULL,
	Player4 varchar(255) NULL,
	IsStandingReservation int NOT NULL
)
GO
CREATE TABLE [StandingReservation](
	StandingReservationID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	UserID int NOT NULL FOREIGN KEY REFERENCES [User](UserID),
	CourseID int NOT NULL FOREIGN KEY REFERENCES [Course](CourseID),
	ReservedTime DateTime NOT NULL,
	EndTime DateTime NOT NULL,
	NumberHoles int NOT NULL,
	NumberCarts int NOT NULL,
	Player2 varchar(255) NULL,
	Player3 varchar(255) NULL,
	Player4 varchar(255),
	Approved int NOT NULL,
	Active int NOT NULL,
)
GO
CREATE TABLE [Score](
	ScoreID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	ReservationID int NOT NULL FOREIGN KEY REFERENCES [Reservation](ReservationID),
	UserEmail varchar(50) NOT NULL,
	ScoreHole1 int NULL,
	ScoreHole2 int NULL,
	ScoreHole3 int NULL,
	ScoreHole4 int NULL,
	ScoreHole5 int NULL,
	ScoreHole6 int NULL,
	ScoreHole7 int NULL,
	ScoreHole8 int NULL,
	ScoreHole9 int NULL,
	ScoreHole10 int NULL,
	ScoreHole11 int NULL,
	ScoreHole12 int NULL,
	ScoreHole13 int NULL,
	ScoreHole14 int NULL,
	ScoreHole15 int NULL,
	ScoreHole16 int NULL,
	ScoreHole17 int NULL,
	ScoreHole18 int NULL,
	RoundTotal int NOT NULL,
	HandicapDifferential decimal(4,2) NOT NULL,
)
GO
-----------------USER PROCEDURES
CREATE PROCEDURE InsertUser(@UserEmail varchar(50), @Password varchar(50),@FirstName varchar(50),@LastName varchar(50),@Phone varchar(10), @Salt varchar(255), @MembershipLevelID int) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @UserEmail IS NULL
	RAISERROR('InsertUser - Required Parameter : @UserEmail',16,1)
IF @Password IS NULL
	RAISERROR('InsertUser - Required Parameter : @Password',16,1)
ELSE
	BEGIN
		INSERT INTO [User](UserEmail, Password, FirstName, LastName, Phone, Salt, MembershipLevelID, Active) VALUES (@UserEmail, @Password, @FirstName, @LastName, @Phone, @Salt, @MembershipLevelID, 1)
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('InsertUser - Insert Error at Users Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectUser(@UserEmail varchar(50)) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @UserEmail IS NULL
	RAISERROR('SelectUser - Required Parameter : @UserEmail',16,1)
ELSE
	BEGIN
		SELECT UserID, UserEmail, Password, FirstName, LastName, Phone, Salt, MembershipLevelID FROM [User] WHERE UserEmail = @UserEmail
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('SelectUser - Select Error from Users Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectUserByID(@UserID int) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @UserID IS NULL
	RAISERROR('SelectUserByID - Required Parameter : @UserID',16,1)
ELSE
	BEGIN
		SELECT * FROM [User] WHERE UserID = @UserID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('SelectUserByID - Select Error from Users Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectUserBatch(@UserEmail varchar(50),@FirstName varchar(50),@LastName varchar(50),@Phone varchar(10)) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
	BEGIN
		SELECT UserID, UserEmail, Password, FirstName, LastName, Phone, Salt, MembershipLevelID 
		FROM [User] 
		WHERE Active = 1 
		AND UserEmail LIKE '%'+@UserEmail+'%'
		 OR FirstName LIKE '%'+@FirstName+'%' 
		 OR LastName LIKE '%'+@LastName+'%' 
		 OR Phone LIKE '%'+@Phone+'%' 
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('SelectUserBatch - Select Error from Users Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE UpdateUser(@UserID int, @UserEmail varchar(50), @Password varchar(50),@FirstName varchar(50),@LastName varchar(50),@Phone varchar(10), @Salt varchar(255), @MembershipLevelID int) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @UserID IS NULL
	RAISERROR('UpdateUser - Required Parameter : @UserID',16,1)
ELSE
	BEGIN
		Update [User] 
		SET 
		UserEmail = @UserEmail
		, Password = @Password
		, FirstName = @FirstName
		, LastName = @LastName
		, Phone = @Phone
		, Salt = @Salt
		, MembershipLevelID = @MembershipLevelID
		WHERE UserID = @UserID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('UpdateUser - Update Error at Users Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE DeleteUser(@UserID int) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @UserID IS NULL
	RAISERROR('DeleteUser - Required Parameter : @UserID',16,1)
ELSE
	BEGIN
		Update [User] SET Active = 0 WHERE UserID = @UserID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('DeleteUser - Update Error at Users Table', 16,1)
	END
RETURN @ReturnCode
GO
---------------USER PROCEDURES


---------------RESERVATION PROCEDURES
CREATE PROCEDURE InsertReservation(@UserID int, @CourseId int, @ReservedTime DateTime, @NumberHoles int, @NumberCarts int, @Player2 varchar(255), @Player3 varchar(255),@Player4 varchar(255), @IsStandingReservation int) as
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @UserID IS NULL
	RAISERROR('InsertReservation - Required Parameter : @UserID',16,1)
IF @ReservedTime IS NULL
	RAISERROR('InsertReservation - Required Parameter : @CourseId',16,1)
IF @CourseId IS NULL
	RAISERROR('InsertReservation - Required Parameter : @ReservedTime',16,1)
IF @NumberHoles IS NULL
	RAISERROR('InsertReservation - Required Parameter : @NumberHoles',16,1)
IF @NumberCarts IS NULL
	RAISERROR('InsertReservation - Required Parameter : @NumberCarts',16,1)
ELSE
	BEGIN
		INSERT INTO [Reservation](UserID,CourseID, ReservedTime, NumberHoles, NumberCarts, Player2, Player3, Player4, IsStandingReservation)
		VALUES (@UserID, @CourseId,@ReservedTime,@NumberHoles,@NumberCarts,@Player2, @Player3, @Player4, @IsStandingReservation)
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('InsertReservation - Insert Error at Reservation Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectReservation(@ReservationID int) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @ReservationID IS NULL
	RAISERROR('GetReservation - Required Parameter : @ReservationID',16,1)
ELSE
	BEGIN
		SELECT * FROM [Reservation] WHERE ReservationID = @ReservationID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('GetReservation - Select Error from Reservation Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectReservationBatchForMember(@UserID int, @UserEmail varchar(255)) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @UserID IS NULL
	RAISERROR('GetReservationBatchForMember - Required Parameter : @UserEmail',16,1)
ELSE
	BEGIN
		SELECT * FROM [Reservation] WHERE UserId = @UserID OR Player2 = @UserEmail OR Player3 = @UserEmail OR Player4 = @UserEmail
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('GetReservationBatchForMember - Select Error from Reservation Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectReservationBatchByTimeFrame(@MinDay DateTime, @MaxDay Datetime) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @MinDay IS NULL
	RAISERROR('GetReservationBatchByTimeFrame - Required Parameter : @MinDay',16,1)
IF @MaxDay IS NULL
	RAISERROR('GetReservationBatchByTimeFrame - Required Parameter : @MaxDay',16,1)
ELSE
	BEGIN
		SELECT * 
		FROM [Reservation]
		WHERE ReservedTime BETWEEN @MinDay AND @MaxDay 
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('GetReservationBatchByTimeFrame - Select Error from Reservation Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE UpdateReservation(@ReservationID int, @UserID int, @CourseId int, @ReservedTime DateTime, @NumberHoles int, @NumberCarts int,  @Player2 varchar(255), @Player3 varchar(255),@Player4 varchar(255), @IsStandingReservation int) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @ReservationID IS NULL
	RAISERROR('UpdateReservation - Required Parameter : @ReservationID',16,1)
ELSE
	BEGIN
		Update [Reservation] 
		SET 
		CourseId = @CourseId
		, ReservedTime = @ReservedTime
		, NumberHoles = @NumberHoles
		, NumberCarts = @NumberCarts
		, Player2 = @Player2
		, Player3 = @Player3
		, Player4 = @Player4
		, IsStandingReservation = @IsStandingReservation
		WHERE ReservationID = @ReservationID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('UpdateReservation - Update Error at Reservation Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE DeleteReservation(@ReservationID int) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @ReservationID IS NULL
	RAISERROR('DeleteReservation - Required Parameter : @ReservationID',16,1)
ELSE
	BEGIN
		DELETE FROM [Reservation] WHERE ReservationID = @ReservationID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('DeleteReservation - Delete Error at Reservation Table', 16,1)
	END
RETURN @ReturnCode
GO

-----------------------------STANDING RESERVATION PROCEDURES
CREATE PROCEDURE InsertStandingReservation(@UserID int, @CourseId int, @ReservedTime DateTime, @EndTime DateTime, @NumberHoles int, @NumberCarts int, @Player2 varchar(255), @Player3 varchar(255), @Player4 varchar(255)) as
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @UserID IS NULL
	RAISERROR('InsertStandingReservation - Required Parameter : @UserID',16,1)
IF @ReservedTime IS NULL
	RAISERROR('InsertStandingReservation - Required Parameter : @CourseId',16,1)
IF @CourseId IS NULL
	RAISERROR('InsertStandingReservation - Required Parameter : @ReservedTime',16,1)
IF @NumberHoles IS NULL
	RAISERROR('InsertStandingReservation - Required Parameter : @NumberHoles',16,1)
IF @NumberCarts IS NULL
	RAISERROR('InsertStandingReservation - Required Parameter : @NumberCarts',16,1)
ELSE
	BEGIN
		INSERT INTO [StandingReservation](UserID,CourseID, ReservedTime, EndTime, NumberHoles, NumberCarts, Player2, Player3, Player4, Approved, Active) VALUES (@UserID, @CourseId, @ReservedTime, @EndTime, @NumberHoles, @NumberCarts, @Player2, @Player3, @Player4, 0, 1)
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('InsertStandingReservation - Insert Error at StandingReservation Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectStandingReservations(@Approved int, @Active int) as
DECLARE @ReturnCode INT
SET @ReturnCode = 1
BEGIN
	SELECT * FROM [StandingReservation] WHERE Approved = @Approved AND Active = @Active
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('GetStandingReservations - Select Error at StandingReservation Table', 16,1)
END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectStandingReservation(@StandingReservationID int) as
DECLARE @ReturnCode INT
SET @ReturnCode = 1
BEGIN
	SELECT * FROM [StandingReservation] WHERE StandingReservationID = @StandingReservationID
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('GetStandingReservations - Select Error at StandingReservation Table', 16,1)
END
RETURN @ReturnCode
GO

CREATE PROCEDURE UpdateStandingReservation(@StandingReservationID int, @UserID int, @CourseId int, @ReservedTime DateTime, @EndTime DateTime, @NumberHoles int, @NumberCarts int, @Player2 varchar(255), @Player3 varchar(255), @Player4 varchar(255)) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @StandingReservationID IS NULL
	RAISERROR('UpdateStandingReservation - Required Parameter : @StandingReservationID',16,1)
ELSE
	BEGIN
		Update [StandingReservation] 
		SET 
		CourseId = @CourseId
		, ReservedTime = @ReservedTime
		, EndTime = @EndTime
		, NumberHoles = @NumberHoles
		, NumberCarts = @NumberCarts
		, Player2 = @Player2
		, Player3 = @Player3
		, Player4 = @Player4
		WHERE StandingReservationID = @StandingReservationID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('UpdateStandingReservation - Update Error at Reservation Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE UpdateStandingReservationApproval(@StandingReservationID int, @Approved int, @Active int) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @StandingReservationID IS NULL
	RAISERROR('UpdateStandingReservationApproval - Required Parameter : @StandingReservationID',16,1)
ELSE
	BEGIN
		Update [StandingReservation] 
		SET 
		Approved = @Approved
		, Active = @Active
		WHERE StandingReservationID = @StandingReservationID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('UpdateStandingReservationApproval - Update Error at Reservation Table', 16,1)
	END
RETURN @ReturnCode
GO

-----------------------------COURSE Procedures
CREATE PROCEDURE InsertCourse(@CourseName varchar(50), @Par1 int,@Par2 int,@Par3 int,@Par4 int,@Par5 int,@Par6 int,@Par7 int,@Par8 int,@Par9 int,@Par10 int,@Par11 int,@Par12 int,@Par13 int,@Par14 int,@Par15 int,@Par16 int,@Par17 int,@Par18 int, @CourseRating decimal(5,2), @SlopeRating decimal(5,2)) as
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @CourseName IS NULL
	RAISERROR('InsertCourse - Required Parameter : @CourseName',16,1)
IF @Par1 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par1',16,1)
IF @Par2 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par2',16,1)
IF @Par3 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par3',16,1)
IF @Par4 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par4',16,1)
IF @Par5 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par5',16,1)
IF @Par6 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par6',16,1)
IF @Par7 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par7',16,1)
IF @Par8 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par8',16,1)
IF @Par9 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par9',16,1)
IF @Par10 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par10',16,1)
IF @Par11 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par11',16,1)
IF @Par12 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par12',16,1)
IF @Par13 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par13',16,1)
IF @Par14 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par14',16,1)
IF @Par15 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par15',16,1)
IF @Par16 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par16',16,1)
IF @Par17 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par17',16,1)
IF @Par18 IS NULL
	RAISERROR('InsertCourse - Required Parameter : @Par18',16,1)
IF @CourseRating IS NULL
	RAISERROR('InsertCourse - Required Parameter : @CourseRating',16,1)
IF @SlopeRating IS NULL
	RAISERROR('InsertCourse - Required Parameter : @SlopeRating',16,1)
ELSE
	BEGIN
		INSERT INTO [Course](CourseName, ParHole1,ParHole2,ParHole3,ParHole4,ParHole5,ParHole6,ParHole7,ParHole8,ParHole9,ParHole10,ParHole11,ParHole12,ParHole13,ParHole14,ParHole15,ParHole16,ParHole17,ParHole18, CourseRating, SlopeRating)
		VALUES (@CourseName, @Par1,@Par2,@Par3,@Par4,@Par5,@Par6,@Par7,@Par8,@Par9,@Par10,@Par11,@Par12,@Par13,@Par14,@Par15,@Par16,@Par17,@Par18, @CourseRating, @SlopeRating)
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('InsertCourse - Insert Error at Course Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectCourse(@CourseID int) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @CourseID IS NULL
	RAISERROR('SelectCourse - Required Parameter : @CourseID',16,1)
ELSE
	BEGIN
		SELECT * FROM [Course] WHERE CourseID = @CourseID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('SelectCourse - Select Error at Course Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectAllCourses AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
BEGIN
	SELECT * FROM [Course]
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('SelectCourse - Select Error at Course Table', 16,1)
END
RETURN @ReturnCode
GO

CREATE PROCEDURE UpdateCourse(@CourseID int, @CourseName varchar(50), @Par1 int,@Par2 int,@Par3 int,@Par4 int,@Par5 int,@Par6 int,@Par7 int,@Par8 int,@Par9 int,@Par10 int,@Par11 int,@Par12 int,@Par13 int,@Par14 int,@Par15 int,@Par16 int,@Par17 int,@Par18 int, @CourseRating decimal(5,2), @SlopeRating decimal(5,2)) as
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @CourseID IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @CourseID',16,1)
IF @CourseName IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @CourseName',16,1)
IF @Par1 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par1',16,1)
IF @Par2 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par2',16,1)
IF @Par3 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par3',16,1)
IF @Par4 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par4',16,1)
IF @Par5 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par5',16,1)
IF @Par6 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par6',16,1)
IF @Par7 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par7',16,1)
IF @Par8 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par8',16,1)
IF @Par9 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par9',16,1)
IF @Par10 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par10',16,1)
IF @Par11 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par11',16,1)
IF @Par12 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par12',16,1)
IF @Par13 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par13',16,1)
IF @Par14 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par14',16,1)
IF @Par15 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par15',16,1)
IF @Par16 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par16',16,1)
IF @Par17 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par17',16,1)
IF @Par18 IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @Par18',16,1)
IF @CourseRating IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @CourseRating',16,1)
IF @SlopeRating IS NULL
	RAISERROR('UpdateCourse - Required Parameter : @SlopeRating',16,1)
ELSE
	BEGIN
		UPDATE [Course]
		SET CourseName= @CourseName
		,ParHole1 = @Par1
		,ParHole2 = @Par2
		,ParHole3 = @Par3
		,ParHole4 = @Par4
		,ParHole5 = @Par5
		,ParHole6 = @Par6
		,ParHole7 = @Par7
		,ParHole8 = @Par8
		,ParHole9 = @Par9
		,ParHole10 = @Par10
		,ParHole11 = @Par11
		,ParHole12 = @Par12
		,ParHole13 = @Par13
		,ParHole14 = @Par14
		,ParHole15 = @Par15
		,ParHole16 = @Par16
		,ParHole17 = @Par17
		,ParHole18 = @Par18
		,CourseRating = @CourseRating
		,SlopeRating = @SlopeRating
		WHERE CourseID = @CourseID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('UpdateCourse - Update Error at Course Table', 16,1)
	END
RETURN @ReturnCode
GO

---------------------------MEMBERSHIP LEVEL PROCEDURES
CREATE PROCEDURE InsertMembershipLevel(@Description varchar(50)) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @Description IS NULL
	RAISERROR('InsertMembershipLevel - Required Parameter : @Description',16,1)
ELSE
	BEGIN
		INSERT INTO [MembershipLevel](Description, Active) VALUES (@Description, 1)
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('InsertMembershipLevel - Insert Error at MembershipLevel Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectMembershipLevel(@MembershipLevelID int) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @MembershipLevelID IS NULL
	RAISERROR('SelectMembershipLevel - Required Parameter : @MembershipLevel',16,1)
ELSE
	BEGIN
		SELECT * FROM [MembershipLevel] WHERE MembershipLevelID = @MembershipLevelID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('SelectMembershipLevel - Select Error at MembershipLevel Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectMembershipLevels AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
BEGIN
	SELECT * FROM [MembershipLevel]
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('SelectMembershipLevels - Select Error at MembershipLevel Table', 16,1)
END
RETURN @ReturnCode
GO

CREATE PROCEDURE UpdateMembershipLevel(@MembershipLevelID int, @Description varchar(50), @Active int) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @MembershipLevelID IS NULL
	RAISERROR('UpdateMembershipLevel - Required Parameter : @Description',16,1)
IF @Description IS NULL
	RAISERROR('UpdateMembershipLevel - Required Parameter : @Description',16,1)
ELSE
	BEGIN
		UPDATE [MembershipLevel] SET Description = @Description, Active = @Active WHERE MembershipLevelID = @MembershipLevelID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('UpdateMembershipLevel - Update Error at MembershipLevel Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE DeleteMembershipLevel(@MembershipLevelID int) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @MembershipLevelID IS NULL
	RAISERROR('DeleteMembershipLevel - Required Parameter : @Description',16,1)
ELSE
	BEGIN
		UPDATE [MembershipLevel] SET Active = 0 WHERE MembershipLevelID = @MembershipLevelID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('DeleteMembershipLevel - Delete Error at MembershipLevel Table', 16,1)
	END
RETURN @ReturnCode
GO

----------------------SCORE PROCEDURES
CREATE PROCEDURE InsertScore(@ReservationID int, @UserEmail varchar(255) ,@Score1 int,@Score2 int,@Score3 int,@Score4 int,@Score5 int,@Score6 int,@Score7 int,@Score8 int,@Score9 int,@Score10 int,@Score11 int,@Score12 int,@Score13 int,@Score14 int,@Score15 int,@Score16 int,@Score17 int,@Score18 int, @RoundTotal int, @HandicapDifferential decimal(4,2)) as
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @ReservationID IS NULL
	RAISERROR('InsertScore - Required Parameter : @ReservationID',16,1)
IF @UserEmail IS NULL
	RAISERROR('InsertScore - Required Parameter : @UserEmail',16,1)
ELSE
	BEGIN
		INSERT INTO [Score](ReservationID, UserEmail, ScoreHole1,ScoreHole2,ScoreHole3,ScoreHole4,ScoreHole5,ScoreHole6,ScoreHole7,ScoreHole8,ScoreHole9,ScoreHole10,ScoreHole11,ScoreHole12,ScoreHole13,ScoreHole14,ScoreHole15,ScoreHole16,ScoreHole17,ScoreHole18, RoundTotal, HandicapDifferential)
		VALUES (@ReservationID, @UserEmail,@Score1 ,@Score2 ,@Score3 ,@Score4 ,@Score5 ,@Score6 ,@Score7 ,@Score8 ,@Score9 ,@Score10 ,@Score11 ,@Score12 ,@Score13 ,@Score14 ,@Score15 ,@Score16 ,@Score17 ,@Score18, @RoundTotal, @HandicapDifferential)
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('InsertScore - Insert Error at Score Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectScores(@UserEmail varchar(255)) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @UserEmail IS NULL
	RAISERROR('SelectScores - Required Parameter : @UserEmail',16,1)
ELSE
	BEGIN
		SELECT * FROM [Score]
		WHERE UserEmail = @UserEmail
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('SelectScores - Select Error at Score Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectScoresForReservation(@ReservationID int) AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
IF @ReservationID IS NULL
	RAISERROR('SelectScores - Required Parameter : @ReservationID',16,1)
ELSE
	BEGIN
		SELECT * FROM [Score] 
		WHERE ReservationID = @ReservationID
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('SelectScoresForReservation - Select Error at Score Table', 16,1)
	END
RETURN @ReturnCode
GO

CREATE PROCEDURE SelectAllScores AS
DECLARE @ReturnCode INT
SET @ReturnCode = 1
BEGIN
	SELECT * FROM [Score]
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('SelectAllScores - Select Error at Score Table', 16,1)
END
RETURN @ReturnCode
GO
--------------------------TEST DATA-----------------------------------
INSERT INTO [MembershipLevel](Description, Active) VALUES ('ADMIN', 1)
INSERT INTO [MembershipLevel](Description, Active) VALUES ('Gold', 1)
INSERT INTO [MembershipLevel](Description, Active) VALUES ('Silver', 1)
INSERT INTO [MembershipLevel](Description, Active) VALUES ('Bronze', 1)
GO
INSERT INTO [Course](CourseName, ParHole1,ParHole2,ParHole3,ParHole4,ParHole5,ParHole6,ParHole7,ParHole8,ParHole9,ParHole10,ParHole11,ParHole12,ParHole13,ParHole14,ParHole15,ParHole16,ParHole17,ParHole18,CourseRating, SlopeRating)
VALUES('Sweaty Pines', 3,4,5,4,3,4,5,4,3,4,5,5,4,3,4,5,3,3, 70, 128)
GO
INSERT INTO [User](UserEmail, Password,FirstName, LastName,Phone, Salt, MembershipLevelID, Active)
VALUES('admin', 'Kr2WN9ExfdIEc6w1yIx7vXL0oqw=', 'Admin', 'Bro', '1111111111', 'ZXlmPD8=', 1, 1)
INSERT INTO [User](UserEmail, Password, FirstName,LastName, Phone, Salt, MembershipLevelID, Active)
VALUES('jeff@goldblum.com', '/lnDs0CJaBEZ6mqtWFCgeFZjZu0=', 'Jeff','Goldblum','7808008000','2sqCAYA=', 2, 1)
INSERT INTO [User](UserEmail, Password, FirstName,LastName, Phone, Salt, MembershipLevelID, Active)
VALUES('sarah@silverman.com', 'MTXrHPsJnwBzUXTMDxZIoshJK+Y=', 'Sarah','Silverman','7807007000','HWQRaog==', 3, 1)
GO
INSERT INTO [Reservation](UserID, CourseID, ReservedTime, NumberHoles,NumberCarts,Player2,Player3,Player4,IsStandingReservation)
VALUES(2,1,'2018-04-20 08:00:00.000',1,2,'sarah@silverman.com','','',0)
INSERT INTO [Reservation](UserID, CourseID, ReservedTime, NumberHoles,NumberCarts,Player2,Player3,Player4,IsStandingReservation)
VALUES(2,1,'2018-04-10 09:00:00.000',2,1,'','','',0)
INSERT INTO [Reservation](UserID, CourseID, ReservedTime, NumberHoles,NumberCarts,Player2,Player3,Player4,IsStandingReservation)
VALUES(2,1,'2018-04-11 10:00:00.000',3,2,'sarah@silverman.com','','',0)
INSERT INTO [Reservation](UserID, CourseID, ReservedTime, NumberHoles,NumberCarts,Player2,Player3,Player4,IsStandingReservation)
VALUES(2,1,'2018-04-12 11:00:00.000',2,1,'','','',0)
INSERT INTO [Reservation](UserID, CourseID, ReservedTime, NumberHoles,NumberCarts,Player2,Player3,Player4,IsStandingReservation)
VALUES(2,1,'2018-04-14 12:00:00.000',1,2,'sarah@silverman.com','','',0)
INSERT INTO [Reservation](UserID, CourseID, ReservedTime, NumberHoles,NumberCarts,Player2,Player3,Player4,IsStandingReservation)
VALUES(3,1,'2018-04-15 08:00:00.000',1,2,'jeff@goldblum.com','','',0)
INSERT INTO [Reservation](UserID, CourseID, ReservedTime, NumberHoles,NumberCarts,Player2,Player3,Player4,IsStandingReservation)
VALUES(3,1,'2018-04-22 09:00:00.000',2,1,'','','',0)
INSERT INTO [Reservation](UserID, CourseID, ReservedTime, NumberHoles,NumberCarts,Player2,Player3,Player4,IsStandingReservation)
VALUES(3,1,'2018-04-21 10:00:00.000',3,2,'jeff@goldblum.com','','',0)
INSERT INTO [Reservation](UserID, CourseID, ReservedTime, NumberHoles,NumberCarts,Player2,Player3,Player4,IsStandingReservation)
VALUES(3,1,'2018-04-09 11:00:00.000',2,1,'','','',0)
INSERT INTO [Reservation](UserID, CourseID, ReservedTime, NumberHoles,NumberCarts,Player2,Player3,Player4,IsStandingReservation)
VALUES(3,1,'2018-04-08 12:00:00.000',1,2,'jeff@goldblum.com','','',0)

------------------------/TEST DATA------------------------------------