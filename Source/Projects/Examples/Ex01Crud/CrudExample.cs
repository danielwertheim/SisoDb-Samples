using System;
using System.Linq;
using Examples.Ex01Crud.CrudModel;

namespace Examples.Ex01Crud
{
    public class CrudExample : Example
    {
        public override void Run()
        {
            var customerId = CreateNewCustomer();

            UpdateCustomer(customerId);

            var orderId = AddOrder();

            //ViolateOrderNoContraintOnOrder(orderId);
        }

        private Guid CreateNewCustomer()
        {
            var customer = new Customer
            {
                PersonalNo = "800501",
                Firstname = "Daniel",
                Lastname = "Wertheim",
                ShoppingIndex = ShoppingIndexes.Level1,
                CustomerSince = DateTime.Now,
                BillingAddress =
                {
                    Street = "The billing street",
                    Zip = "12345",
                    City = "The billing city",
                    Country = "Sweden"
                }
            };

            Db.UseOnceTo().Insert(customer);

            return customer.Id;
        }

        private void UpdateCustomer(Guid id)
        {
            using (var session = Db.BeginSession())
            {
                var customer = session.GetById<Customer>(id);

                customer.DeliveryAddress = new Address
                {
                    Street = "The delivery street",
                    Zip = "44453",
                    City = "Gothenbourg",
                    Country = "Sweden"
                };

                session.Update(customer);
            }
        }

        private Customer GetCustomer()
        {
            return Db.UseOnceTo().Query<Customer>().Where(c => c.PersonalNo == "800501").Single();
        }

        private int AddOrder()
        {
            var customer = GetCustomer();

            var order = new Order { CustomerId = customer.Id, OrderNo = "2010-10-15-1" };
            order.AddNewProduct("1", 2);
            order.AddNewProduct("2", 1);

            Db.UseOnceTo().Insert(order);

            return order.Id;
        }

        private void ViolateOrderNoContraintOnOrder(int orderId)
        {
            try
            {
                using (var session = Db.BeginSession())
                {
                    var order = session.GetById<Order>(orderId);

                    session.Insert(order);
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("ex.Message = {0}", ex.Message);
            }
        }
    }
}