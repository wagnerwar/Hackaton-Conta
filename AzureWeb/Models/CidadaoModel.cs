using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AzureWeb.Models
{
    public class CidadaoModel
    {

        public CidadaoModel() {

            radioTipDeDados = new[] { "Texto", "Audio" };
        }
    

        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [Required(ErrorMessage = "Digite o CEP")]
        [JsonProperty(PropertyName = "cep")]
        public string cep { get; set; }
        
        [JsonProperty(PropertyName = "nome")]
        public string nome { get; set; }

        [DataType(DataType.MultilineText)]
        [JsonProperty(PropertyName = "texto")]
        public string texto { get; set; }

        [JsonProperty(PropertyName = "regiao")]
        public string regiao { get; set; }

        [JsonProperty(PropertyName = "servico")]
        public string servico { get; set; }

        [JsonProperty(PropertyName = "sentimento")]
        public string sentimento { get; set; }

        [JsonProperty(PropertyName = "tipoEntrada")]
        public string tipoEntrada { get; set; }

        public EnumRegiao regioes { get; set; }
        public EnumServicoReclamacao servicos { get; set; }
        public IFormFile arquivo { set; get; }

        public string[] radioTipDeDados { set; get; }


}

    public static class RegiaoMetodos
    {
        public static string PegarDescricaoEnum(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static List<RegiaoModel> ObterListaCodigoDescricao()
        {
            List<RegiaoModel> listaRetorno = null;
            var listaEnumRegiao = Enum.GetValues(typeof(EnumRegiao));
            if (listaEnumRegiao != null && listaEnumRegiao.Length > 0)
            {
                listaRetorno = new List<RegiaoModel>();
                foreach (var itemEnum in listaEnumRegiao)
                {
                    RegiaoModel entidadeRegiao = new RegiaoModel();
                    entidadeRegiao.Codigo = (int)(EnumRegiao)itemEnum;
                    entidadeRegiao.Descricao = RegiaoMetodos.PegarDescricaoEnum((EnumRegiao)itemEnum);
                    listaRetorno.Add(entidadeRegiao);
                }
            }

            return listaRetorno;
        }

    }
}
