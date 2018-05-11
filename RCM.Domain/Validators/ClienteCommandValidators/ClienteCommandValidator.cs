﻿using FluentValidation;
using FluentValidation.Validators;
using RCM.Domain.Commands.ClienteCommands;
using RCM.Domain.Models;
using RCM.Domain.Models.ClienteModels;

namespace RCM.Domain.Validators.ClienteCommandValidators
{
    public abstract class ClienteCommandValidator<T> : AbstractValidator<T> where T : ClienteCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O Id do cliente não deve estar vazio.");
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(100)
                .WithMessage("O nome do cliente deve ter entre 10 e 100 caracteres e não deve estar vazio.");
        }

        protected void ValidatePontuacao()
        {
            RuleFor(c => c.Pontuacao)
                .NotEmpty()
                .WithMessage("A classificação do cliente não deve estar vazia.");
        }

        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                .MaximumLength(1000)
                .WithMessage("A descrição do cliente deve ter até 1000 caracteres.");
        }

        #region Contato
        protected void ValidateContato()
        {
            ValidateContatoNotEmpty();
            ValidateContatoEmail();
            ValidateContatoCelular();
            ValidateContatoTelefoneComercial();
            ValidateContatoTelefoneResidencial();
            ValidateContatoObservacao();
        }

        private void ValidateContatoNotEmpty()
        {
            RuleFor(c => this)
                .Must((c, m) => ValidateContatoProperties(c))
                .WithMessage("Você deve preencher pelo menos um dos meios de contato.");
        }

        private void ValidateContatoEmail()
        {
            RuleFor(c => c.ContatoEmail)
                .EmailAddress()
                .MaximumLength(100)
                .WithMessage("O e-mail do cliente deve ter entre 10 e 100 caracteres e não deve estar vazio.");
        }

        private void ValidateContatoTelefoneResidencial()
        {
            RuleFor(c => c.ContatoTelefoneResidencial)
                .MaximumLength(15)
                .WithMessage("O telefone residencial do cliente deve ter entre 8 e 15 caracteres e não deve estar vazio.");
        }

        private void ValidateContatoTelefoneComercial()
        {
            RuleFor(c => c.ContatoTelefoneComercial)
                .MaximumLength(15)
                .WithMessage("O telefone comercial do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");
        }

        private void ValidateContatoCelular()
        {
            RuleFor(c => c.ContatoCelular)
                .MaximumLength(15)
                .WithMessage("O celular do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");
        }

        private void ValidateContatoObservacao()
        {
            RuleFor(c => c.ContatoObservacao)
                .MaximumLength(250)
                .WithMessage("A observação deve ter até 250 caracteres e não deve estar vazia.");
        }

        private bool ValidateContatoProperties(T command)
        {
            if (!string.IsNullOrWhiteSpace(command.ContatoCelular))
                return true;
            if (!string.IsNullOrWhiteSpace(command.ContatoTelefoneComercial))
                return true;
            if (!string.IsNullOrWhiteSpace(command.ContatoTelefoneResidencial))
                return true;
            if (!string.IsNullOrWhiteSpace(command.ContatoEmail))
                return true;

            return false;
        }
        #endregion

        #region Endereco
        protected void ValidateEndereco()
        {
            ValidateEnderecoNumero();
            ValidateEnderecoRua();
            ValidateEnderecoBairro();
            ValidateEnderecoComplemento();
            ValidateEnderecoCEP();
        }

        private void ValidateEnderecoNumero()
        {
            RuleFor(c => c.EnderecoNumero)
                .ExclusiveBetween(0, 9999)
                .WithMessage("O número do endereço deve estar em um formato válido.");
        }

        private void ValidateEnderecoRua()
        {
            RuleFor(c => c.EnderecoRua)
                .MinimumLength(3)
                .MaximumLength(100)
                .WithMessage("O nome da rua deve ter entre 3 caracteres e 100 e não pode estar vazio.");
        }

        private void ValidateEnderecoBairro()
        {
            RuleFor(c => c.EnderecoBairro)
                .MinimumLength(3)
                .MaximumLength(25)
                .WithMessage("O nome do bairro deve ter entre 3 e 25 caracteres e não pode estar vazio.");
        }

        private void ValidateEnderecoComplemento()
        {
            RuleFor(c => c.EnderecoComplemento)
                .MaximumLength(250)
                .WithMessage("O complemento do endereço deve ter até 250 caracteres e não pode estar vazio");
        }

        private void ValidateEnderecoCEP()
        {
            RuleFor(c => c.EnderecoCEP)
                .MaximumLength(8)
                .WithMessage("O CEP do endereço deve ter 8 caracteres.");
        }
        #endregion

        #region Documento
        protected void ValidateDocumento()
        {
            RuleFor(c => c.DocumentoCadastroNacional)
                .NotEmpty()
                .Must((command, property) => ValidateDocumentoCadastroNacional(command))
                .WithMessage("O CPF/CNPJ deve estar em um formato válido.");

            RuleFor(c => c.DocumentoCadastroEstadual)
                .NotEmpty()
                .Must((command, property) => ValidateDocumentoCadastroEstadual(command))
                .WithMessage("O RG/Inscrição Estadual deve estar em um formato válido.");
        }

        private bool ValidateDocumentoCadastroNacional(ClienteCommand command)
        {
            if (command.DocumentoCadastroNacional == null)
                return false;

            if (command.Tipo == ClienteTipoEnum.PessoaFisica)
                return command.DocumentoCadastroNacional.Length == 11;
            else
                return command.DocumentoCadastroNacional.Length == 14;
        }

        private bool ValidateDocumentoCadastroEstadual(ClienteCommand command)
        {
            if (command.DocumentoCadastroEstadual == null)
                return false;

            var length = command.DocumentoCadastroEstadual.Length;
            
            if (command.Tipo == ClienteTipoEnum.PessoaFisica)
                return length <= 12;
            else
                return length > 12 && length <= 14;
        }
        #endregion
    }
}
