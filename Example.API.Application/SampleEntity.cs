namespace Example.API.Application;

public class SampleEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public SampleEntity(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
