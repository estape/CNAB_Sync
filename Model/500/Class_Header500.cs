namespace CNAB500
{
    public class Class_Header500
    {
        /// <summary>
        /// Identificação do Registro (posição 1 a 1). (Obrigatório).
        /// </summary>
        /// <value>0</value>
        public string? IdentificacaoRegistro { get; set; }

        /// <summary>
        /// Identificação do Arquivo Remessa (posição 2 a 2). (Obrigatório).
        /// </summary>
        /// <value>8</value>
        public string? IdentificacaoArquivoRemessa { get; set; }

        /// <summary>
        /// Literal Remessa (posição 3 a 9). (Obrigatório).
        /// </summary>
        /// <value>REMESSA</value>
        public string? LiteralRemessa { get; set; }

        /// <summary>
        /// Código de Serviço (posição 10 a 11). (Obrigatório).
        /// </summary>
        /// <value>01</value>
        public string? CodigoServico { get; set; }

        /// <summary>
        /// Literal Serviço (posição 12 a 26). (Obrigatório).
        /// </summary>
        /// <value>COBRANCA</value>
        public string? LiteralServico { get; set; }

        /// <summary>
        /// Código do Originador (Consultoria) (posição 27 a 46). (Obrigatório).
        /// </summary>
        /// <value>Será fornecido pelo Custodiante, quando do Cadastramento. Vide tópico 2.1 - Seção A</value>
        public string? CodigoOriginador { get; set; }

        /// <summary>
        /// Nome do Originador (Consultoria) (posição 47 a 76). (Obrigatório).
        /// </summary>
        /// <value>Razão Social</value>
        public string? NomeOriginador { get; set; }

        /// <summary>
        /// Número do Banco (posição 77 a 79). (Obrigatório).
        /// </summary>
        /// <value>Número do Banco</value>
        public string? NumeroBanco { get; set; }

        /// <summary>
        /// Nome do Banco (posição 80 a 94). (Obrigatório).
        /// </summary>
        /// <value>Nome do Banco</value>
        public string? NomeBanco { get; set; }

        /// <summary>
        /// Data da Gravação do Arquivo (posição 95 a 100). (Obrigatório).
        /// </summary>
        /// <value>DDMMAA Vide tópico 2.1 - Seção B</value>
        public string? DataGravacaoArquivo { get; set; }

        /// <summary>
        /// Branco (posição 101 a 108). (Obrigatório).
        /// </summary>
        /// <value>Branco</value>
        public string? Branco1 { get; set; }

        /// <summary>
        /// Identificação do Sistema (posição 109 a 110). (Obrigatório).
        /// </summary>
        /// <value>MX</value>
        public string? IdentificacaoSistema { get; set; }

        /// <summary>
        /// Nº Sequencial do Arquivo (posição 111 a 117). (Obrigatório).
        /// </summary>
        /// <value>Sequencial</value>
        public string? NumeroSequencialArquivo { get; set; }

        /// <summary>
        /// Número do banco (posição 118 a 120).
        /// </summary>
        /// <value>Número do banco do cedente</value>
        public string? NumeroBancoCedente { get; set; }

        /// <summary>
        /// Número da agencia do banco (posição 121 a 125).
        /// </summary>
        /// <value>Agência do Cedente</value>
        public string? NumeroAgenciaBanco { get; set; }

        /// <summary>
        /// Digito verificador da agencia (posição 126 a 126).
        /// </summary>
        /// <value>Dígito verificador da agência do cedente</value>
        public string? DigitoVerificadorAgencia { get; set; }

        /// <summary>
        /// Número da conta corrente (posição 127 a 138).
        /// </summary>
        /// <value>Número da conta corrente do cedente</value>
        public string? NumeroContaCorrente { get; set; }

        /// <summary>
        /// Digito verificador da conta corrente (posição 139 a 139).
        /// </summary>
        /// <value>Dígito verificador da conta corrente do</value>
        public string? DigitoVerificadorContaCorrente { get; set; }

        /// <summary>
        /// Branco (posição 140 a 494). (Obrigatório).
        /// </summary>
        /// <value>Branco</value>
        public string? Branco2 { get; set; }

        /// <summary>
        /// Nº Sequencial do Registro (de 1 em 1) (posição 495 a 500). (Obrigatório).
        /// </summary>
        /// <value>000001</value>
        public string? NumeroSequencialRegistro { get; set; }

    }
}
