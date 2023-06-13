using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    [SerializeField] private float deltaTimeMove = 0.0125f;
    [SerializeField] private float moveDistance = 0.0125f;
    [SerializeField] private Rigidbody2D thisUnit;
    [SerializeField] private float previousTimeMove = 0.0f;

	private float objStartTime;
    private float objElapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        objStartTime = Time.time;
        objElapsedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        objElapsedTime = Time.time - objStartTime;
        moveThisUnitIfShouldMove();
    }

    public void moveThisUnitIfShouldMove() {
        if (objElapsedTime - deltaTimeMove < previousTimeMove) {
            return;
        }
        Vector3 originalPosition = thisUnit.position;
        Vector3 newPosition = originalPosition + new Vector3(moveDistance, 0f, 0f);
        thisUnit.position = newPosition;
        
        previousTimeMove += deltaTimeMove;
    }
}