using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Core.Specefication.Product
{
    public class ProductSpecefication : BaseSpecefication<Entites.Product>
    {

        private Expression<Func<Entites.Product, object>> brand = product => product.Brand;
        private Expression<Func<Entites.Product, object>> ProductType = product => product.ProductType;

        public ProductSpecefication(Order order = null)
        {
            SetIncludes();
            SetOrder(order);
        }



        public ProductSpecefication(Expression<Func<Entites.Product, bool>> predicate, Order order = null) : base(predicate)
        {
            SetIncludes();
            SetOrder(order);

        }

        public ProductSpecefication(Expression<Func<Entites.Product, bool>> predicate,
         List<Expression<Func<Entites.Product, object>>> includes, Order order = null) : base(predicate, includes)
        {

            SetOrder(order);
        }

        private void SetIncludes()
        {
            AddInclude(brand);
            AddInclude(ProductType);
        }
        private void SetOrder(Order order)
        {
            if (order != null)
            {
                var p = Expression.Parameter(typeof(Entites.Product));
                var SortBy = Expression.Lambda<Func<Entites.Product, object>>(Expression.TypeAs(Expression.Property(p, order.PropertyName), typeof(object)), p).Compile();
                Expression<Func<Entites.Product, object>> orderItem = p => SortBy;
                
                AddOrder(orderItem, order.OrderType);
            }
        }
    }
}