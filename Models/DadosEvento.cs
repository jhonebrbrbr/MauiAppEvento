using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppEvento.Models
{
    public class DadosEvento
    {
        public NomeEvento Nome { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Termino { get; set; }
        public int Numero_Participantes { get; set; }
        public double Custo_Participante { get; set; }
        public string Local_Evento { get; set; }

        public double Custo_Total
        {
            get
            {
                return Numero_Participantes * Custo_Participante;
            }
        }

        public double Duracao_Evento
        {
            get
            {
                TimeSpan duracao = Data_Termino - Data_Inicio;
                return duracao.TotalDays;
            }
        }
    }
}
   
