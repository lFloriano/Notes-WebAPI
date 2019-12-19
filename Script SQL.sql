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
	('Nota 1', 'Conteúdo da anotação 1'),
	('Nota 2', 'Conteúdo da anotação 2'),
	('Nota 3', 'Conteúdo da anotação 3'),
	('Nota 4', 'Conteúdo da anotação 4')
GO

select * from tbl_notes