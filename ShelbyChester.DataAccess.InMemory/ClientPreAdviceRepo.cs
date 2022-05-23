using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using ShelbyChester.Core.Models;

namespace ShelbyChester.DataAccess.InMemory
{
    public class ClientPreAdviceRepo
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
            ClientPreAdvice clientAdviceToUpdate = clientPreAdvices.Find(c => c.Id == clientPreAdvice.Id);

            if (clientAdviceToUpdate != null)
            {
                clientAdviceToUpdate = clientPreAdvice;
            }
            else
            {
                throw new Exception("Client Pre-advice not found");
            }
        }

        public ClientPreAdvice Find(string Id)
        {
            ClientPreAdvice clientPreAdvice = clientPreAdvices.Find(c => c.Id == Id);

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
            ClientPreAdvice clientAdviceToDelete = clientPreAdvices.Find(c => c.Id == Id);

            if (clientAdviceToDelete != null)
            {
                clientPreAdvices.Remove(clientAdviceToDelete);
            }
            else
            {
                throw new Exception("Client Pre-advice not found");
            }
        }
    }
}
