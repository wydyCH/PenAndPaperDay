using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public class BaseRepository<T, U> : IBaseRepository<T, U>
        where T : Entity
        where U : Mapping
    {
        protected readonly PenAndPaperDBContext _dbContext;
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;

        public BaseRepository(PenAndPaperDBContext dbContext, ILogger logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public U GetById(object id)
        {
            T result = _dbContext.Find<T>(id);
            return _mapper.Map<T, U>(result);
        }

        public IList<U> GetAll()
        {
            IList<T> result = _dbContext.Set<T>().ToList();
            return _mapper.Map<IList<T>, IList<U>>(result);
        }

        public U Insert(U entityDTO)
        {
            T entity = _mapper.Map<U, T>(entityDTO);

            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            entityDTO = _mapper.Map<T, U>(entity);

            return entityDTO;
        }

        public IList<U> Insert(IList<U> entityDTO)
        {
            IList<U> result = new List<U>();
            if (entityDTO.Any())
            {
                foreach (var entity in entityDTO)
                {
                    result.Add(Insert(entity));
                }
            }

            return result;
        }

        public U Update(U entityDTO)
        {
            T entity = _dbContext.Find<T>(entityDTO.Id);
            entity = _mapper.Map<U, T>(entityDTO, entity);

            _dbContext.SaveChanges();

            entityDTO = _mapper.Map<T, U>(entity);
            return entityDTO;
        }

        public bool Delete(U entityDTO)
        {
            T entity = _dbContext.Find<T>(entityDTO.Id);
            entity = _mapper.Map<U, T>(entityDTO, entity);

            _dbContext.Set<T>().Remove(entity);

            _dbContext.SaveChanges();

            return true;
        }

        public bool Delete(IList<U> entityDTO)
        {
            bool result = true;

            foreach (var entity in entityDTO)
            {
                result &= Delete(entity);
            }

            return result;
        }
    }
}
