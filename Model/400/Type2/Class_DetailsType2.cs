namespace CNAB400.Type2
{
    public class Class_DetailsType2
    {
        /// <summary>
        /// Tipo Registro (posição 1 a 1).
        /// </summary>
        /// <value>2</value>
        public string? TipoRegistro { get; set; }

        /// <summary>
        /// Mensagem 1 (posição 2 a 81).
        /// </summary>
        public string? Mensagem1 { get; set; }

        /// <summary>
        /// Mensagem 2 (posição 82 a 161).
        /// </summary>
        public string? Mensagem2 { get; set; }

        /// <summary>
        /// Mensagem 3 (posição 162 a 241).
        /// </summary>
        public string? Mensagem3 { get; set; }

        /// <summary>
        /// Mensagem 4 (posição 242 a 321).
        /// </summary>
        public string? Mensagem4 { get; set; }

        /// <summary>
        /// Data-Limite para Concessão de Desconto 2 (posição 322 a 327).
        /// </summary>
        public string? DataLimiteConcessaoDesconto2 { get; set; }

        /// <summary>
        /// Valor do Desconto 2 (posição 328 a 340).
        /// </summary>
        public string? ValorDesconto2 { get; set; }

        /// <summary>
        /// Data-Limite para Concessão de Desconto 3 (posição 341 a 346).
        /// </summary>
        public string? DataLimiteConcessaoDesconto3 { get; set; }

        /// <summary>
        /// Valor do Desconto 3 (posição 347 a 359).
        /// </summary>
        public string? ValorDesconto3 { get; set; }

        /// <summary>
        /// Reserva (posição 360 a 366).
        /// </summary>
        /// <value>Filler</value>
        public string? Reserva { get; set; }

        /// <summary>
        /// Carteira (posição 367 a 369).
        /// </summary>
        public string? Carteira { get; set; }

        /// <summary>
        /// Agência (posição 370 a 374).
        /// </summary>
        public string? Agencia { get; set; }

        /// <summary>
        /// Conta-Corrente (posição 375 a 381).
        /// </summary>
        public string? ContaCorrente { get; set; }

        /// <summary>
        /// Dígito C/C (posição 382 a 382).
        /// </summary>
        public string? DigitoContaCorrente { get; set; }

        /// <summary>
        /// Nosso Número (posição 383 a 393).
        /// </summary>
        public string? NossoNumero { get; set; }

        /// <summary>
        /// DAC Nosso Número (posição 394 a 394).
        /// </summary>
        public string? DacNossoNumero { get; set; }

        /// <summary>
        /// Nº Sequencial de Registro (posição 395 a 400).
        /// </summary>
        public string? NumeroSequencialRegistro { get; set; }
    }
}

