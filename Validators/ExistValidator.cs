using FluentValidation.Resources;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Patlus.Common.UseCase.Validators
{
    internal class ExistValidator<TEntity, TProperty> : PropertyValidator
    {
        private readonly IQueryable<TEntity> _source;
        private readonly Func<TProperty, Expression<Func<TEntity, bool>>> _predicateBuilder;

        public ExistValidator(IQueryable<TEntity> source, Func<TProperty, Expression<Func<TEntity, bool>>> predicateBuilder, IStringSource errorMessageSource) : base(errorMessageSource)
        {
            _source = source;
            _predicateBuilder = predicateBuilder;
        }

        public ExistValidator(IQueryable<TEntity> source, Func<TProperty, Expression<Func<TEntity, bool>>> predicateBuilder, string errorMessage) : base(errorMessage)
        {
            _source = source;
            _predicateBuilder = predicateBuilder;
        }

        public ExistValidator(IQueryable<TEntity> source, Func<TProperty, Expression<Func<TEntity, bool>>> predicateBuilder) : this(source, predicateBuilder, "{PropertyName} isn't exist.")
        {
            _source = source;
            _predicateBuilder = predicateBuilder;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var value = (TProperty)context.PropertyValue;
            var expression = _predicateBuilder.Invoke(value);

            return _source.Where(expression).Count() > 0;
        }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            var value = (TProperty)context.PropertyValue;
            var expression = _predicateBuilder.Invoke(value);

            return await _source.Where(expression).CountAsync(cancellation) > 0;
        }
    }
}
