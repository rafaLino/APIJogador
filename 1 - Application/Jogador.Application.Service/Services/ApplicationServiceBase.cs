using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jogador.Application.Service.Interfaces;
using Jogador.Domain.Core.Models;
using Jogador.Domain.Interfaces.Service;

namespace Jogador.Application.Service.Services
{
    public abstract class ApplicationServiceBase<TEntity, TInput, TOutput> : IApplicationServiceBase<TInput, TOutput> where TEntity : Entity where TInput : class where TOutput : class
    {
        private readonly IDomainServiceBase<TEntity> _domainServiceBase;
        private readonly IMapper _mapper;

        public ApplicationServiceBase(IDomainServiceBase<TEntity> domainServiceBase, IMapper mapper)
        {
            _domainServiceBase = domainServiceBase;
            _mapper = mapper;
        }
        public async Task<TOutput> AddAsync(TInput input)
        {
            var entity = _mapper.Map<TEntity>(input);
            var result = await _domainServiceBase.AddAsync(entity);

            return _mapper.Map<TOutput>(result);

        }

        public async Task DeleteAsync(string id)
        {
            await _domainServiceBase.DeleteAsync(id);
        }

        public async Task<IEnumerable<TOutput>> GetAsync()
        {
            var result = await _domainServiceBase.GetAsync();

            return _mapper.Map<IEnumerable<TOutput>>(result);
        }

        public async Task<TOutput> GetAsync(string id)
        {
            var result = await _domainServiceBase.GetAsync(id);

            return _mapper.Map<TOutput>(result);
        }

        public async Task UpdateAsync(string id, TInput input)
        {
            var entity = _mapper.Map<TEntity>(input);
            await _domainServiceBase.UpdateAsync(id, entity);
        }
    }
}
