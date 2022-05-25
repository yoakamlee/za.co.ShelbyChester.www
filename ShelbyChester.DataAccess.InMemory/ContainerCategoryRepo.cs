using ShelbyChester.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.DataAccess.InMemory
{
    public class ContainerCategoryRepo
    {

        ObjectCache cache = MemoryCache.Default;
        List<ContainerCategory> containerCategories;

        public ContainerCategoryRepo()
        {
            containerCategories = cache["containerCategories"] as List<ContainerCategory>;
            if (containerCategories == null)
            {
                containerCategories = new List<ContainerCategory>();
            }
        }

        public void Commit()
        {
            cache["containerCategories"] = containerCategories;
        }

        public void Insert(ContainerCategory c)
        {
            containerCategories.Add(c);
        }

        public void Update(ContainerCategory containerCategory)
        {
            ContainerCategory containerCategoryToUpdate = containerCategories.Find(c => c.Id == containerCategory.Id);

            if (containerCategoryToUpdate != null)
            {
                containerCategoryToUpdate = containerCategory;
            }
            else
            {
                throw new Exception("Container type not found");
            }
        }

        public ContainerCategory Find(string Id)
        {
            ContainerCategory containerCategory = containerCategories.Find(c => c.Id == Id);

            if (containerCategory != null)
            {
                return containerCategory;
            }
            else
            {
                throw new Exception("Container type not found");
            }
        }

        public IQueryable<ContainerCategory> Collection()
        {
            return containerCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ContainerCategory containerCategoryToDelete = containerCategories.Find(c => c.Id == Id);

            if (containerCategoryToDelete != null)
            {
                containerCategories.Remove(containerCategoryToDelete);
            }
            else
            {
                throw new Exception("Container type not found");
            }
        }
    }
}
