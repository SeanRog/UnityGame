using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
	[SerializeField] private float deltaTimeMove = 0.0125f;
	[SerializeField] private float moveDistance = 0.0125f;

	[SerializeField] private Rigidbody2D circleRedObject;

	[SerializeField] private float previousTimeMove = 0.0f;
	// Start is called before the first frame update
	void Start()
	{
		previousTimeMove = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		moveCurrentCircleIfShouldMove();

	}

	private void moveCurrentCircleIfShouldMove()
	{
		if (Time.time - deltaTimeMove < previousTimeMove)
		{
			return;
		}
		if (circleRedObject == null)
		{
			Debug.Log("circleRedObject is null");
			return;
		}
		circleRedObject.isKinematic = true;
		Vector3 originalPosition = circleRedObject.position;
		Vector3 newPosition = originalPosition + new Vector3(moveDistance, 0f, 0f);
		circleRedObject.position = newPosition;

		previousTimeMove = Time.time;
	}


}
