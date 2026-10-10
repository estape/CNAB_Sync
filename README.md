# CNAB Sync

CNAB Sync is a .NET application designed to manage, parse, and generate CNAB (Centro Nacional de Automação Bancária) files. This project standardizes the exchange of financial information between companies and Brazilian banks, providing strongly-typed C# models for different CNAB layouts.

## Features

- **CNAB 240 Support:** Includes data models for Banking Conciliation layouts (Version 5.0), mapping File Headers, Batch Headers, Detail Segments (Segment E), Batch Trailers, and File Trailers.
- **CNAB 400 Support:** Includes data models for Bradesco Collection (Cobrança) layouts, featuring Header and Trailer records, as well as multiple transaction detail types (Type 1, Type 2, and Type 3).
- **CNAB 444 Support:** Includes data models for CNAB 444 Remittance (Mercado) layouts (Header, Detail, Trailer) used for specific FIDC operations (FROMTIS).
- **CNAB 500 Support:** Includes data models for CNAB 500 Remittance (FIDD) layouts (Header, Detail, Trailer) tailored for FIDC (Fundo de Investimentos em Direitos Creditórios / sinqia).
- **Strongly Typed Models:** Maps positional flat-file string data into structured C# POCO classes to simplify read and write operations.
- **Extensible Architecture:** Designed to easily accommodate new banks, layouts, and versions.

## Project Structure

The project's domain models are organized by layout size and specific transaction types:

```text
CNAB_Sync/
└── Model/
    ├── 240/
    │   ├── Class_BatchHeaderRegistration.cs
    │   ├── Class_BatchTrailerRegistration.cs
    │   ├── Class_DetailRegistrationSegE.cs
    │   ├── Class_FileHeaderRegistration.cs
    │   └── Class_FileTrailerRegistration.cs
    ├── 400/
    │   ├── Class_Header.cs
    │   ├── Class_Trailer.cs
    │   ├── Type1/
    │   │   └── Class_DetailsType1.cs
    │   ├── Type2/
    │   │   └── Class_DetailsType2.cs
    │   └── Type3/
    │       └── Class_DetailsType3.cs
    ├── 444/
    │   ├── Class_Detalhe444.cs
    │   ├── Class_Header444.cs
    │   └── Class_Trailler444.cs
    └── 500/
        ├── Class_Detalhe500.cs
        ├── Class_Header500.cs
        └── Class_Trailler500.cs
```

## Documentation

The models were generated based on official banking and FIDC documentation:
- **Banking Conciliation Layout 240 positions Version 5.0**
- **Manual de Procedimentos Operacionais para Troca de Arquivos (Cobrança Bradesco - CNAB 400)**
- **CNAB 444 - REMESSA (MERCADO) - FIDC / FROMTIS**
- **CNAB 500 - REMESSA (FIDD) - FIDC / sinqia**

## Getting Started

### Opening the Project
The choice of IDE is entirely up to the developer (e.g., Visual Studio 2022+, Visual Studio Code, JetBrains Rider, etc.). 
To open the project, simply open the root folder `CNAB_Sync` or the `CNAB_Sync.csproj` file in your preferred IDE.

### Prerequisites
- **.NET 10.0 SDK** or later installed on your machine.
- Since this project uses **Photino.NET** for UI and **ClosedXML**, ensure your environment can resolve NuGet packages.

### Compilation & Running
To compile the project and restore the necessary dependencies, open your terminal at the root of the project and run:
```bash
dotnet build
```
To run the application (which will also copy the required web assets from `View/wwwroot/` to the output directory), use:
```bash
dotnet run
```

## Contributing

Feel free to open issues or submit pull requests if you want to extend support for additional banks (e.g., Itaú, Banco do Brasil, Caixa) or new CNAB segment types.

## License

This project is open-source and available under the MIT License.
