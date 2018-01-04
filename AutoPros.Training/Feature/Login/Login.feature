#language: pt-br
Funcionalidade: Login
	Efetuar login
	Desejo efetuar o login

@mytag
Cenário: Efetuar Login
	Dado Acessar a HOME
	Quando Preencher o campo codigo
	Então Clicar no botao login
		