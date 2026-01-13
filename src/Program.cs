using System;

namespace AvaliacaoParadigma
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Avaliação Técnica Paradigma - Tarefa 2 ===\n");

            // Cenário 1
            Console.WriteLine("Cenário 1:");
            Console.WriteLine("Array de entrada: [3, 2, 1, 6, 0, 5]");
            int[] array1 = { 3, 2, 1, 6, 0, 5 };
            NoArvore raiz1 = ConstrutorArvore.ConstruirArvore(array1);
            Console.WriteLine("\nÁrvore construída:");
            ConstrutorArvore.ImprimirArvore(raiz1);
            Console.WriteLine("\nTravessia In-Order: ");
            ConstrutorArvore.ImprimirEmOrdem(raiz1);
            Console.WriteLine("\n");

            // Cenário 2
            Console.WriteLine("Cenário 2:");
            Console.WriteLine("Array de entrada: [7, 5, 13, 9, 1, 6, 4]");
            int[] array2 = { 7, 5, 13, 9, 1, 6, 4 };
            NoArvore raiz2 = ConstrutorArvore.ConstruirArvore(array2);
            Console.WriteLine("\nÁrvore construída:");
            ConstrutorArvore.ImprimirArvore(raiz2);
            Console.WriteLine("\nTravessia In-Order: ");
            ConstrutorArvore.ImprimirEmOrdem(raiz2);
            Console.WriteLine("\n");

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
