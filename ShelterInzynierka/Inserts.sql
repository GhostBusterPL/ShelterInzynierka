-- VOLUNTEER
INSERT INTO Volunteer (Name, Surname, Age)
VALUES ('Adam', 'Nowak', 22);
INSERT INTO Volunteer (Name, Surname, Age)
VALUES ('Ola', 'Nowak', 32);
INSERT INTO Volunteer (Name, Surname, Age)
VALUES ('Eliza', 'Januszewski', 16);
INSERT INTO Volunteer (Name, Surname, Age)
VALUES ('Maciek', 'Kowalski', 44);

-- ADRESS
INSERT INTO Adress (City, PostCode)
VALUES ('Lubartów', '21100');
INSERT INTO Adress (City, PostCode)
VALUES ('Lublin', '20150');
INSERT INTO Adress (City, PostCode)
VALUES ('Warszawa', '00022');
INSERT INTO Adress (City, PostCode)
VALUES ('Mielno', '05200');

-- ADOPTER
INSERT INTO Adopter (Name, Surname, PhoneNumber, Street, HouseNumber, IdAdress)
VALUES ('Janusz', 'Kowalski', '732239922', 'Ulica 1', '16B', 2);
INSERT INTO Adopter (Name, Surname, PhoneNumber, Street, HouseNumber, IdAdress)
VALUES ('Klaudia', 'Wytyk', '602817653', '', '321', 1);


-- COLOR
INSERT INTO Color (Name)
VALUES ('Szary');
INSERT INTO Color (Name)
VALUES ('Czarny');
INSERT INTO Color (Name)
VALUES ('Biały');
INSERT INTO Color (Name)
VALUES ('Beżowy');

-- DOGSATTITUDE
INSERT INTO DogsAttitude (Name)
VALUES ('Wrogi');
INSERT INTO DogsAttitude (Name)
VALUES ('Przyjazny');
INSERT INTO DogsAttitude (Name)
VALUES ('Neutralny');

-- CATSATTITUDE
INSERT INTO CatsAttitude (Name)
VALUES ('Wrogi');
INSERT INTO CatsAttitude (Name)
VALUES ('Przyjazny');
INSERT INTO CatsAttitude (Name)
VALUES ('Neutralny');

-- KIDSATTITUDE
INSERT INTO KidsAttitude (Name)
VALUES ('Wrogi');
INSERT INTO KidsAttitude (Name)
VALUES ('Przyjazny');
INSERT INTO KidsAttitude (Name)
VALUES ('Neutralny');

-- DOGS
INSERT INTO Dog (ChipNumber, Name, Age, Weight, Height, HaveCastration, IdKidsAttitude, IdCatsAttitude, IdDogsAttitude, Sex, Description, JoinDate, LeaveDate)
VALUES ('123456789012345', 'Azor', 12, 42, 65, true, 1, 3, 2, 'K', 'Fajny piesek. A to jest test opisu jaki ktoś zrobił.', '2019-05-05', '2021-01-01');
INSERT INTO Dog (ChipNumber, Name, Age, Weight, Height, HaveCastration, IdKidsAttitude, IdCatsAttitude, IdDogsAttitude, Sex, Description, JoinDate, LeaveDate)
VALUES ('012345123456789', 'Burek', 7, 22, 29, false, 1, 1, 1, 'M', 'To jest malutki piesek. A to jest test opisu jaki ktoś zrobił, żeby sobie było.','2019-11-2', '2020-06-07');





