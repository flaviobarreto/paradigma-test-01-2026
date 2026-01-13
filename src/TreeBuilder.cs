using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoParadigma
{
    public class NoArvore
    {
        public int Valor { get; set; }
        public NoArvore Esquerda { get; set; }
        public NoArvore Direita { get; set; }

        public NoArvore(int valor)
        {
            Valor = valor;
            Esquerda = null;
            Direita = null;
        }
    }

    public class ConstrutorArvore
    {
        public static NoArvore ConstruirArvore(int[] array)
        {
            if (array == null || array.Length == 0)
                return null;

            // Encontra o índice do maior valor (raiz)
            int maxIndex = Array.IndexOf(array, array.Max());
            int rootValue = array[maxIndex];

            // Cria a raiz
            NoArvore raiz = new NoArvore(rootValue);

            // Divide o array em duas partes: esquerda e direita da raiz
            int[] arrayEsquerda = array.Take(maxIndex).ToArray();
            int[] arrayDireita = array.Skip(maxIndex + 1).ToArray();

            // Constrói os galhos da esquerda (ordem decrescente)
            raiz.Esquerda = ConstruirGalhoEsquerdo(arrayEsquerda);

            // Constrói os galhos da direita (ordem decrescente)
            raiz.Direita = ConstruirGalhoDireito(arrayDireita);

            return raiz;
        }

        private static NoArvore ConstruirGalhoEsquerdo(int[] array)
        {
            if (array == null || array.Length == 0)
                return null;

            // Ordena em ordem decrescente
            int[] ordenado = array.OrderByDescending(x => x).ToArray();

            // Constrói a árvore: o maior valor fica no topo, os menores abaixo
            NoArvore raiz = new NoArvore(ordenado[0]);

            // Insere os valores restantes em ordem decrescente
            for (int i = 1; i < ordenado.Length; i++)
            {
                InserirEsquerda(raiz, ordenado[i]);
            }

            return raiz;
        }
        
        private static NoArvore ConstruirGalhoDireito(int[] array)
        {
            if (array == null || array.Length == 0)
                return null;

            // Ordena em ordem decrescente
            int[] ordenado = array.OrderByDescending(x => x).ToArray();

            // Constrói a árvore: o maior valor fica no topo, os menores abaixo
            NoArvore raiz = new NoArvore(ordenado[0]);

            // Insere os valores restantes em ordem decrescente
            for (int i = 1; i < ordenado.Length; i++)
            {
                InserirDireita(raiz, ordenado[i]);
            }

            return raiz;
        }

        private static void InserirEsquerda(NoArvore no, int valor)
        {
            if (no.Esquerda == null)
            {
                no.Esquerda = new NoArvore(valor);
            }
            else
            {
                // Continua descendo pela esquerda
                InserirEsquerda(no.Esquerda, valor);
            }
        }

        private static void InserirDireita(NoArvore no, int valor)
        {
            if (no.Direita == null)
            {
                no.Direita = new NoArvore(valor);
            }
            else
            {
                // Continua descendo pela direita
                InserirDireita(no.Direita, valor);
            }
        }

        public static void ImprimirArvore(NoArvore raiz, string prefixo = "", bool eUltimo = true)
        {
            if (raiz == null)
                return;

            Console.WriteLine(prefixo + (eUltimo ? "└── " : "├── ") + raiz.Valor);

            string novoPrefixo = prefixo + (eUltimo ? "    " : "│   ");

            if (raiz.Esquerda != null || raiz.Direita != null)
            {
                if (raiz.Esquerda != null)
                {
                    ImprimirArvore(raiz.Esquerda, novoPrefixo, raiz.Direita == null);
                }
                if (raiz.Direita != null)
                {
                    ImprimirArvore(raiz.Direita, novoPrefixo, true);
                }
            }
        }

        public static void ImprimirEmOrdem(NoArvore raiz)
        {
            if (raiz != null)
            {
                ImprimirEmOrdem(raiz.Esquerda);
                Console.Write(raiz.Valor + " ");
                ImprimirEmOrdem(raiz.Direita);
            }
        }
    }
}
