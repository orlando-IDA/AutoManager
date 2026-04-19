# API - Oficina Automotiva

**Disciplina:** Advanced Business Development with .NET <br>
**Avaliação:** CP02 - Implementação de API com Persistência e Clean Architecture

## Integrantes do Grupo
* **Orlando Gonçalves** - RM: 561584
* **Gabriel Lourenço Martins** - RM: 562194
* **André Emygdio Ferreira** - RM: 565592

## Domínio e Entidades
O sistema gerencia uma oficina mecânica através das seguintes entidades principais:
1. **Cliente:** Cadastro do proprietário (Nome, CPF, Telefone).
2. **Veículo:** Dados do automóvel vinculado ao cliente (Placa, Montadora, Modelo).
3. **OrdemServico:** Registro da manutenção e controle de status.
4. **OrderItem:** Itens de peças ou serviços aplicados em uma OS.
5. **Pagamento:** Finalização financeira da ordem de serviço.

## Arquitetura do Projeto
A solução foi implementada utilizando uma arquitetura em 4 camadas:
* **Domain:** Contém as entidades de negócio, enums e a lógica de validação via construtores. Utiliza propriedades com setters privados para garantir o encapsulamento.
* **Application:** Define os contratos (Interfaces) e os objetos de transferência de dados (DTOs) utilizando C# Records e Data Annotations para validação de entrada.
* **Infrastructure:** Implementa o acesso a dados utilizando Entity Framework Core, o contexto do banco de dados e as configurações de mapeamento via Fluent API.
* **API:** Camada de entrada com Controllers documentados, configuração de injeção de dependência e exposição dos endpoints.

## Tecnologias e Padrões
* .NET 9.0 SDK
* Entity Framework Core 9.0 (ORM)
* SQLite (Banco de dados local)
* Repository Pattern (Específico por entidade)
* Primary Constructors (C# 12)

## Instruções para Execução
1. Certifique-se de ter o .NET 9 SDK instalado.
2. Caso não possua a ferramenta do Entity Framework, instale via terminal:
   `dotnet tool install --global dotnet-ef`
3. No diretório raiz do projeto, execute o comando para atualizar o banco de dados:
   `dotnet ef database update --project AutoManager.Infrastructure --startup-project AutoManager.API`
4. Execute o projeto:
   `dotnet run --project AutoManager.API`

## Fluxo de Trabalho Sugerido
Para testar a integração completa do sistema, siga a sequência de operações abaixo via API:
1. **Cadastro de Cliente:** Criar um novo proprietário via `POST /api/Customer`.
2. **Registro de Veículo:** Vincular um carro ao cliente utilizando o ID retornado no passo anterior via `POST /api/Vehicle`.
3. **Abertura de Ordem de Serviço:** Iniciar um atendimento para o veículo via `POST /api/ServiceOrder`.
4. **Adição de Itens:** Inserir peças ou serviços à ordem de serviço via `POST /api/OrderItem`.
5. **Encerramento e Pagamento:** Registrar o acerto financeiro final via `POST /api/Payment`.
