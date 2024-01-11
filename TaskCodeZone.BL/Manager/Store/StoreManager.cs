using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCodeZone.BL.Dtos.Store;
using TaskCodeZone.DAL;

namespace TaskCodeZone.BL
{
    public class StoreManager : IStoreManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public StoreManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Get All stores
        public List<StoreDto>? GetAllStores()
        {
            List<Store> DbStore = _unitOfWork.StoreRepo.GetAll();
            if (DbStore == null) { return null; }
            return DbStore.Select(s => new StoreDto
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
            }).ToList();
        }
        #endregion
        #region Add Store
        public void AddStore(StoreDto store)
        {
            Store DbStore = new Store
            {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address,
            };
            _unitOfWork.StoreRepo.Add(DbStore);
            _unitOfWork.SaveChanges();
        }
        #endregion

        #region get all items of store
        public GetAllItemsForStoreDto GetAllItemsForStore(int id) 
        {
            Store store = _unitOfWork.StoreItemRepo.GetAllStoreItems(id);
            if(store == null) { return null; }
            return new GetAllItemsForStoreDto
            {
                StoreId = store.Id,
                StoreName = store.Name,
                StoreItems = store.StoreItems.Select(si => new ChildStoreItemDto
                {
                    CurrentNumberOfItems = si.CurrentNumberOfItems,
                    LimitedNumberOfItems = si.LimitedNumberOfItems,
                    ItemId = si.Item.Id,
                    ItemName = si.Item.Name,
                    MeasurmentUnit = si.Item.MeasurementUnit
                }).ToList()
            };
        }
        #endregion
        #region Delete Store by id
        public void DeleteStoreById(int id)
        {
            _unitOfWork.StoreRepo.DeleteById(id);
            _unitOfWork.SaveChanges();
        }
        #endregion
        #region update Store 
        public void UpdateStore(StoreDto store)
        {
            Store DbStore = new Store
            {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address,
            };
            _unitOfWork.StoreRepo.Update(DbStore);
            _unitOfWork.SaveChanges();
        }
        #endregion
        #region Get Store By Id
        public StoreDto GetStoreByID(int id)
        {
            Store DbStore = _unitOfWork.StoreRepo.GetById(id);
            if(DbStore == null) { return null!; }
            else
            {
                return new StoreDto
                {
                    Id = DbStore.Id,
                    Name = DbStore.Name,
                    Address = DbStore.Address,
                };
            }
        }
        #endregion
        #region Add Item in Store
        public void AddItemInStore(ItemInStoreDto StoreItem)
        {
            StoreItem DbStoreItem = new StoreItem
            {
                ItemId = StoreItem.ItemId,
                StoreId = StoreItem.StoreId,
                CurrentNumberOfItems = StoreItem.CurrentNumberOfItems,
                LimitedNumberOfItems = StoreItem.LimitedNumberOfItems,
            };
            _unitOfWork.StoreItemRepo.Add(DbStoreItem);
            _unitOfWork.SaveChanges();
        }
        #endregion
        #region update current count
        public void updateCurrentCount(ItemInStoreDto updateCurrentCountDto)
        {
            StoreItem DbStoreItem = new StoreItem
            {
                StoreId = updateCurrentCountDto.StoreId,
                ItemId = updateCurrentCountDto.ItemId,
                CurrentNumberOfItems = updateCurrentCountDto.CurrentNumberOfItems,
                
                LimitedNumberOfItems= updateCurrentCountDto.LimitedNumberOfItems,
            };
            _unitOfWork.StoreItemRepo.Update(DbStoreItem);
            _unitOfWork.SaveChanges();

        }
        #endregion
        #region get store item by id
        public ItemInStoreDto GetStoreItemById(int storeId , int itemId)
        {
           StoreItem DbstoreItem = _unitOfWork.StoreItemRepo.GetStoreItem(storeId, itemId);
           if(DbstoreItem == null) { return null; }
            return new ItemInStoreDto
            {
                StoreId = DbstoreItem.StoreId,
                ItemId = DbstoreItem.ItemId,
                CurrentNumberOfItems = DbstoreItem.CurrentNumberOfItems,
                LimitedNumberOfItems = DbstoreItem.LimitedNumberOfItems
            };
        }
        #endregion
        #region Get Store By Name And Adress
        public StoreDto GetStoreByNameAndAddress(string name, string adress)
        {
            Store DbStore = _unitOfWork.StoreRepo.GetStoreByNameAndAddress(name, adress);
            if(DbStore == null) { return null; }
            return new StoreDto
            {
                Id = DbStore.Id,
                Name = name,
                Address = adress
            };
        }
        #endregion
    }
}
