# CNAB Sync

**CNAB Sync** is a modern cross-platform desktop application built on **.NET 10** and **Photino.NET** designed to parse, inspect, manage, and export Brazilian banking automation files (**CNAB** - *Centro Nacional de Automação Bancária*).

It provides a responsive web-based desktop user interface coupled with strongly-typed C# domain models, enabling financial analysts and developers to load flat-file CNAB streams, review grouped receivables, inspect contract details, and export datasets to Excel or CSV.

---

## Architecture & Technology Stack

- **Platform & Runtime:** [.NET 10.0](https://dotnet.microsoft.com/) (C# 13 / Nullable reference types enabled)
- **Desktop UI Framework:** [Photino.NET](https://www.tryphotino.io/) — lightweight native desktop window hosting a fast HTML/CSS/JavaScript webview front end without Chromium/Electron overhead.
- **Spreadsheet Processing:** [ClosedXML](https://github.com/ClosedXML/ClosedXML) — used for generating and exporting formatted Microsoft Excel (`.xlsx`) workbooks.
- **Front End:** Modern HTML5, modular CSS themes (Light/Dark mode support), and native asynchronous JavaScript message passing via Photino IPC.

---

## Key Features

- **Multi-Layout Model Support:**
  - **CNAB 240:** Banking Conciliation layout (v5.0), including File Header/Trailer, Batch Header/Trailer, and Detail (Segment E) records.
  - **CNAB 400:** Bradesco Collection (*Cobrança*) layout, including Header, Trailer, and Detail records (Type 1, Type 2 - Messages, and Type 3 - Credit Split / Rateio).
  - **CNAB 444:** FIDC Remittance (*Mercado / FROMTIS*) layout with full parsing and export capabilities.
  - **CNAB 500:** FIDC Remittance (*FIDD / Sinqia*) layout supporting extended post-fixed and credit rights specifications.
- **Intelligent Customer & Installment Grouping:** Automatically groups individual financial entries and receivables by CPF/CNPJ into cohesive customer portfolios with calculated totals.
- **Dynamic File Date Parsing:** Automatically detects and extracts the file generation / recording date directly from the CNAB header across different layout lengths.
- **Exporting Capabilities:**
  - Export structured client and installment tables to formatted **Excel (`.xlsx`)** spreadsheets.
  - Export records to delimiter-separated **CSV** files.
  - Save and reload parsed sessions using native **`.CNABSync`** proprietary workspace files.
- **Theme Support:** Built-in dynamic theme switcher (Light and Dark themes).

---

## Project Structure

```text
CNAB_Sync/
├── Controller/
│   ├── Class_Core.cs            # Application state & configuration management
│   ├── Class_DataHandler.cs     # Data formatting & HTML card generation
│   └── Class_FileManager.cs     # CNAB parsing, validation, Excel & CSV exporters
├── Model/
│   ├── 240/                     # CNAB 240 Banking Conciliation models
│   ├── 400/                     # CNAB 400 Bradesco Collection models (Type 1, 2, 3)
│   ├── 444/                     # CNAB 444 FIDC models
│   ├── 500/                     # CNAB 500 FIDC models
│   └── Class_Config.cs          # User settings & layout preferences
├── View/
│   ├── Class_ViewHandler.cs     # Photino native window & IPC bridge
│   └── wwwroot/                 # Desktop UI (HTML, CSS themes, JavaScript)
│       ├── css/ (dark & light)
│       ├── js/fronthandler.js
│       ├── index.html
│       └── editor.html
├── CNAB_Sync.csproj
├── LICENSE.md                   # MPL-2.0 and third-party dependency licenses
├── README.md                    # Project documentation
└── SECURITY.md                  # Security & vulnerability reporting policy
```

---

## Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet) or later installed.
- Any development environment or IDE of your choice:
  - Visual Studio 2022+ / Visual Studio Code / JetBrains Rider / Command Line (`dotnet CLI`).

### Compilation & Running

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/CNAB_Sync.git
   cd CNAB_Sync
   ```

2. **Restore dependencies & Build:**
   ```bash
   dotnet build
   ```

3. **Run the application:**
   ```bash
   dotnet run
   ```

*Note: The build process automatically copies the UI assets located in `View/wwwroot/**/*` to the build output directory.*

---

## Security

Please review [SECURITY.md](file:///d:/Rodrigo/Documents/Dev/vscode/Desktop/dotNET/CNAB_Sync/SECURITY.md) for vulnerability reporting guidelines and coordinated disclosure via GitHub Security Advisories.

---

## Licensing

This project is licensed under the **Mozilla Public License Version 2.0 (MPL-2.0)**. See the [LICENSE.md](file:///d:/Rodrigo/Documents/Dev/vscode/Desktop/dotNET/CNAB_Sync/LICENSE.md) file for the complete license text.

### Third-Party Component Licenses

- **Photino.NET**: Distributed under the [Apache License 2.0](https://github.com/tryphotino/photino.NET/blob/master/LICENSE).
- **ClosedXML**: Distributed under the [MIT License](https://github.com/ClosedXML/ClosedXML/blob/develop/LICENSE).
- **Microsoft .NET Runtime**: Distributed under the [MIT License](https://github.com/dotnet/runtime/blob/main/LICENSE.TXT).
