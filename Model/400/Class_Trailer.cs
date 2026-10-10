namespace CNAB400
{
    public class Class_Trailer
    {
        /// <summary>
        /// Identificação do Registro (posição 1 a 1).
        /// </summary>
        /// <value>9</value>
        public string? IdentificacaoRegistro { get; set; }

        /// <summary>
        /// Branco (posição 2 a 394).
        /// </summary>
        /// <value>Branco</value>
        public string? Branco1 { get; set; }

        /// <summary>
        /// Número Sequencial de Registro (posição 395 a 400).
        /// </summary>
        public string? NumeroSequencialRegistro { get; set; }
    }
}

