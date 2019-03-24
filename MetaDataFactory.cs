using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace DynamicProxy
{
    /// <summary>
    /// Factory class used to cache Types instances
    /// </summary>
    public class MetaDataFactory
    {
        private static IDictionary<string, Type> typeMap = new ConcurrentDictionary<string, Type>();

        /// <summary>
        /// Class constructor.  Private because this is a static class.
        /// </summary>
        private MetaDataFactory() { }

        ///<summary>
        /// Method to add a new Type to the cache, using the type's fully qualified
        /// name as the key
        ///</summary>
        ///<param name="interfaceType">Type to cache</param>
        public static void Add(Type interfaceType)
        {
            if(interfaceType == null)
                return;
            
            string interfaceTypeName = interfaceType.FullName;
            if(typeMap.ContainsKey(interfaceTypeName))
                return;
            
            typeMap.Add(interfaceTypeName, interfaceType);
        }

        ///<summary>
        /// Method to return the method of a given type at a specified index.
        ///</summary>
        ///<param name="name">Fully qualified name of the method to return</param>
        ///<param name="i">Index to use to return MethodInfo</param>
        ///<returns>MethodInfo</returns>
        public static MethodInfo GetMethod(string name, int i)
        {
            Type type = typeMap[name];
            MethodInfo[] methods = type.GetMethods();
            return (i < methods.Length) ? methods[i] : null;
        }
    }
}