Drop Table  if Exists Teachers;

Create Table Teachers(
			Id int primary key not null,
			TeachersName nvarchar(50) not null,
			TeachersSurName nvarchar(50) not null,
			Subjects nvarchar(50) not null,
);
Drop Table  if Exists Pupils;


Create Table Pupils(
			Id int primary key not null,
			PupilsName nvarchar(50) not null,
			PupilsSurName nvarchar(50) not null,
			class nvarchar(50) not null,
);

Drop Table  if Exists Teacher_Pupil;

Create Table Teacher_Pupil(
		TeachersId int not null,
		PupilsId int not null,
		Foreign Key(TeachersId) References Teachers(Id) On Update Cascade On Delete No Action,
		Foreign Key(PupilsId) References Pupils(Id) On Update Cascade On Delete No Action,
		Primary Key (TeachersId, PupilsId)
);



Insert Into Teachers(Id, TeachersName,TeachersSurName,Subjects)
Values(1,'avto', 'chichinadze', 'maTematika');
Insert Into Teachers(Id, TeachersName,TeachersSurName,Subjects)
Values(2,'lela', 'xomeriki', 'qarTuli');
Insert Into Teachers(Id, TeachersName,TeachersSurName,Subjects)
Values(3,'cico', 'vekua', 'fizika');




Insert Into Pupils(Id, PupilsName,PupilsSurName,class)
Values(1,'giorgi', 'loladze', 'meore klasi');
Insert Into Pupils(Id, PupilsName,PupilsSurName,class)
Values(2,'lika', 'vekua', 'meore klasi');
Insert Into Pupils(Id, PupilsName,PupilsSurName,class)
Values(3,'zaza', 'fiqali', 'meotxe klasi');
Insert Into Pupils(Id, PupilsName,PupilsSurName,class)
Values(4,'emzari', 'chkadua', 'meotxe klasi');
Insert Into Pupils(Id, PupilsName,PupilsSurName,class)
Values(5,'joni', 'afaqidze', 'mexute klasi');

