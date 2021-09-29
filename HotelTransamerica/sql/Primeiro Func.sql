
/*
	Informações de primeiro acesso na plataforma

	Observação: A senha é gerada pela a aplicação (Identity) e armazenada no banco criptrografada, a senha que sera armazenada no banco é: @Q@b7#97SS
*/

INSERT dbo.AspNetUsers VALUES 
(N'5599636a-ebe7-4795-9d05-d3536bf80313', N'leandro.klingeroliveira@gmail.com', N'LEANDRO.KLINGEROLIVEIRA@GMAIL.COM', N'leandro.klingeroliveira@gmail.com', 
 N'LEANDRO.KLINGEROLIVEIRA@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEBEWOwO/vLMw1FUp8kiR9Q2IRiU07rhs/wYQVyvfpt1ab7EpVRtTFeBhvoWw1N14xw==', N'XIH6QTMPVKSVIJ7WV6LZ44OV34W7AL2L', 
 N'02ff17d1-ad46-45a3-aa05-19ecc4f941f7', NULL, 0, 0, NULL, 1, 0)

INSERT dbo.TB_Cargo VALUES (N'043EF481-C8C5-49AA-B239-216A98D097ED', '20210922 12:04:23.0072264', NULL, 'Desenvolvedor')

insert TB_GrupoFuncionario values('4599636a-ebe7-4795-9d05-d3536bf80313',GETDATE(), null,'Administrador')
insert TB_Acesso values('4699636a-ebe7-4795-9d05-d3536bf80313',GETDATE(), null,'Funcionario','Home, Novo, Editar, Detalhes, Deletar','4599636a-ebe7-4795-9d05-d3536bf80313')
insert TB_Acesso values('4699635a-ebe7-4795-9d05-d3536bf80313',GETDATE(), null,'Cargo','Home, Novo, Editar, Detalhes, Deletar','4599636a-ebe7-4795-9d05-d3536bf80313')
insert TB_Acesso values('4699634a-ebe7-4795-9d05-d3536bf80313',GETDATE(), null,'GrupoFuncionario','Home, Novo, Editar, Detalhes, Deletar','4599636a-ebe7-4795-9d05-d3536bf80313')
insert TB_Acesso values('4699633a-ebe7-4795-9d05-d3536bf80313',GETDATE(), null,'Home','Home, Novo, Editar, Detalhes, Deletar','4599636a-ebe7-4795-9d05-d3536bf80313')
insert TB_Acesso values('4699633a-ebe7-4795-9d05-d3536bf80311',GETDATE(), null,'Hospede','Home, Novo, Editar, Detalhes, Deletar','4599636a-ebe7-4795-9d05-d3536bf80313')
insert TB_Acesso values('4689633a-ebe7-4795-9d05-d3536bf80311',GETDATE(), null,'Anuncio','Home, Novo, Editar, Detalhes, Deletar','4599636a-ebe7-4795-9d05-d3536bf80313')
insert TB_Acesso values('4679633a-ebe7-4795-9d05-d3536bf80311',GETDATE(), null,'Quarto','Home, Novo, Editar, Detalhes, Deletar','4599636a-ebe7-4795-9d05-d3536bf80313')
insert TB_Acesso values('5679633a-ebe7-4795-9d05-d3536bf80311',GETDATE(), null,'Categoria','Home, Novo, Editar, Detalhes, Deletar','4599636a-ebe7-4795-9d05-d3536bf80313')

INSERT dbo.TB_Funcionario VALUES ('99DCC0F2-65FE-4C33-85E8-CC0EE43B185D', '20210922 12:05:27.9023709', NULL, N'043EF481-C8C5-49AA-B239-216A98D097ED','4599636a-ebe7-4795-9d05-d3536bf80313',
					'Leandro Klinger', '36018556820', '19951109 00:00:00.0000000')

INSERT dbo.TB_Email VALUES ('13837F80-4BEA-4B81-892E-4B991928A2B9', '20210922 12:05:27.9023304', NULL,
					'leandro.klingeroliveira@gmail.com', 2, N'99DCC0F2-65FE-4C33-85E8-CC0EE43B185D',NULL)

INSERT dbo.TB_Telefone VALUES (N'3CFBF6C3-157A-40D6-AE3E-C484319A7759', '20210922 12:05:27.9023591', NULL, '11', '954645456', 1, N'99DCC0F2-65FE-4C33-85E8-CC0EE43B185D',null)

insert TB_Endereco values('3CFBF6C3-157A-40D6-AE3E-a484319A7759',GETDATE(),null,'06622280','Logradouro','71','oficial',null,'Tereza','C5EB2CED-F08D-4541-8B3D-FF8DC494B651','99DCC0F2-65FE-4C33-85E8-CC0EE43B185D',null)/*

Inserindo Clains Identity
*/
insert AspNetUserClaims values('5599636a-ebe7-4795-9d05-d3536bf80313','Cargo','Home, Novo, Editar, Detalhes, Deletar')
insert AspNetUserClaims values('5599636a-ebe7-4795-9d05-d3536bf80313','Funcionario','Home, Novo, Editar, Detalhes, Deletar')
insert AspNetUserClaims values('5599636a-ebe7-4795-9d05-d3536bf80313','Hospede','Home, Novo, Editar, Detalhes, Deletar')
insert AspNetUserClaims values('5599636a-ebe7-4795-9d05-d3536bf80313','GrupoFuncionario','Home, Novo, Editar, Detalhes, Deletar')
insert AspNetUserClaims values('5599636a-ebe7-4795-9d05-d3536bf80313','Quarto','Home, Novo, Editar, Detalhes, Deletar')
insert AspNetUserClaims values('5599636a-ebe7-4795-9d05-d3536bf80313','Anuncio','Home, Novo, Editar, Detalhes, Deletar')
insert AspNetUserClaims values('19F8CC51-D54F-40C4-8841-C78C280B0DA6','Categoria','Home, Novo, Editar, Detalhes, Deletar')
insert AspNetUserClaims values('19F8CC51-D54F-40C4-8841-C78C280B0DA6','Produto','Home, Novo, Editar, Detalhes, Deletar')

/*
	
*/


