using Nancy;
using Nancy.TinyIoc;
using CraigToDoList.Repository;

namespace CraigToDoList
{
    
    public class ToDoListBootstrapper : DefaultNancyBootstrapper
    {

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Register<IToDoRepository, ToDoInMemoryRepository>();
        }

    }
}