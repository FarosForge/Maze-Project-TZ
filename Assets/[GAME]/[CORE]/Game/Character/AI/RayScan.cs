using UnityEngine;
using System.Collections;
using PLAYER;

public class RayScan : MonoBehaviour
{
	[SerializeField] private int rays = 6;
	[SerializeField] private int distance = 15;
	[SerializeField] private float angle = 20;
	[SerializeField] private Vector3 offset;
	public Transform target { get; private set; }

	void Start()
	{
		target = FindObjectOfType<PlayerView>().transform;
		Debug.Log(target);
	}

	bool GetRaycast(Vector3 dir)
	{
		bool result = false;
		RaycastHit hit = new RaycastHit();
		Vector3 pos = transform.position + offset;
		if (Physics.Raycast(pos, dir, out hit, distance))
		{
			if (hit.transform == target)
			{
				result = true;
#if UNITY_EDITOR
				Debug.DrawLine(pos, hit.point, Color.green);
#endif
			}
			else
			{
#if UNITY_EDITOR

				Debug.DrawLine(pos, hit.point, Color.blue);
#endif
			}
		}
		else
		{
#if UNITY_EDITOR
			Debug.DrawRay(pos, dir * distance, Color.red);
#endif
		}
		return result;
	}

	public bool RayToScan()
	{
		bool result = false;
		bool a = false;
		bool b = false;
		float j = 0;
		for (int i = 0; i < rays; i++)
		{
			var x = Mathf.Sin(j);
			var y = Mathf.Cos(j);

			j += angle * Mathf.Deg2Rad / rays;

			Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
			if (GetRaycast(dir)) a = true;

			if (x != 0)
			{
				dir = transform.TransformDirection(new Vector3(-x, 0, y));
				if (GetRaycast(dir)) b = true;
			}
		}

		if (a || b) result = true;
		return result;
	}
}