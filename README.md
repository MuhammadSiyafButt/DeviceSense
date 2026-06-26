# DeviceSense

AI-powered system health & storage advisor for Windows. Consolidates a laptop's scattered diagnostics — performance, storage, battery, network, security, and system health — into one visual dashboard, with an embedded AI chatbot (Urdu/English mixed) that explains the data and gives rule-grounded suggestions.

> Formerly named **Laptop Sahayak / System Sahayak**.

## Tech Stack

| Layer | Technology |
|---|---|
| UI | C# / WPF / XAML, MVVM (CommunityToolkit.Mvvm) |
| Charts | LiveCharts2 |
| Hardware monitoring | LibreHardwareMonitorLib, System.Management (WMI) |
| Battery diagnostics | powercfg, Win32_Battery |
| AI integration | OpenAI / Anthropic Claude API (HttpClient, REST) |
| Local history | SQLite (EF Core) |

## Project Structure

```
DeviceSense/
├── src/
│   ├── DeviceSense.UI/        # WPF views, view-models, controls, resources
│   ├── DeviceSense.Core/      # Data collection services, models, insight engine
│   ├── DeviceSense.AI/        # AI client, prompt builder, chat service
│   └── DeviceSense.Data/      # Local history persistence (EF Core + SQLite)
├── tests/
│   └── DeviceSense.Tests/     # Unit tests
├── docs/                      # Project documentation
└── config/                    # appsettings.json (gitignored secrets)
```

See `docs/DeviceSense_Documentation.docx` for full architecture, insight rules, and roadmap.

## Getting Started

1. Open `DeviceSense.sln` in Visual Studio 2022+ (or `dotnet restore` from the repo root).
2. Copy `config/appsettings.json` → `config/appsettings.local.json` and add your AI API key. The `.local.json` file is gitignored.
3. Build and run `DeviceSense.UI` as the startup project.

**Requirements:** Windows 10/11, .NET 8.0, Visual Studio 2022 (with WPF workload).

## Team Workflow

- Each subsystem (Performance, Storage, Battery, Network, Security, SystemHealth, Peripherals) has its own folder under `Services/`, `Models/`, `Views/`, and `ViewModels/` — pick a category and implement end-to-end.
- Keep API keys out of source control — use `config/appsettings.local.json`.
- Add unit tests under `tests/DeviceSense.Tests/<Category>/` alongside new services.

## License

Academic project — COMSATS University Islamabad, Abbottabad Campus.
