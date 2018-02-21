﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;

namespace RCM.Presentation.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Cheques")]
    public class ChequesController : Controller
    {
        private readonly IChequeApplicationService _chequeApplicationService;

        public ChequesController(IChequeApplicationService chequeApplicationService)
        {
            _chequeApplicationService = chequeApplicationService;
        }

        [HttpGet]
        public IEnumerable<ChequeViewModel> Get()
        {
            return _chequeApplicationService.Get();
        }

        [HttpGet("{id}")]
        public ChequeViewModel Get(int id)
        {
            ChequeViewModel model = new ChequeViewModel()
            {
                Agencia = "422",
                Conta = "256-9", 
                DataEmissao = DateTime.Now,
                DataVencimento = DateTime.Now,
                NumeroCheque = "4515153",
                Valor = 122.51m,
            };
            _chequeApplicationService.Add(model);

            return _chequeApplicationService.GetById(id);
        }
        
        [HttpPost]
        public void Post(ChequeViewModel model)
        {
            _chequeApplicationService.Add(model);
        }
        
        [HttpPut("{id}")]
        public void Put(int id, ChequeViewModel model)
        {
            _chequeApplicationService.Update(model);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _chequeApplicationService.Remove(new ChequeViewModel { Id = id });
        }
    }
}
