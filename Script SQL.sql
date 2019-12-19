CREATE DATABASE Notes
GO

USE Notes
GO

CREATE TABLE tbl_notes(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Creation DATETIME NOT NULL DEFAULT GETDATE(),
	Updated DATETIME,

	Title NVARCHAR(100),
	Content NVARCHAR(1000) NOT NULL
)
GO

INSERT INTO tbl_notes
	(Title, Content)
VALUES
	('Nota 1', 'Conte�do da anota��o 1'),
	('Nota 2', 'Conte�do da anota��o 2'),
	('Nota 3', 'Conte�do da anota��o 3'),
	('Nota 4', 'Conte�do da anota��o 4')
GO

select * from tbl_notes