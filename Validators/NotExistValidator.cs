using FluentValidation.Resources;
using FluentValidation.Validators;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Patlus.Common.UseCase.Validators
{
    internal class NotExistValidator<TEntity, TProperty> : ExistValidator<TEntity, TProperty>
    {
        public NotExistValidator(IQueryable<TEntity> source, Func<TProperty, Expression<Func<TEntity, bool>>> predicateBuilder, IStringSource errorMessageSource)
            : base(source, predicateBuilder, errorMessageSource)
        { }
        public NotExistValidator(IQueryable<TEntity> source, Func<TProperty, Expression<Func<TEntity, bool>>> predicateBuilder, string errorMessage)
            : base(source, predicateBuilder, errorMessage)
        { }

        public NotExistValidator(IQueryable<TEntity> source, Func<TProperty, Expression<Func<TEntity, bool>>> predicateBuilder) : base(source, predicateBuilder, "{PropertyName} is already exist.")
        { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return !base.IsValid(context);
        }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            return !(await base.IsValidAsync(context, cancellation));
        }
    }
}
