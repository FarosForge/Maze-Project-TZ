using UnityEngine;
using System.Collections;
using PLAYER;

public class RayScan
{

	private int distance = 10;

	private Vector3 pos, forward;
	private Ray ray;

    public RayScan(Transform transform, Transform target)
    {
        this.transform = transform;
        this.target = target;
    }

    public Transform transform { get; private set; }
	public Transform target { get; private set; }

	public bool CheckViewSpace()
    {
		pos = target.position - transform.position;
		forward = transform.TransformDirection(Vector3.forward);
		ray = new Ray(transform.position, pos.normalized);
		
		if (Vector3.Dot(forward, pos) > 0)
        {
			if (Physics.Raycast(ray, out RaycastHit hit, distance))
            {
				if (hit.collider.GetComponent<PlayerView>())
				{
					return true;
				}
			}
		}

		return false;
    }
}