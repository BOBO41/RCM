﻿using RCM.Domain.Core.Models;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.ProdutoModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Domain.Models.OrdemServicoModels
{
    public class OrdemServico : Entity<OrdemServico>
    {
        public OrdemServicoStatus Status { get; private set; }
        public Guid ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }

        private List<Produto> _produtos;
        public virtual IReadOnlyList<Produto> Produtos
        {
            get
            {
                return _produtos;
            }
        }

       // public virtual Carro Carro { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime? DataSaida { get; private set; }
        public decimal Total { get; private set; }

        protected OrdemServico() { }

        public OrdemServico(Cliente cliente, List<Produto> produtos, DateTime? dataEntrada = null)
        {
            Cliente = cliente;
            _produtos = produtos;
            DataEntrada = dataEntrada ?? DateTime.Now;
            Status = OrdemServicoStatus.Aberta;
        }

        public void AdicionarProduto(Produto produto)
        {
            _produtos.Add(produto);
        }
        
        public decimal CalcularTotal()
        {
            return Produtos.Sum(p => p.PrecoVenda);
        }

        public OrdemServico FecharOrdem(DateTime dataSaida)
        {
            DataSaida = dataSaida;
            Status = OrdemServicoStatus.Fechada;
            return this;
        }
    }
}
