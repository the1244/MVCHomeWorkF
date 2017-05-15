using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVCHomeWorkF.Models
{
    public class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
    {
        public IQueryable<客戶銀行資訊> get客戶銀行資訊List()
        {
            return this.All().Where(p => p.客戶資料.IsDeleted == false && p.IsDeleted == false);
        }

        public 客戶銀行資訊 Find(int? id)
        {
            return this.All().Where(p => p.Id == id).First();
        }

        public void Update(客戶銀行資訊 客戶銀行資訊)
        {
            this.UnitOfWork.Context.Entry(客戶銀行資訊).State = EntityState.Modified;
        }

        public void Remove(客戶銀行資訊 客戶銀行資訊)
        {
            客戶銀行資訊.IsDeleted = true;
        }
    }

    public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}