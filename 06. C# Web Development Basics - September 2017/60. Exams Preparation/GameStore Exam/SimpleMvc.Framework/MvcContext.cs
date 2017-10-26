namespace SimpleMvc.Framework
{
    public class MvcContext
    {
        private static MvcContext instance;

        private MvcContext()
        {
        }

        public static MvcContext Get => instance == null ? (instance = new MvcContext()) : instance;

        public string AssemblyName { get; set; }

        public string ResourcesFolder { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllersSuffix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }
    }
}