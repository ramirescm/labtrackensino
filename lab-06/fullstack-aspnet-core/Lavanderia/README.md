- Baixar o projeto
- Instalar o Postegres
- Criar o banco lavanderia 
	- configura��es de conex�es ficam no appsettings.json l� voc� pode editar as configura��es de conex�o com o banco

```
CREATE DATABASE lavanderia

INSERT INTO public.usuarios(
	id, login, senha)
	VALUES (1, 'admin@gmail.com', '123');
INSERT INTO public.usuarios(
	id, login, senha)
	VALUES (2, 'manager@gmail.com', '123');	
	
```

- Em Package Manager Console -> selecionar o projeto Lavanderia.Infra e executar o update-database

Refer�ncia via linha de comando para restaurar os pacotes
https://docs.microsoft.com/pt-br/dotnet/core/tools/dotnet-restore