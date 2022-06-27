using MyRoadMap.Domain.Model.Entities.Base;
using MyRoadMap.Domain.Model.Entities.Interfaces;
using MyRoadMap.Domain.Model.Validation;
using MyRoadMap.Domain.Repositories;
using MyRoadMap.Domain.Services.Interfaces;
using MyRoadMap.Domain.Validators.Base;
using MyRoadMap.Domain.ValueObjects;

namespace MyRoadMap.Domain.Services.Base
{
    public class CrudService<T> : QueryService<T>, ICrudService<T> where T : Entity, IAggregateRoot
    {
        protected readonly Validator<T> Validator;
        protected new readonly IRepository<T> Repository;

        public CrudService(IRepository<T> repository, Validator<T> validator) : base(repository)
        {
            Repository = repository;
            Validator = validator;
        }

        public virtual async Task Delete(T entity)
        {
            await Validator.Validate(entity, ValidationType.Delete);

            if (!Validator.IsValid)
                throw new ValidationException(Validator.ValidationResults);

            await Repository.Delete(entity);
        }

        public virtual async Task Insert(T entity)
        {
            await Validator.Validate(entity, ValidationType.Insert);

            if (!Validator.IsValid)
                throw new ValidationException(Validator.ValidationResults);

            await Repository.Insert(entity);
        }

        public virtual async Task Update(T entity)
        {
            await Validator.Validate(entity, ValidationType.Update);

            if (!Validator.IsValid)
                throw new ValidationException(Validator.ValidationResults);

            await Repository.Update(entity);
        }
    }
}
