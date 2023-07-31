using System.Windows;
using DctTestTask.Mappers;
using DctTestTask.Models.DTOs;
using DctTestTask.Repositories;
using DctTestTask.Repositories.Abstract;
using DctTestTask.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DctTestTask;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddAutoMapper(typeof(MappingProfile));
                services.AddTransient<ICryptoService<CoinCapCurrency>,CoinCapService>();
                services.AddTransient<MainWindowViewModel>();
                services.AddSingleton<MainWindow>();
            })
            .Build();
    }
    
    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host!.StartAsync();
        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();
        base.OnStartup(e);
    }
 
    protected override async void OnExit(ExitEventArgs e)
    {
        await _host!.StopAsync();
        _host.Dispose();
        base.OnExit(e);
    }
}
