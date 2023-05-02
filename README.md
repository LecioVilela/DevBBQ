# DevBBQ
<!-- <img width="192" alt="image" src="https://user-images.githubusercontent.com/76961685/235512783-9e5e9c7c-184b-480e-bdb6-ac168abcc9fc.png"> -->

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
    - Core ou Domain:
        - Camada mais importante da Arquitetura Limpa. É nela onde o foco de desenvolvimento inicial deve estar. O Domain-Driven Design está bem caracterizado nos conceitos dessa arquitetura, por agregar a importância de se entender bem o domínio, as regras de negócio contidas nele, bem como o linguajar utilizado pelos diferentes usuários.(Ubíqua)
    - Infrastructure:
        - Camada responsável pelo código de infraestrutura, como acesso a dados, conexão com serviços de computação na nuvem, integração entre sistemas, entre outros.
        Cada um desses sub-itens pode ser dividido em projetos próprios, como Persistence, Integration e CloudService.
        - No acesso a dados podemos utilizar o Entity Framework Core correspondente ao contexto de dados normalmente utilizado com um arquivo DbContext.cs
        Onde é até possível mapear nossas entidades e as relacionar.
    - Application:
        - Camada responsável por código de aplicação, onde as funcionalidades expostas vão estar, em forma de serviços, normalmente são utilizados Commands ou Queries, mas vai depender do padrão utilizado.
        - Nessa camada também podemos criar nossos modelos de entrada e saída da aplicação, onde diretamente serão utilizados na nossa camada API.
    - API:
        - Application Programming Interface(Interface de Programação de Aplicação).
        - Camada responsável por toda interface do nosso código, seja ela uma API com padrão REST ou até mesmo uma View Controller do padrão MVC.
        - Aqui é onde tudo deve estar em pleno funcionamento pois ela depende de todas as outras camadas. Nessa camada nós configuramos a injeção de dependência e as demais implementações do projeto.

---

## Entity Framework Core (Em Memória)

EF Core In-Memory é a adição de um provedor de dados que torna possível prototipar aplicações e escrever testes sem ter que configurar um banco de dados local ou externo.

---

## Run e Build

- Build:
    - Uma boa prática após o clone de nosso projeto é realizar o build de nossa aplicação, pode ser realizado via terminal com o comando:
~~~ bash
dotnet build
~~~

- Run:
    - Para rodarmos nossa aplicação em modo **run** precisamos garantir que estamos com nossa linha de comando apontada para a camada de **API**, nela podemos utilizar o comando:
~~~ bash
dotnet run
~~~

- Run e Debug:
    - Em caso de necessitar de uma depuração do código e realizar uma análise mais profunda sobre o mesmo, podemos rodar em modo de depuração, onde utilizamos break points. Sendo assim a IDE irá realizar uma ''parada'' no momento em que a sua linha marcada está em execução:
~~~ bash
Basta apertar F5
~~~

