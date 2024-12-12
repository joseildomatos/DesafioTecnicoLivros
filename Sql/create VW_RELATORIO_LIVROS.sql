USE DesafioTecnicoSpassuTJRJ
GO

CREATE VIEW DBO.VW_RELATORIO_LIVROS AS
SELECT        TOP (100) PERCENT dbo.Autor.Id AS AutorId, 
								dbo.Autor.Nome AS AutorNome, 
								dbo.Livro.Titulo AS LivroNome, 
								dbo.Assunto.Descricao AS AssuntoDescricao
FROM            dbo.Assunto INNER JOIN
                         dbo.LivroAssunto ON dbo.Assunto.Id = dbo.LivroAssunto.AssuntoId INNER JOIN
                         dbo.Livro ON dbo.LivroAssunto.LivroId = dbo.Livro.Id INNER JOIN
                         dbo.LivroAutor ON dbo.Livro.Id = dbo.LivroAutor.LivroId RIGHT OUTER JOIN
                         dbo.Autor ON dbo.LivroAutor.AutorId = dbo.Autor.Id
ORDER BY Autor.Id, Livro.Titulo, Assunto.Descricao