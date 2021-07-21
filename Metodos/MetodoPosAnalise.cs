using System;

namespace ChainOfResponsability.Metodos
{
    public abstract class MetodoPosAnalise
    {
        public int Ordem { get; set; }

        protected MetodoPosAnalise ProximoMetodo { get; set; }

        public void ConfigurarProximoMetodo(MetodoPosAnalise proximoMetodo)
        {
            ProximoMetodo = proximoMetodo;
        }

        public void Iniciar(int ordem)
        {
            Console.WriteLine("Início");
            var resultado = false;

            if (this.Ordem >= ordem)
            {                
                resultado = Executar();
                SalvarResultado(1000);
            }

            if (ProximoMetodo != null && !resultado)
                ProximoMetodo.Iniciar(Ordem);
            else
                Console.WriteLine("Fim");
        }

        abstract protected bool Executar();
        abstract protected void SalvarResultado(long tempoExecucao);
    }
}
