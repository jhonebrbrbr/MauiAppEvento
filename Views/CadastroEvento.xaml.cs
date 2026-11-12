using MauiAppEvento.Models;

namespace MauiAppEvento.Views;

public partial class CadastroEvento : ContentPage
{

    App PropriedadesApp;
    public CadastroEvento()
	{
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_NomeEvento.ItemsSource = PropriedadesApp.Nome_Evento;

        dtpck_InicioEvento.MinimumDate = DateTime.Now;
        dtpck_InicioEvento.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);


        dtpck_InicioEvento.MinimumDate = dtpck_InicioEvento.Date?.AddDays(1) ?? DateTime.Now.AddDays(1);
        dtpck_TerminoEvento.MaximumDate = dtpck_TerminoEvento.Date?.AddMonths(6) ?? DateTime.Now.AddMonths(6);
    }


    //dtpck_TerminoEvento_DateSelected
    private async void dtpck_InicioEvento_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;


        DateTime data_selecionada_checkin = elemento.Date.Value;

        dtpck_InicioEvento.MinimumDate = data_selecionada_checkin.AddDays(1);

        dtpck_TerminoEvento.MaximumDate = data_selecionada_checkin.AddMonths(6);


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
                Nome = (NomeEvento)pck_NomeEvento.SelectedItem,
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