using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS_OOP_Advanced_Exam_Prep_July_2016.Provider.Types
{
    public interface ITypeProvider
    {
        void AddAssembly(Assembly assembly);

        IEnumerable<Type> GetClassesByAttribute(Type attributeType);

        IEnumerable<MethodInfo> GetMethodsByAttribute(Type fromClass, Type attributeType);

        IEnumerable<Type> GetSubClasses(Type superType);
    }
}
