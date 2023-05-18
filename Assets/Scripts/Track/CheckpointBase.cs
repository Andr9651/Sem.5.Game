using System;
using UnityEngine;

public abstract class CheckpointBase : MonoBehaviour, ICheckpoint
{
	[SerializeField] private float width;
	[SerializeField] private Transform leftPole;
	[SerializeField] private Transform rightPole;
	[SerializeField] private Transform topPart;

	public Transform Transform => gameObject.transform;
	
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

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Vector3 forwardPos = ((Component)this).transform.position + ((Component)this).transform.forward * 2;
		Gizmos.color = Color.red;
		Gizmos.DrawLine(((Component)this).transform.position, forwardPos);
		Gizmos.DrawSphere(forwardPos,0.1f);
	}
#endif

	public virtual event TriggerCheckpointHandler OnTriggerCheckpoint;
}