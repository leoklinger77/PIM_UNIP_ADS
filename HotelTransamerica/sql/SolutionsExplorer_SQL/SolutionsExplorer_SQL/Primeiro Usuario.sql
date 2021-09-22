
/*
	Informações de primeiro acesso na plataforma

	Observação: A senha é gerada pela a aplicação (Identity) e armazenada no banco criptrografada, a senha que sera armazenada no banco é: @Q@b7#97SS
*/


-- `dbo.AspNetUsers` -- Alterar apenas o E-mail, conforme o E-mail Cadastrado na TB_Email
INSERT dbo.AspNetUsers VALUES 
(N'5599636a-ebe7-4795-9d05-d3536bf80313', N'leandro.klingeroliveira@gmail.com', N'LEANDRO.KLINGEROLIVEIRA@GMAIL.COM', N'leandro.klingeroliveira@gmail.com', N'LEANDRO.KLINGEROLIVEIRA@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEBEWOwO/vLMw1FUp8kiR9Q2IRiU07rhs/wYQVyvfpt1ab7EpVRtTFeBhvoWw1N14xw==', N'XIH6QTMPVKSVIJ7WV6LZ44OV34W7AL2L', N'02ff17d1-ad46-45a3-aa05-19ecc4f941f7', NULL, 0, 0, NULL, 1, 0)

-- `dbo.TB_Cargo`
INSERT dbo.TB_Cargo VALUES (N'043EF481-C8C5-49AA-B239-216A98D097ED', '20210922 12:04:23.0072264', NULL, 'Desenvolvedor')

-- `dbo.TB_Funcionario` - Alterar apenas o Nome e CPF
INSERT dbo.TB_Funcionario VALUES (N'99DCC0F2-65FE-4C33-85E8-CC0EE43B185D', '20210922 12:05:27.9023709', NULL, N'043EF481-C8C5-49AA-B239-216A98D097ED',
					'Leandro Klinger', '36018556820', '19951109 00:00:00.0000000')

-- `dbo.TB_Email` - Alterar apenas o e-mail
INSERT dbo.TB_Email VALUES (N'13837F80-4BEA-4B81-892E-4B991928A2B9', '20210922 12:05:27.9023304', NULL,
					'leandro.klingeroliveira@gmail.com', 2, N'99DCC0F2-65FE-4C33-85E8-CC0EE43B185D')

-- `dbo.TB_Telefone` - Alterar apenas o Telefone
INSERT dbo.TB_Telefone VALUES (N'3CFBF6C3-157A-40D6-AE3E-C484319A7759', '20210922 12:05:27.9023591', NULL, '11', '954645456', 1, N'99DCC0F2-65FE-4C33-85E8-CC0EE43B185D')
