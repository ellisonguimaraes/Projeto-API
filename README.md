# Projeto de API: Criando e Consumindo

Este projeto tem como objetivo criar uma API (*Application Programming Interface*) qualquer e criar um outro projeto de página web que realiza um CRUD utilizando a API desenvolvida.



## Tecnologias Utilizadas

Este projeto foi desenvolvido em **ASP.NET Core 2.2**. O download do **Sdk** poderá ser feito através do link a seguir:  https://dotnet.microsoft.com/download/dotnet-core/2.2 (Disponível para Windows, Linux, MacOS, etc.).

Para executar o projeto, é necessário percorrer até o diretório base do projeto através do **CMD/Terminal**. Quando estiver no diretório deverá ser executado o comando `dotnet build && dotnet run`, como mostra na figura a seguir:

![image-20201121211348609](images_markdown\image-20201121211348609.png)

Quando executar, aparecerá uma mensagem de compilação com êxito e será exibido o link/porta de acesso.



## Projeto API (Funcionario.API)

O projeto de API é encontrado no diretório `Funcionarios.API/Funcionarios.API`. Nesse projeto, foi setado `IP/PORT` fixo para `http://localhost/5005`.

> Caso queira alterar IP e PORTA de acesso, é necessário fazer a modificação no arquivo `Program.cs` contido na pasta base do projeto de API.  
>
> Ou também, há a possibilidade de remover IP/PORT fixo, deixando o *dotnet* escolher em qual link será feito o acesso. Para isso, é necessário trocar a linha 14:
>
> ```C#
> CreateWebHostBuilder(args).UseUrls("http://localhost:5005").Build().Run();
> ```
>
> por
>
> ```C#
> CreateWebHostBuilder(args).Build().Run();
> ```
>
> Porém, caso seja feita qualquer alteração acima, é necessário que faça a configuração do novo acesso no projeto que consome esta API. Essa configuração pode ser feito através da pasta base do projeto, no arquivo `ConsumindoAPI/Repositories/FuncionarioRepository.cs` na linha 18:
>
> ```C#
> private string url = "http://localhost:5005/v1/funcionarios";
> ```



Neste projeto, há os seguintes métodos de requisição HTTP de acesso:

- `GET`: 

  - http://localhost:5005/v1/funcionarios : Retorna todos os funcionários.
  - http://localhost:5005/v1/funcionarios/id : Retorna o funcionário com base no ID informado.

- `POST`:

  - http://localhost:5005/v1/funcionarios : Adiciona um novo funcionário.

    Com *Request Body* em *Json*:

    ```json
    {
        "nome": "Marcos",
        "dataNascimento": "1994-02-26T00:00:00",
        "salario": 7500
    }
    ```

- `PUT`:

  - http://localhost:5005/v1/funcionarios/id : Edita um funcionário.

    Com *Request Body* em *Json*:

    ```json
    {
        "id": "b4ac4a66-2729-4d9a-b0b7-dab5f3e92052",
        "nome": "Ellison",
        "dataNascimento": "1998-01-17T00:00:00",
        "salario": 1569.0
    }
    ```

- `DEL`:

  - http://localhost:64339/v1/funcionarios/id : Exclui um funcionário.





## Projeto Interface CRUD (ConsumindoAPI)

O projeto de API é encontrado no diretório `ConsumindoAPI/ConsumindoAPI`. Nesse projeto, não foi setado `IP/PORT` fixo. Para isso, é necessário ver a posta disponível ao executar o comando `dotnet build && dotnet run`.

![image-20201121215244348](/images_markdown\image-20201121215158502.png)

Ao acessar o link, será exibido uma página de CRUD na qual foram utilizados `HTML`, `CSS` e `BOOSTRAP` e as *TagsHelpers* do `ASP.NET CORE`.

![image-20201121215434433](./images_markdown\image-20201121215434433.png)