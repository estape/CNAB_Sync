const totalArquivoCNAB = document.getElementById("totalArquivoCNAB");
const parcelasContrato = document.getElementById("parcelasContrato");

const menuTopNovo = document.getElementById("menuTopNovo");
const menuTopSalvar = document.getElementById("menuTopSalvar");
const menuTopCarregar = document.getElementById("menuTopCarregar");
const menuTopImportarCNAB = document.getElementById("menuTopImportarCNAB");
const menuTopExportarCNAB = document.getElementById("menuTopExportarCNAB");
const menuTopExcel = document.getElementById("menuTopExcel");
const menuTopCSV = document.getElementById("menuTopCSV");
const btnSwitchTheme = document.getElementById("btnSwitchTheme");
const menuTopEditorArquivo = document.getElementById("menuTopEditorArquivo");

if (menuTopNovo) menuTopNovo.addEventListener("click", function (e) { e.preventDefault(); window.external.sendMessage("menuTopNovo"); });
if (menuTopSalvar) menuTopSalvar.addEventListener("click", function (e) { e.preventDefault(); window.external.sendMessage("menuTopSalvar"); });
if (menuTopCarregar) menuTopCarregar.addEventListener("click", function (e) { e.preventDefault(); window.external.sendMessage("menuTopCarregar"); });
if (menuTopImportarCNAB) menuTopImportarCNAB.addEventListener("click", function (e) { e.preventDefault(); window.external.sendMessage("menuTopImportarCNAB"); });
if (menuTopExportarCNAB) menuTopExportarCNAB.addEventListener("click", function (e) { e.preventDefault(); window.external.sendMessage("menuTopExportarCNAB"); });
if (menuTopExcel) menuTopExcel.addEventListener("click", function (e) { e.preventDefault(); window.external.sendMessage("menuTopExcel"); });
if (menuTopCSV) menuTopCSV.addEventListener("click", function (e) { e.preventDefault(); window.external.sendMessage("menuTopCSV"); });
if (btnSwitchTheme) btnSwitchTheme.addEventListener("click", function (e) { e.preventDefault(); window.external.sendMessage("btnSwitchTheme"); });
if (menuTopEditorArquivo) menuTopEditorArquivo.addEventListener("click", function (e) { e.preventDefault(); window.external.sendMessage("menuTopEditorArquivo"); });

window.external.receiveMessage(function (message) {
    if (message.startsWith("updateTotalParcelasCNAB:")) {
        const total = message.substring("updateTotalParcelasCNAB:".length);
        if (totalArquivoCNAB) {
            totalArquivoCNAB.textContent = "R$ " + total;
        }
    }
    if (message.startsWith("UPDATE_CLIENTS_HTML:")) {
        const clientListData = message.substring("UPDATE_CLIENTS_HTML:".length);
        const containerList = document.querySelector(".client-list");
        if (containerList) {
            containerList.innerHTML = clientListData;
        }
    }

    if (message.startsWith("UPDATE_PARCELAS_CONTRATO:")) {
        const parcelasContratoData = message.substring("UPDATE_PARCELAS_CONTRATO:".length);
        if (parcelasContrato) {
            parcelasContrato.innerHTML = parcelasContratoData;
        }
    }

    if (message.startsWith("UPDATE_TOTAL_CLIENTE:")) {
        const total = message.substring("UPDATE_TOTAL_CLIENTE:".length);
        const totalParcelasCliente = document.getElementById("totalParcelasCliente");
        if (totalParcelasCliente) {
            totalParcelasCliente.textContent = "R$ " + total;
        }
    }

    if (message.startsWith("SWITCH_THEME_DARK")) {
        loadCSS("css/dark/styles.css");
    }

    if (message.startsWith("SWITCH_THEME_LIGHT")) {
        loadCSS("css/light/styles.css");
    }
});

function loadCSS(url) {
    const stylesheet = document.getElementById("theme-stylesheet");
    if (stylesheet) {
        stylesheet.setAttribute("href", url);
    }
}

document.addEventListener("click", function (e) {
    const clientItem = e.target.closest(".client-item");
    if (clientItem) {
        e.preventDefault();
        const index = clientItem.getAttribute("data-index");
        if (index !== null) {
            window.external.sendMessage("get_client_info:" + index);
        }
    }
});

// Request initial theme
setTimeout(() => {
    window.external.sendMessage("get_initial_theme");
    window.external.sendMessage("get_initial_data");
}, 100);
