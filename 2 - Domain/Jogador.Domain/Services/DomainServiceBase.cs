using Jogador.Domain.Core.Models;
using Jogador.Domain.Interfaces.Data;
using Jogador.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jogador.Domain.Services
{
    public abstract class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity> where TEntity : Entity
    {
        private readonly IRepositoryBase<TEntity> _repository;

        protected DomainServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var id = await _repository.AddAsync(entity);
            return await _repository.GetAsync(id);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<TEntity> GetAsync(string id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task UpdateAsync(string id, TEntity entity)
        {
            var result = _repository.GetAsync(id);

            if (result == null)
                throw new Exception("Not Found");

            entity.UpdateId(id);
            await _repository.UpdateAsync(entity);

        }
    }
}
