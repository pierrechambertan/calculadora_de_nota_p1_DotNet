using System;

public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double NotaFinal { get; set; }

    public Aluno(int id, string nome)
    {
        Id = id;
        Nome = nome;
        NotaFinal = 0.0;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Nome: {Nome}, Nota Final: {NotaFinal}";
    }
}