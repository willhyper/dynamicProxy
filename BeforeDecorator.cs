using System;

namespace DynamicProxy
{
    
	public class BeforeDecorator : IProxyInvocationHandler
	{
        private Object clz;
        private Action decorator;

        private BeforeDecorator(Object cls, Action decorator) {
            this.clz = cls;
            this.decorator = decorator;
        }

        public static Object GetDecoratedProxy(Object cls, Action decorator)
        {
            BeforeDecorator dec = new BeforeDecorator(cls, decorator);
            return ProxyFactory.Create(dec, cls.GetType());
        }
        

        public Object Invoke(Object proxy, System.Reflection.MethodInfo method, Object[] parameters) {

            // decorator logic
            decorator();

            // The actual method is invoked
            Object retVal = method.Invoke( clz, parameters );
                        
            return retVal;
        }
    }
}