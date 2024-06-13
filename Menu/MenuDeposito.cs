using SimuladorATM.Modelos;
using System.Text.Json;

namespace SimuladorATM.Menu;

internal class MenuDeposito : Menu
{
    public override void Execute()
    {
        Console.Write("Numero da Conta: ");
        string conta = Console.ReadLine()!;
        //string json = File.ReadAllText(@"C:\Users\fegui\OneDrive\Área de Trabalho\Curso em Vídeo\C#\Projetos\SimuladorATM\SimuladorATM\bin\Debug\net8.0\Contas.json");
        string json = File.ReadAllText(@"C:\Users\Família Guimaraes\source\repos\Fezaoo\SimuladorATM\bin\Debug\net8.0\Contas.json");
        Dictionary<string, DadosConta> contas = JsonSerializer.Deserialize<Dictionary<string, DadosConta>>(json)!;
        if (contas.ContainsKey(conta))
        {
            Console.Write("Insira sua senha: ");
            string senha = Console.ReadLine()!;
            if (contas[conta].Senha!.Equals(senha))
            {
                DadosConta contaAcessada = contas[conta];
                Console.Write("Quanto deseja depositar? ");
                double valor = Convert.ToInt32(Console.ReadLine());
                double novoSaldo = valor + contaAcessada.Saldo;

                Console.WriteLine(json);

                //for (int i = 0; i < json.Length; i++)
                //{
                //    if (jsona.Contains(conta))
                //    {
                //        break; // Remove esta linha se quiser substituir todas as ocorrências
                //    }
                //} 
                {
                    Console.WriteLine("Acess Denied");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma conta foi encontrada! ");
            }


        }
    }
}



