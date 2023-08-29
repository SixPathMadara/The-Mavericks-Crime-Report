USE Beta;

-- Create Table Users
CREATE TABLE Users
(
	 UserID INT IDENTITY(1,1) NOT NULL,
	 UserName VARCHAR(255) NOT NULL,
	 UserFirstName VARCHAR(255),
	 UserSurname VARCHAR(255),
	 UserEmail VARCHAR(255) UNIQUE NOT NULL,
	 UserPassword VARCHAR(255) NOT NULL,
	 IsOptedIn BIT NOT NULL DEFAULT 1,
	 Latitude DECIMAL(9,6),     -- Store user's latitude
	 Longitude DECIMAL(9,6),    -- Store user's longitude
	 CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), 
	 PRIMARY KEY (UserID)
);

-- Create Table CrimeTypes 
CREATE TABLE CrimeTypes 
(
	TypeID INT IDENTITY(1,1) NOT NULL,
	CrimeType VARCHAR(12) NOT NULL,
	PRIMARY KEY (TypeID)
);

-- Create Table CrimeReports
CREATE TABLE CrimeReports
(
	ReportID INT IDENTITY(1,1) NOT NULL,
	UserID INT NOT NULL,
	TypeID INT NOT NULL,
	CrimeDescription VARCHAR(2000),
	ReportDate DATE,
	Latitude DECIMAL(9,6),    -- Store latitude of the crime report location
	Longitude DECIMAL(9,6),   -- Store longitude of the crime report location
	CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	PRIMARY KEY (ReportID),
	FOREIGN KEY (UserID) REFERENCES Users(UserID),
	FOREIGN KEY (TypeID) REFERENCES CrimeTypes(TypeID)
);

-- Create Table Attachments
CREATE TABLE Attachments
(
    AttachmentID INT IDENTITY(1,1) NOT NULL,
    ReportID INT NOT NULL,
    FileType VARCHAR(10) NOT NULL,
    FileContent VARBINARY(MAX) NOT NULL,
    PRIMARY KEY (AttachmentID),
    FOREIGN KEY (ReportID) REFERENCES CrimeReports(ReportID)
)

--Create Table Notifications
CREATE TABLE Notifications
(
	NotificationID INT IDENTITY(1,1) NOT NULL,
	SenderUserID INT NOT NULL,
	NotificationContent TEXT NOT NULL, --This can store whatever you want as text basicall a notification
	CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	PRIMARY KEY (NotificationID),
	FOREIGN KEY (SenderUserID) REFERENCES Users(UserID)
);

--Create Bridging table UserNotifications
CREATE TABLE UserNotifications
(
	UserNotificationID INT IDENTITY(1,1) NOT NULL,
	UserID INT NOT NULL,
	NotificationID INT NOT NULL,
	IsRead BIT NOT NULL DEFAULT 0,
	PRIMARY KEY (UserNotificationID),
	FOREIGN KEY (UserID) REFERENCES Users(UserID),
	FOREIGN KEY (NotificationID) REFERENCES Notifications(NotificationID)
);