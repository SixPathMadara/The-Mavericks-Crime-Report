Use Prototype1;

Create Table Users
(
	 UserID INT NOT NULL,
	 UserName VARCHAR(255) NOT NULL,
	 UserFirstName VARCHAR(255),
	 UserSurname VARCHAR(255),
	 UserEmail VARCHAR(255) UNIQUE NOT NULL,
	 UserPassword VARCHAR(16) NOT NULL,
	 PRIMARY KEY (UserID)
);

Create Table CrimeTypes 
(
	TypeID INT NOT NULL,
	Crimetype VARCHAR(12) NOT NULL,
	PRIMARY KEY (TypeID)
);

Create Table CrimeLocation
(
	locID INT NOT NULL,
	longitude DOUBLE NOT NULL,
	latitude DOUBLE NOT NULL
);

Create Table CrimeReports
(
	
	ReportID INT NOT NULL,
	UserID INT NOT NULL,
	TypeID INT NOT NULL,
	CrimeDescription VARCHAR(2000),
	LocID INT NOT NULL,
	PRIMARY KEY (ReportID),
	FOREIGN KEY (UserID) REFERENCES Users(UserID),
	FOREIGN KEY (TypeID) REFERENCES CrimeTypes(TypeID),
	FOREIGN KEY (LocID) REFERENCES CrimeLocation(LocID)
);

Create Table EyeWitnessReport
(
	WitnessID INT NOT NULL,
	UserID INT NOT NULL,
	ReportID INT NOT NULL,
	PRIMARY KEY (WitnessID),
	FOREIGN KEY(UserID) REFERENCES users(UserID),
	FOREIGN KEY(ReportID) REFERENCES CrimeReports(ReportID)
);



