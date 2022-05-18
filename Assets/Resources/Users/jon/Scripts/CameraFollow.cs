using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] Vector3 offset;
	[SerializeField, Range(1, 10)] public float smoothFactor;

	private void FixedUpdate()
	{
		Follow();
	}

	void Follow()
	{
		Vector3 targetPosition = target.position + offset;
		Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
		transform.position = smoothPosition;
	}
}