using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entites;

namespace Core.Specefication.Product
{
    public class ProductSpecefication : BaseSpecefication<Entites.Product>
    {

        // public  Expression<Func<Entites.Product, Brand>> brand => s.
        public Expression<Func<Entites.Product, object>> brand = s => s.Brand;
        public Expression<Func<Entites.Product, object>> ProductType = s => s.ProductType;
        
        public ProductSpecefication()
        {
            SetIncludes();
        }

        public ProductSpecefication(Expression<Func<Entites.Product, bool>> predicate) : base(predicate)
        {
            SetIncludes();
        }

        public ProductSpecefication(Expression<Func<Entites.Product, bool>> predicate,
         List<Expression<Func<Entites.Product, object>>> includes) : base(predicate, includes)
        {

        }
        private void SetIncludes()
        {
            AddInclude(brand);
            // AddInclude(x => x.ProductType);
            AddInclude(ProductType);
        }
    }
}