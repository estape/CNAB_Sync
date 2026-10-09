using System.Collections.Generic;
using System.Linq;

namespace DataHandler
{
    public class Class_DataHandler
    {
        public string ListClients(IEnumerable<dynamic> clients)
        {
            string htmlFinal = "";
            var htmlClients = clients
                .Select((client, index) => new { client, index })
                .Where(x => !string.IsNullOrWhiteSpace((string)x.client.Nome) && !string.IsNullOrWhiteSpace((string)x.client.CPF_CNPJ))
                .Select(x => $"<a href='#cliente_{x.index}' class='client-item' data-index='{x.index}'><span class='client-name'>{x.client.Nome}</span><span class='client-doc'>{x.client.CPF_CNPJ}</span></a>")
                .ToList();

            htmlFinal = string.Join("", htmlClients);
            return htmlFinal;
        }

        public string GetClientTotal(IEnumerable<dynamic> clients, int index)
        {
            var clientList = clients.ToList();
            if (clientList == null || index < 0 || index >= clientList.Count)
                return "0,00";

            var client = clientList[index];
            decimal total = 0m;

            foreach (var parcelaStr in client.Parcelas)
            {
                var parts = parcelaStr.Split('|');
                if (parts.Length == 3)
                {
                    var valorPart = parts[2].Replace("Parcela a pagar:", "").Replace("R$", "").Trim();
                    if (decimal.TryParse(valorPart, System.Globalization.NumberStyles.Any, new System.Globalization.CultureInfo("pt-BR"), out decimal valorParsed))
                    {
                        total += valorParsed;
                    }
                }
            }

            return total.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
        }

        public string LoadAmountClient(IEnumerable<dynamic> clients, int index)
        {   
            var clientList = clients.ToList();
            if (clientList == null || index < 0 || index >= clientList.Count)
                return string.Empty;

            var client = clientList[index];
            var htmlBuilder = new List<string>();

            foreach (var parcelaStr in client.Parcelas)
            {
                var parts = parcelaStr.Split('|');
                if (parts.Length == 3)
                {
                    var ccbPart = parts[0].Replace("Número CCB:", "").Trim();
                    var vencPart = parts[1].Replace("Vencimento:", "").Trim();
                    var valorPart = parts[2].Replace("Parcela a pagar:", "").Trim();

                    htmlBuilder.Add($"<div class=\"contract-line\"><span>Número CCB: <span class=\"tag\">{ccbPart}</span></span><span>Vencimento: <span class=\"tag\">{vencPart}</span></span><span>Parcela a pagar: <span class=\"money font-weight-bold\">{valorPart}</span></span></div>");
                }
            }

            return string.Join("", htmlBuilder);
        }
    }
}