using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MyRoadMap.Domain.Model.Validation
{
    public static class ValidationExtensions
    {
        public static void ValidateAnnotations<T>(this T obj, List<ValidationResult> validationResults, ISet<object> validatedObjects) where T : class
        {
            if (validatedObjects.Contains(obj))
                return;

            var validationContext = new ValidationContext(obj);
            Validator.TryValidateObject(obj, validationContext, validationResults);
            validatedObjects.Add(obj);

            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string) || property.PropertyType.IsValueType)
                    continue;

                var value = property.GetValue(obj, null);

                if (value == null) continue;

                var asEnumerable = value as IEnumerable;

                if (asEnumerable is not null)
                {
                    foreach (var item in asEnumerable)
                    {
                        var currentValidationResults = new List<ValidationResult>();
                        item.ValidateAnnotations(currentValidationResults, validatedObjects);
                        if (currentValidationResults.Count != 0)
                        {
                            foreach (var validationResult in currentValidationResults)
                                validationResults.Add(new ValidationResult(validationResult.ErrorMessage, validationResult.MemberNames.Select(x => property.Name + "." + x)));
                        }
                    }
                }
                else
                {
                    var currentValidationResults = new List<ValidationResult>();
                    value.ValidateAnnotations(currentValidationResults, validatedObjects);
                    if (currentValidationResults.Count != 0)
                    {
                        foreach (var validationResult in currentValidationResults)
                            validationResults.Add(new ValidationResult(validationResult.ErrorMessage, validationResult.MemberNames.Select(x => property.Name + "." + x)));
                    }
                }
            }
        }
    }
}
