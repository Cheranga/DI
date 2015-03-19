using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIDemo.Business;
using DIDemo.Business.Models;
using DIDemo.DAL_Memory;
using DIDemo.DAL_Memory.Repositories;
using DIDemo.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DIDemo.Tests
{
    [TestClass]
    public class BaseRepositoryTest
    {

        private readonly List<Customer> customers = new List<Customer>
        {
            new Customer {Id = 1, Name = "Cheranga Hatangala"},
            new Customer {Id = 2, Name = "Muralidhar Mishra"},
            new Customer {Id = 3, Name = "Van Nguyen"},
            new Customer {Id = 4, Name = "Michael Hinn"},
        };



        [TestMethod]
        public void Test_GetAll()
        {   
            //
            // Arrange
            //
            var customerRepository = new Mock<BaseRepository<Customer>>(this.customers);
            //
            // Act
            //
            var customerList = customerRepository.Object.GetAll().ToList();
            //
            // Assert
            //
            Assert.IsNotNull(customerList);
            Assert.IsTrue(customerList.Count == 4);
            Assert.IsTrue(customerList[0].Name == "Cheranga Hatangala");
        }

        [TestMethod]
        public void Test_GetById_ReturnsObject()
        {
            //
            // Arrange
            //
            var customerRepository = new Mock<BaseRepository<Customer>>(this.customers);
            //
            // Act
            //
            var customer = customerRepository.Object.GetById(1);
            //
            // Assert
            //
            Assert.IsNotNull(customer);
            Assert.IsTrue(customer.Id == 1 && customer.Name == "Cheranga Hatangala", "Customer is not the same as required");
        }

        [TestMethod]
        public void Test_GetById_ReturnsNullIfIdIsNotPresent()
        {
            //
            // Arrange
            //
            var customerRepository = new Mock<BaseRepository<Customer>>(this.customers);
            //
            // Act
            //
            var customer = customerRepository.Object.GetById(100);
            //
            // Assert
            //
            Assert.IsNull(customer);
        }

        [TestMethod]
        public void Test_Add_Using_a_Proper_Entity()
        {
            //
            // Arrange
            //
            Mock<BaseRepository<Customer>> customerRepository = new Mock<BaseRepository<Customer>>(customers);
            var customerToAdd = new Customer { Id = 999, Name = "Talal Tayyab" };
            //
            // Act
            //
            customerRepository.Object.Add(customerToAdd);
            //
            // Assert
            //
            Assert.IsTrue(customers.Count == 5, "Customer has not been added to the list");
            Assert.IsTrue(customers[4].Id == 999 && customers[4].Name == "Talal Tayyab", "The customer has not been added to the end of the list");
        }

        [TestMethod]
        public void Test_Add_Using_a_Null_Entity()
        {
            //
            // Arrange
            //
            Mock<BaseRepository<Customer>> customerRepository = new Mock<BaseRepository<Customer>>(customers);
            //
            // Act
            //
            customerRepository.Object.Add(null);
            //
            // Assert
            //
            Assert.IsTrue(customers.Count == 4, "Customer has not been added to the list");
        }

        [TestMethod]
        public void Test_Update_Using_a_Proper_Entity()
        {
            //
            // Arrange
            //
            var customerRepository = new Mock<BaseRepository<Customer>>(this.customers);
            var customerToUpdate = new Customer {Id = 1, Name = "Chera Hata"};
            //
            // Act
            //
            customerRepository.Object.Update(customerToUpdate);
            //
            // Assert
            //
            Assert.IsTrue(customers.Count == 4, "The item count in the repository have changed");
            Assert.IsTrue(customers[0].Name == "Chera Hata", "The entity wasn't updated");
        }
    }
}
