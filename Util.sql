SELECT * FROM dbo.Empresas
SELECT * FROM dbo.Usuarios


INSERT INTO dbo.Empresas VALUES ('BFSOFTWARE', 'BFSOFTWARE', '88.960.849/0001-58', 'Serviços', 'Endereço 1', 'Email 1', 'Telefone 1', 1, GETDATE(), 'ADMIN')
INSERT INTO dbo.Usuarios VALUES ('BrunoFranca', 'minhasenha', 'Bruno', 'França Souza', 'brunofrancasouza@gmail.com', 'Admin', 1, GETDATE(), 'ADMIN', 1)

DELETE FROM dbo.Empresas
DELETE FROM dbo.Usuarios

DBCC CHECKIDENT ('[Empresas]', RESEED, 0);
DBCC CHECKIDENT ('[Usuarios]', RESEED, 0);
