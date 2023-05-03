using UnityEngine;

public abstract class CheckpointBase : MonoBehaviour, ICheckpoint
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        if (Id == 0)
        {
            Id = id;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerCheckpoint?.Invoke(Id);
    }

    public virtual event TriggerCheckpointHandler OnTriggerCheckpoint;
}