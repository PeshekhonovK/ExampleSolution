using Example.DAL;
using Ninject.Modules;

namespace Example.BLL
{
    public class BLLModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEmployeeBLL>().To<EmployeeBLL>();
            this.Bind<IDepartmentBLL>().To<DepartmentBLL>();
            this.Bind<IRepository>().To<Repository>();
        }
    }
}
