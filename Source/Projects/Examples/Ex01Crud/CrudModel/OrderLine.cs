using System;
using PineCone.Annotations;

namespace Examples.Ex01Crud.CrudModel
{
    [Serializable]
    public class OrderLine
    {
        public string ProductNo { get; set; }

        public int Quantity { get; set; }
    }
}