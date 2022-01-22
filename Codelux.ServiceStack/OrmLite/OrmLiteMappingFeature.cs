﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ServiceStack;

namespace Codelux.ServiceStack.OrmLite
{
    public class OrmLiteMappingFeature : IPlugin
    {
        public void Register(IAppHost appHost)
        {
            Type baseType = typeof(IOrmLiteMapping);
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                try
                {
                    List<Type> typeList = assembly.GetTypes().Where(type =>
                        type != baseType && !type.IsAbstract && baseType.IsAssignableFrom(type)).ToList();
                    foreach (Type type in typeList)
                        Activator.CreateInstance(type);
                }
                catch
                {

                }
            }
        }
    }
}
