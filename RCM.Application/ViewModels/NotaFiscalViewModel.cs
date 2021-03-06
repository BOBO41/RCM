﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class NotaFiscalViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Número do documento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo número do documento é requerido.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "O campo número do documento deve ter 6 caracteres.")]
        public string NumeroDocumento { get; set; }

        [Display(Name = "Duplicatas")]
        public List<DuplicataViewModel> Duplicatas { get; set; }

        [Display(Name = "Data de Emissão")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data de emissão é requerido.")]
        public DateTime DataEmissao { get; set; }

        [Display(Name = "Data de Chegada")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data de chegada é requerido.")]
        public DateTime DataChegada { get; set; }

        [Display(Name = "Valor")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo valor é requerido.")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        public decimal Valor { get; set; }
    }
}