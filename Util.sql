SELECT * FROM dbo.Empresas
SELECT * FROM dbo.Usuarios


INSERT INTO dbo.Empresas VALUES ('BFSOFTWARE', 'BFSOFTWARE', '88.960.849/0001-58', 'Servi�os', 'Endere�o 1', 'Email 1', 'Telefone 1', 1, GETDATE(), 'ADMIN')

INSERT INTO dbo.Usuarios VALUES ('BrunoFranca1', 'minhasenha1', 'Bruno', 'Fran�a Souza', 'brunofrancasouza@gmail.com', 'Admin', 1, GETDATE(), 'ADMIN', 1)
INSERT INTO dbo.Usuarios VALUES ('BrunoFranca2', 'minhasenha2', 'Bruno', 'Fran�a Souza', 'brunofrancasouza@gmail.com', 'Admin', 1, GETDATE(), 'ADMIN', 1)
INSERT INTO dbo.Usuarios VALUES ('BrunoFranca3', 'minhasenha3', 'Bruno', 'Fran�a Souza', 'brunofrancasouza@gmail.com', 'Admin', 1, GETDATE(), 'ADMIN', 1)

DELETE FROM dbo.Empresas
DELETE FROM dbo.Usuarios

DBCC CHECKIDENT ('[Empresas]', RESEED, 0);
DBCC CHECKIDENT ('[Usuarios]', RESEED, 0);
