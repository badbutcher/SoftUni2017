using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS_OOP_Advanced_Exam_Prep_July_2016.Provider.Types
{
    public class TypeProvider : ITypeProvider
    {
        private IList<Assembly> assemblies;
        private List<Type> classes;

        private IDictionary<Type, IEnumerable<Type>>
            classesByAttribute;

        private IDictionary<Type, IDictionary<Type, IEnumerable<MethodInfo>>>
            methodsByAttribute;

        private IDictionary<Type, IEnumerable<Type>>
            subclasses;

        public TypeProvider(params Assembly[] assemblies)
        {
            this.methodsByAttribute = new Dictionary<Type, IDictionary<Type, IEnumerable<MethodInfo>>>();
            this.classesByAttribute = new Dictionary<Type, IEnumerable<Type>>();
            this.subclasses = new Dictionary<Type, IEnumerable<Type>>();
            this.classes = new List<Type>();
            this.assemblies = new List<Assembly>();
            foreach (var assembly in assemblies)
            {
                this.AddAssembly(assembly);
            }
        }

        public void AddAssembly(Assembly assembly)
        {
            this.classes.AddRange(assembly.GetTypes());
            this.assemblies.Add(assembly);
        }

        public IEnumerable<Type> GetClassesByAttribute(Type attributeType)
        {
            if (this.classesByAttribute.ContainsKey(attributeType))
            {
                return this.classesByAttribute[attributeType];
            }

            IEnumerable<Type> result = this.classes.Where(
                c => c.IsDefined(attributeType)
                );

            this.classesByAttribute[attributeType] = result;

            return result;
        }

        public IEnumerable<MethodInfo> GetMethodsByAttribute(Type fromClass, Type attributeType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Type> GetSubClasses(Type superType)
        {
            throw new NotImplementedException();
        }
    }
}
