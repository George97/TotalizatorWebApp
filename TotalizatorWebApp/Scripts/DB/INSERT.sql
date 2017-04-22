
INSERT INTO Leagues (Name) VALUES ('Premier League')

INSERT INTO Stages (Name,LeagueId)
VALUES ('Round 34',1);

INSERT INTO Teams (Name) 
VALUES ('Chelsea'),('Tottenham Hotspur'),('Liverpool'),('Manchester City'),
       ('Manchester United'),('Everton'),('Arsenal'),('West Bromwich Albion'),
	   ('Southampton'),('Watford'),('Stoke City'),('AFC Bournemouth'),('West Ham United'),
	   ('Leicester City'),('Burnley'),('Crystal Palace'),('Hull City'),('Swansea City'),
	   ('Middlesbrough'),('Sunderland');

INSERT INTO Matches (HomeTeamID,GuestTeamID,Date,StageId)
VALUES (12,19,'2017-04-22 17:00',1),(17,10,'2017-04-22 17:00',1),(18,11,'2017-04-22 17:00',1),(13,6,'2017-04-22 17:00',1),
	   (15,5,'2017-04-23 16:15',1),(2,16,'2017-04-23 18:30',1),
	   (1,9,'2017-04-25 21:45',1),(7,20,'2017-05-16 21:45',1),(4,8,'2017-05-16 22:00',1),(14,2,'2017-05-18 21:45',1);

INSERT INTO Users (FullName,Login,Password,Points)
VALUES ('Matsko Vova' , 'Nilan','1111',70),('Fai Vasia','lasaV','1111',71),('Peleh Bohdan','Batia','1111',73),('Olia Solar','o_Soliar','1111',75)
