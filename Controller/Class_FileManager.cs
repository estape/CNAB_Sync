using Detalhe444;
using CNAB500;
using Photino.NET;
using System.IO;
using System.Reflection;
using ClosedXML.Excel;
using System.Text.Json;

namespace FileManager
{
    public class Class_FileManager
    {
        public string GetCnabDate(string filePath)
        {
            try
            {
                var firstLine = File.ReadLines(filePath).FirstOrDefault();
                if (firstLine != null && firstLine.StartsWith("0"))
                {
                    if (firstLine.Length >= 240 && firstLine.Length < 400) // Assumes CNAB 240
                    {
                        if (firstLine.Length >= 151)
                        {
                            string datePart = firstLine.Substring(143, 8); // DDMMAAAA
                            if (datePart.Length == 8 && int.TryParse(datePart, out _))
                            {
                                return $"{datePart.Substring(0, 2)}/{datePart.Substring(2, 2)}/{datePart.Substring(6, 2)}";
                            }
                        }
                    }
                    else if (firstLine.Length >= 100) // CNAB 400, 444, 500
                    {
                        string datePart = firstLine.Substring(94, 6); // DDMMAA
                        if (datePart.Length == 6 && int.TryParse(datePart, out _))
                        {
                            return $"{datePart.Substring(0, 2)}/{datePart.Substring(2, 2)}/{datePart.Substring(4, 2)}";
                        }
                    }
                }
            }
            catch { }
            return "";
        }

        private List<Class_Detalhe444> clientObj = new List<Class_Detalhe444>();
        
        /// <summary>
        /// Validate required fields of <see cref="Class_Detalhe444"/>.
        /// </summary>
        /// <param name="fieldItem">A <see cref="Class_Detalhe444"/> object to validate.</param>
        /// <returns> Content in Tuple:
        /// <list type="bullet">
        /// <item><description>A <see cref="bool"/> that returns <c>true</c> if valid, otherwise <c>false</c>.</description></item>
        /// <item><description>A <see cref="string"/> that return a error string, or empty/<c>null</c> if validation was successful.</description></item>
        /// </list>
        /// </returns>
        private (bool, string) ValidateFields444(Class_Detalhe444 fieldItem)
        {
            var listFieldItems = new string[]
            {
                nameof(fieldItem.IdentificacaoRegistro),
                nameof(fieldItem.Coobrigacao),
                nameof(fieldItem.NumeroControleParticipante),
                nameof(fieldItem.IdentificacaoOcorrencia),
                nameof(fieldItem.NumeroDocumento),
                nameof(fieldItem.DataVencimentoTitulo),
                nameof(fieldItem.EspecieTitulo),
                nameof(fieldItem.DatasEmissao),
                nameof(fieldItem.TipoPessoaCedente),
                nameof(fieldItem.NumeroTermoCessao),
                nameof(fieldItem.ValorPresenteParcela),
                nameof(fieldItem.IdentTipoInscricaoSacado),
                nameof(fieldItem.EnderecoCompleto),
                nameof(fieldItem.CEP),
                nameof(fieldItem.Cedente),
                nameof(fieldItem.NumeroSequencialRegistro)
            };

            foreach (var field in listFieldItems)
            {
                // Obtém a propriedade pelo nome
                PropertyInfo? propInfo = typeof(Class_Detalhe444).GetProperty(field);

                if (propInfo != null)
                {
                    // Obtém o valor da propriedade
                    var propField = propInfo.GetValue(fieldItem)?.ToString();

                    // Verifica se o valor é nulo ou vazio
                    if (string.IsNullOrWhiteSpace(propField))
                    {
                        return (false, $"Field '{field}' is required and cannot be null or empty.");
                    }
                }
            }

            return (true, "");
        }

        ///<summary>
        /// Read raw CNAB 444 file and convert to <see cref="List{Class_Detalhe444}"/>
        ///</summary>
        /// <param name="filePath">CNAB 444 filepath.</param>
        /// <returns> Content in Tuple:
        /// <list type="bullet">
        /// <item><description>A <see cref="List{Class_Detalhe444}"/> with data get from file.</description></item>
        /// <item><description>A <see cref="string"/> that return error, or <c>null</c> if read file was successful.</description></item>
        /// </list>
        /// </returns>
        public (List<Class_Detalhe444>, string) ReadFile444(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return (new List<Class_Detalhe444>(), $"File '{filePath}' does not exist.");
            }

            decimal totalParcelasCNAB = 0; // Total de parcelas do arquivo CNAB.
            long intCpfCnpj = 0;
            Class_Detalhe444 _lineClient = new Class_Detalhe444();

            try
            {
                foreach (var _line in File.ReadLines(filePath))
                {
                    if (_line.Length < 444)
                        continue; // Ignorar linhas incompletas

                    string tipoRegistro = _line.Substring(0, 1);
                    if (tipoRegistro == "0" || tipoRegistro == "9")
                        continue; // Ignorar Header e Trailler

                    // Extrair CPF/CNPJ (posições 221 a 234)
                    string cpfCnpj = _line.Substring(220, 14).Trim();

                    // Extrair Nome (posições 235 a 274)
                    string nome = _line.Substring(234, 40).Trim();

                    // Verificar se o CPF/CNPJ e o nome estão preenchidos corretamente
                    if (string.IsNullOrWhiteSpace(cpfCnpj) || string.IsNullOrWhiteSpace(nome))
                    {
                        continue; // Ignorar clientInfo com dados incompletos
                    }

                    // Se o cliente não estiver na lista, tenta adicionar um novo
                    try
                    {
                        intCpfCnpj = Convert.ToInt64(cpfCnpj); // Tenta remover os zeros extra a esquerda, se não for possivel o texto extraido não é um CNPJ ou CPF ou pode estar com formato inválido.
                    }
                    catch (System.FormatException)
                    {
                        clientObj.Clear();
                        return (clientObj, "Erro de formato ao ler CPF/CNPJ.");
                    }

                    string cpfCnpjFormatado = intCpfCnpj.ToString();

                    // Verifica se CNPJ está com 13 digitos ou CPF está com 10 digitos ou não, devido a removção de zeros a esquerda anteriormente.
                    if (cpfCnpj.Contains(' '))
                    {
                        clientObj.Clear();
                        return (clientObj, ""); // Arquivo comprometido, interromper processamento
                    }

                    // Verificar se é CNPJ (14 dígitos) ou CPF (11 dígitos)
                    if (cpfCnpjFormatado.Length == 13)
                    {
                        // Formatar como CNPJ: 00.000.000/0000-00
                        cpfCnpjFormatado = "0" + cpfCnpjFormatado;
                        cpfCnpjFormatado = $"CNPJ: {cpfCnpjFormatado.Substring(0, 2)}.{cpfCnpjFormatado.Substring(2, 3)}.{cpfCnpjFormatado.Substring(5, 3)}/{cpfCnpjFormatado.Substring(8, 4)}-{cpfCnpjFormatado.Substring(12, 2)}";
                    }
                    else if (cpfCnpjFormatado.Length == 14)
                    {
                        // Formatar como CNPJ: 00.000.000/0000-00
                        cpfCnpjFormatado = $"CNPJ: {cpfCnpjFormatado.Substring(0, 2)}.{cpfCnpjFormatado.Substring(2, 3)}.{cpfCnpjFormatado.Substring(5, 3)}/{cpfCnpjFormatado.Substring(8, 4)}-{cpfCnpjFormatado.Substring(12, 2)}";
                    }
                    else if (cpfCnpjFormatado.Length == 10)
                    {
                        // Formatar como CPF: 000.000.000-00
                        cpfCnpjFormatado = "0" + cpfCnpjFormatado;
                        cpfCnpjFormatado = $"CPF: {cpfCnpjFormatado.Substring(0, 3)}.{cpfCnpjFormatado.Substring(3, 3)}.{cpfCnpjFormatado.Substring(6, 3)}-{cpfCnpjFormatado.Substring(9, 2)}";
                    }
                    else if (cpfCnpjFormatado.Length == 11)
                    {
                        // Formatar como CPF: 000.000.000-00
                        cpfCnpjFormatado = $"CPF: {cpfCnpjFormatado.Substring(0, 3)}.{cpfCnpjFormatado.Substring(3, 3)}.{cpfCnpjFormatado.Substring(6, 3)}-{cpfCnpjFormatado.Substring(9, 2)}";
                    }
                    else
                    {
                        // Retorna erro se não for um CPF ou CNPJ válido
                        clientObj.Clear();
                        return (clientObj, ""); // Interromper a execução se o CPF/CNPJ for inválido
                    }

                    // Procurar cliente na lista
                    var foundClient = clientObj.FirstOrDefault(clientLine => clientLine.CPF_CNPJ == cpfCnpjFormatado);

                    if (foundClient == null)
                    {
                        // Adiciona um novo cliente com o CPF/CNPJ formatado
                        _lineClient = new Class_Detalhe444
                        {
                            IdentificacaoRegistro = _line.Substring(0, 1),
                            Coobrigacao = _line.Substring(20, 2),
                            NumeroControleParticipante = _line.Substring(37, 25),
                            NumeroBanco = _line.Substring(62, 3), // Sim, para cheque
                            Zeros2 = _line.Substring(65, 5),
                            ValorPago = _line.Substring(82, 10), // Sim, para ocorrências de liquidação
                            DataLiquidacao = _line.Substring(94, 6), // Sim, para ocorrências de liquidação
                            IdentificacaoOcorrencia = _line.Substring(108, 2),
                            NumeroDocumento = _line.Substring(110, 10),
                            DataVencimentoTitulo = _line.Substring(120, 6),
                            EspecieTitulo = _line.Substring(147, 2),
                            TipoPessoaCedente = _line.Substring(159, 2),
                            NumeroTermoCessao = _line.Substring(173, 19),
                            ValorPresenteParcela = _line.Substring(192, 13),
                            IdentTipoInscricaoSacado = _line.Substring(218, 2),
                            CPF_CNPJ = cpfCnpjFormatado,
                            Nome = nome,
                            EnderecoCompleto = _line.Substring(274, 40),
                            NumeroNotaFiscalDuplicata = _line.Substring(314, 9), // Sim, para duplicata
                            CEP = _line.Substring(326, 8),
                            Cedente = _line.Substring(334, 60),
                            ChaveNota = _line.Substring(394, 44), // Sim, para duplicata
                            NumeroSequencialRegistro = _line.Substring(438, 6)
                        };

                        clientObj.Add(_lineClient);

                    }

                    else
                    {
                        _lineClient = foundClient; // Atualiza a referência para o cliente existente
                    }

                    // Extrair o valor da parcela (posição 127 a 139)
                    string valorParcelaStr = _line.Substring(126, 13).Trim();
                    if (decimal.TryParse(valorParcelaStr, out decimal valorParcela))
                    {
                        valorParcela /= 100; // Convertendo centavos para reais

                        // Somar o valor da parcela ao total do Cliente
                        _lineClient.TotalParcelasCliente += valorParcela;

                        // Somar o valor da parcela ao total do CNAB
                        totalParcelasCNAB += valorParcela;
                    }

                    // Preencher a lista de datas de emissão (posição 151 a 156)
                    string dataEmissao = _line.Substring(150, 6).Trim();
                    if (dataEmissao.Length == 6)
                    {
                        // Formatar como DD/MM/AA
                        dataEmissao = $"{dataEmissao.Substring(0, 2)}/{dataEmissao.Substring(2, 2)}/{dataEmissao.Substring(4, 2)}";
                    }
                    _lineClient.DatasEmissao = dataEmissao;

                    // Aciona o CheckRequiredFields para verificar os campos obrigatórios se não são vazios.
                    var (fieldRequiredBool, fieldError) = ValidateFields444(_lineClient);
                    if (!fieldRequiredBool)
                    {
                        return (clientObj, fieldError);
                    }

                    // Adicionar a parcela formatada ao Cliente
                    string dataVencimento = _line.Substring(120, 6);
                    if (dataVencimento.Length == 6)
                    {
                        dataVencimento = $"{dataVencimento.Substring(0, 2)}/{dataVencimento.Substring(2, 2)}/{dataVencimento.Substring(4, 2)}";
                    }
                    string numeroDocumento = _line.Substring(110, 10).Trim();
                    string parcelaFormatada = $"Número CCB: {numeroDocumento} | Vencimento: {dataVencimento} | Parcela a pagar: R$ {valorParcela:N2}";
                    _lineClient.DataVencimentoTitulo = dataVencimento;
                    _lineClient.Parcelas.Add(parcelaFormatada);
                    _lineClient.NumeroDocumento = numeroDocumento;
                }
            }
            catch (Exception ex)
            {
                return (new List<Class_Detalhe444>(), $"Error reading file: {ex.Message}");
            }

            return (clientObj, totalParcelasCNAB.ToString("N2"));
        }

        /// <summary>
        /// Save CNAB file as proprietary file format.
        /// </summary>
        /// <param name="clients">List of <see cref="Class_Detalhe444"/> objects.</param>
        /// <param name="filepath">File path to save the file.</param>
        /// <returns> Content in Tuple:
        /// <list type="bullet">
        /// <item><description>A <see cref="bool"/> that returns <c>true</c> if valid, otherwise <c>false</c>.</description></item>
        /// <item><description>A <see cref="string"/> that return a error string, or empty/<c>null</c> if validation was successful.</description></item>
        /// </list>
        /// </returns>
        public (bool success, string errorMessage) SavePropFile(List<Class_Detalhe444> clients, string filepath)
        {
            try
            {
                if (!filepath.EndsWith(".CNABSync", StringComparison.OrdinalIgnoreCase))
                {
                    filepath += ".CNABSync";
                }
                string json = JsonSerializer.Serialize(clients, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filepath, json, System.Text.Encoding.UTF8);
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, $"Error saving prop file: {ex.Message}");
            }
        }

        /// <summary>
        /// Load CNAB file from proprietary file format.
        /// </summary>
        /// <param name="filepath">File path to load the file from.</param>
        /// <returns>A <see cref="List{Class_Detalhe444}"/> with data loaded, or <c>null</c> if an error occurred.</returns>
        public List<Class_Detalhe444>? LoadPropFile(string filepath)
        {
            try
            {
                if (!filepath.EndsWith(".CNABSync", StringComparison.OrdinalIgnoreCase))
                {
                    filepath += ".CNABSync";
                }
                string json = File.ReadAllText(filepath, System.Text.Encoding.UTF8);
                return JsonSerializer.Deserialize<List<Class_Detalhe444>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading prop file: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Export CNAB file to Excel format.
        /// </summary>
        /// <param name="clients">List of <see cref="Class_Detalhe444"/> objects.</param>
        /// <param name="filepath">File path to save the file.</param>
        /// <returns> Content in Tuple:
        /// <list type="bullet">
        /// <item><description>A <see cref="bool"/> that returns <c>true</c> if valid, otherwise <c>false</c>.</description></item>
        /// <item><description>A <see cref="string"/> that return a error string, or empty/<c>null</c> if validation was successful.</description></item>
        /// </list>
        /// </returns>
        public (bool success, string errorMessage) Export444XLSX(List<Class_Detalhe444> clients, string filepath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Clientes");

                    // Add headers
                    worksheet.Cell(1, 1).Value = "IdentificacaoRegistro";
                    worksheet.Cell(1, 2).Value = "DataCarencia";
                    worksheet.Cell(1, 3).Value = "TipoJuros";
                    worksheet.Cell(1, 4).Value = "Branco1";
                    worksheet.Cell(1, 5).Value = "TaxaJuros";
                    worksheet.Cell(1, 6).Value = "Coobrigacao";
                    worksheet.Cell(1, 7).Value = "CaracteristicaEspecial";
                    worksheet.Cell(1, 8).Value = "ModalidadeOperacao";
                    worksheet.Cell(1, 9).Value = "NaturezaOperacao";
                    worksheet.Cell(1, 10).Value = "OrigemRecurso";
                    worksheet.Cell(1, 11).Value = "ClasseRiscoOperacao";
                    worksheet.Cell(1, 12).Value = "Zeros1";
                    worksheet.Cell(1, 13).Value = "NumeroControleParticipante";
                    worksheet.Cell(1, 14).Value = "NumeroBanco";
                    worksheet.Cell(1, 15).Value = "Zeros2";
                    worksheet.Cell(1, 16).Value = "IdentificacaoTituloBanco";
                    worksheet.Cell(1, 17).Value = "DigitoNossoNumero";
                    worksheet.Cell(1, 18).Value = "ValorPago";
                    worksheet.Cell(1, 19).Value = "CondicaoEmissaoPapeletaCobranca";
                    worksheet.Cell(1, 20).Value = "IdentEmitePapeletaDebitoAutomatico";
                    worksheet.Cell(1, 21).Value = "DataLiquidacao";
                    worksheet.Cell(1, 22).Value = "IdentificacaoOperacaoBanco";
                    worksheet.Cell(1, 23).Value = "IndicadorRateioCredito";
                    worksheet.Cell(1, 24).Value = "EnderecamentoAvisoDebitoAutomatico";
                    worksheet.Cell(1, 25).Value = "Branco2";
                    worksheet.Cell(1, 26).Value = "IdentificacaoOcorrencia";
                    worksheet.Cell(1, 27).Value = "NumeroDocumento";
                    worksheet.Cell(1, 28).Value = "DataVencimentoTitulo";
                    worksheet.Cell(1, 29).Value = "Parcelas";
                    worksheet.Cell(1, 30).Value = "BancoEncarregadoCobranca";
                    worksheet.Cell(1, 31).Value = "AgenciaDepositaria";
                    worksheet.Cell(1, 32).Value = "EspecieTitulo";
                    worksheet.Cell(1, 33).Value = "Identificacao";
                    worksheet.Cell(1, 34).Value = "DatasEmissao";
                    worksheet.Cell(1, 35).Value = "PrimeiraInstrucao";
                    worksheet.Cell(1, 36).Value = "SegundaInstrucao";
                    worksheet.Cell(1, 37).Value = "TipoPessoaCedente";
                    worksheet.Cell(1, 38).Value = "JurosMora";
                    worksheet.Cell(1, 39).Value = "NumeroTermoCessao";
                    worksheet.Cell(1, 40).Value = "ValorPresenteParcela";
                    worksheet.Cell(1, 41).Value = "ValorAbatimento";
                    worksheet.Cell(1, 42).Value = "IdentTipoInscricaoSacado";
                    worksheet.Cell(1, 43).Value = "CPF_CNPJ";
                    worksheet.Cell(1, 44).Value = "Nome";
                    worksheet.Cell(1, 45).Value = "EnderecoCompleto";
                    worksheet.Cell(1, 46).Value = "NumeroNotaFiscalDuplicata";
                    worksheet.Cell(1, 47).Value = "NumeroSerieNotaFiscalDuplicata";
                    worksheet.Cell(1, 48).Value = "CEP";
                    worksheet.Cell(1, 49).Value = "Cedente";
                    worksheet.Cell(1, 50).Value = "ChaveNota";
                    worksheet.Cell(1, 51).Value = "NumeroSequencialRegistro";
                    worksheet.Cell(1, 52).Value = "TotalParcelasCliente";

                    int row = 2;

                    foreach (var client in clients)
                    {
                        worksheet.Cell(row, 1).Value = client.IdentificacaoRegistro;
                        worksheet.Cell(row, 2).Value = client.DataCarencia;
                        worksheet.Cell(row, 3).Value = client.TipoJuros;
                        worksheet.Cell(row, 4).Value = client.Branco1;
                        worksheet.Cell(row, 5).Value = client.TaxaJuros;
                        worksheet.Cell(row, 6).Value = client.Coobrigacao;
                        worksheet.Cell(row, 7).Value = client.CaracteristicaEspecial;
                        worksheet.Cell(row, 8).Value = client.ModalidadeOperacao;
                        worksheet.Cell(row, 9).Value = client.NaturezaOperacao;
                        worksheet.Cell(row, 10).Value = client.OrigemRecurso;
                        worksheet.Cell(row, 11).Value = client.ClasseRiscoOperacao;
                        worksheet.Cell(row, 12).Value = client.Zeros1;
                        worksheet.Cell(row, 13).Value = client.NumeroControleParticipante;
                        worksheet.Cell(row, 14).Value = client.NumeroBanco;
                        worksheet.Cell(row, 15).Value = client.Zeros2;
                        worksheet.Cell(row, 16).Value = client.IdentificacaoTituloBanco;
                        worksheet.Cell(row, 17).Value = client.DigitoNossoNumero;
                        worksheet.Cell(row, 18).Value = client.ValorPago;
                        worksheet.Cell(row, 19).Value = client.CondicaoEmissaoPapeletaCobranca;
                        worksheet.Cell(row, 20).Value = client.IdentEmitePapeletaDebitoAutomatico;
                        worksheet.Cell(row, 21).Value = client.DataLiquidacao;
                        worksheet.Cell(row, 22).Value = client.IdentificacaoOperacaoBanco;
                        worksheet.Cell(row, 23).Value = client.IndicadorRateioCredito;
                        worksheet.Cell(row, 24).Value = client.EnderecamentoAvisoDebitoAutomatico;
                        worksheet.Cell(row, 25).Value = client.Branco2;
                        worksheet.Cell(row, 26).Value = client.IdentificacaoOcorrencia;
                        worksheet.Cell(row, 27).Value = client.NumeroDocumento;
                        worksheet.Cell(row, 28).Value = client.DataVencimentoTitulo;
                        worksheet.Cell(row, 29).Value = string.Join(", ", client.Parcelas);
                        worksheet.Cell(row, 30).Value = client.BancoEncarregadoCobranca;
                        worksheet.Cell(row, 31).Value = client.AgenciaDepositaria;
                        worksheet.Cell(row, 32).Value = client.EspecieTitulo;
                        worksheet.Cell(row, 33).Value = client.Identificacao;
                        worksheet.Cell(row, 34).Value = client.DatasEmissao;
                        worksheet.Cell(row, 35).Value = client.PrimeiraInstrucao;
                        worksheet.Cell(row, 36).Value = client.SegundaInstrucao;
                        worksheet.Cell(row, 37).Value = client.TipoPessoaCedente;
                        worksheet.Cell(row, 38).Value = client.JurosMora;
                        worksheet.Cell(row, 39).Value = client.NumeroTermoCessao;
                        worksheet.Cell(row, 40).Value = client.ValorPresenteParcela;
                        worksheet.Cell(row, 41).Value = client.ValorAbatimento;
                        worksheet.Cell(row, 42).Value = client.IdentTipoInscricaoSacado;
                        worksheet.Cell(row, 43).Value = client.CPF_CNPJ;
                        worksheet.Cell(row, 44).Value = client.Nome;
                        worksheet.Cell(row, 45).Value = client.EnderecoCompleto;
                        worksheet.Cell(row, 46).Value = client.NumeroNotaFiscalDuplicata;
                        worksheet.Cell(row, 47).Value = client.NumeroSerieNotaFiscalDuplicata;
                        worksheet.Cell(row, 48).Value = client.CEP;
                        worksheet.Cell(row, 49).Value = client.Cedente;
                        worksheet.Cell(row, 50).Value = client.ChaveNota;
                        worksheet.Cell(row, 51).Value = client.NumeroSequencialRegistro;
                        worksheet.Cell(row, 52).Value = client.TotalParcelasCliente;

                        row++;
                    }

                    // Save the workbook
                    workbook.SaveAs(filepath);
                    return (true, string.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exportar XLSX: {ex.Message}");
                return (false, ex.Message);
            }
        }

        /// <summary>
        /// Export CNAB file to CSV format.
        /// </summary>
        /// <param name="clients">List of <see cref="Class_Detalhe444"/> objects.</param>
        /// <param name="filepath">File path to save the file.</param>
        /// <returns> Content in Tuple:
        /// <list type="bullet">
        /// <item><description>A <see cref="bool"/> that returns <c>true</c> if valid, otherwise <c>false</c>.</description></item>
        /// <item><description>A <see cref="string"/> that return a error string, or empty/<c>null</c> if validation was successful.</description></item>
        /// </list>
        /// </returns>
        public (bool success, string errorMessage) Export444CSV(List<Class_Detalhe444> clients, string filepath)
        {
            try
            {
                using (var writer = new StreamWriter(filepath + ".csv", false, System.Text.Encoding.UTF8))
                {
                    // Write headers
                    writer.WriteLine("IdentificacaoRegistro;DataCarencia;TipoJuros;Branco1;TaxaJuros;Coobrigacao;CaracteristicaEspecial;ModalidadeOperacao;NaturezaOperacao;OrigemRecurso;ClasseRiscoOperacao;Zeros1;NumeroControleParticipante;NumeroBanco;Zeros2;IdentificacaoTituloBanco;DigitoNossoNumero;ValorPago;CondicaoEmissaoPapeletaCobranca;IdentEmitePapeletaDebitoAutomatico;DataLiquidacao;IdentificacaoOperacaoBanco;IndicadorRateioCredito;EnderecamentoAvisoDebitoAutomatico;Branco2;IdentificacaoOcorrencia;NumeroDocumento;DataVencimentoTitulo;Parcelas;BancoEncarregadoCobranca;AgenciaDepositaria;EspecieTitulo;Identificacao;DatasEmissao;PrimeiraInstrucao;SegundaInstrucao;TipoPessoaCedente;JurosMora;NumeroTermoCessao;ValorPresenteParcela;ValorAbatimento;IdentTipoInscricaoSacado;CPF_CNPJ;Nome;EnderecoCompleto;NumeroNotaFiscalDuplicata;NumeroSerieNotaFiscalDuplicata;CEP;Cedente;ChaveNota;NumeroSequencialRegistro;TotalParcelasCliente");

                    foreach (var client in clients)
                    {
                        var parcelas = client.Parcelas != null ? string.Join(",", client.Parcelas) : "";
                        var line = $"{client.IdentificacaoRegistro};{client.DataCarencia};{client.TipoJuros};{client.Branco1};{client.TaxaJuros};{client.Coobrigacao};{client.CaracteristicaEspecial};{client.ModalidadeOperacao};{client.NaturezaOperacao};{client.OrigemRecurso};{client.ClasseRiscoOperacao};{client.Zeros1};{client.NumeroControleParticipante};{client.NumeroBanco};{client.Zeros2};{client.IdentificacaoTituloBanco};{client.DigitoNossoNumero};{client.ValorPago};{client.CondicaoEmissaoPapeletaCobranca};{client.IdentEmitePapeletaDebitoAutomatico};{client.DataLiquidacao};{client.IdentificacaoOperacaoBanco};{client.IndicadorRateioCredito};{client.EnderecamentoAvisoDebitoAutomatico};{client.Branco2};{client.IdentificacaoOcorrencia};{client.NumeroDocumento};{client.DataVencimentoTitulo};{parcelas};{client.BancoEncarregadoCobranca};{client.AgenciaDepositaria};{client.EspecieTitulo};{client.Identificacao};{client.DatasEmissao};{client.PrimeiraInstrucao};{client.SegundaInstrucao};{client.TipoPessoaCedente};{client.JurosMora};{client.NumeroTermoCessao};{client.ValorPresenteParcela};{client.ValorAbatimento};{client.IdentTipoInscricaoSacado};{client.CPF_CNPJ};{client.Nome};{client.EnderecoCompleto};{client.NumeroNotaFiscalDuplicata};{client.NumeroSerieNotaFiscalDuplicata};{client.CEP};{client.Cedente};{client.ChaveNota};{client.NumeroSequencialRegistro};{client.TotalParcelasCliente}";
                        writer.WriteLine(line);
                    }
                }
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exportar CSV: {ex.Message}");
                return (false, ex.Message);
            }
        }

        private (bool, string) ValidateFields500(Class_Detalhe500 fieldItem)
        {
            var listFieldItems = new string[]
            {
                nameof(fieldItem.IdentificacaoRegistro),
                nameof(fieldItem.Coobrigacao),
                nameof(fieldItem.NumeroControleParticipante),
                nameof(fieldItem.IdentificacaoOcorrencia),
                nameof(fieldItem.NumeroDocumento),
                nameof(fieldItem.DataVencimentoTitulo),
                nameof(fieldItem.EspecieTitulo),
                nameof(fieldItem.DatasEmissao),
                nameof(fieldItem.TipoPessoaCedente),
                nameof(fieldItem.NumeroTermoCessao),
                nameof(fieldItem.ValorPresenteParcela),
                nameof(fieldItem.IdentTipoInscricaoSacado),
                nameof(fieldItem.EnderecoCompleto),
                nameof(fieldItem.CEP),
                nameof(fieldItem.Cedente),
                nameof(fieldItem.NumeroSequencialRegistro)
            };

            foreach (var field in listFieldItems)
            {
                PropertyInfo? propInfo = typeof(Class_Detalhe500).GetProperty(field);
                if (propInfo != null)
                {
                    var propField = propInfo.GetValue(fieldItem)?.ToString();
                    if (string.IsNullOrWhiteSpace(propField))
                    {
                        return (false, $"Field '{field}' is required and cannot be null or empty.");
                    }
                }
            }
            return (true, "");
        }

        public (List<Class_Detalhe500>, string) ReadFile500(string filePath)
        {
            var clientObj500 = new List<Class_Detalhe500>();
            if (!File.Exists(filePath))
                return (clientObj500, $"File '{filePath}' does not exist.");

            decimal totalParcelasCNAB = 0;
            long intCpfCnpj = 0;

            try
            {
                foreach (var _line in File.ReadLines(filePath))
                {
                    if (_line.Length < 500) continue;

                    string tipoRegistro = _line.Substring(0, 1);
                    if (tipoRegistro == "0" || tipoRegistro == "9") continue;

                    string cpfCnpj = _line.Substring(220, 14).Trim();
                    string nome = _line.Substring(234, 40).Trim();

                    if (string.IsNullOrWhiteSpace(cpfCnpj) || string.IsNullOrWhiteSpace(nome)) continue;

                    try { intCpfCnpj = Convert.ToInt64(cpfCnpj); }
                    catch (System.FormatException) { return (new List<Class_Detalhe500>(), "Erro de formato ao ler CPF/CNPJ."); }

                    string cpfCnpjFormatado = intCpfCnpj.ToString();
                    if (cpfCnpj.Contains(' ')) return (new List<Class_Detalhe500>(), "Arquivo comprometido.");

                    if (cpfCnpjFormatado.Length == 13) { cpfCnpjFormatado = "0" + cpfCnpjFormatado; cpfCnpjFormatado = $"CNPJ: {cpfCnpjFormatado.Substring(0, 2)}.{cpfCnpjFormatado.Substring(2, 3)}.{cpfCnpjFormatado.Substring(5, 3)}/{cpfCnpjFormatado.Substring(8, 4)}-{cpfCnpjFormatado.Substring(12, 2)}"; }
                    else if (cpfCnpjFormatado.Length == 14) { cpfCnpjFormatado = $"CNPJ: {cpfCnpjFormatado.Substring(0, 2)}.{cpfCnpjFormatado.Substring(2, 3)}.{cpfCnpjFormatado.Substring(5, 3)}/{cpfCnpjFormatado.Substring(8, 4)}-{cpfCnpjFormatado.Substring(12, 2)}"; }
                    else if (cpfCnpjFormatado.Length == 10) { cpfCnpjFormatado = "0" + cpfCnpjFormatado; cpfCnpjFormatado = $"CPF: {cpfCnpjFormatado.Substring(0, 3)}.{cpfCnpjFormatado.Substring(3, 3)}.{cpfCnpjFormatado.Substring(6, 3)}-{cpfCnpjFormatado.Substring(9, 2)}"; }
                    else if (cpfCnpjFormatado.Length == 11) { cpfCnpjFormatado = $"CPF: {cpfCnpjFormatado.Substring(0, 3)}.{cpfCnpjFormatado.Substring(3, 3)}.{cpfCnpjFormatado.Substring(6, 3)}-{cpfCnpjFormatado.Substring(9, 2)}"; }
                    else { return (new List<Class_Detalhe500>(), "Erro: CPF/CNPJ com formato inválido."); }

                    var foundClient = clientObj500.FirstOrDefault(c => c.CPF_CNPJ == cpfCnpjFormatado);
                    Class_Detalhe500 _lineClient;

                    if (foundClient == null)
                    {
                        _lineClient = new Class_Detalhe500
                        {
                            IdentificacaoRegistro = tipoRegistro,
                            DataCarencia = _line.Substring(1, 6),
                            TipoJuros = _line.Substring(7, 1),
                            Branco1 = _line.Substring(8, 2),
                            TaxaJuros = _line.Substring(10, 10),
                            Coobrigacao = _line.Substring(20, 2),
                            CaracteristicaEspecial = _line.Substring(22, 2),
                            ModalidadeOperacao = _line.Substring(24, 4),
                            NaturezaOperacao = _line.Substring(28, 2),
                            OrigemRecurso = _line.Substring(30, 4),
                            ClasseRiscoOperacao = _line.Substring(34, 2),
                            Zeros1 = _line.Substring(36, 1),
                            NumeroControleParticipante = _line.Substring(37, 25),
                            NumeroBanco = _line.Substring(62, 3),
                            QuantidadeDeLastros = _line.Substring(65, 3),
                            Branco2 = _line.Substring(68, 13),
                            Branco3 = _line.Substring(81, 1),
                            ValorPago = _line.Substring(82, 10),
                            CondicaoEmissaoPapeletaCobranca = _line.Substring(92, 1),
                            IdentEmitePapeletaDebitoAutomatico = _line.Substring(93, 1),
                            DataLiquidacao = _line.Substring(94, 6),
                            IdentificacaoOperacaoBanco = _line.Substring(100, 4),
                            IndicadorRateioCredito = _line.Substring(104, 1),
                            EnderecamentoAvisoDebitoAutomatico = _line.Substring(105, 1),
                            Branco4 = _line.Substring(106, 2),
                            IdentificacaoOcorrencia = _line.Substring(108, 2),
                            NumeroDocumento = _line.Substring(110, 10),
                            DataVencimentoTitulo = _line.Substring(120, 6),
                            BancoEncarregadoCobranca = _line.Substring(139, 3),
                            AgenciaDepositaria = _line.Substring(142, 5),
                            EspecieTitulo = _line.Substring(147, 2),
                            Identificacao = _line.Substring(149, 1),
                            PrimeiraInstrucao = _line.Substring(156, 2),
                            SegundaInstrucao = _line.Substring(158, 1),
                            TipoPessoaCedente = _line.Substring(159, 2),
                            JurosMora = _line.Substring(161, 12),
                            NumeroTermoCessao = _line.Substring(173, 19),
                            ValorPresenteParcela = _line.Substring(192, 13),
                            ValorAbatimento = _line.Substring(205, 13),
                            IdentTipoInscricaoSacado = _line.Substring(218, 2),
                            CPF_CNPJ = cpfCnpjFormatado,
                            Nome = nome,
                            EnderecoCompleto = _line.Substring(274, 40),
                            NumeroNotaFiscalDuplicata = _line.Substring(314, 9),
                            NumeroSerieNotaFiscalDuplicata = _line.Substring(323, 3),
                            CEP = _line.Substring(326, 8),
                            Cedente = _line.Substring(334, 60),
                            DataEncargo1 = _line.Substring(394, 6),
                            PercentualEncargo1 = _line.Substring(400, 8),
                            DataEncargo2 = _line.Substring(408, 6),
                            PercentualEncargo2 = _line.Substring(414, 8),
                            TaxaAdicional = _line.Substring(422, 8),
                            Branco5 = _line.Substring(430, 8),
                            TaxaJurosMensal = _line.Substring(438, 8),
                            JurosDeMoraDetalhe = _line.Substring(446, 8),
                            Multa = _line.Substring(454, 13),
                            Branco6 = _line.Substring(467, 27),
                            NumeroSequencialRegistro = _line.Substring(494, 6)
                        };
                        clientObj500.Add(_lineClient);
                    }
                    else
                    {
                        _lineClient = foundClient;
                    }

                    string valorParcelaStr = _line.Substring(126, 13).Trim();
                    if (decimal.TryParse(valorParcelaStr, out decimal valorParcela))
                    {
                        valorParcela /= 100;
                        _lineClient.TotalParcelasCliente += valorParcela;
                        totalParcelasCNAB += valorParcela;
                    }

                    string dataEmissao = _line.Substring(150, 6).Trim();
                    if (dataEmissao.Length == 6) dataEmissao = $"{dataEmissao.Substring(0, 2)}/{dataEmissao.Substring(2, 2)}/{dataEmissao.Substring(4, 2)}";
                    _lineClient.DatasEmissao = dataEmissao;

                    var (fieldRequiredBool, fieldError) = ValidateFields500(_lineClient);
                    if (!fieldRequiredBool) return (clientObj500, fieldError);

                    string dataVencimento = _line.Substring(120, 6);
                    if (dataVencimento.Length == 6) dataVencimento = $"{dataVencimento.Substring(0, 2)}/{dataVencimento.Substring(2, 2)}/{dataVencimento.Substring(4, 2)}";
                    string numeroDocumento = _line.Substring(110, 10).Trim();
                    string parcelaFormatada = $"Número CCB: {numeroDocumento} | Vencimento: {dataVencimento} | Parcela a pagar: R$ {valorParcela:N2}";
                    _lineClient.DataVencimentoTitulo = dataVencimento;
                    _lineClient.Parcelas.Add(parcelaFormatada);
                    _lineClient.NumeroDocumento = numeroDocumento;
                }
            }
            catch (Exception ex)
            {
                return (new List<Class_Detalhe500>(), $"Error reading file: {ex.Message}");
            }

            return (clientObj500, totalParcelasCNAB.ToString("N2"));
        }
    }
}