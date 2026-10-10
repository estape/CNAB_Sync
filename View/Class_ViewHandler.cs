using System.Linq;
using Photino.NET;
using Core;
using FileManager;
using DataHandler;
using Detalhe444;

namespace ViewHandler
{
    public class Class_ViewHandler
    {
        string totalParcelasCNAB = "";
        string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        (string CNABFile, string[] extensions) defaultFilter = ("Arquivos CNAB(*.txt)", new[] { "txt", "rem", "ret" });
        dynamic? clients = null;
        bool isCNAB500 = false;
        int currentClientIndex = -1;
        private string? error;

        Class_FileManager fileManager = new Class_FileManager();
        Class_DataHandler dataHandler = new Class_DataHandler();
        Class_Core core = new Class_Core();

        public static void Start()
        {
            var viewHandler = new Class_ViewHandler();
            viewHandler.Run();
        }

        public void Run()
        {
            // Cria a janela de aplicativo nativa
            var window = new PhotinoWindow()
                .SetTitle("CNAB Sync")
                .SetUseOsDefaultSize(false)
                .SetSize(1280, 720)
                .Center()
                .SetDevToolsEnabled(false)
                .SetContextMenuEnabled(false)
                .Load("View/wwwroot/index.html");

            if (core.AppConfig.LastPath != null)
                defaultPath = core.AppConfig.LastPath;

            _ = window.RegisterWebMessageReceivedHandler((object? sender, string message) =>
            {
                message = message.Trim('"');
                Console.WriteLine(message); // Debug to console.
                // Header Menu
                switch (message)
                {
                    case "menuTopNovo":
                        // Here we can refresh everything if user want start all new again
                        break;

                    case "menuTopImportarCNAB":
                        window.Invoke(() =>
                        {
                            var cnabFilters = new[] { ("Arquivos Suportados (*.rem, *.txt)", new[] { "rem", "txt" }) };
                            string[] filesGet = [];
                            try
                            {
                                filesGet = window.ShowOpenFile(title: "Importar CNAB", defaultPath: string.IsNullOrEmpty(defaultPath) ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : defaultPath, multiSelect: false, filters: cnabFilters);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Erro ao abrir janela: " + ex.Message);
                            }

                            if (filesGet != null && filesGet.Length > 0)
                            {
                                string ext = System.IO.Path.GetExtension(filesGet[0]).ToLower();
                                if (ext != ".rem" && ext != ".txt")
                                {
                                    window.ShowMessage("CNAB Sync - Erro", "Por favor, selecione um arquivo valido (.rem ou .txt).", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Error);
                                    return;
                                }

                                string firstLine = System.IO.File.ReadLines(filesGet[0]).FirstOrDefault() ?? "";
                                if (firstLine.Length >= 500)
                                {
                                    (clients, totalParcelasCNAB) = fileManager.ReadFile500(filesGet[0]);
                                    isCNAB500 = true;
                                }
                                else
                                {
                                    (clients, totalParcelasCNAB) = fileManager.ReadFile444(filesGet[0]);
                                    isCNAB500 = false;
                                }

                                if (totalParcelasCNAB != null && (totalParcelasCNAB.StartsWith("Field") || totalParcelasCNAB.StartsWith("Error") || totalParcelasCNAB.StartsWith("Arquivo")))
                                {
                                    Console.WriteLine($"Failed to draw Layout CNAB: {totalParcelasCNAB}");
                                    window.ShowMessage("CNAB Sync - Erro", $"Falha de Layout CNAB: {totalParcelasCNAB}", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Error);
                                    return;
                                }

                                if (totalParcelasCNAB == null) { totalParcelasCNAB = "0,00"; }
                                window.SendWebMessage($"updateTotalParcelasCNAB:{totalParcelasCNAB}");
                                string htmlFinal = dataHandler.ListClients(clients);
                                window.SendWebMessage($"UPDATE_CLIENTS_HTML:{htmlFinal}");

                                // Update default path for next time
                                defaultPath = System.IO.Path.GetDirectoryName(filesGet[0]);
                                core.AppConfig.LastPath = defaultPath;
                                core.WriteConfig(core.AppConfig);
                            }
                            else
                            {
                                // User cancelled or error
                                window.ShowMessage("CNAB Sync", "Nenhum arquivo selecionado ou erro ao abrir.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Warning);
                                Console.WriteLine("An error occurred at 'menuTopImportarCNAB' case");
                            }
                        });
                        break;

                    case "menuTopSalvar":
                        if (clients != null && clients.Count > 0)
                        {
                            string path = window.ShowSaveFile(
                                title: "Salvar Arquivo CNABSync",
                                defaultPath: defaultPath,
                                filters: new[] { ("CNABSync Files", new[] { "CNABSync" }) }
                            );

                            if (!string.IsNullOrEmpty(path))
                            {
                                if (isCNAB500)
                                {
                                    window.ShowMessage("CNAB Sync - Aviso", "Salvamento de arquivo .CNABSync para formato 500 ainda não suportado.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Warning);
                                }
                                else
                                {
                                    var result = fileManager.SavePropFile(clients, path);
                                    if (result.success)
                                    {
                                        window.ShowMessage("CNAB Sync", "Arquivo salvo com sucesso.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Info);
                                    }
                                    else
                                    {
                                        window.ShowMessage("CNAB Sync - Erro", $"Falha ao salvar.\nDetalhes: {result.errorMessage}", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Error);
                                    }
                                }
                            }
                        }
                        else
                        {
                            window.ShowMessage("CNAB Sync", "Não há dados para salvar.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Warning);
                        }
                        break;

                    case "menuTopCarregar":
                        string[] propFiles = window.ShowOpenFile(
                            title: "Carregar Arquivo CNABSync",
                            defaultPath: defaultPath,
                            multiSelect: false,
                            filters: new[] { ("CNABSync Files", new[] { "CNABSync" }) }
                        );

                        if (propFiles.Length > 0)
                        {
                            var loadedClients = fileManager.LoadPropFile(propFiles[0]);
                            if (loadedClients != null)
                            {
                                clients = loadedClients;
                                decimal total = 0;
                                foreach (var c in clients) total += c.TotalParcelasCliente;
                                string totalParcelas = total.ToString("N2");
                                window.SendWebMessage($"updateTotalParcelasCNAB:{totalParcelas}");
                                string htmlFinal = dataHandler.ListClients(clients);
                                window.SendWebMessage($"UPDATE_CLIENTS_HTML:{htmlFinal}");

                                defaultPath = System.IO.Path.GetDirectoryName(propFiles[0]);
                                core.AppConfig.LastPath = defaultPath;
                                core.WriteConfig(core.AppConfig);
                                window.ShowMessage("CNAB Sync", "Arquivo carregado com sucesso.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Info);
                            }
                            else
                            {
                                window.ShowMessage("CNAB Sync - Erro", "Falha ao carregar o arquivo.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Error);
                            }
                        }
                        break;

                    case "menuTopEditorArquivo":
                        if (clients != null && clients.Count > 0 && currentClientIndex >= 0)
                        {
                            window.Load("View/wwwroot/editor.html");
                        }
                        else
                        {
                            window.ShowMessage("CNAB Sync", "Selecione um cliente primeiro para editar.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Warning);
                        }
                        break;

                    case "menuTopExportarCNAB":
                        window.ShowMessage("CNAB Sync", "Exportar CNAB será implementado em breve.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Info);
                        break;

                    case "menuTopExcel":
                        if (clients != null && clients.Count > 0)
                        {
                            string path = window.ShowSaveFile(
                                title: "Exportar CNAB para Excel",
                                defaultPath: defaultPath,
                                filters: new[] { ("Excel Files", new[] { "xlsx" }) }
                            );

                            if (!string.IsNullOrEmpty(path))
                            {
                                if (isCNAB500)
                                {
                                    window.ShowMessage("CNAB Sync - Aviso", "Exportação para CNAB 500 ainda não suportada.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Warning);
                                }
                                else
                                {
                                    var result = fileManager.Export444XLSX(clients, path);
                                    if (result.success)
                                    {
                                        window.ShowMessage("CNAB Sync - Sucesso", "CNAB exportado para Excel com sucesso.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Info);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"CNAB Sync - Erro: Falha ao exportar CNAB para Excel. Detalhes: {result.errorMessage}");
                                        window.ShowMessage("CNAB Sync - Erro", $"Falha ao exportar CNAB para Excel.\nDetalhes: {result.errorMessage}", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Error);
                                    }
                                }
                            }
                        }
                        else
                        {
                            window.ShowMessage("CNAB Sync - Atenção", "Não há dados carregados para exportar.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Warning);
                        }
                        break;

                    case "menuTopCSV":
                        if (clients != null && clients.Count > 0)
                        {
                            string path = window.ShowSaveFile(
                                title: "Exportar CNAB para CSV",
                                defaultPath: defaultPath,
                                filters: new[] { ("CSV Files", new[] { "csv" }) }
                            );

                            if (!string.IsNullOrEmpty(path))
                            {
                                if (isCNAB500)
                                {
                                    window.ShowMessage("CNAB Sync - Aviso", "Exportação para CNAB 500 ainda não suportada.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Warning);
                                }
                                else
                                {
                                    var result = fileManager.Export444CSV(clients, path);
                                    if (result.success)
                                    {
                                        Console.WriteLine("CNAB Sync - Sucesso: CNAB exportado para CSV com sucesso.");
                                        window.ShowMessage("CNAB Sync - Sucesso", "CNAB exportado para CSV com sucesso.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Info);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"CNAB Sync - Erro: Falha ao exportar CNAB para CSV. Detalhes: {result.errorMessage}");
                                        window.ShowMessage("CNAB Sync - Erro", $"Falha ao exportar CNAB para CSV.\nDetalhes: {result.errorMessage}", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Error);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("CNAB Sync - Atenção: Não há dados carregados para exportar.");
                            window.ShowMessage("CNAB Sync - Atenção", "Não há dados carregados para exportar.", PhotinoDialogButtons.Ok, PhotinoDialogIcon.Warning);
                        }
                        break;

                    case "btnSwitchTheme":
                        string newTheme = core.CycleTheme(core.AppConfig.ThemeDefault == 0 ? 1 : 0);
                        window.SendWebMessage(newTheme);
                        break;

                    default:
                        break;
                }

                // CNAB Editor
                switch (message)
                {
                    case "closeEditor":
                        window.Load("View/wwwroot/index.html");
                        break;

                    case "get_editor_data":
                        if (clients != null && currentClientIndex >= 0 && currentClientIndex < clients.Count)
                        {
                            var clientData = new { index = currentClientIndex, client = clients[currentClientIndex] };
                            string json = System.Text.Json.JsonSerializer.Serialize(clientData);
                            window.SendWebMessage($"LOAD_CLIENT_DATA:{json}");
                        }
                        break;

                    case "get_initial_data":
                        if (clients != null && ((System.Collections.IList)clients).Count > 0)
                        {
                            string htmlFinal = dataHandler.ListClients(clients);
                            window.SendWebMessage($"UPDATE_CLIENTS_HTML:{htmlFinal}");

                            decimal total = 0;
                            foreach (var c in clients) total += c.TotalParcelasCliente;
                            totalParcelasCNAB = total.ToString("N2");
                            window.SendWebMessage($"updateTotalParcelasCNAB:{totalParcelasCNAB}");

                            // If there's a selected client, we can restore its detail view
                            if (currentClientIndex >= 0 && currentClientIndex < ((System.Collections.IList)clients).Count)
                            {
                                string clientHtml = GetClientInfo(currentClientIndex);
                                string clientTotal = dataHandler.GetClientTotal(clients, currentClientIndex);
                                window.SendWebMessage($"UPDATE_PARCELAS_CONTRATO:{clientHtml}");
                                window.SendWebMessage($"UPDATE_TOTAL_CLIENTE:{clientTotal}");
                            }
                        }
                        break;

                    case "get_initial_theme":
                        if (core.AppConfig.ThemeDefault == 0)
                            window.SendWebMessage("SWITCH_THEME_LIGHT");
                        else
                            window.SendWebMessage("SWITCH_THEME_DARK");
                        break;
                }

                if (message.StartsWith("get_client_info:"))
                {
                    if (int.TryParse(message.Substring("get_client_info:".Length), out int index))
                    {
                        currentClientIndex = index;
                        string html = GetClientInfo(index);
                        string total = dataHandler.GetClientTotal(clients, index);
                        window.SendWebMessage($"UPDATE_PARCELAS_CONTRATO:{html}");
                        window.SendWebMessage($"UPDATE_TOTAL_CLIENTE:{total}");
                    }
                }

                if (message.StartsWith("SAVE_CLIENT_DATA:"))
                {

                }
            });

            // Mantém o aplicativo rodando até a janela ser fechada
            window.WaitForClose();
        }

        public string GetClientInfo(int index)
        {
            if (clients != null && index >= 0 && index < clients.Count)
            {
                return dataHandler.LoadAmountClient(clients, index);
            }

            return "";
        }
    }
}
