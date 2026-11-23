using BibliotecaGrupo6.Models;
using BibliotecaGrupo6.Services;

BibliotecaService biblioteca = new();

biblioteca.Cadastrar(new Livro { Codigo = 101, Titulo = "Dom Casmurro", Autor = "Machado de Assis", Ano = 1899, QuantidadeTotal = 3 });
biblioteca.Cadastrar(new Livro { Codigo = 102, Titulo = "O Cortico", Autor = "Aluisio Azevedo", Ano = 1890, QuantidadeTotal = 2 });
biblioteca.Cadastrar(new Livro { Codigo = 103, Titulo = "Iracema", Autor = "Jose de Alencar", Ano = 1865, QuantidadeTotal = 1 });

while (true)
{
    Console.WriteLine("\n=== SISTEMA DE BIBLIOTECA - GRUPO 6 ===");
    Console.WriteLine("1 - Cadastrar livro");
    Console.WriteLine("2 - Listar livros");
    Console.WriteLine("3 - Buscar por codigo");
    Console.WriteLine("4 - Buscar por titulo");
    Console.WriteLine("5 - Selecionar por autor");
    Console.WriteLine("6 - Selecionar por disponibilidade");
    Console.WriteLine("7 - Ordenar por titulo");
    Console.WriteLine("8 - Ordenar por ano");
    Console.WriteLine("9 - Emprestar livro");
    Console.WriteLine("10 - Devolver livro");
    Console.WriteLine("11 - Resumo do acervo");
    Console.WriteLine("0 - Sair");
    int opcao = LerInteiro("Opcao: ");
    switch (opcao)
    {
        case 1:
            Livro novo = new()
            {
                Codigo = LerInteiro("Codigo: "),
                Titulo = LerTexto("Titulo: "),
                Autor = LerTexto("Autor: "),
                Ano = LerInteiro("Ano: "),
                QuantidadeTotal = LerInteiro("Quantidade de exemplares: ")
            };
            Console.WriteLine(biblioteca.Cadastrar(novo) ? "Livro cadastrado." : "Cadastro invalido ou codigo duplicado.");
            break;
        case 2: Exibir(biblioteca.Listar()); break;
        case 3:
            Livro? encontrado = biblioteca.BuscarPorCodigo(LerInteiro("Codigo: "));
            Exibir(encontrado == null ? new List<Livro>() : new List<Livro> { encontrado });
            break;
        case 4: Exibir(biblioteca.BuscarPorTitulo(LerTexto("Titulo ou parte: "))); break;
        case 5: Exibir(biblioteca.SelecionarPorAutor(LerTexto("Autor ou parte: "))); break;
        case 6: Exibir(biblioteca.SelecionarPorDisponibilidade(true)); break;
        case 7: Exibir(biblioteca.OrdenarPorTitulo()); break;
        case 8: Exibir(biblioteca.OrdenarPorAno()); break;
        case 9: Console.WriteLine(biblioteca.Emprestar(LerInteiro("Codigo: ")) ? "Emprestimo realizado." : "Livro inexistente ou indisponivel."); break;
        case 10: Console.WriteLine(biblioteca.Devolver(LerInteiro("Codigo: ")) ? "Devolucao realizada." : "Devolucao nao permitida."); break;
        case 11:
            var resumo = biblioteca.Resumo();
            Console.WriteLine($"Titulos: {resumo.Titulos} | Exemplares: {resumo.Exemplares} | Disponiveis: {resumo.Disponiveis}");
            break;
        case 0: return;
        default: Console.WriteLine("Opcao invalida."); break;
    }
}

static int LerInteiro(string mensagem)
{
    while (true)
    {
        Console.Write(mensagem);
        if (int.TryParse(Console.ReadLine(), out int numero)) return numero;
        Console.WriteLine("Informe um numero inteiro valido.");
    }
}

static string LerTexto(string mensagem)
{
    while (true)
    {
        Console.Write(mensagem);
        string texto = (Console.ReadLine() ?? "").Trim();
        if (texto.Length > 0) return texto;
        Console.WriteLine("O campo nao pode ficar vazio.");
    }
}

static void Exibir(List<Livro> livros)
{
    if (livros.Count == 0) { Console.WriteLine("Nenhum livro encontrado."); return; }
    Console.WriteLine("CODIGO | TITULO | AUTOR | ANO | DISPONIVEIS/TOTAL");
    foreach (Livro livro in livros)
        Console.WriteLine($"{livro.Codigo} | {livro.Titulo} | {livro.Autor} | {livro.Ano} | {livro.Disponiveis}/{livro.QuantidadeTotal}");
}
