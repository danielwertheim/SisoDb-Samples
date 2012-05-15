﻿using System;
using System.Collections.Generic;
using System.Linq;
using PineCone.Annotations;

namespace Examples.Ex01Crud.CrudModel
{
    [Serializable]
    public class Order
    {
        public int Id { get; set; }

        public Guid CustomerId { get; set; }

        [Unique(UniqueModes.PerType)]
        public string OrderNo { get; set; }

        public IList<OrderLine> Lines { get; set; }

        public Order()
        {
            Lines = new List<OrderLine>();
        }

        public void AddNewProduct(string productNo, int quantity)
        {
            var line = Lines.SingleOrDefault(l => l.ProductNo.Equals(productNo)) ?? new OrderLine { ProductNo = productNo };

            line.Quantity += quantity;

            Lines.Add(line);
        }
    }
}