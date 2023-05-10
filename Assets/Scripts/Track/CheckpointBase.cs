using System;
using UnityEngine;

public abstract class CheckpointBase : MonoBehaviour, ICheckpoint
{

    [SerializeField] private float width;
    [SerializeField] private Transform leftPole; 
    [SerializeField] private Transform rightPole;
    [SerializeField] private Transform topPart;
    
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

    private void OnValidate()
    {
        if (!leftPole || !rightPole || !topPart) return;
          
        leftPole.localPosition = new Vector3(-width / 2, 2, 0);
        rightPole.localPosition = new Vector3(width / 2, 2, 0);
        
        topPart.localScale = new Vector3(width, 1, 0.2f);

        BoxCollider collider = GetComponent<BoxCollider>();
        collider.size = new Vector3(width, 4, 0.1f);
    }

    public virtual event TriggerCheckpointHandler OnTriggerCheckpoint;
}