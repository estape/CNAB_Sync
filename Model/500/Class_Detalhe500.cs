namespace CNAB500
{
    public class Class_Detalhe500
    {
        /// <summary>
        /// Identificação do registro (posição 1 a 1). (Obrigatório).
        /// </summary>
        /// <value>1</value>
        public string? IdentificacaoRegistro { get; set; }

        /// <summary>
        /// Data de Carência (posição 2 a 7).
        /// </summary>
        /// <value>DDMMAA Data de carência</value>
        public string? DataCarencia { get; set; }

        /// <summary>
        /// Tipo de Juros (posição 8 a 8).
        /// </summary>
        /// <value>0 - Título sem correção; 1 - Juros Fixo; 2 - CDI; 3 - IPCA-15; 4 - IPCA; 5 - IGPM; Para recebíveis pós-fixados</value>
        public string? TipoJuros { get; set; }

        /// <summary>
        /// Branco (posição 9 a 10).
        /// </summary>
        /// <value>Branco</value>
        public string? Branco1 { get; set; }

        /// <summary>
        /// Taxa de Juros (posição 11 a 20).
        /// </summary>
        /// <value>Juros para a correção do título seja correção fixa ou % do indexador para recebíveis pós-fixados</value>
        public string? TaxaJuros { get; set; }

        /// <summary>
        /// Coobrigação (posição 21 a 22). (Obrigatório).
        /// </summary>
        /// <value>01 =com coobrigação 02 = sem coobrigação</value>
        public string? Coobrigacao { get; set; }

        /// <summary>
        /// Característica especial (posição 23 a 24).
        /// </summary>
        /// <value>Src3040 do BACEN Preencher de acordo com o anexo 8</value>
        public string? CaracteristicaEspecial { get; set; }

        /// <summary>
        /// Modalidade da operação (posição 25 a 28).
        /// </summary>
        /// <value>Src3040 do BACEN Preencher de acordo com o anexo 3 Preencher o domínio e o subdomínio</value>
        public string? ModalidadeOperacao { get; set; }

        /// <summary>
        /// Natureza da operação (posição 29 a 30).
        /// </summary>
        /// <value>Src3040 do BACEN Preencher de acordo com o anexo 2</value>
        public string? NaturezaOperacao { get; set; }

        /// <summary>
        /// Origem do recurso (posição 31 a 34).
        /// </summary>
        /// <value>Src3040 do BACEN Preencher de acordo com o anexo 4 Preencher o domínio e o subdomínio</value>
        public string? OrigemRecurso { get; set; }

        /// <summary>
        /// Classe risco da operação (posição 35 a 36).
        /// </summary>
        /// <value>Src3040 do BACEN Preencher de acordo com o anexo 17 Preencher da esquerda para direita</value>
        public string? ClasseRiscoOperacao { get; set; }

        /// <summary>
        /// Zeros (posição 37 a 37).
        /// </summary>
        /// <value>Zeros</value>
        public string? Zeros1 { get; set; }

        /// <summary>
        /// Nº de controle do participante (posição 38 a 62). (Obrigatório).
        /// </summary>
        /// <value>Número de identificação do título na consultoria (Este campo deve ser o mesmo informado ao banco cobrador)</value>
        public string? NumeroControleParticipante { get; set; }

        /// <summary>
        /// Número do banco (posição 63 a 65).
        /// </summary>
        /// <value>Número do banco pertencente ao cheque</value>
        public string? NumeroBanco { get; set; }

        /// <summary>
        /// Quantidade De Lastros (posição 66 a 68).
        /// </summary>
        /// <value>Quantidade de Lastros que o recebível possuirá</value>
        public string? QuantidadeDeLastros { get; set; }

        /// <summary>
        /// Branco (posição 69 a 81).
        /// </summary>
        /// <value>Branco</value>
        public string? Branco2 { get; set; }

        /// <summary>
        /// Branco (posição 82 a 82).
        /// </summary>
        /// <value>Branco</value>
        public string? Branco3 { get; set; }

        /// <summary>
        /// Valor pago (posição 83 a 92).
        /// </summary>
        /// <value>Se ocorrência diferente de liquidação preencher com zeros</value>
        public string? ValorPago { get; set; }

        /// <summary>
        /// Condição para emissão da papeleta de cobrança (posição 93 a 93).
        /// </summary>
        /// <value>Branco</value>
        public string? CondicaoEmissaoPapeletaCobranca { get; set; }

        /// <summary>
        /// Ident. Se emite papeleta para débito automático (posição 94 a 94).
        /// </summary>
        /// <value>Branco</value>
        public string? IdentEmitePapeletaDebitoAutomatico { get; set; }

        /// <summary>
        /// Data da liquidação (posição 95 a 100).
        /// </summary>
        /// <value>DDMMAA (Somente para liquidação do título)</value>
        public string? DataLiquidacao { get; set; }

        /// <summary>
        /// Identificação da operação do banco (posição 101 a 104).
        /// </summary>
        /// <value>Branco</value>
        public string? IdentificacaoOperacaoBanco { get; set; }

        /// <summary>
        /// Indicador rateio crédito (posição 105 a 105).
        /// </summary>
        /// <value>Branco</value>
        public string? IndicadorRateioCredito { get; set; }

        /// <summary>
        /// Endereçamento para aviso do débito automático em conta corrente (posição 106 a 106).
        /// </summary>
        /// <value>Branco</value>
        public string? EnderecamentoAvisoDebitoAutomatico { get; set; }

        /// <summary>
        /// Branco (posição 107 a 108).
        /// </summary>
        /// <value>Branco</value>
        public string? Branco4 { get; set; }

        /// <summary>
        /// Identificação ocorrência (posição 109 a 110). (Obrigatório).
        /// </summary>
        /// <value>Vide seção 3.1 - seção A</value>
        public string? IdentificacaoOcorrencia { get; set; }

        /// <summary>
        /// Nº do documento (posição 111 a 120). (Obrigatório).
        /// </summary>
        /// <value>Número de identificação do documento na consultoria (Este campo deve ser o mesmo informado ao banco cobrador)</value>
        public string? NumeroDocumento { get; set; }

        /// <summary>
        /// Data do vencimento do título (posição 121 a 126). (Obrigatório).
        /// </summary>
        /// <value>DDMMAA</value>
        public string? DataVencimentoTitulo { get; set; }

        /// <summary>
        /// Valor do título (face) (posição 127 a 139). (Obrigatório).
        /// </summary>
        /// <value>Valor nominal do título</value>
        public List<string> Parcelas { get; set; } = [];

        /// <summary>
        /// Banco encarregado da cobrança (posição 140 a 142).
        /// </summary>
        /// <value>Nº do banco na câmara de compensação</value>
        public string? BancoEncarregadoCobranca { get; set; }

        /// <summary>
        /// Agência depositária (posição 143 a 147).
        /// </summary>
        /// <value>Código da agência depositária</value>
        public string? AgenciaDepositaria { get; set; }

        /// <summary>
        /// Espécie de título (posição 148 a 149). (Obrigatório).
        /// </summary>
        /// <value>01 - Duplicata; 02 - Nota promissória; 51 - Cheque; 60 - Contrato; ... Vide tópico 3.1 - seção E</value>
        public string? EspecieTitulo { get; set; }

        /// <summary>
        /// Identificação (posição 150 a 150).
        /// </summary>
        /// <value>Branco</value>
        public string? Identificacao { get; set; }

        /// <summary>
        /// Data da emissão do título (posição 151 a 156). (Obrigatório).
        /// </summary>
        /// <value>DDMMAA</value>
        public string? DatasEmissao { get; set; }

        /// <summary>
        /// 1ª instrução (posição 157 a 158).
        /// </summary>
        /// <value>00</value>
        public string? PrimeiraInstrucao { get; set; }

        /// <summary>
        /// 2ª instrução (posição 159 a 159).
        /// </summary>
        /// <value>0</value>
        public string? SegundaInstrucao { get; set; }

        /// <summary>
        /// Tipo de pessoa do cedente (posição 160 a 161). (Obrigatório).
        /// </summary>
        /// <value>01 - pessoa física; 02 - pessoa jurídica;</value>
        public string? TipoPessoaCedente { get; set; }

        /// <summary>
        /// Juros/Mora (posição 162 a 173).
        /// </summary>
        /// <value>Juros a cobrar por dia de atraso</value>
        public string? JurosMora { get; set; }

        /// <summary>
        /// Número do termo de cessão (posição 174 a 192). (Obrigatório).
        /// </summary>
        /// <value>Conforme número enviado pela consultoria</value>
        public string? NumeroTermoCessao { get; set; }

        /// <summary>
        /// Valor presente da parcela (posição 193 a 205). (Obrigatório).
        /// </summary>
        /// <value>Valor da parcela na data que foi cedida. Valor de aquisição do título.</value>
        public string? ValorPresenteParcela { get; set; }

        /// <summary>
        /// Valor do abatimento (posição 206 a 218).
        /// </summary>
        /// <value>Valor do abatimento a ser concedido na instrução</value>
        public string? ValorAbatimento { get; set; }

        /// <summary>
        /// Identificação do tipo de inscrição do sacado (posição 219 a 220). (Obrigatório).
        /// </summary>
        /// <value>01 - pessoa física; 02 - pessoa jurídica;</value>
        public string? IdentTipoInscricaoSacado { get; set; }

        /// <summary>
        /// Nº inscrição do sacado (posição 221 a 234). (Obrigatório).
        /// </summary>
        /// <value>CNPJ/CPF</value>
        public string? CPF_CNPJ { get; set; }

        /// <summary>
        /// Nome do sacado (posição 235 a 274). (Obrigatório).
        /// </summary>
        /// <value>Nome do sacado</value>
        public string? Nome { get; set; }

        /// <summary>
        /// Endereço completo (posição 275 a 314). (Obrigatório).
        /// </summary>
        /// <value>Endereço do sacado</value>
        public string? EnderecoCompleto { get; set; }

        /// <summary>
        /// Número da nota fiscal da duplicata (posição 315 a 323).
        /// </summary>
        /// <value>Número da nota fiscal da duplicata</value>
        public string? NumeroNotaFiscalDuplicata { get; set; }

        /// <summary>
        /// Número da série da nota fiscal da duplicata (posição 324 a 326).
        /// </summary>
        /// <value>Número da série da nota fiscal da duplicata</value>
        public string? NumeroSerieNotaFiscalDuplicata { get; set; }

        /// <summary>
        /// CEP (posição 327 a 334). (Obrigatório).
        /// </summary>
        /// <value>CEP do sacado</value>
        public string? CEP { get; set; }

        /// <summary>
        /// Cedente (posição 335 a 394). (Obrigatório).
        /// </summary>
        /// <value>Decomposição Vide tópico 3.1 - seção D</value>
        public string? Cedente { get; set; }

        /// <summary>
        /// Data Encargo 1 (posição 395 a 400).
        /// </summary>
        /// <value>DDMMAA</value>
        public string? DataEncargo1 { get; set; }

        /// <summary>
        /// Percentual de Encargo 1 (posição 401 a 408).
        /// </summary>
        /// <value>Percentual de Encargo</value>
        public string? PercentualEncargo1 { get; set; }

        /// <summary>
        /// Data Encargo 2 (posição 409 a 414).
        /// </summary>
        /// <value>DDMMAA</value>
        public string? DataEncargo2 { get; set; }

        /// <summary>
        /// Percentual de Encargo 2 (posição 415 a 422).
        /// </summary>
        /// <value>Percentual de Encargo</value>
        public string? PercentualEncargo2 { get; set; }

        /// <summary>
        /// Taxa Adicional (Pós Fixados + Taxa) (posição 423 a 430).
        /// </summary>
        /// <value>(preencher sem ponto e sem vírgula) Pós Fixado</value>
        public string? TaxaAdicional { get; set; }

        /// <summary>
        /// Branco (posição 431 a 438).
        /// </summary>
        /// <value>Branco</value>
        public string? Branco5 { get; set; }

        /// <summary>
        /// Taxa Juros Mensal (posição 439 a 446).
        /// </summary>
        /// <value>(preencher sem ponto e sem vírgula) Pós Vencido</value>
        public string? TaxaJurosMensal { get; set; }

        /// <summary>
        /// Juros de Mora (posição 447 a 454).
        /// </summary>
        /// <value>(preencher sem ponto e sem vírgula) Pós Vencido</value>
        public string? JurosDeMoraDetalhe { get; set; }

        /// <summary>
        /// Multa (posição 455 a 467).
        /// </summary>
        /// <value>Multa (preencher sem ponto e sem vírgula) Pós Vencido</value>
        public string? Multa { get; set; }

        /// <summary>
        /// Branco (posição 468 a 494).
        /// </summary>
        /// <value>Branco</value>
        public string? Branco6 { get; set; }

        /// <summary>
        /// Nº sequencial do registro (posição 495 a 500). (Obrigatório).
        /// </summary>
        /// <value>Nº sequencial do registro</value>
        public string? NumeroSequencialRegistro { get; set; }

        /// <summary>
        /// Para armazenar o total de parcelas do cliente.
        /// </summary>
        public decimal TotalParcelasCliente { get; set; } = 0;

    }
}
