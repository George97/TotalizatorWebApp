
INSERT INTO Leagues (Name) VALUES ('Premier League'),('Champions League')

INSERT INTO Stages (Name,MatchDay,LeagueId)
VALUES ('Round',34,1),('Quarter-Final',8,2),('Semi-Final',9,2),('Round',36,1);

INSERT INTO Teams (Name) 
VALUES ('Chelsea FC'),('Tottenham Hotspur FC'),('Liverpool FC'),('Manchester City FC'),
       ('Manchester United FC'),('Everton FC'),('Arsenal FC'),('West Bromwich Albion FC'),
	   ('Southampton FC'),('Watford FC'),('Stoke City FC'),('AFC Bournemouth'),('West Ham United FC'),
	   ('Leicester City FC'),('Burnley FC'),('Crystal Palace FC'),('Hull City FC'),('Swansea City FC'),
	   ('Middlesbrough FC'),('Sunderland AFC');

INSERT INTO Matches (HomeTeamID,GuestTeamID,Date,StageId)
VALUES (12,19,'2017-04-22 17:00',1),(17,10,'2017-04-22 17:00',1),(18,11,'2017-04-22 17:00',1),
	   (13,6,'2017-04-22 17:00',1),(15,5,'2017-04-23 16:15',1),(3,16,'2017-04-23 18:30',1),
	   (1,9,'2017-04-25 21:45',1),(7,20,'2017-05-16 21:45',1),(4,8,'2017-05-16 22:00',1),(14,2,'2017-05-18 21:45',1);

INSERT INTO Users (FullName,Login,Password,Points,Roles,isBanned)
VALUES ('Yura Maluga','admin','777',0,'Admin',0)
INSERT INTO Users (FullName,Login,Password,Points,isBanned)
VALUES ('Matsko Vova' , 'Nilan','1111',0,0),('Fai Vasia','lasaV','1111',0,0),('Peleh Bohdan','Batia','1111',0,0),
       ('Olia Solar','o_Soliar','1111',0,0),('Diana Kruskuw','DianaDiana','1111',0,0),('Vladik Bug','vladik','1111',0,0);
INSERT INTO Users (FullName,Login,Password,Points,isBanned)
VALUES ('Katia Fedak','k_Fedak','1111',0,0),('Nina Piatenko','n_5enko','1111',0,0)

INSERT INTO Teams (Name) 
VALUES ('Real Madrid CF'),('Club Atlético de Madrid'),('AS Monaco FC'),('Juventus Turin'),('Leicester City FC'),('FC Bayern München'),
		('FC Barcelona'),('Borussia Dortmund')

INSERT INTO Matches (HomeTeamID,GuestTeamID,Date,StageId)
VALUES (25,22,'2017-04-18 21:45',2),(21,26,'2017-04-18 21:45',2),
		(27,24,'2017-04-19 21:45',2),(23,28,'2017-04-19 21:45',2),
		(21,22,'2017-05-02 21:45',3),(23,24,'2017-05-03 21:45',3)

INSERT INTO Matches (HomeTeamID,GuestTeamID,Date,StageId)
VALUES (13,2,'2017-05-05 22:00',4),(4,16,'2017-05-06 14:30',4),(3,9,'2017-05-07 15:30',4),
		(7,5,'2017-05-07 18:00',4)


