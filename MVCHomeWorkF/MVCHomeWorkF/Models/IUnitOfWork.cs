using System.Data.Entity;

namespace MVCHomeWorkF.Models
{
	public interface IUnitOfWork
	{
		DbContext Context { get; set; }
		void Commit();
		bool LazyLoadingEnabled { get; set; }
		bool ProxyCreationEnabled { get; set; }
		string ConnectionString { get; set; }
	}
}