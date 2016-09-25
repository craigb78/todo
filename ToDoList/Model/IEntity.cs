namespace CraigToDoList.Model
{
  
    /// <summary>
    /// Something with an identity (that is persisted).
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }

}