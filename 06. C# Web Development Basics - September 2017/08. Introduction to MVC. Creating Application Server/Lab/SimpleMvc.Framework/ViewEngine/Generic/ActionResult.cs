namespace SimpleMvc.Framework.ViewEngine.Generic
{
    using System;
    using SimpleMvc.Framework.Contracts.Generic;

    public class ActionResult<TModel> : IActionResult<TModel>
    {
        public ActionResult(string viewFullQualifedName, TModel model)
        {
            this.Action = (IRenderable<TModel>)Activator.CreateInstance(Type.GetType(viewFullQualifedName));

            this.Action.Model = model;
        }

        public IRenderable<TModel> Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}