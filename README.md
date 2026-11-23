# Sistema de Gerenciamento de Biblioteca — Grupo 6

**Disciplina:** Estrutura de Dados — TED 2026.2  
**Tema:** Biblioteca  
**Instituição:** UniSapiens (a confirmar)  
**Integrantes:** Felipe Rodrigues Mendes Valente; Antony Gabriel Carvalho da Silva

## Descrição
Aplicação de console desenvolvida em C# para gerenciar um pequeno acervo bibliográfico. Permite cadastro, consulta, empréstimo e devolução de livros, além de operações de busca, seleção e ordenação.

## Requisitos
- .NET SDK 8.0 ou superior compatível com o projeto.

## Execução
No terminal, na pasta que contém `BibliotecaGrupo6.csproj`:

```bash
dotnet run
```

## Estrutura de dados
A classe `BibliotecaService` mantém os livros em `List<Livro>`, estrutura de dados linear dinâmica.

## Algoritmos e critérios
| Operação | Critério 1 | Critério 2 |
| --- | --- | --- |
| Busca linear | Código | Título (parcial, sem diferenciar maiúsculas) |
| Seleção/filtro | Autor | Disponibilidade |
| Ordenação por seleção (Selection Sort) | Título (A–Z) | Ano (crescente) |

As ordenações produzem uma cópia da lista e não alteram a ordem do cadastro. A busca e a seleção percorrem os elementos da lista.

## Funcionalidades
Cadastro com validação de código duplicado; listagem; busca por código e título; filtros por autor e disponibilidade; ordenação por título e ano; empréstimo e devolução com controle de exemplares; resumo do acervo.

O programa inicia com três livros de exemplo para facilitar a demonstração. Os dados são mantidos apenas em memória durante a execução.

## Testes sugeridos para registro de tela
1. Executar `dotnet run` e capturar o menu.
2. Selecionar a opção `2` e capturar a listagem.
3. Selecionar a opção `3`, informar `101` e capturar a busca.
4. Selecionar a opção `7` e capturar a ordenação alfabética.
5. Selecionar a opção `9`, informar `101`, e depois a opção `11` para conferir a quantidade disponível.
6. Selecionar a opção `10`, informar `101`, e consultar novamente a opção `11`.

## Organização
- `Program.cs`: menu e interação com o usuário.
- `Models/Livro.cs`: modelo de dados.
- `Services/BibliotecaService.cs`: regras de negócio e algoritmos.
- `docs/`: relatório e evidências de execução.

## Entrega
Publicar este projeto em um repositório **público** no GitHub, preencher os nomes dos integrantes e anexar o relatório em PDF com capturas reais de execução.
