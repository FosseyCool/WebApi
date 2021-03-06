using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Entities;

namespace WebApp.Repositories
{
    public class InMemItemsRepository:IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item() {Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow},
            new Item() {Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow},
            new Item() {Id = Guid.NewGuid(), Name = "Bronze Chield", Price = 18, CreatedDate = DateTimeOffset.UtcNow}
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id ==id);
            items.RemoveAt(index);
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
            //return items.SingleOrDefault(item => item.Id == id);
        }
        
    }
}