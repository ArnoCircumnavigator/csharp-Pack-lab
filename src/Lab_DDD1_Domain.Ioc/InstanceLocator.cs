using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.Ioc
{
    public sealed class InstanceLocator : IInstanceLocator
    {
        private static IInstanceLocator? currentLocator;
        private InstanceLocator()
        {

        }
        public static IInstanceLocator Current
        {
            get
            {
                return currentLocator;
            }
        }
        public static void SetLocator(IInstanceLocator locator)
        {
            currentLocator = locator;
        }

        public T GetInstance<T>()
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type type)
        {
            throw new NotImplementedException();
        }

        public bool IsTypeRegistered<T>()
        {
            throw new NotImplementedException();
        }

        public bool IsTypeRegistered(Type type)
        {
            throw new NotImplementedException();
        }

        public void RegisterType<T>()
        {
            throw new NotImplementedException();
        }

        public void RegisterType(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
