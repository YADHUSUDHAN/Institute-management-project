# Institute Management System (VB.NET & MySQL)

## 📌 Overview
The **Institute Management System** is a **Windows Forms Application** developed in **VB.NET** with **MySQL** as the backend database. This system is designed to manage various institute operations, including student, faculty, and course details. The application provides **role-based access**, ensuring secure and efficient management of academic records.

## 🚀 Features
✅ **User Authentication:** Secure login with SHA-256 password hashing.  
✅ **Role-Based Access:**
- **Admin:** Full access to students, faculty, and course management. Can add/edit users.
- **Faculty:** Can access and modify student details. Can view course and faculty details in read-only mode.
✅ **Student Management:** Add, edit, and view student details.
✅ **Faculty Management:** Register and manage faculty details.
✅ **Course Management:** Add, edit, and view course information.
✅ **Attendance Management:** Mark student attendance for subjects.
✅ **Validation:** Ensures proper data entry with form validation.
✅ **Database Integration:** Uses MySQL with relational tables for structured data management.

## 📂 Database Structure
The system consists of multiple relational tables:

### **CourseDetails**
Stores course information, including duration and fees.

### **CourseSubjects**
Contains subjects for each course.

### **StudentDetails**
Manages student records, including personal and academic information.

### **Users**
Stores login credentials and user roles (Admin/Faculty).

### **FacultyDetails**
Contains faculty records and their assigned courses.

### **FacultySubjects**
Stores subjects taught by each faculty member.

### **Attendance**
Records student attendance for each subject.

## 🔧 Setup Instructions
1️⃣ Install **MySQL Server** and create the required database.  
2️⃣ Run the provided **SQL script** to set up tables and insert test data.  
3️⃣ Open the project in **Visual Studio** and configure the database connection.  
4️⃣ Run the application and log in using test credentials:
   - **Admin:** Username: `admin1`, Password: `admin123`
   - **Faculty:** Username: `faculty1`, Password: `faculty123`

## 📢 Contributions & Issues
Feel free to **fork this repository**, report issues, or suggest improvements! 🚀

