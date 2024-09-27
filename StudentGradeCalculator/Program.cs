using System;
using System.Collections.Generic;

class Program
{
    static List<Aluno> alunos = new List<Aluno>();
    static GerenciadorNota gerenciadorNota = new GerenciadorNota();

    static void Main(string[] args)
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Cadastrar Aluno");
            Console.WriteLine("2. Calcular Nota de Aluno");
            Console.WriteLine("3. Exibir Todos os Alunos");
            Console.WriteLine("4. Sair");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarAluno();
                    break;
                case "2":
                    CalcularNotaAluno();
                    break;
                case "3":
                    ExibirAlunos();
                    break;
                case "4":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void CadastrarAluno()
    {
        Console.Write("Digite o ID do aluno: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido!");
            return;
        }
        Console.Write("Digite o nome do aluno: ");
        string nome = Console.ReadLine();
        if (string.IsNullOrEmpty(nome))
        {
            Console.WriteLine("Nome inválido!");
            return;
        }

        alunos.Add(new Aluno(id, nome));
        Console.WriteLine("Aluno cadastrado com sucesso!");
    }

    static void CalcularNotaAluno()
    {
        Console.Write("Digite o ID do aluno para calcular a nota: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido!");
            return;
        }

        var aluno = alunos.Find(a => a.Id == id);
        if (aluno != null)
        {
            var notas = new Dictionary<string, double>();
            Console.WriteLine("Digite as notas para os seguintes critérios:");
            foreach (var peso in gerenciadorNota.GetPesos())
            {
                Console.Write($"{peso.Key} (Peso {peso.Value}): ");
                if (!double.TryParse(Console.ReadLine(), out double nota))
                {
                    Console.WriteLine("Nota inválida!");
                    return;
                }
                notas.Add(peso.Key, nota);
            }

            aluno.NotaFinal = gerenciadorNota.CalcularNotaFinal(notas);
            Console.WriteLine($"Nota final calculada: {aluno.NotaFinal}");
        }
        else
        {
            Console.WriteLine("Aluno não encontrado!");
        }
    }

    static void ExibirAlunos()
    {
        foreach (var aluno in alunos)
        {
            Console.WriteLine(aluno);
        }
    }
}