using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using ShelbyChester.Core.Models;

namespace ShelbyChester.DataAccess.InMemory
{
    internal class ClientPreAdviceRepo
    {
        ObjectCache cache = MemoryCache.Default;
        List<ClientPreAdvice> clientPreAdvices;

        public ClientPreAdviceRepo()
        {
            clientPreAdvices = cache["clientPreAdvices"] as List<ClientPreAdvice>;
            if (clientPreAdvices == null)
            {
                clientPreAdvices = new List<ClientPreAdvice>();
            }
        }

        public void Commit()
        {
            cache["clientPreAdvices"] = clientPreAdvices;
        }

        public void Insert(ClientPreAdvice c)
        {
            clientPreAdvices.Add(c);
        }

        public void Update(ClientPreAdvice clientPreAdvice)
        {
            ClientPreAdvice clientToUpdate = clientPreAdvices.Find(c => c.Id == clientPreAdvice.Id);

            if (clientToUpdate != null)
            {
                clientToUpdate = clientPreAdvice;
            }
            else
            {
                throw new Exception("Client Pre-advice not found");
            }
        }

        public ClientPreAdvice Find(string Id)
        {
            ClientPreAdvice clientPreAdvice = clientPreAdvices.Find(p => p.Id == Id);

            if (clientPreAdvice != null)
            {
                return clientPreAdvice;
            }
            else
            {
                throw new Exception("Client Pre-advice not found");
            }
        }

        public IQueryable<ClientPreAdvice> Collection()
        {
            return clientPreAdvices.AsQueryable();
        }

        public void Delete(string Id)
        {
            ClientPreAdvice productToDelete = clientPreAdvices.Find(p => p.Id == Id);

            if (productToDelete != null)
            {
                clientPreAdvices.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Client Pre-advice not found");
            }
        }
    }
}
