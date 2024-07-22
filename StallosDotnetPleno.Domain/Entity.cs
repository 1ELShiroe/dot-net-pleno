using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FluentValidation.Results;
using FluentValidation;

namespace StallosDotnetPleno.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }

        [NotMapped]
        [JsonIgnore]
        public bool IsValid { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ValidationResult? ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return IsValid = ValidationResult.IsValid;
        }
    }
}