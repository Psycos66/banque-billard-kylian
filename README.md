# banque-billard-kylian

SCRIPT SQL

CREATE TABLE Client(
   IdClient INT,
   Nom VARCHAR(50),
   Prenom VARCHAR(50),
   Adresse VARCHAR(50),
   PRIMARY KEY(IdClient)
);

CREATE TABLE Compte(
   IdCompte INT,
   Libelle VARCHAR(255),
   PRIMARY KEY(IdCompte)
);

CREATE TABLE Operation(
   IdOperation INT,
   type INT,
   IdCompte INT NOT NULL,
   PRIMARY KEY(IdOperation),
   FOREIGN KEY(IdCompte) REFERENCES Compte(IdCompte)
);

CREATE TABLE ClientCompte(
   IdClient INT,
   IdCompte INT,
   PRIMARY KEY(IdClient, IdCompte),
   FOREIGN KEY(IdClient) REFERENCES Client(IdClient),
   FOREIGN KEY(IdCompte) REFERENCES Compte(IdCompte)
);
