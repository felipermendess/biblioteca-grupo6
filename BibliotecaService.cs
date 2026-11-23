using BibliotecaGrupo6.Models;

namespace BibliotecaGrupo6.Services;

public class BibliotecaService
{
    private readonly List<Livro> livros = new();

    public bool Cadastrar(Livro livro)
    {
        if (livro.Codigo <= 0 || string.IsNullOrWhiteSpace(livro.Titulo) ||
            string.IsNullOrWhiteSpace(livro.Autor) || livro.Ano < 1450 ||
            livro.Ano > DateTime.Now.Year || livro.QuantidadeTotal < 1 ||
            BuscarPorCodigo(livro.Codigo) != null) return false;
        livro.Disponiveis = livro.QuantidadeTotal;
        livros.Add(livro);
        return true;
    }

    public List<Livro> Listar() => new(livros);

    public Livro? BuscarPorCodigo(int codigo)
    {
        foreach (Livro livro in livros)
            if (livro.Codigo == codigo) return livro;
        return null;
    }

    public List<Livro> BuscarPorTitulo(string titulo)
    {
        List<Livro> encontrados = new();
        foreach (Livro livro in livros)
            if (livro.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase))
                encontrados.Add(livro);
        return encontrados;
    }

    public List<Livro> SelecionarPorAutor(string autor)
    {
        List<Livro> selecionados = new();
        foreach (Livro livro in livros)
            if (livro.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase))
                selecionados.Add(livro);
        return selecionados;
    }

    public List<Livro> SelecionarPorDisponibilidade(bool apenasDisponiveis)
    {
        List<Livro> selecionados = new();
        foreach (Livro livro in livros)
            if (!apenasDisponiveis || livro.Disponiveis > 0)
                selecionados.Add(livro);
        return selecionados;
    }

    public List<Livro> OrdenarPorTitulo() => Ordenar((a, b) =>
        string.Compare(a.Titulo, b.Titulo, StringComparison.OrdinalIgnoreCase));

    public List<Livro> OrdenarPorAno() => Ordenar((a, b) => a.Ano.CompareTo(b.Ano));

    private List<Livro> Ordenar(Comparison<Livro> comparar)
    {
        List<Livro> resultado = new(livros);
        for (int i = 0; i < resultado.Count - 1; i++)
        {
            int menor = i;
            for (int j = i + 1; j < resultado.Count; j++)
                if (comparar(resultado[j], resultado[menor]) < 0) menor = j;
            (resultado[i], resultado[menor]) = (resultado[menor], resultado[i]);
        }
        return resultado;
    }

    public bool Emprestar(int codigo)
    {
        Livro? livro = BuscarPorCodigo(codigo);
        if (livro == null || livro.Disponiveis == 0) return false;
        livro.Disponiveis--;
        return true;
    }

    public bool Devolver(int codigo)
    {
        Livro? livro = BuscarPorCodigo(codigo);
        if (livro == null || livro.Disponiveis >= livro.QuantidadeTotal) return false;
        livro.Disponiveis++;
        return true;
    }

    public (int Titulos, int Exemplares, int Disponiveis) Resumo() =>
        (livros.Count, livros.Sum(l => l.QuantidadeTotal), livros.Sum(l => l.Disponiveis));
}
