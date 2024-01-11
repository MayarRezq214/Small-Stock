using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCodeZone.DAL;

namespace TaskCodeZone.BL
{
    public class ItemManager : IItemManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Get All Items
        public List<ItemDto>? GetAllItems()
        {
            List<Item> DbItem = _unitOfWork.ItemRepo.GetAll();
            if (DbItem == null) { return null; }
            return DbItem.Select(s => new ItemDto
            {
                Id = s.Id,
                Name = s.Name,
                MeasurementUnit = s.MeasurementUnit
            }).ToList();
        }
        #endregion
        #region Add Item
        public void AddItem(ItemDto Item)
        {
            Item DbItem = new Item
            {
                Id = Item.Id,
                Name = Item.Name,
                MeasurementUnit = Item.MeasurementUnit
            };
            _unitOfWork.ItemRepo.Add(DbItem);
            _unitOfWork.SaveChanges();
        }
        #endregion
        #region Delete Store by id
        public void DeleteItemById(int id)
        {
            _unitOfWork.ItemRepo.DeleteById(id);
            _unitOfWork.SaveChanges();
        }
        #endregion
        #region update Item
        public void UpdateItem(ItemDto Item)
        {
            Item DbItem = new Item
            {
                Id = Item.Id,
                Name = Item.Name,
                MeasurementUnit = Item.MeasurementUnit
            };
            _unitOfWork.ItemRepo.Update(DbItem);
            _unitOfWork.SaveChanges();
        }
        #endregion
        #region get Item by Id
        public ItemDto GetItemById(int id)
        {
            Item DbItem = _unitOfWork.ItemRepo.GetById(id);
            if(DbItem == null) { return null; }
            return new ItemDto
            {
                Id = DbItem.Id,
                Name = DbItem.Name,
                MeasurementUnit = DbItem.MeasurementUnit
            };
        }
        #endregion
        #region Get Item By Name
        public ItemDto GetItemByName(string Name)
        {
            Item DbItem = _unitOfWork.ItemRepo.GetItemByName(Name);
            if(DbItem == null) { return null; }
            return new ItemDto
            {
                Id = DbItem.Id,
                Name = DbItem.Name,
                MeasurementUnit = DbItem.MeasurementUnit
            };
        }
        #endregion
    }
}
