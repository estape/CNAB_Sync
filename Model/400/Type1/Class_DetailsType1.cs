namespace CNAB400.Type1
{
    public class Class_DetailsType1
    {
        /// <summary>
        /// Identificação do Registro (posição 1 a 1).
        /// </summary>
        /// <value>1</value>
        public string? IdentificacaoRegistro { get; set; }

        /// <summary>
        /// Agência de Débito (opcional) (posição 2 a 6).
        /// </summary>
        public string? AgenciaDebito { get; set; }

        /// <summary>
        /// Dígito da Agência de Débito (opcional) (posição 7 a 7).
        /// </summary>
        public string? DigitoAgenciaDebito { get; set; }

        /// <summary>
        /// Razão da Conta-Corrente (opcional) (posição 8 a 12).
        /// </summary>
        public string? RazaoContaCorrente { get; set; }

        /// <summary>
        /// Conta-Corrente (opcional) (posição 13 a 19).
        /// </summary>
        public string? ContaCorrente { get; set; }

        /// <summary>
        /// Dígito da Conta-Corrente (opcional) (posição 20 a 20).
        /// </summary>
        public string? DigitoContaCorrente { get; set; }

        /// <summary>
        /// Identificação da Empresa Beneficiária no Banco (posição 21 a 37).
        /// </summary>
        public string? IdentificacaoEmpresaBeneficiaria { get; set; }

        /// <summary>
        /// Nº Controle do Participante (posição 38 a 62).
        /// </summary>
        public string? NumeroControleParticipante { get; set; }

        /// <summary>
        /// Código do Banco a ser debitado na Câmara de Compensação (posição 63 a 65).
        /// </summary>
        public string? CodigoBancoCompensacao { get; set; }

        /// <summary>
        /// Campo de Multa (posição 66 a 66).
        /// </summary>
        public string? CampoMulta { get; set; }

        /// <summary>
        /// Percentual de Multa (posição 67 a 70).
        /// </summary>
        public string? PercentualMulta { get; set; }

        /// <summary>
        /// Identificação do Título no Banco (posição 71 a 81).
        /// </summary>
        public string? IdentificacaoTituloBanco { get; set; }

        /// <summary>
        /// Dígito de Autoconferência do Número Bancário (posição 82 a 82).
        /// </summary>
        public string? DigitoAutoconferenciaNumeroBancario { get; set; }

        /// <summary>
        /// Desconto Bonificação por dia (posição 83 a 92).
        /// </summary>
        public string? DescontoBonificacaoPorDia { get; set; }

        /// <summary>
        /// Condição para Emissão da Papeleta de Cobrança (posição 93 a 93).
        /// </summary>
        public string? CondicaoEmissaoPapeleta { get; set; }

        /// <summary>
        /// Ident. se emite Boleto para Débito Automático (posição 94 a 94).
        /// </summary>
        public string? IdentEmiteBoletoDebitoAutomatico { get; set; }

        /// <summary>
        /// Identificação da Operação do Banco (posição 95 a 104).
        /// </summary>
        /// <value>Brancos</value>
        public string? IdentificacaoOperacaoBanco { get; set; }

        /// <summary>
        /// Indicador Rateio Crédito (opcional) (posição 105 a 105).
        /// </summary>
        public string? IndicadorRateioCredito { get; set; }

        /// <summary>
        /// Endereçamento para Aviso do Débito Automático em Conta-Corrente (opcional) (posição 106 a 106).
        /// </summary>
        public string? EnderecamentoAvisoDebitoAutomatico { get; set; }

        /// <summary>
        /// Quantidade de Pagamentos (posição 107 a 108).
        /// </summary>
        public string? QuantidadePagamentos { get; set; }

        /// <summary>
        /// Identificação da Ocorrência (posição 109 a 110).
        /// </summary>
        public string? IdentificacaoOcorrencia { get; set; }

        /// <summary>
        /// Nº do Documento (posição 111 a 120).
        /// </summary>
        public string? NumeroDocumento { get; set; }

        /// <summary>
        /// Data do Vencimento do Título (posição 121 a 126).
        /// </summary>
        public string? DataVencimentoTitulo { get; set; }

        /// <summary>
        /// Valor do Título (posição 127 a 139).
        /// </summary>
        public string? ValorTitulo { get; set; }

        /// <summary>
        /// Banco Encarregado da Cobrança (posição 140 a 142).
        /// </summary>
        /// <value>000</value>
        public string? BancoEncarregadoCobranca { get; set; }

        /// <summary>
        /// Agência Depositária (posição 143 a 147).
        /// </summary>
        /// <value>00000</value>
        public string? AgenciaDepositaria { get; set; }

        /// <summary>
        /// Espécie de Título (posição 148 a 149).
        /// </summary>
        public string? EspecieTitulo { get; set; }

        /// <summary>
        /// Identificação (posição 150 a 150).
        /// </summary>
        /// <value>N</value>
        public string? Identificacao { get; set; }

        /// <summary>
        /// Data da Emissão do Título (posição 151 a 156).
        /// </summary>
        public string? DataEmissaoTitulo { get; set; }

        /// <summary>
        /// 1ª Instrução (posição 157 a 158).
        /// </summary>
        public string? PrimeiraInstrucao { get; set; }

        /// <summary>
        /// 2ª Instrução (posição 159 a 160).
        /// </summary>
        public string? SegundaInstrucao { get; set; }

        /// <summary>
        /// Valor a ser Cobrado por Dia de Atraso (posição 161 a 173).
        /// </summary>
        public string? ValorCobradoPorDiaAtraso { get; set; }

        /// <summary>
        /// Data Limite P/Concessão de Desconto (posição 174 a 179).
        /// </summary>
        public string? DataLimiteConcessaoDesconto { get; set; }

        /// <summary>
        /// Valor do Desconto (posição 180 a 192).
        /// </summary>
        public string? ValorDesconto { get; set; }

        /// <summary>
        /// Valor do IOF (posição 193 a 205).
        /// </summary>
        public string? ValorIOF { get; set; }

        /// <summary>
        /// Valor do Abatimento a ser Concedido ou Cancelado (posição 206 a 218).
        /// </summary>
        public string? ValorAbatimento { get; set; }

        /// <summary>
        /// Identificação do Tipo de Inscrição do Pagador (posição 219 a 220).
        /// </summary>
        public string? IdentificacaoTipoInscricaoPagador { get; set; }

        /// <summary>
        /// Nº Inscrição do Pagador (posição 221 a 234).
        /// </summary>
        public string? NumeroInscricaoPagador { get; set; }

        /// <summary>
        /// Nome do Pagador (posição 235 a 274).
        /// </summary>
        public string? NomePagador { get; set; }

        /// <summary>
        /// Endereço Completo (posição 275 a 314).
        /// </summary>
        public string? EnderecoCompleto { get; set; }

        /// <summary>
        /// 1ª Mensagem (posição 315 a 326).
        /// </summary>
        public string? PrimeiraMensagem { get; set; }

        /// <summary>
        /// CEP (posição 327 a 331).
        /// </summary>
        public string? Cep { get; set; }

        /// <summary>
        /// Sufixo do CEP (posição 332 a 334).
        /// </summary>
        public string? SufixoCep { get; set; }

        /// <summary>
        /// Beneficiário Final ou 2ª Mensagem (posição 335 a 394).
        /// </summary>
        public string? BeneficiarioFinal { get; set; }

        /// <summary>
        /// Nº Sequencial do Registro (posição 395 a 400).
        /// </summary>
        public string? NumeroSequencialRegistro { get; set; }
    }
}

