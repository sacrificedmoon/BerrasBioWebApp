use [BerrasBioDb]

GO

INSERT INTO Film
VALUES	('Casino Royale ', 1954, '01:00'),
		('Goldenfinger', 1964, '01:50'),
		('Live and Let Die', 1973, '02:00'),
		('Octopussy', 1983, '02:10'),
		('Tomorrow Never Dies (Pierce Brosnan)', 1997, '02:00'),
		('Quantum of Solace (Daniel Craig)', 2008, '01:50');

GO

INSERT INTO Salon
VALUES	('Saga', 50),
		('Scala', 100);

GO

INSERT INTO FilmSchedule
VALUES    (1, 1, '2020-04-01 16:00:00', 50, 0),
        (1, 2, '2020-04-01 16:00:00', 100, 0),
        (2, 1, '2020-04-01 18:30:00', 50, 0),
        (2, 2, '2020-04-01 18:30:00', 100, 0),
        (3, 1, '2020-04-01 21:00:00', 50, 0),
        (3, 2, '2020-04-01 21:00:00', 100, 0);