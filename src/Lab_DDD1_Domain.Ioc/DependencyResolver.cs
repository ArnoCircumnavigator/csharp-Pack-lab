using Microsoft.VisualBasic;
using System.Data.SqlTypes;

namespace Lab_DDD1_Domain.Ioc
{
    public class DependencyResolver
    {
        private static readonly IInstanceLocator instanceLocator = InstanceLocator.Current;

        public static T Resolve<T>()
        {
            return instanceLocator.GetInstance<T>();
        }
        public static object Resolve(Type type)
        {
            return instanceLocator.GetInstance(type);
        }
        public static void RegisterType<T>()
        {
            instanceLocator.RegisterType<T>();
        }
        public static void RegisterType(Type type)
        {
            instanceLocator.RegisterType(type);
        }
        public static bool IsTypeRegistered<T>()
        {
            return instanceLocator.IsTypeRegistered<T>();
        }
        public static bool IsTypeRegistered(Type type)
        {
            return instanceLocator.IsTypeRegistered(type);
        }
    }
}