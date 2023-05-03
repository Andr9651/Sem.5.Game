public interface ICheckpoint
{
    public event TriggerCheckpointHandler OnTriggerCheckpoint;

    public void SetId(int id);
}
//defines a method signature that can be used on trigger checkpoint events
public delegate void TriggerCheckpointHandler(int id); 

