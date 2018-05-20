﻿using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;
using System;
using System.Linq;

namespace RCM.Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }

        public override Cliente GetById(Guid id)
        {
            return _dbSet
                .AsNoTracking()
                .Include(ch => ch.Cheques)
                .Include(d => d.Endereco.Cidade)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
