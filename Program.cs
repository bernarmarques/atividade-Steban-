using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

class JogoDaForca
{
    static void Main()
    {
        // Lista de palavras
        string[] palavras = { "programacao", "teclado", "Metodo", "Rede" };
        Random rand = new Random();
        string palavraSecreta = palavras[rand.Next(palavras.Length)];

        // Inicializa o progresso do jogador com '_'
        char[] progresso = new string('_', palavraSecreta.Length).ToCharArray();

        int tentativasRestantes = 6;
        List<char> letrasTentadas = new List<char>();

        while (tentativasRestantes > 0 && progresso.Contains('_'))
        {
            Console.Clear();
            DesenharBoneco(6 - tentativasRestantes); // Mostra o boneco conforme os erros
            Console.WriteLine("\nPalavra: " + string.Join(" ", progresso));
            Console.WriteLine($"Tentativas restantes: {tentativasRestantes}");
            Console.WriteLine("Letras já tentadas: " + string.Join(", ", letrasTentadas));
            Console.Write("Digite uma letra: ");
            string entrada = Console.ReadLine().ToLower();

            // Validação
            if (entrada.Length != 1 || !char.IsLetter(entrada[0]))
            {
                Console.WriteLine("Entrada inválida. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                continue;
            }

            char letra = entrada[0];

            if (letrasTentadas.Contains(letra))
            {
                Console.WriteLine("Você já tentou essa letra. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                continue;
            }

            letrasTentadas.Add(letra);

            if (palavraSecreta.Contains(letra))
            {
                Console.WriteLine(" Letra correta!");
                Color corVerde = Color.FromArgb(0, 128, 0); // Verde

                for (int i = 0; i < palavraSecreta.Length; i++)
                {
                    if (palavraSecreta[i] == letra)
                        progresso[i] = letra;
                }
            }
            else
            {
                Console.WriteLine(" Letra incorreta.");
                tentativasRestantes--;
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        // Resultado final
        Console.Clear();
        DesenharBoneco(6 - tentativasRestantes); // Mostra o boneco final
        Console.WriteLine("\nPalavra: " + string.Join(" ", progresso));

        if (!progresso.Contains('_'))
        {
            Console.WriteLine(" Parabéns! Você descobriu a palavra: " + palavraSecreta);
        }
        else
        {
            Console.WriteLine(" Fim de jogo! A palavra era: " + palavraSecreta);
        }

        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    // Método que desenha o boneco da forca com base nos erros 
    static void DesenharBoneco(int erros)
    {
        Console.WriteLine(" +---+");
        Console.WriteLine(" |   |");

        Console.WriteLine(" " + (erros >= 1 ? "O" : " ") + "   |");

        if (erros == 2)
            Console.WriteLine(" |   |");
        else if (erros == 3)
            Console.WriteLine("/|   |");
        else if (erros >= 4)
            Console.WriteLine("/|\\  |");
        else
            Console.WriteLine("     |");

        if (erros == 5)
            Console.WriteLine("/    |");
        else if (erros >= 6)
            Console.WriteLine("/ \\  |");
        else
            Console.WriteLine("     |");

        Console.WriteLine("     |");
        Console.WriteLine("=====");
    }
}
