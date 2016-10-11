using Sefin.ApiTester.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            var currentAsm = Assembly.GetExecutingAssembly();
            ExploreAssembly(currentAsm);

            foreach (var asmName in currentAsm.GetReferencedAssemblies())
            {
                if (asmName.FullName.StartsWith("System")) continue;
                if (asmName.FullName.StartsWith("mscor")) continue;
                ExploreAssembly(Assembly.Load(asmName));
            }
        }

        private void ExploreAssembly(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes()) {
                //if (type.GetInterfaces().Any(i => i == typeof(ITestApi))) {
                if (typeof(ITestApi).IsAssignableFrom(type)) { 
                    ExploreType(type);
                    continue;
                }

                var attrib = type.GetCustomAttribute<CategoryAttribute>();
                if (attrib != null && "Test".Equals(attrib.Category, StringComparison.CurrentCultureIgnoreCase))
                {
                    string name = null;
                    var descrAttribute = type.GetCustomAttribute<DescriptionAttribute>();
                    if (descrAttribute != null)
                        name = descrAttribute.Description;

                    ExploreType(type, name);
                    continue;
                }

                var testAttrib = type.GetCustomAttribute<TestApiAttribute>();
                if (testAttrib != null)
                {
                    ExploreType(type, testAttrib.Label);
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

        public string TypeDescription { get; private set; }


        public RunnableMethod(MethodInfo method, string categoryLabel = null)
        {
            Method = method;

            TypeDescription = categoryLabel ?? Method.DeclaringType.Name;

            var name = method.Name;
            var descrAttribute = Method.GetCustomAttribute<DescriptionAttribute>();
            if (descrAttribute != null)
            {
                name = descrAttribute.Description;
            }

            var attr = Method.GetCustomAttribute<TestApiAttribute>();
            if (attr != null)
            {
                name = attr.Label;
            }

            Label = String.Format("{0} ({1})", name, TypeDescription);
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
