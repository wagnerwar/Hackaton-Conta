using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AzureWeb.Models
{
    public enum EnumServicoReclamacao
    {
        [Description("Controladoria Geral do Município")]
        [Display(Name = "Controladoria Geral do Município")]
        CGM,

        [Description("Secretaria do Governo Municipal")]
        [Display(Name = "Secretaria do Governo Municipal")]
        SGM,

        [Description("Secretaria Especial de Comunicação")]
        [Display(Name = "Secretaria Especial de Comunicação")]
        SECOM,

        [Description("Secretaria Municipal de Infraestrutura Urbana e Obras")]
        [Display(Name = "Secretaria Municipal de Infraestrutura Urbana e Obras")]
        SIURB,

        [Description("Secretaria Especial de Relações Sociais")]
        [Display(Name = "Secretaria Especial de Relações Sociais")]
        SMRS,

        [Description("Secretaria Municipal da Pessoa com Deficiência")]
        [Display(Name = "Secretaria Municipal da Pessoa com Deficiência")]
        SMPED,

        [Description("Secretaria Municipal da Saúde")]
        [Display(Name = "Secretaria Municipal da Saúde")]
        SMS,

        [Description("Secretaria Municipal de Assistência e Desenvolvimento Social")]
        [Display(Name = "Secretaria Municipal de Assistência e Desenvolvimento Social")]
        SMADS,

        [Description("Secretaria Municipal das Subprefeituras")]
        [Display(Name = "Secretaria Municipal das Subprefeituras")]
        SMSUB,

        [Description("Secretaria Municipal de Cultura")]
        [Display(Name = "Secretaria Municipal de Cultura")]
        SMC,

        [Description("Secretaria Municipal de Desenvolvimento Urbano")]
        [Display(Name = "Secretaria Municipal de Desenvolvimento Urbano")]
        SMDU,

        [Description("Secretaria Municipal de Direitos Humanos e Cidadania")]
        [Display(Name = "Secretaria Municipal de Direitos Humanos e Cidadania")]
        SMDHC,

        [Description("Secretaria Municipal de Educação")]
        [Display(Name = "Secretaria Municipal de Educação")]
        SME,

        [Description("Secretaria Municipal de Esportes e Lazer")]
        [Display(Name = "Secretaria Municipal de Esportes e Lazer")]
        SEME,

        [Description("Secretaria Municipal da Fazenda")]
        [Display(Name = "Secretaria Municipal da Fazenda")]
        SF,

        [Description("Secretaria Municipal de Gestão")]
        [Display(Name = "Secretaria Municipal de Gestão")]
        SG,

        [Description("Secretaria Municipal de Habitação")]
        [Display(Name = "Secretaria Municipal de Habitação")]
        SEHAB,

        [Description("Secretaria Municipal de Licenciamento")]
        [Display(Name = "Secretaria Municipal de Licenciamento")]
        SEL,

        [Description("Secretaria Municipal de Relações Internacionais")]
        [Display(Name = "Secretaria Municipal de Relações Internacionais")]
        SMRIF,

        [Description("Secretaria Municipal de Segurança Urbana")]
        [Display(Name = "Secretaria Municipal de Segurança Urbana")]
        SMSU,

        [Description("Secretaria Municipal de Inovação e Tecnologia")]
        [Display(Name = "Secretaria Municipal de Inovação e Tecnologia")]
        SMIT,

        [Description("Secretaria Municipal de Desenvolvimento Econômico e Trabalho")]
        [Display(Name = "Secretaria Municipal de Desenvolvimento Econômico e Trabalho")]
        SMDET,

        [Description("Secretaria Municipal do Verde e do Meio Ambiente")]
        [Display(Name = "Secretaria Municipal do Verde e do Meio Ambiente")]
        SVMA,

        [Description("Secretaria Municipal de Justiça")]
        [Display(Name = "Secretaria Municipal de Justiça")]
        SMJ,

        [Description("Secretaria Municipal de Mobilidade e Transportes")]
        [Display(Name = "Secretaria Municipal de Mobilidade e Transportes")]
        SMT,

        [Description("Procuradoria Geral do Município")]
        [Display(Name = "Procuradoria Geral do Município")]
        PGM,

        [Description("Secretaria Municipal da Casa Civil")]
        [Display(Name = "Secretaria Municipal da Casa Civil")]
        SMCC
    }
}
