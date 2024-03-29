﻿using FluentNHibernate.Mapping;
using NHibernateDemo.Infrastructure.Entities;

namespace NHibernateDemo.Infrastructure.Maps
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(255);
            Map(x => x.Description);
            Table("Product");
        }
    }
}
