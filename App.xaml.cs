using Microsoft.Extensions.DependencyInjection;
using MauiAppEvento.Views;
using MauiAppEvento.Models;


namespace MauiAppEvento
{
    public partial class App : Application
    {

        public List<NomeEvento> Nome_Evento = new List<NomeEvento>

        {
            new NomeEvento() { Nome = "Show Musical"},
            new NomeEvento() { Nome = "Evento Esportivo"},
            new NomeEvento() { Nome = "Palestras"},
            new NomeEvento() { Nome = "Retiro Religioso"},
            new NomeEvento() { Nome = "Teatro"}

        };

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //return new Window(new AppShell());

            var window = new Window(new NavigationPage(new Views.CadastroEvento()));

            window.Width = 480;
            window.Height = 700;
            window.X = 0;
            window.Y = 0;
            return window;
        }
    }
}