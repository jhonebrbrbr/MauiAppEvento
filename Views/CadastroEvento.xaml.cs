using MauiAppEvento.Models;

namespace MauiAppEvento.Views;

public partial class CadastroEvento : ContentPage
{

    App PropriedadesApp;
    public CadastroEvento()
	{
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_NomeEvento.ItemsSource = PropriedadesApp.Descricao_Evento;

        dtpck_InicioEvento.MinimumDate = DateTime.Now;
        dtpck_InicioEvento.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);


        dtpck_TerminoEvento.MinimumDate = dtpck_InicioEvento.Date?.AddDays(1) ?? DateTime.Now.AddDays(1);
        dtpck_TerminoEvento.MaximumDate = dtpck_InicioEvento.Date?.AddMonths(6) ?? DateTime.Now.AddMonths(6);

    }


    //dtpck_TerminoEvento_DateSelected
    private async void dtpck_InicioEvento_DateSelected(object sender, DateChangedEventArgs e)
    {

        try
        {
            DatePicker elemento = sender as DatePicker;


            DateTime data_selecionada_InicioEvento = elemento.Date.Value;

            dtpck_TerminoEvento.MinimumDate = data_selecionada_InicioEvento.AddDays(1);

            dtpck_TerminoEvento.MaximumDate = data_selecionada_InicioEvento.AddMonths(6);
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", $"Ocorreu um erro ao selecionar a data de início do evento: {ex.Message}", "OK");


        }

    }


    private async void dtpck_TerminoEvento_DateSelected(object sender, DateChangedEventArgs e)
    {

    }

    private async void Btn_Avancar_Clicked(object sender, EventArgs e)
    {
        try
        {
            DadosEvento d = new DadosEvento
            {
                Descricao = (DescricaoEvento)pck_NomeEvento.SelectedItem,
                Data_Inicio = dtpck_InicioEvento.Date.Value,
                Data_Termino = dtpck_TerminoEvento.Date.Value,
                Numero_Participantes = Convert.ToInt32(stp_participantes.Value),
                Local_Evento = Txt_Local_Evento.Text,
                Custo_Participante = Convert.ToDouble(Txt_Custo_Participante.Text),
                
            };  
     

            Application.Current.Windows[0].Page = new ExibicaoCadastro()
            {
                BindingContext = d

            };


        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "OK");
        }

    }
}