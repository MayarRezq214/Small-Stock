using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCodeZone.BL.Dtos.Store;

namespace TaskCodeZone.BL
{
    public interface IStoreManager
    {
        public List<StoreDto>? GetAllStores();
        public void AddStore(StoreDto store);
        public GetAllItemsForStoreDto GetAllItemsForStore(int id);
        public void DeleteStoreById(int id);
        public void UpdateStore(StoreDto store);
        public StoreDto GetStoreByID(int id);
        public void AddItemInStore(ItemInStoreDto StoreItem);
        public void updateCurrentCount(ItemInStoreDto updateCurrentCountDto);
        public ItemInStoreDto GetStoreItemById(int storeId, int itemId);
        public StoreDto GetStoreByNameAndAddress(string name, string adress);
    }
}
