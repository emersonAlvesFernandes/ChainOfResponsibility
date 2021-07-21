using System;

namespace ChainOfResponsability.Metodos
{
    public class MetodoExecutor : MetodoPosAnalise
    {
        public MetodoExecutor(int id, string nome, string url, int ordem)
        {
            Id = id;
            Nome = nome;
            Url = url;
            Ordem = ordem;
        }

        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Url { get; set; }
        public int TimeOut { get; set; }

        protected override bool Executar()
        {
            //TODO: Configurar TimeOut
            Console.WriteLine($"Executar Método {Nome} - {Url}");
            return false; 
        }

        protected override void SalvarResultado(long tempoExecucao)
        {
            Console.WriteLine($"Executei Método {Nome} - {tempoExecucao}ms");
        }
    }
}
