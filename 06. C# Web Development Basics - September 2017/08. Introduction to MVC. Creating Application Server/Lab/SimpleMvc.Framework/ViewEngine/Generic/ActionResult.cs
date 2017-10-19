namespace SimpleMvc.Framework.ViewEngine.Generic
{
    using System;
    using SimpleMvc.Framework.Interfaces.Generic;

    public class ActionResult<T> : IActionResult<T>
    {
        public ActionResult(string viewQualifedName, T model)
        {
            this.Action = (IRenderable<T>)Activator.CreateInstance(Type.GetType(viewQualifedName));

            this.Action.Model = model;
        }

        public IRenderable<T> Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}