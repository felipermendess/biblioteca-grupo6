namespace BibliotecaGrupo6.Models;

public class Livro
{
    public int Codigo { get; set; }
    public string Titulo { get; set; } = "";
    public string Autor { get; set; } = "";
    public int Ano { get; set; }
    public int QuantidadeTotal { get; set; }
    public int Disponiveis { get; set; }
}
