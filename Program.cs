using ChainOfResponsability.Metodos;
using System;
using System.Collections.Generic;

namespace ChainOfResponsability
{
    /// <summary>
    /// Se a ideia é executar sequencialmente, não há necessidade de criarmos brokers
    /// Pois não haverá execução assíncrona;
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("POC encadeamento de execução de API's");
            var encadeamento = new Encadeamento(100515);
            MetodoExecutor executor = encadeamento.Obter();
            executor.Iniciar(executor.Ordem);
        }
    }

    /// <summary>
    /// Considerar esta classe abstraída
    /// </summary>
    public class Encadeamento
    {
        public int EntidadeId { get; set; }        
        public Encadeamento(int entidadeId)
        {
            EntidadeId = entidadeId;
        }
        
        /// <summary>
        /// Por uma questão de simplicidade este método cria instancias.
        /// Considerar obter estes dados parametrizados em algum repositório (Sql/Redis/Mongo)        
        /// </summary>
        /// <returns></returns>
        public MetodoExecutor Obter()
        {
            var MetodoTransbordo = new MetodoExecutor(0, "Transbordo", "URL http://920627-apis-asp.globalrs.rack.space/api/Transbordo", 0);
            var MetodoSimSwap = new MetodoExecutor(1, "SimSwap", "URL http://920627-apis-asp.globalrs.rack.space/api/SimSwap", 1);
            var MetodoFluxoVip = new MetodoExecutor(2, "FluxoVip", "URL http://920627-apis-asp.globalrs.rack.space/api/FluxoVip", 2);

            MetodoTransbordo.ConfigurarProximoMetodo(MetodoSimSwap);
            MetodoSimSwap.ConfigurarProximoMetodo(MetodoFluxoVip);

            return MetodoTransbordo;
        }
    }
}
