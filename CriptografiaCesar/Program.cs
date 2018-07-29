using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptografiaCesar
{
    class Program
    {
        static void Main(string[] args)
        {
            char op = opcao();
            int chave;

            Console.WriteLine("\nTexto: ");
            string txt = Console.ReadLine().ToUpper();

            Console.WriteLine("\nChave: ");
            string num = Console.ReadLine();

            chave = validacao(num);

            Console.WriteLine("--- Resultado ---");

            if (op == 'C')
                Console.WriteLine(criptografar(txt, chave));
            else
                Console.WriteLine(descriptografar(txt, chave));

        }

        private static int validacao(string num)
        {
            int chave;
            do
            {
                if (!Int32.TryParse(num, out chave) | chave < 0 | chave > 25)
                {
                    Console.WriteLine("\nValor Inválido! A Chave deve estar entre 0~25");
                }
            } while (!Int32.TryParse(num, out chave) | chave < 0 | chave > 25);
            return chave;
        }

        private static char opcao()
        {
            char op;
            do
            {
                Console.WriteLine("Criptografar ou Descriptografar? [C/D]");

                op = char.ToUpper(Console.ReadKey().KeyChar);

                if (op != 'C' && op != 'D')
                {
                    Console.WriteLine("\nOpção Inválida! Informe 'C' ou 'D'");
                }

            } while (op != 'C' && op != 'D');
            return op;
        }

        private static String criptografar(String texto, int chave)
        {
            return algoritmo(texto, chave, true);
        }

        private static String descriptografar(String texto, int chave)
        {
            return algoritmo(texto, chave, false);
        }

        private static String algoritmo(String texto, int chave, bool opCriptografar)
        {
            String resultado = "";
            for (int i = 0; i < texto.Length; i++)
            {
                if (!char.IsLetter(texto[i]))
                {
                    resultado += texto[i];
                    continue;
                }

                char letraA = char.IsUpper(texto[i]) ? 'A' : 'a';
                char letraZ = char.IsUpper(texto[i]) ? 'Z' : 'z';

                int calc;

                if (opCriptografar)
                {
                    calc = texto[i] + chave;
                    if (calc > letraZ) calc -= 26;
                }
                else
                {
                    calc = texto[i] - chave;
                    if (calc < letraA) calc += 26;
                }

                resultado += (char)calc;
            }

            return resultado;
        }
    }
}
