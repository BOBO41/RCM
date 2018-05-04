﻿using RCM.Domain.Core.Models;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.ProdutoModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Domain.Models.VendaModels
{
    public class Venda : Entity<Venda>
    {
        public DateTime DataVenda { get; private set; }
        public Guid ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public string Detalhes { get; private set; }

        private List<VendaProduto> _produtos;
        public virtual IReadOnlyList<VendaProduto> Produtos
        {
            get
            {
                return _produtos;
            }
        }

        public int TotalProdutos
        {
            get
            {
                return _produtos.Count();
            }
        }

        public decimal TotalVenda
        {
            get
            {
                return _produtos.Sum(pv => pv.PrecoFinal);
            }
        }

        public VendaStatusEnum Status { get; private set; }

        public Venda(DateTime dataVenda, string detalhes, Cliente cliente)
        {
            DataVenda = dataVenda;
            Detalhes = detalhes;
            Cliente = cliente;

            Status = VendaStatusEnum.Aberta;
            _produtos = new List<VendaProduto>();
        }

        public Venda(Guid id, DateTime dataVenda, string detalhes, Cliente cliente)
        {
            Id = id;
            DataVenda = dataVenda;
            Detalhes = detalhes;
            Cliente = cliente;

            Status = VendaStatusEnum.Aberta;
            _produtos = new List<VendaProduto>();
        }

        public void AdicionarProduto(Produto produto, decimal desconto, decimal acrescimo)
        {
            if (produto.Estoque <= 0) {
                AddDomainError("Não é possível adicionar um produto com estoque zerado.");
                return;
            }

            VendaProduto vendaProduto = new VendaProduto(this, produto, desconto, acrescimo);

            if (!_produtos.Contains(vendaProduto))
            {
                _produtos.Add(vendaProduto);
            }
            else
                AddDomainError("O produto já foi adicionado à venda.");
        }

        public void RemoverProduto(Produto produto)
        {
            VendaProduto vendaProduto = new VendaProduto(this, produto);

            if (_produtos.Contains(vendaProduto))
            {
                _produtos.Remove(vendaProduto);
            }
            else
                AddDomainError("O produto ainda foi adicionado à venda.");
        }

        public Venda Finalizar()
        {
            if (!_produtos.Any())
            {
                AddDomainError("Não é possível finalizar a venda sem nenhum item.");
                return null;
            }
            
            DeduzirProdutoEstoque(_produtos);
            Status = VendaStatusEnum.Fechada;

            return this;
        }

        public void DeduzirProdutoEstoque(IEnumerable<VendaProduto> produtos)
        {
            foreach (Produto produto in produtos.Select(pv => pv.Produto))
            {
                if (produto == null)
                {
                    AddDomainError("Erro ao deduzir do estoque");
                    return;
                }

                produto.DeduzirEstoque();
            }
        }
    }
}
