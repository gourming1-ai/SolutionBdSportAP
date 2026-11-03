drop database if exists bdSportif;
create database if not exists bdSportif;

use bdSportif;

CREATE TABLE Sportif (
    id INT AUTO_INCREMENT,
    nom VARCHAR(50),
    prenom VARCHAR(50),
    dateN DATE,
    rue VARCHAR(100),
    cp VARCHAR(10),
    ville VARCHAR(50),
    nivExp VARCHAR(30),
    nomSport VARCHAR(50),
    primary key (id) );
    
CREATE TABLE Utilisateur (
    id INT AUTO_INCREMENT,
    login VARCHAR(50) NOT NULL,
    motDePasse VARCHAR(100) NOT NULL,
    PRIMARY KEY (id));
  
    
insert into Sportif(nom,prenom,dateN,rue,cp,ville,nivExp,nomSport)
values ('Martin', 'Lucas', '2002-05-14', '12 rue Victor Hugo', '75015', 'Paris', 'Débutant', 'Football'),
('Dupont', 'Emma', '1999-09-22', '8 avenue de Lyon', '69003', 'Lyon', 'Confirmé', 'Tennis'),
('Bernard', 'Hugo', '2001-02-10', '25 rue Nationale', '59000', 'Lille', 'Avancé', 'Natation'),
('Robert', 'Clara', '2003-11-05', '17 rue des Fleurs', '31000', 'Toulouse', 'Débutant', 'Basketball'),
('Petit', 'Thomas', '1997-07-30', '4 boulevard Gambetta', '13001', 'Marseille', 'Professionnel', 'Cyclisme');

INSERT INTO Utilisateur(login, motDePasse)
VALUES ('admin', 'admin123');