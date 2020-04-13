namespace Domain
{
    public class EntityModel: IEntityIdentity
    {
        public int? Id { get; }
        
        public EntityModel(int id)
        {
            Id = id;
        }
    }
}