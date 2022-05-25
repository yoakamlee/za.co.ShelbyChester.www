using ShelbyChester.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.DataAccess.InMemory
{
    public class WarehouseStorageRepo
    {
        ObjectCache cache = MemoryCache.Default;
        List<WarehouseStorage> warehouseStorages;

        public WarehouseStorageRepo()
        {
            warehouseStorages = cache["warehouseStorages"] as List<WarehouseStorage>;
            if (warehouseStorages == null)
            {
                warehouseStorages = new List<WarehouseStorage>();
            }
        }

        public void Commit()
        {
            cache["warehouseStorages"] = warehouseStorages;
        }

        public void Insert(WarehouseStorage w)
        {
            warehouseStorages.Add(w);
        }

        public void Update(WarehouseStorage warehouseStorage)
        {
            WarehouseStorage warehouseStorageToUpdate = warehouseStorages.Find(w => w.Id == warehouseStorage.Id);

            if (warehouseStorageToUpdate != null)
            {
                warehouseStorageToUpdate = warehouseStorage;
            }
            else
            {
                throw new Exception("Warehouse not found");
            }
        }

        public WarehouseStorage Find(string Id)
        {
            WarehouseStorage warehouseStorage = warehouseStorages.Find(c => c.Id == Id);

            if (warehouseStorage != null)
            {
                return warehouseStorage;
            }
            else
            {
                throw new Exception("Warehouse not found");
            }
        }

        public IQueryable<WarehouseStorage> Collection()
        {
            return warehouseStorages.AsQueryable();
        }

        public void Delete(string Id)
        {
            WarehouseStorage warehouseStorageToDelete = warehouseStorages.Find(c => c.Id == Id);

            if (warehouseStorageToDelete != null)
            {
                warehouseStorages.Remove(warehouseStorageToDelete);
            }
            else
            {
                throw new Exception("Warehouse not found");
            }
        }
    }
}
