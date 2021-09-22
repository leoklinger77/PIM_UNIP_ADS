select * from TB_Cargo

select * from TB_Funcionario
select * from TB_Email
select * from TB_Telefone
select * from TB_Endereco

select * from TB_Cidade

select * from AspNetUsers

delete AspNetUsers



select * from TB_Cidade C
	join TB_Estado T on T.Id = c.EstadoId
	where c.Nome = 'Jandira' and t.Uf = 'SP';