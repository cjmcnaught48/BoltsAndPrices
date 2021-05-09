using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoltsAndPrices.Data.Domain;
using BoltsAndPrices.Data.Repositories;
using BoltsAndPrices.Infrastructure.Models;

namespace BoltsAndPrices.Infrastructure.Services
{
    public class InventoryService
    {
        private IUnitOfWork _unitOfWork;

        public InventoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Inventory> GetInventories(string term)
        {
            return _unitOfWork.Inventory.GetWhere(i => i.InventoryCode.Contains(term));
        }

        public IEnumerable<Inventory> GetInventories()
        {
            try
            {
                var result = _unitOfWork.Inventory.GetAll().ToList();
                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void AddOrUpdate(IInventoryModel inventoryModel)
        {
            if(inventoryModel.Exists())
            {
                Update(inventoryModel);
            }
            else
            {
                Add(inventoryModel);
            }
        }

        public void Add(IInventoryModel boltModel)
        {
            Inventory inventory;

            inventory = new Inventory();
            inventory.InventoryCode = boltModel.InventoryCode;
            inventory.Price = boltModel.Price;

            _unitOfWork.Inventory.Add(inventory);

            _unitOfWork.Save();
        }

        public void Update(IInventoryModel inventoryModel)
        {
            if(inventoryModel.InventoryId == null)
            {
                throw new ModelInvalidException();
            }

            var bolt = _unitOfWork.Inventory.Find(inventoryModel.InventoryId.Value);

            if(bolt == null)
            {
                throw new ModelInvalidException();
            }

            bolt.InventoryCode = inventoryModel.InventoryCode;
            bolt.Price = inventoryModel.Price;

            _unitOfWork.Save();

        }
    }
}
