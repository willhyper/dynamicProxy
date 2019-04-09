using System;

namespace DynamicProxy
{
    
	public class BeforeDecorator : IProxyInvocationHandler
	{
        private object clz;
        private Action decorator;

        private BeforeDecorator(object cls, Action decorator) {
            this.clz = cls;
            this.decorator = decorator;
        }

        public static T GetDecoratedProxy<T>(object cls, Action decorator)
        {
            BeforeDecorator dec = new BeforeDecorator(cls, decorator);
            return (T) ProxyFactory.Create(dec, cls.GetType());
        }
        

        public object Invoke(object proxy, System.Reflection.MethodInfo method, object[] parameters) {

            // decorator logic
            decorator();

            // The actual method is invoked
            object retVal = method.Invoke( clz, parameters );
                        
            return retVal;
        }
    }
}