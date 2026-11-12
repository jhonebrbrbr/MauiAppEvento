using MauiAppEvento.Models;

namespace MauiAppEvento.Views;

public partial class ExibicaoCadastro : ContentPage
{
	public ExibicaoCadastro()
	{
		InitializeComponent();
	}

    private void Btn_Voltar_Clicked(object sender, EventArgs e)
    {
        try
        {
            Application.Current.Windows[0].Page = new CadastroEvento();
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Erro", $"Ocorreu um erro ao navegar para a página " +
                $"CadastroEvento: {ex.Message}", "OK");
        }

    }
}