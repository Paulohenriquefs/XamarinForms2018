using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
		}

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();
            if (isValidCep(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscaCep(cep);
                    if(end != null) {
                        RESULTADO.Text = string.Format("Endereço: {0},{1} {2}", end.Localidade, end.Uf, end.Logradouro);
                    } else {
                        DisplayAlert("Erro", "Voce digitou um CEP invalido", "OK");
                    }
                    
                }
                catch(Exception e) {
                    DisplayAlert("Erro Crítico", e.Message, "OK");
                }
            }
        }

        private bool isValidCep(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP deve conter 8 caracteres", "OK", "Cancelar");
                valido = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP contem letras ou caracteres especiais", "OK", "Cancelar");
                valido = false;
            }

            return true;
        }

    }
}
