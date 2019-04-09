using System;

namespace DynamicProxy
{

    public class MainClass
	{
        
		//[STAThread]
		static void Main( string[] args ) {
            Action dec = ()=>Console.WriteLine("bbbbbb");

            IMyClass myClass = new MyClass(Console.WriteLine);
            IMyClass myDecClass = (IMyClass) BeforeDecorator.GetDecoratedProxy( myClass, dec );
            
            myClass.Func1();
            myClass.Func2( 1, "2" );

            myDecClass.Func1();
            myDecClass.Func2(3,"4");
		}
	}

    public interface IMyClass 
    {
        void Func1();
        object Func2( object a, object b );
    }

    public class MyClass : IMyClass {

        private Action<string> _action;
        public MyClass(Action<string> action)
        {
            _action = action;
        }
        public void Func1() {
            _action( nameof(Func1) );
        }

        public object Func2( object a, object b ) {

            _action( nameof(Func2) );
            return null;
        }
    }
}