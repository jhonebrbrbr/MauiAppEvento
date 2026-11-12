using Microsoft.Extensions.DependencyInjection;
using MauiAppEvento.Views;
using MauiAppEvento.Models;


namespace MauiAppEvento
{
    public partial class App : Application
    {

        public List<DescricaoEvento> Descricao_Evento = new List<DescricaoEvento>

        {
            new DescricaoEvento() { Descricao = "Show Musical"},
            new DescricaoEvento() { Descricao = "Evento Esportivo"},
            new DescricaoEvento() { Descricao = "Palestras"},
            new DescricaoEvento() { Descricao = "Retiro Religioso"},
            new DescricaoEvento() { Descricao = "Teatro"}

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