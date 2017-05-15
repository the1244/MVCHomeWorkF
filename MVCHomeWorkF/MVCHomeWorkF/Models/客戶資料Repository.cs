using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVCHomeWorkF.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public IQueryable<客戶資料> get客戶資料AllList()
        {
            return this.All().Where(p => p.IsDeleted == false).OrderByDescending(a => a.Id);
        }

        internal IQueryable<客戶資料> 搜尋關鍵字(IQueryable<客戶資料> list,string strSearch)
        {
            return list.Where(a => a.客戶名稱.Contains(strSearch));
        }

        internal 客戶資料 取得單筆客戶資料byId(int? id)
        {
            return this.All().Where(a => a.Id == id).First();
        }

        public void Update(客戶資料 客戶資料)
        {
            this.UnitOfWork.Context.Entry(客戶資料).State = EntityState.Modified;
        }

        internal void Deleted(客戶資料 客戶資料)
        {
            客戶資料.IsDeleted = true;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}