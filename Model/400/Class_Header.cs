namespace CNAB400
{
    public class Class_Header
    {
        /// <summary>
        /// Identificação do Registro (posição 1 a 1).
        /// </summary>
        /// <value>0</value>
        public string? IdentificacaoRegistro { get; set; }

        /// <summary>
        /// Identificação do Arquivo-Remessa (posição 2 a 2).
        /// </summary>
        /// <value>1</value>
        public string? IdentificacaoArquivoRemessa { get; set; }

        /// <summary>
        /// Literal Remessa (posição 3 a 9).
        /// </summary>
        /// <value>REMESSA</value>
        public string? LiteralRemessa { get; set; }

        /// <summary>
        /// Código de Serviço (posição 10 a 11).
        /// </summary>
        /// <value>01</value>
        public string? CodigoServico { get; set; }

        /// <summary>
        /// Literal Serviço (posição 12 a 26).
        /// </summary>
        /// <value>COBRANCA</value>
        public string? LiteralServico { get; set; }

        /// <summary>
        /// Código da Empresa (posição 27 a 46).
        /// </summary>
        public string? CodigoEmpresa { get; set; }

        /// <summary>
        /// Nome da Empresa (posição 47 a 76).
        /// </summary>
        public string? NomeEmpresa { get; set; }

        /// <summary>
        /// Número do Bradesco na Câmara de Compensação (posição 77 a 79).
        /// </summary>
        /// <value>237</value>
        public string? NumeroBradesco { get; set; }

        /// <summary>
        /// Nome do Banco por Extenso (posição 80 a 94).
        /// </summary>
        /// <value>Bradesco</value>
        public string? NomeBanco { get; set; }

        /// <summary>
        /// Data da Gravação do Arquivo (posição 95 a 100).
        /// </summary>
        public string? DataGravacaoArquivo { get; set; }

        /// <summary>
        /// Branco (posição 101 a 108).
        /// </summary>
        /// <value>Branco</value>
        public string? Branco1 { get; set; }

        /// <summary>
        /// Identificação do Sistema (posição 109 a 110).
        /// </summary>
        /// <value>MX</value>
        public string? IdentificacaoSistema { get; set; }

        /// <summary>
        /// Nº Sequencial de Remessa (posição 111 a 117).
        /// </summary>
        public string? NumeroSequencialRemessa { get; set; }

        /// <summary>
        /// Branco (posição 118 a 394).
        /// </summary>
        /// <value>Branco</value>
        public string? Branco2 { get; set; }

        /// <summary>
        /// Nº Sequencial do Registro de Um em Um (posição 395 a 400).
        /// </summary>
        /// <value>000001</value>
        public string? NumeroSequencialRegistro { get; set; }
    }
}

