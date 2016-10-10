using Sefin.ApiTester.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.ApiTester
{
    public class RunnerManager
    {
        public List<RunnableMethod> Methods { get; private set; }

        Type[] _emptyTypes = new Type[0];

        public RunnerManager() {
            Methods = new List<RunnableMethod>();
        }

        public void Init() {
            Clear();
            ExploreAssembly(Assembly.GetEntryAssembly());
        }

        private void ExploreAssembly(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes()) {
                //if (type.GetInterfaces().Any(i => i == typeof(ITestApi))) {
                if (typeof(ITestApi).IsAssignableFrom(type)) { 
                    ExploreType(type);
                    continue;
                }

                var attrib = type.GetCustomAttribute<TestApiAttribute>();
                if (attrib != null) {
                    ExploreType(type, attrib.Label);
                    continue;
                } 
            }
        }

        private void ExploreType(Type type, string label = null)
        {
            bool hasEmtpyConstructor = type.GetConstructor(_emptyTypes) != null;

            var testMethods = type.GetMethods( )
                                    .Where(p => p.DeclaringType == type && p.GetParameters().Length == 0 );

            foreach (var method in testMethods) {
                if ((!hasEmtpyConstructor) && (!method.IsStatic)) continue;

                AddMethod(method);
            }


        }

        private void AddMethod(MethodInfo method)
        {
            Methods.Add(new RunnableMethod(method));
        }

        private void Clear()
        {
            //throw new NotImplementedException();
        }

    }


    public class RunnableMethod
    {
        public MethodInfo Method { get; protected set; }
        public string Label { get; private set; }

        public RunnableMethod(MethodInfo method)
        {
            Method = method;

            var attr = Method.GetCustomAttribute<TestApiAttribute>();

            var name = method.Name;
            if (attr != null)
            {
                name = attr.Label;
            }

            Label = String.Format("{0} ({1})", name, Method.DeclaringType.Name);
        }

        public object Execute()
        {
            object instance = null;
            if (!Method.IsStatic)
            {
                instance = Activator.CreateInstance(Method.DeclaringType);
            }

            return Method.Invoke(instance, Array.Empty<object>());
        }

        public override string ToString()
        {
            return Label;
        }
    }

}
