using FluentValidation;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Patlus.Common.UseCase.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> Exist<T, TProperty, TEntity>(this IRuleBuilder<T, TProperty> ruleBuilder, IQueryable<TEntity> source, Func<TProperty, Expression<Func<TEntity, bool>>> predicateBuilder)
        {
            return ruleBuilder.SetValidator(new ExistValidator<TEntity, TProperty>(source, predicateBuilder));
        }

        public static IRuleBuilderOptions<T, TProperty> NotExist<T, TProperty, TEntity>(this IRuleBuilder<T, TProperty> ruleBuilder, IQueryable<TEntity> source, Func<TProperty, Expression<Func<TEntity, bool>>> predicateBuilder)
        {
            return ruleBuilder.SetValidator(new NotExistValidator<TEntity, TProperty>(source, predicateBuilder));
        }

        public static IRuleBuilderOptions<T, TProperty> Unique<T, TProperty, TEntity>(this IRuleBuilder<T, TProperty> ruleBuilder, IQueryable<TEntity> source, Func<TProperty, Expression<Func<TEntity, bool>>> predicateBuilder)
        {
            return ruleBuilder.SetValidator(new NotExistValidator<TEntity, TProperty>(source, predicateBuilder)).WithMessage("{PropertyName} should be unique");
        }
    }
}
