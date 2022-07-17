namespace GarageRev.Models {

    //é o viewmodel dos carros que vai retornar os valores da API para o react
    public class ApiViewModel {

        /// <summary>
        /// Identificador de cada Carro
        /// </summary>
        public int IdCarro { get; set; }
        /// <summary>
        /// Marca de cada carro
        /// </summary>
        public string Marca { get; set; }
        /// <summary>
        /// Modelo de cada carro
        /// </summary>
        public string Modelo { get; set; }
        /// <summary>
        /// Versão de cada Carro
        /// </summary>
        public string Versao { get; set; }
        /// <summary>
        /// Tipo de Combustivel de cada Carro
        /// </summary>
        public string Combustivel { get; set; }
        /// <summary>
        /// Ano de fabrico de cada Carro
        /// </summary>
        public int Ano { get; set; }
        /// <summary>
        /// Cilindrada, em cm3, de cada Carro ou bateria em kwh
        /// </summary>
        public int CilindradaouCapacidadeBateria { get; set; }
        /// <summary>
        /// Potencia, em cv, de cada Carro
        /// </summary>
        public int Potencia { get; set; }
        /// <summary>
        /// Tipo de Caixa de cada Carro
        /// </summary>
        public string TipoCaixa { get; set; }
        /// <summary>
        /// Numero de Portas de cada Carro
        /// </summary>
        public string Nportas { get; set; }
        /// <summary>
        /// Fotografias de cada carro
        /// </summary>
        public string Foto { get; set; }

    }
}
