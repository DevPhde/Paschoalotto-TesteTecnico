# Teste Técnico Paschoalotto
*Sobre a aplicação*
- Desenvolvi também um HUB websocket utilizando SignalR, decidi criar o HUB para que a tabela de Heróis ficasse mais flúida. Caso seja adicionado ou removido um usuário pelo backend a tabela é atualizada automaticamente.
- Escolhi utilizar o ORM Entity framework na conexão com o banco para agilizar na criação do repositório e mapeamento das entidades.
- Sobre a aplicação Angular, utilizei Angular Material somado ao Bootstrap para facilitar e ganhar um boost no desenvolvimento das interfaces e componentes.

## Instruções para inicializar os projetos

*BACKEND*
- Primeiro você deve rodar uma migration para carregar as tabelas.
- Para isso você precisa abrir o projeto e navegar até a pasta do projeto API (UserProject.API)
- Rodar o seguinte comando `dotnet ef database update --no-build`

 
PS: Pode ser que pelo terminal com o comando acima não funcione, caso isso ocorra tente pelo `Console do Gerenciador de pacotes` do próprio visual studio utilizando o comando `update-database`

OBS:
Para rodar o docker-compose basta ter o docker instalado no computador e rodar o comnado docker-compose up

*FRONTEND*
- Abrir a pasta do projeto frontend
- Rodar `npm i`
- Caso não possua a CLI do angular rode o comando `npm i @angular/cli@16.2.14`
- Rode o comando ng s
- A aplicação irá iniciar na seguinte url => http://localhost:4200

