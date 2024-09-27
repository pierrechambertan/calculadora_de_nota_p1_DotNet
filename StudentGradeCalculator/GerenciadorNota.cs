using System;
using System.Collections.Generic;

public class GerenciadorNota
{
    private Dictionary<string, double> pesos;

    public GerenciadorNota()
    {
        pesos = new Dictionary<string, double>
        {
            { "Clareza", 4.0 },
            { "Malidade do Material", 4.0 },
            { "Esclarecimentos", 4.0 },
            { "Introdução", 6.0 },
            { "Referencial", 6.0 },
            { "Linguagem Padrao", 6.0 },
            { "Relevancia", 6.0 }
        };
    }

    public Dictionary<string, double> GetPesos()
    {
        return new Dictionary<string, double>(pesos);
    }

    public double CalcularNotaFinal(Dictionary<string, double> notas)
    {
        double somaNotasPonderadas = 0.0;
        double somaPesos = 0.0;
        
        foreach (var item in notas)
        {
            if (pesos.ContainsKey(item.Key))
            {
                somaNotasPonderadas += item.Value * pesos[item.Key];
                somaPesos += pesos[item.Key];
            }
        }

        return somaPesos > 0 ? somaNotasPonderadas / somaPesos : 0;
    }
}