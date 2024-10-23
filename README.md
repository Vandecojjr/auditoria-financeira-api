# auditoria-financeira-api

## Execução do projeto.

### Requisitos

- Docker

### Como executar

```sh
git clone https://github.com/Vandecojjr/auditoria-financeira-api.git
````
dentro da pasta `auditoria-financeira-api`

```sh
docker-compose up --build -d
```

## Usando a Api

Agora o projeto esta rodando na url: http://localhost:8080 e basta usar o postman ou acessar http://localhost:8080/swagger/index.html 
para utilizar o Swagger e testar as rotas documentadas.

Agora basta criar um usuario usando a rodara /v1/usuario e apos isso basta logar e fazer as requisições 
desejadas.

## Estrutura do Projeto e Arquitetura

Para o desenvolvimento deste projeto, utilizei a arquitetura limpa, que separa as responsabilidades em camadas distintas.

- **Domain**: Esta camada é responsável pelas regras de negócio da aplicação. A camada de domínio não possui dependências em relação às outras camadas, o que garante que sua única e exclusiva função seja cuidar das entidades e das regras de negócio. Para essa camada, utilizei os padrões CQRS (Command Query Responsibility Segregation), Notification Pattern e Repository.

- **Infra**: A camada de infraestrutura é responsável pelo acesso e persistência de dados, mantendo o restante da aplicação livre dessas preocupações.

- **Api**: A camada de API trata das requisições e responde de acordo com o padrão REST, permitindo a comunicação entre o cliente e a aplicação.

- **Test**: A camada de teste é responsável por validar as outras camadas, garantindo que a aplicação possua a maior cobertura de testes possível.

Decidi adotar essa estrutura com o foco em escalabilidade, permitindo que a aplicação possa fazer parte de um conjunto de aplicações (sistema distribuído) ou até mesmo de um grande monólito, mas com uma estrutura preparada para ser desmembrada. Como a camada de domínio não depende de como a aplicação lida com os dados, conseguimos desacoplar a aplicação de dependências mais pesadas, como o banco de dados.

Por exemplo, ao utilizar a camada de infraestrutura, posso trocar de banco de dados ou até mesmo persistir os dados em outra aplicação sem afetar o restante do sistema.

O mesmo se aplica às regras de negócio. Como a camada de domínio é independente, posso aplicá-la em outra aplicação ou serviço sem causar impacto.

Dessa forma, a aplicação se torna mais flexível, com menos dependências e pronta para ser escalada.
