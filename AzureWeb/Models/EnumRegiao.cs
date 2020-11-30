using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AzureWeb.Models
{
    public enum EnumRegiao
    {
        //Aricanduva / Vila Formosa        
        [Display(Name ="Aricanduva / Vila Formosa")]
        Aricanduva_Vila_Formosa,

        //Butantã
        [Description("Butantã")]
        [Display(Name = "Butantã")]
        Butata,

        //Campo Limpo
        [Description("Campo Limpo")]
        [Display(Name = "Campo Limpo")]
        Campo_Limpo,

        //Capela do Socorro
        [Description("Capela do Socorro")]
        [Display(Name = "Capela do Socorro")]
        Capela_Socorro,

        //Casa Verde
        [Description("Casa Verde")]
        [Display(Name = "Casa Verde")]
        Casa_Verde,

        //Cidade Ademar
        [Description("Cidade Ademar")]
        [Display(Name = "Cidade Ademar")]
        Cidade_Ademar,

        //Cidade Tiradentes
        [Description("Cidade Tiradentes")]
        [Display(Name = "Cidade Tiradentes")]
        Cidade_Tiradentes,

        //Ermelino Matarazzo
        [Description("Ermelino Matarazzo")]
        [Display(Name = "Ermelino Matarazzo")]
        Ermelino_Matarazzo,

        //Freguesia do Ó / Brasilândia
        [Description("Freguesia do Ó / Brasilândia")]
        [Display(Name = "Freguesia do Ó / Brasilândia")]
        Freguesia_do_O_Brasilandia,

        //Guaianases
        [Description("Guaianases")]
        [Display(Name = "Guaianases")]
        Guaianases,

        //Ipiranga
        [Description("Ipiranga")]
        [Display(Name = "Ipiranga")]
        Ipiranga,

        //Itaim Paulista
        [Description("Itaim Paulista")]
        [Display(Name = "Itaim Paulista")]
        Itaim_Paulista,

        //Itaquera
        [Description("Itaquera")]
        [Display(Name = "Itaquera")]
        Itaquera,

        //Jabaquara
        [Description("Jabaquara")]
        [Display(Name = "Jabaquara")]
        Jabaquara,

        //Jaçanã / Tremembé
        [Description("Jaçanã / Tremembé")]
        [Display(Name = "Jaçanã / Tremembé")]
        Jacana_Tremebe,

        //Lapa
        [Description("Lapa")]
        [Display(Name = "Lapa")]
        Lapa,

        //M’Boi Mirim
        [Description("M’Boi Mirim")]
        [Display(Name = "M’Boi Mirim")]
        M_Boi_Mirim,

        //Mooca
        [Description("Mooca")]
        [Display(Name = "Mooca")]
        Mooca,

        //MSP
        [Description("MSP")]
        [Display(Name = "MSP")]
        MSP,

        //Parelheiros
        [Description("Parelheiros")]
        [Display(Name = "Parelheiros")]
        Parelheiros,

        //Penha
        [Description("Penha")]
        [Display(Name = "Penha")]
        Penha,

        //Perus
        [Description("Perus")]
        [Display(Name = "Perus")]
        Perus,

        //Pinheiros
        [Description("Pinheiros")]
        [Display(Name = "Pinheiros")]
        Pinheiros,

        //Pirituba / Jaraguá
        [Description("Pirituba / Jaraguá")]
        [Display(Name = "Pirituba / Jaraguá")]
        Pirituba_Jaragua,

        //Santana / Tucuruvi
        [Description("Santana / Tucuruvi")]
        [Display(Name = "Santana / Tucuruvi")]
        Santana_Tucuruvi,

        //Santo Amaro
        [Description("Santo Amaro")]
        [Display(Name = "Santo Amaro")]
        Santo_Amaro,

        //São Mateus
        [Description("São Mateus")]
        [Display(Name = "São Mateus")]
        Sao_Mateus,

        //São Miguel Paulista
        [Description("São Miguel Paulista")]
        [Display(Name = "São Miguel Paulista")]
        Sao_Miguel_Paulista,

        //Sé
        [Description("Sé")]
        [Display(Name = "Sé")]
        Se,

        //Vila Maria / Vila Guilherme
        [Description("Vila Maria / Vila Guilherme")]
        [Display(Name = "Vila Maria / Vila Guilherme")]
        Vila_Maria_Vila_Guilherme,

        //Vila Mariana
        [Description("Vila Mariana")]
        [Display(Name = "Vila Mariana")]
        Vila_Mariana,

        //Vila Prudente
        [Description("Vila Prudente")]
        [Display(Name = "Vila Prudente")]
        Vila_Prudente

    }
}
