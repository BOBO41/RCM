﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Presentation.Web.Controllers;
using System;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Area("Platform")]
    [Authorize]
    public class OrdensServicoController : BaseController
    {
        private readonly IOrdemServicoApplicationService _ordemServicoApplicationService;
        private readonly IClienteApplicationService _clienteApplicationService;
        private readonly IProdutoApplicationService _produtoApplicationService;

        public OrdensServicoController(IOrdemServicoApplicationService ordemServicoApplicationService, IClienteApplicationService clienteApplicationService, IProdutoApplicationService produtoApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _ordemServicoApplicationService = ordemServicoApplicationService;
            _clienteApplicationService = clienteApplicationService;
            _produtoApplicationService = produtoApplicationService;
        }

        public IActionResult Index(string name, string description)
        {
            return View();
        }

        public IActionResult Details(Guid id)
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrdemServicoViewModel ordemServico)
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Edit(Guid id)
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, OrdemServicoViewModel ordemServico)
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        public IActionResult Delete(Guid id)
        {
            return View();
        }

        [Authorize(Policy = "ActiveUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, OrdemServicoViewModel ordemServico)
        {
            return View();
        }
    }
}