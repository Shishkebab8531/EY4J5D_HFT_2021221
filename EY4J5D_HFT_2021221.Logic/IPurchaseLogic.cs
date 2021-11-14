using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EY4J5D_HFT_2021221.Logic
{
    interface IPurchaseLogic
    {
        public void Create(Purchase newModel);
        public Purchase Read(int id);
        public IEnumerable<Purchase> ReadAll();
        public void Update(Purchase updated);
        public void Delete(int id);
    }
}
