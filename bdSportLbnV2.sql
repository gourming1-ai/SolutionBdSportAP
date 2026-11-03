drop database if exists bdSportif;
create database if not exists bdSportif;

use bdSportif;

Create Table Sportif (
    id int Auto_Increment,
    nom varchar(30) not null,
    prenom varchar(30) not null,
    dateN date not null,
    rue varchar(50),
    cp varchar(10),
    ville varchar(30),
    Primary Key (id)
);

Create Table Sport (
    idSport int Auto_Increment,
    nomSport varchar(50) not null,
    Primary Key (idSport)
);

Create Table Niveau (
    idNiveau int Auto_Increment,
    libelle varchar(30) not null,
    Primary Key (idNiveau)
);

Create Table Pratiquer (
    idSportif int,
    idSport int,
    idNiveau int not null,
    Primary Key (idSportif, idSport),
    Foreign Key (idSportif) References Sportif(id),
    Foreign Key (idSport) References Sport(idSport),
    Foreign Key (idNiveau) References Niveau(idNiveau)
);
    
CREATE TABLE Utilisateur (
    id INT AUTO_INCREMENT,
    login VARCHAR(50) NOT NULL,
    motDePasse VARCHAR(100) NOT NULL,
    PRIMARY KEY (id));
  
    
Insert Into Sportif (nom, prenom, dateN, rue, cp, ville) Values
('DAVOLIO', 'Jeanne', '2000-05-12', 'Rue A', '63000', 'Clermont-Ferrand'),
('MARTIN', 'Julien', '2001-08-20', 'Rue B', '63000', 'Clermont-Ferrand'),
('DUPONT', 'Lucas', '2002-03-15', 'Rue C', '63100', 'Clermont-Ferrand'),
('BERNARD', 'Emma', '2003-07-22', 'Rue D', '63000', 'Clermont-Ferrand'),
('PETIT', 'Thomas', '1999-11-08', 'Rue E', '63100', 'Clermont-Ferrand'),
('ROBERT', 'Sarah', '2001-01-30', 'Rue F', '63000', 'Clermont-Ferrand'),
('MOREAU', 'Hugo', '2004-09-17', 'Rue G', '63100', 'Clermont-Ferrand');

Insert Into Sport (nomSport) Values
('Tennis'),
('Natation'),
('Football');

Insert Into Niveau (libelle) Values
('Débutant'),
('Confirmé'),
('Avancé'),
('Professionnel');

Insert Into Pratiquer Values
(1, 1, 3),
(1, 2, 2),
(2, 3, 2),
(2, 1, 1),
(3, 3, 4),
(3, 1, 2),
(4, 2, 3),
(4, 3, 1),
(5, 1, 4),
(5, 3, 3),
(6, 2, 1),
(6, 1, 2),
(7, 3, 3),
(7, 2, 4);

INSERT INTO Utilisateur(login, motDePasse)
VALUES ('admin', 'admin123');