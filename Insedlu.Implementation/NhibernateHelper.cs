using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace Insedlu.Implementation
{
    static class NhibernateHelper
    {
        public static void Startup()
        {
            var configuartion = new Configuration();
            configuartion.DataBaseIntegration(x =>
            {
                x.ConnectionString = "<metadata=res://*/Connection.Model1.csdl|res://*/Connection.Model1.ssdl|res://*/Connection.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=Insendlu;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot; providerName=System.Data.EntityClient />";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });
        }
    }
}
