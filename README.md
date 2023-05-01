<img width="192" alt="image" src="https://user-images.githubusercontent.com/76961685/235512783-9e5e9c7c-184b-480e-bdb6-ac168abcc9fc.png">

Projeto realizado com objetivo de uma mini gestão para cadastro de churrascos e participantes, utilizando .NET 7.

O objetivo deste projeto é, aperfeiçoar o framework, construindo uma **API REST**, utilizamos vários recursos como:

- Swagger
- Arquitetura Limpa
    - Camadas -> Core, Infrastructure, Application, API
- Entity Framework Core (Em Memória)

Mas quais funcionalidades foram implementadas?

- Cadastro, Atualização, Cancelamento e Consulta de Churrasco.
- Cadastro de Participantes, Remoção dos mesmos.
    - Apontados para um churrasco especifíco e seu valor de contribuição.

---

## Swagger

Ferramenta que simplifica o desenvolvimento de APIs, permitindo entre outras funcionalidades, a documentar e testar APIs. Ele consegue gerar uma interface gráfica contendo todos os pontos de acesso (Endpoints) da API, permitindo realizar requisições diretamente em sua interface.

---

## Arquitetura Limpa

Também conhecida como **Onion Architecture**, ou Arquitetura Cebola.
Tem como foco o **domínio** do sistema, tendo em sua essência o DDD - Domain Driven Design, sendo dividida em 4 camadas principais:

- Core, Infrastructure, Application e API

---

## Entity Framework Core (Em Memória)

EF Core In-Memory é a adição de um provedor de dados que torna possível prototipar aplicações e escrever testes sem ter que configurar um banco de dados local ou externo.

---