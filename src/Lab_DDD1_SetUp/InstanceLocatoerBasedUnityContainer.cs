using Lab_DDD1_Domain.Ioc;
using Unity;

namespace Lab_DDD1_SetUp
{
    /// <summary>
    /// 基于UnityContainer实现的实例定位
    /// </summary>
    public class InstanceLocatoerBasedUnityContainer : IInstanceLocator
    {
        public T GetInstance<T>()
        {
            return UnityContainerHolder.UnityContainer.Resolve<T>();
        }

        public object GetInstance(Type type)
        {
            return UnityContainerHolder.UnityContainer.Resolve(type);
        }

        public bool IsTypeRegistered<T>()
        {
            return UnityContainerHolder.UnityContainer.IsRegistered<T>();
        }

        public bool IsTypeRegistered(Type type)
        {
            return UnityContainerHolder.UnityContainer.IsRegistered(type);
        }

        public void RegisterType<T>()
        {
            UnityContainerHolder.UnityContainer.RegisterType<T>();
        }

        public void RegisterType(Type type)
        {
            UnityContainerHolder.UnityContainer.RegisterType(type);
        }
    }
}
