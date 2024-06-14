namespace SimuladorATM.Funcoes
{
    internal class Mensagem
    {
        private const ConsoleColor corOriginalTexto = ConsoleColor.White;
        private const ConsoleColor corOriginalFundo = ConsoleColor.Black;
        public static void ExibirSucesso(string mensagem, bool writeLine = true) 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (writeLine)
            {
                Console.WriteLine(mensagem);
            }
            else
            {
                Console.Write(mensagem);
            }
            Console.ForegroundColor = corOriginalTexto;
        }
        public static void ExibirFracasso(string mensagem, bool writeLine = true) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (writeLine)
            {
                Console.WriteLine(mensagem);
            }
            else 
            {
                Console.Write(mensagem);
            }
            Console.ForegroundColor = corOriginalTexto;
        }
    }
}
