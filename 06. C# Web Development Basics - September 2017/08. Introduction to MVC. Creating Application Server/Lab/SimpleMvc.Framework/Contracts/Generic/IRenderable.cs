namespace SimpleMvc.Framework.Contracts.Generic
{
    public interface IRenderable<TModel> : IRenderable
    {
        TModel Model { get; set; }
    }
}