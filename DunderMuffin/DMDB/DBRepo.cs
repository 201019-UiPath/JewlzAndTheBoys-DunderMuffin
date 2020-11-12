using System.Collections.Generic;
using DMDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography.X509Certificates;

namespace DMDB
{
    public class DBRepo : IInventoryItemRepo, ILocationRepo, IProductRepo, IEmployeeRepo
    {
        private DMContext context;

        public DBRepo(DMContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// CRUD methods for Inventory Items
        /// </summary>
        /// <param name="inventoryItem"></param>
        public void AddInventoryItem(InventoryItem inventoryItem)
        {
            context.inventoryItems.Add(inventoryItem);
            context.SaveChanges();
        }

        public void UpdateInventoryItem(InventoryItem inventoryItem)
        {
            context.inventoryItems.Update(inventoryItem);
            context.SaveChanges();
        }

        public void DeleteInventoryItem(InventoryItem inventoryItem)
        {
            context.inventoryItems.Remove(inventoryItem);
            context.SaveChanges();
        }

        public InventoryItem GetInventoryItemByLocationIdProductId(int locationId, int productId) {
            return context.inventoryItems.Single(x => x.locationId == locationId && x.productId == productId);
        }

        public List<InventoryItem> GetAllInventoryItemsByLocationId(int locationId) {
            return context.inventoryItems.Include("Product").Where(x => x.locationId == locationId).ToList();
        }

        /// <summary>
        /// CRUD methods for Locations
        /// </summary>
        /// <param name="location"></param>
        public void AddLocation(Location location)
        {
            context.locations.Add(location);
            context.SaveChanges();
        }

        public void UpdateLocation(Location location)
        {
            context.locations.Update(location);
            context.SaveChanges();
        }

        public void DeleteLocation(Location location)
        {
            context.locations.Remove(location);
            context.SaveChanges();
        }

        public Location GetLocationById(int id)
        {
            return context.locations.Single(x => x.locationId == id);
        }

        public Location GetLocationByName(string name)
        {
            return context.locations.Single(x => x.locationName == name);
        }

        public List<Location> GetAllLocations()
        {
            return context.locations.Select(x => x).ToList();
        }

        /// <summary>
        /// CRUD methods for Products
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            context.products.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            context.products.Update(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.products.Remove(product);
            context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return context.products.Single(x => x.productId == id);
        }

        public Product GetProductByName(string name)
        {
            return context.products.Single(x => x.productName == name);
        }

        public List<Product> GetAllProducts()
        {
            return context.products.Select(x => x).ToList();
        }

        /// <summary>
        /// CRUD methods for Employees
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployee(Employee employee)
        {
            context.employees.Add(employee);
            context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            context.employees.Update(employee);
            context.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            context.employees.Remove(employee);
            context.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            return context.employees.Single(x => x.employeeID == id);
        }

        public Employee GetEmployeeByFirstName(string name)
        {
            return context.employees.Single(x => x.employeeFName == name);
        }

        public List<Employee> GetAllEmployees()
        {
            return context.employees.Select(x => x).ToList();
        }
    }
}