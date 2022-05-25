using ShelbyChester.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.DataAccess.InMemory
{
    public  class FreightQuotationRepo
    {
        ObjectCache cache = MemoryCache.Default;
        List<FreightQuotation> freightQuotations;

        public FreightQuotationRepo()
        {
            freightQuotations = cache["freightQuotations"] as List<FreightQuotation>;
            if (freightQuotations == null)
            {
                freightQuotations = new List<FreightQuotation>();
            }
        }

        public void Commit()
        {
            cache["freightQuotations"] = freightQuotations;
        }

        public void Insert(FreightQuotation f)
        {
            freightQuotations.Add(f);
        }

        public void Update(FreightQuotation freightQuotation)
        {
            FreightQuotation freightQuotationToUpdate = freightQuotations.Find(f => f.Id == freightQuotation.Id);

            if (freightQuotationToUpdate != null)
            {
                freightQuotationToUpdate = freightQuotation;
            }
            else
            {
                throw new Exception("Freight quote not found");
            }
        }

        public FreightQuotation Find(string Id)
        {
            FreightQuotation freightQuotation = freightQuotations.Find(c => c.Id == Id);

            if (freightQuotation != null)
            {
                return freightQuotation;
            }
            else
            {
                throw new Exception("Freight quote not found");
            }
        }

        public IQueryable<FreightQuotation> Collection()
        {
            return freightQuotations.AsQueryable();
        }

        public void Delete(string Id)
        {
            FreightQuotation freightQuotationToDelete = freightQuotations.Find(c => c.Id == Id);

            if (freightQuotationToDelete != null)
            {
                freightQuotations.Remove(freightQuotationToDelete);
            }
            else
            {
                throw new Exception("Freight quote not found");
            }
        }
    }
}
