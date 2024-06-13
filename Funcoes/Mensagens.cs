namespace SimuladorATM.Funcoes
{
    internal class Mensagens
    {
        private const ConsoleColor corOriginalTexto = ConsoleColor.White;
        private const ConsoleColor corOriginalFundo = ConsoleColor.Black;
        public static void ExibirSucesso(string mensagem) 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensagem);
            Console.ForegroundColor = corOriginalTexto;
        }
        public static void ExibirFracasso(string mensagem) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ForegroundColor = corOriginalTexto;
        }

    }
}
