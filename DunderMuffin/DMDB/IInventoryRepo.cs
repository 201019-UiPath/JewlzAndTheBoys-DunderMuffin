using System.Collections.Generic;
using DMDB.Models;

namespace DMDB
{
    /// <summary>
    /// Data access interface for DunderMuffin location inventories
    /// </summary>
    public interface IInventoryItemRepo
    {
        void AddInventoryItem(InventoryItem inventoryItem);
        void UpdateInventoryItem(InventoryItem inventoryItem);
        void DeleteInventoryItem(InventoryItem inventoryItem);
        InventoryItem GetInventoryItemByLocationIdProductId(int locationId, int productId);
        List<InventoryItem> GetAllInventoryItemsByLocationId(int locationId);
    }
}