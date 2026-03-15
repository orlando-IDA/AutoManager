# API - Oficina Automotiva

**Disciplina:** Advanced Business Development with .NET <br>
**Avaliação:** CP01 - Modelo Entidade-Relacionamento e Estrutura Clean Arch  

## Integrantes do Grupo
* **Orlando Gonçalves** - RM: 561584
* **Gabriel Lourenço Martins** - RM: 562194
* **André Emygdio Ferreira** - RM: 565592

## Domínio Escolhido
O domínio escolhido foi um **Sistema de Gerenciamento para Oficina Mecânica Automotiva**. O sistema tem como objetivo registrar clientes, seus respectivos veículos e gerenciar as Ordens de Serviço de upgrades e manutenções, incluindo as peças aplicadas e o pagamento final.

## Entidades Modeladas
Foram modeladas 5 entidades principais:
1. **Cliente:** Registra os dados do proprietário (Id_Cliente, Nome, Cpf, Telefone).
2. **Veículo:** Registra os carros vinculados ao cliente (Id_Veiculo, Placa, Montadora, Modelo).
3. **OrdemServico:** Representa o serviço sendo executado no veículo (Id_OrdemServico, DataEntrada, Status).
4. **ItemPeca:** Peças ou serviços aplicados em uma OS específica (Id_ItemPeca, Descricao, Valor).
5. **Pagamento:** O acerto financeiro final vinculado a uma OS (Id_Pagamento, ValorTotal, Metodo).


## Resumo dos Relacionamentos
* **Cliente -> Veículo:** (1:N) - Um cliente pode ter vários veículos, mas um veículo pertence obrigatoriamente a um cliente.
* **Veículo -> OrdemServico:** (1:N) - Um veículo pode ter várias Ordens de Serviço ao longo do tempo, mas uma OS pertence a apenas um veículo.
* **OrdemServico -> ItemPeca:** (1:N) - Uma OS pode conter várias peças, e uma peça registrada no sistema pertence a uma única OS.
* **OrdemServico -> Pagamento:** (1:1) - Uma OS possui apenas um pagamento correspondente. A existência do pagamento é opcional na abertura da OS.