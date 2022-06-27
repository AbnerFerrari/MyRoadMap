using MyRoadMap.Domain.Model.Entities.Base;
using MyRoadMap.Domain.Model.Validation;
using MyRoadMap.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace MyRoadMap.Domain.Validators.Base
{
    public class Validator<T> where T : Entity
    {
        public List<ValidationResult> ValidationResults { get; set; } = new();

        public bool IsValid => ValidationResults.Count == 0;

        public Task Validate(T entity, ValidationType validationType)
        {
            ValidationResults.Clear();
            return validationType switch
            {
                ValidationType.Insert => InsertValidations(entity),
                ValidationType.Update => UpdateValidations(entity),
                ValidationType.Delete => DeleteValidations(entity),
                _ => throw new ArgumentException("Argument doesn't exists")
            };
        }

        public virtual Task DefaultValidations(T entity)
        {
            entity.ValidateAnnotations(ValidationResults, new HashSet<object>());

            return Task.CompletedTask;
        }

        public virtual Task InsertValidations(T entity)
        {
            return DefaultValidations(entity);
        }

        public virtual Task UpdateValidations(T entity)
        {
            return DefaultValidations(entity);
        }

        public virtual Task DeleteValidations(T entity)
        {
            return Task.CompletedTask;
        }
    }
}
