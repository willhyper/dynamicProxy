using System;

namespace DynamicProxy
{
    
	public class MainClass
	{
        
		//[STAThread]
		static void Main( string[] args ) {
            Action dec = ()=>Console.WriteLine("bbbbbb");

            IMyClass myClass = new MyClass();
            IMyClass myDecClass = (IMyClass) BeforeDecorator.GetDecoratedProxy( myClass, dec );
            
            myClass.TestFunctionOne();
            myClass.TestFunctionTwo( 1, "2" );

            myDecClass.TestFunctionOne();
            myDecClass.TestFunctionTwo(3,"4");
		}
	}

    public interface IMyClass 
    {
        void TestFunctionOne();
        Object TestFunctionTwo( Object a, Object b );
    }

    public class MyClass : IMyClass {
        public void TestFunctionOne() {
            Console.WriteLine( "In TestImpl.TestFunctionOne()" );
        }

        public Object TestFunctionTwo( Object a, Object b ) {

            Console.WriteLine( $"In TestImpl.TestFunctionTwo( {a},{b} )" );
            return null;
        }
    }
}