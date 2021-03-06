﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using RCM.Domain.Models.OrdemServicoModels;
using RCM.Infra.Data.Context;
using System;

namespace RCM.Infra.Data.Migrations
{
    [DbContext(typeof(RCMDbContext))]
    [Migration("20180413004136_ChequeStateLengthUpdate")]
    partial class ChequeStateLengthUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RCM.Domain.Models.BancoModels.Banco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoCompensacao")
                        .HasMaxLength(4);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("RCM.Domain.Models.ChequeModels.Cheque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Agencia")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<Guid>("BancoId");

                    b.Property<Guid>("ClienteId");

                    b.Property<string>("Conta")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<DateTime>("DataEmissao");

                    b.Property<DateTime?>("DataPagamento");

                    b.Property<DateTime>("DataVencimento");

                    b.Property<string>("NumeroCheque")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<string>("Observacao")
                        .HasMaxLength(1000);

                    b.Property<decimal>("Valor")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cheques");
                });

            modelBuilder.Entity("RCM.Domain.Models.ChequeModels.ChequeStates.EstadoCheque", b =>
                {
                    b.Property<Guid>("ChequeId");

                    b.Property<DateTime>("DataEvento");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<Guid>("Id");

                    b.HasKey("ChequeId");

                    b.ToTable("EstadosCheques");

                    b.HasDiscriminator<string>("Discriminator").HasValue("EstadoCheque");
                });

            modelBuilder.Entity("RCM.Domain.Models.CidadeModels.Cidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EstadoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("RCM.Domain.Models.ClienteModels.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .HasMaxLength(1000);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RCM.Domain.Models.Contato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClienteId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Observacao")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("RCM.Domain.Models.DuplicataModels.Duplicata", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataEmissao");

                    b.Property<DateTime>("DataVencimento");

                    b.Property<Guid>("FornecedorId");

                    b.Property<Guid?>("NotaFiscalId");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Observacao")
                        .HasMaxLength(1000);

                    b.Property<decimal>("Valor")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("NotaFiscalId");

                    b.ToTable("Duplicatas");
                });

            modelBuilder.Entity("RCM.Domain.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<Guid>("CidadeId");

                    b.Property<Guid>("ClienteId");

                    b.Property<string>("Complemento")
                        .HasMaxLength(100);

                    b.Property<int>("Numero")
                        .HasMaxLength(4);

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("RCM.Domain.Models.EstadoModels.Estado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("RCM.Domain.Models.FornecedorModels.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Observacao")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("RCM.Domain.Models.NotaFiscalModels.NotaFiscal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataChegada")
                        .IsRequired();

                    b.Property<DateTime>("DataEmissao");

                    b.Property<Guid?>("FornecedorId");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.Property<decimal>("Valor")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("NotasFiscais");
                });

            modelBuilder.Entity("RCM.Domain.Models.OrdemServicoModels.OrdemServico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClienteId");

                    b.Property<DateTime>("DataEntrada");

                    b.Property<DateTime?>("DataSaida");

                    b.Property<int>("Status");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("OrdensServico");
                });

            modelBuilder.Entity("RCM.Domain.Models.ProdutoModels.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Aplicacao")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid?>("NotaFiscalId");

                    b.Property<Guid?>("OrdemServicoId");

                    b.Property<decimal>("PrecoVenda")
                        .HasMaxLength(4);

                    b.Property<int>("Quantidade")
                        .HasMaxLength(4);

                    b.Property<Guid?>("VendaId");

                    b.HasKey("Id");

                    b.HasIndex("NotaFiscalId");

                    b.HasIndex("OrdemServicoId");

                    b.HasIndex("VendaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("RCM.Domain.Models.VendaModels.Venda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClienteId");

                    b.Property<DateTime>("DataVenda");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("RCM.Domain.Models.ChequeModels.ChequeStates.ChequeBloqueado", b =>
                {
                    b.HasBaseType("RCM.Domain.Models.ChequeModels.ChequeStates.EstadoCheque");


                    b.ToTable("ChequeBloqueado");

                    b.HasDiscriminator().HasValue("ChequeBloqueado");
                });

            modelBuilder.Entity("RCM.Domain.Models.ChequeModels.ChequeStates.ChequeCompensado", b =>
                {
                    b.HasBaseType("RCM.Domain.Models.ChequeModels.ChequeStates.EstadoCheque");


                    b.ToTable("ChequeCompensado");

                    b.HasDiscriminator().HasValue("ChequeCompensado");
                });

            modelBuilder.Entity("RCM.Domain.Models.ChequeModels.ChequeStates.ChequeDevolvido", b =>
                {
                    b.HasBaseType("RCM.Domain.Models.ChequeModels.ChequeStates.EstadoCheque");

                    b.Property<string>("Motivo")
                        .HasColumnName("Motivo")
                        .HasMaxLength(100);

                    b.ToTable("ChequeDevolvido");

                    b.HasDiscriminator().HasValue("ChequeDevolvido");
                });

            modelBuilder.Entity("RCM.Domain.Models.ChequeModels.ChequeStates.ChequeRepassado", b =>
                {
                    b.HasBaseType("RCM.Domain.Models.ChequeModels.ChequeStates.EstadoCheque");

                    b.Property<Guid>("ClienteId");

                    b.HasIndex("ClienteId");

                    b.ToTable("ChequeRepassado");

                    b.HasDiscriminator().HasValue("ChequeRepassado");
                });

            modelBuilder.Entity("RCM.Domain.Models.ChequeModels.ChequeStates.ChequeSustado", b =>
                {
                    b.HasBaseType("RCM.Domain.Models.ChequeModels.ChequeStates.EstadoCheque");

                    b.Property<string>("Motivo")
                        .HasColumnName("Motivo")
                        .HasMaxLength(100);

                    b.ToTable("ChequeSustado");

                    b.HasDiscriminator().HasValue("ChequeSustado");
                });

            modelBuilder.Entity("RCM.Domain.Models.ChequeModels.Cheque", b =>
                {
                    b.HasOne("RCM.Domain.Models.BancoModels.Banco", "Banco")
                        .WithMany("Cheques")
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RCM.Domain.Models.ClienteModels.Cliente", "Cliente")
                        .WithMany("Cheques")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RCM.Domain.Models.ChequeModels.ChequeStates.EstadoCheque", b =>
                {
                    b.HasOne("RCM.Domain.Models.ChequeModels.Cheque", "Cheque")
                        .WithOne("EstadoCheque")
                        .HasForeignKey("RCM.Domain.Models.ChequeModels.ChequeStates.EstadoCheque", "ChequeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RCM.Domain.Models.CidadeModels.Cidade", b =>
                {
                    b.HasOne("RCM.Domain.Models.EstadoModels.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RCM.Domain.Models.Contato", b =>
                {
                    b.HasOne("RCM.Domain.Models.ClienteModels.Cliente", "Cliente")
                        .WithMany("Contatos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RCM.Domain.Models.DuplicataModels.Duplicata", b =>
                {
                    b.HasOne("RCM.Domain.Models.FornecedorModels.Fornecedor", "Fornecedor")
                        .WithMany("Duplicatas")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RCM.Domain.Models.NotaFiscalModels.NotaFiscal", "NotaFiscal")
                        .WithMany("Duplicatas")
                        .HasForeignKey("NotaFiscalId");

                    b.OwnsOne("RCM.Domain.Models.Pagamento", "Pagamento", b1 =>
                        {
                            b1.Property<Guid>("DuplicataId");

                            b1.Property<DateTime>("DataPagamento")
                                .HasColumnName("DataPagamento");

                            b1.Property<decimal>("ValorPago")
                                .HasColumnName("ValorPago");

                            b1.ToTable("Duplicatas");

                            b1.HasOne("RCM.Domain.Models.DuplicataModels.Duplicata")
                                .WithOne("Pagamento")
                                .HasForeignKey("RCM.Domain.Models.Pagamento", "DuplicataId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("RCM.Domain.Models.Endereco", b =>
                {
                    b.HasOne("RCM.Domain.Models.CidadeModels.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RCM.Domain.Models.ClienteModels.Cliente", "Cliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RCM.Domain.Models.NotaFiscalModels.NotaFiscal", b =>
                {
                    b.HasOne("RCM.Domain.Models.FornecedorModels.Fornecedor")
                        .WithMany("NotasFiscais")
                        .HasForeignKey("FornecedorId");
                });

            modelBuilder.Entity("RCM.Domain.Models.OrdemServicoModels.OrdemServico", b =>
                {
                    b.HasOne("RCM.Domain.Models.ClienteModels.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RCM.Domain.Models.ProdutoModels.Produto", b =>
                {
                    b.HasOne("RCM.Domain.Models.NotaFiscalModels.NotaFiscal")
                        .WithMany("Produtos")
                        .HasForeignKey("NotaFiscalId");

                    b.HasOne("RCM.Domain.Models.OrdemServicoModels.OrdemServico")
                        .WithMany("Produtos")
                        .HasForeignKey("OrdemServicoId");

                    b.HasOne("RCM.Domain.Models.VendaModels.Venda")
                        .WithMany("Produtos")
                        .HasForeignKey("VendaId");
                });

            modelBuilder.Entity("RCM.Domain.Models.VendaModels.Venda", b =>
                {
                    b.HasOne("RCM.Domain.Models.ClienteModels.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RCM.Domain.Models.ChequeModels.ChequeStates.ChequeRepassado", b =>
                {
                    b.HasOne("RCM.Domain.Models.ClienteModels.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
