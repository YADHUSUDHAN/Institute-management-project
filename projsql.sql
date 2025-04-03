use  proj;
CREATE TABLE CourseDetails (
    CourseID VARCHAR(20) PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    Duration VARCHAR(50) NOT NULL,
    Fees DECIMAL(10,2) NOT NULL
);

CREATE TABLE CourseSubjects (
    SubjectID INT AUTO_INCREMENT PRIMARY KEY,
    CourseID VARCHAR(20) NOT NULL,
    SubjectName VARCHAR(100) NOT NULL,
    FOREIGN KEY (CourseID) REFERENCES CourseDetails(CourseID) ON DELETE CASCADE
);


INSERT INTO CourseDetails (CourseID, CourseName, Duration, Fees) VALUES
('DCA', 'Diploma in Computer Applications', '6 Months', 12000),
('PGDCA', 'Post Graduate Diploma in Computer Applications', '1 Year', 25000),
('PDCFA', 'Professional Diploma in Computerized Financial Accounting', '6 Months', 15000),
('FashionDesign', 'Fashion Design', '1 Year', 30000),
('CWPDE', 'Certificate in Word Processing and Data Entry', '6 Months', 10000),
('DataEntry', 'Data Entry', '3 Months', 5000),
('PDDTP', 'Professional Diploma in Desk Top Publishing', '6 Months', 8000);

-- PDDTPDCA & PGDCA Subjects
INSERT INTO CourseSubjects (CourseID, SubjectName) VALUES
('DCA', 'Fundamentals of Computer'),
('DCA', 'CPP'),
('DCA', 'Python'),
('DCA', 'VB.Net'),
('DCA', 'System Engineering'),
('DCA', 'SQL'),
('PGDCA', 'Fundamentals of Computer'),
('PGDCA', 'CPP'),
('PGDCA', 'Python'),
('PGDCA', 'VB.Net'),
('PGDCA', 'System Engineering'),
('PGDCA', 'SQL');

-- PDCFA Subjects
INSERT INTO CourseSubjects (CourseID, SubjectName) VALUES
('PDCFA', 'Foreign Accounting');

-- Fashion Design Subjects
INSERT INTO CourseSubjects (CourseID, SubjectName) VALUES
('FashionDesign', 'Stitching'),
('FashionDesign', 'Photoshop'),
('FashionDesign', 'Embroidery');

-- CWPDE Subjects
INSERT INTO CourseSubjects (CourseID, SubjectName) VALUES
('CWPDE', 'Fundamentals of Computer'),
('CWPDE', 'Office'),
('CWPDE', 'PageMaker'),
('CWPDE', 'Malayalam Typing');

-- Data Entry Subjects
INSERT INTO CourseSubjects (CourseID, SubjectName) VALUES
('DataEntry', 'Fundamentals of Computer'),
('DataEntry', 'Office');

-- PDDTP Subjects
INSERT INTO CourseSubjects (CourseID, SubjectName) VALUES
('PDDTP', 'Photoshop'),
('PDDTP', 'PageMaker'),
('PDDTP', 'Office');


CREATE TABLE StudentDetails (
    ApplicationNo INT PRIMARY KEY,
    Name VARCHAR(100),
    DOB DATE,
    Age INT,
    Sex VARCHAR(10),
    Caste VARCHAR(50),
    Religion VARCHAR(50),
    CurrentAddress TEXT,
    PermanentAddress TEXT,
    Email VARCHAR(100),
    Phone VARCHAR(15),
    FatherName VARCHAR(100),
    FatherJob VARCHAR(100),
    MotherName VARCHAR(100),
    MotherJob VARCHAR(100),
    Qualification VARCHAR(100),
    University VARCHAR(100),
    PassoutYear INT,
    Mark FLOAT,
    Course VARCHAR(100),
    Image LONGBLOB,
    Batch VARCHAR(50),
    CourseStartDate DATE,
    CourseEndDate DATE,
    FeesPaid DECIMAL(10,2),
    FeesRemaining DECIMAL(10,2),
    ExamDate VARCHAR(50) DEFAULT 'Not Available',
    Result VARCHAR(50) DEFAULT 'Not Published',
    ResultDate VARCHAR(50) DEFAULT 'Not Available',
    CertificateCollectedDate VARCHAR(50) DEFAULT 'Not Available',
    FOREIGN KEY (Course) REFERENCES CourseDetails(CourseID) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE Users (
    UserID INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,  -- Store hashed password for security
    UserType ENUM('Admin', 'Faculty') NOT NULL
);
INSERT INTO Users (Username, Password, UserType) VALUES 
('admin1', SHA2('admin123', 256), 'Admin'),
('admin2', SHA2('admin456', 256), 'Admin'),
('faculty1', SHA2('faculty123', 256), 'Faculty'),
('faculty2', SHA2('faculty456', 256), 'Faculty');
CREATE TABLE FacultyDetails (
    EmployeeID VARCHAR(20) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    DOB DATE NOT NULL,
    Phone VARCHAR(15) NOT NULL,
    CourseID VARCHAR(20) NOT NULL,
    Image LONGBLOB,
    FOREIGN KEY (CourseID) REFERENCES CourseDetails(CourseID) ON DELETE CASCADE
);

CREATE TABLE FacultySubjects (
    FacultyID VARCHAR(20) NOT NULL,
    SubjectName VARCHAR(100) NOT NULL,
    PRIMARY KEY (FacultyID, SubjectName),
    FOREIGN KEY (FacultyID) REFERENCES FacultyDetails(EmployeeID) ON DELETE CASCADE
);

CREATE TABLE Attendance (
    AttendanceID INT AUTO_INCREMENT PRIMARY KEY,
    ApplicationNo INT  unique NOT NULL,
    AttendanceDate DATE NOT NULL,
    Subject VARCHAR(100) NOT NULL,
    IsPresent BOOLEAN NOT NULL
);

drop table Attendance;


SELECT DISTINCT Batch FROM studentdetails;






