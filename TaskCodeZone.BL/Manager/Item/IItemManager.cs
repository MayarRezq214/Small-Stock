using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskCodeZone.BL
{
    public interface IItemManager
    {
        public void AddItem(ItemDto Item);
        public List<ItemDto>? GetAllItems();
        public void DeleteItemById(int id);
        public ItemDto GetItemById(int id);
        public void UpdateItem(ItemDto Item);
        public ItemDto GetItemByName(string Name);
    }
}
