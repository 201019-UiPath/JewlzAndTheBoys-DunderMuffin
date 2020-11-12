using DMDB;
using DMDB.Models;
using System.Collections.Generic;

namespace DMLib
{
    public class InventoryItemServices
    {
        /// <summary>
        /// These Are The Methods That Connect With The DBRepo and Allow Us To Use Inventory Item Related Business Logic Like Adding Updating Deleting Or Getting Inventory Items
        /// </summary>
        private IInventoryItemRepo repo;

        public InventoryItemServices(IInventoryItemRepo repo)
        {
            this.repo = repo;
        }
        public void AddInventoryItem(InventoryItem inventoryItem)
        {
            repo.AddInventoryItem(inventoryItem);
        }
        public void UpdateInventoryItem(InventoryItem inventoryItem)
        {
            repo.UpdateInventoryItem(inventoryItem);
        }
        public void DeleteInventoryItem(InventoryItem inventoryItem)
        {
            repo.DeleteInventoryItem(inventoryItem);
        }
        public InventoryItem GetInventoryItemByLocationIdProductId(int locationId, int productId) 
        {
             InventoryItem item = repo.GetInventoryItemByLocationIdProductId(locationId, productId);
             return item;
        }
        public List<InventoryItem> GetAllInventoryItemsByLocationId(int locationId) 
        {
             List<InventoryItem> items = repo.GetAllInventoryItemsByLocationId(locationId);
             return items;
        }
    }
}