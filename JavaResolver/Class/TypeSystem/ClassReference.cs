using JavaResolver.Class.Constants;

namespace JavaResolver.Class.TypeSystem
{
    public class ClassReference
    {
        private readonly LazyValue<string> _name;

        public ClassReference(string name)
        {
            _name = new LazyValue<string>(name);
        }

        internal ClassReference(JavaClassFile classFile, ClassInfo classInfo)
        {
            _name = new LazyValue<string>(() =>
                classFile.ConstantPool.ResolveString(classInfo.NameIndex) ?? $"<<<INVALID({classInfo.NameIndex})>>>");
        }
        
        public string Name
        {
            get => _name.Value;
            set => _name.Value = value;
        }
    }
}