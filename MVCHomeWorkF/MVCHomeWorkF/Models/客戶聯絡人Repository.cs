using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVCHomeWorkF.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public IQueryable<客戶聯絡人> get客戶聯絡人List()
        {
            return this.All().Where(p => p.客戶資料.IsDeleted == false && p.IsDeleted == false);
        }

        public 客戶聯絡人 Find(int? id)
        {
            return this.All().Where(p => p.Id == id).First();
        }

        public void Update(客戶聯絡人 客戶聯絡人)
        {
            this.UnitOfWork.Context.Entry(客戶聯絡人).State = EntityState.Modified;
        }

        public void Remove(客戶聯絡人 客戶聯絡人)
        {
            客戶聯絡人.IsDeleted = true;
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}