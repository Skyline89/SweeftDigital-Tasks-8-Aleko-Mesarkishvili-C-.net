Select  Teachers.TeachersName
From Teacher_Pupil
Inner Join Teachers On Teacher_Pupil.TeachersId = Teachers.Id
Inner Join Pupils On Teacher_Pupil.PupilsId = Pupils.Id
Where PupilsName = 'giorgi';