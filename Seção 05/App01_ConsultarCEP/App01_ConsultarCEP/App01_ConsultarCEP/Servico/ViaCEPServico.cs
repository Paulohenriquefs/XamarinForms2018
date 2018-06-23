using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;
namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoUrl = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscaCep(string cep)
        {
            string novoEndereco = string.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();

            string Conteudo = wc.DownloadString(novoEndereco);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end == null) return null;

            return end;
        }
    }
}
