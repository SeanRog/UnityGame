using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
	[SerializeField] private Rigidbody2D baseRed;
    [SerializeField] private GameObject circleRedPrefab;
    [SerializeField] private float deltaTimeSpawn = 1.0f;
    [SerializeField] private float deltaTimeMove = 0.0125f;
    [SerializeField] private float moveDistance = 0.0125f;

    private Rigidbody2D currentCircleRigidBody;
    [SerializeField] private float initialTimeSpawn = 0.0f;
    [SerializeField] private float initialTimeMove = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        initialTimeMove = Time.time;
        initialTimeSpawn = Time.time;
        SpawnNewCircle();
    }

    // Update is called once per frame
    void Update()
    {
        moveCurrentCircleIfShouldMove();
        SpawnNewCircleIfShouldSpawn();
    }

    private void moveCurrentCircleIfShouldMove() {
        if (Time.time - deltaTimeMove < initialTimeMove) {
            return;
        }
        if (currentCircleRigidBody == null) {
            return;
        }
        
        Vector3 originalPosition = currentCircleRigidBody.position;
        Vector3 newPosition = originalPosition + new Vector3(moveDistance, 0f, 0f);
        currentCircleRigidBody.position = newPosition;

        initialTimeMove = Time.time;
    }

    private void SpawnNewCircleIfShouldSpawn() {
        if (Time.time - deltaTimeSpawn < initialTimeSpawn) {
            return;
        }
        
        SpawnNewCircle();
        initialTimeSpawn = Time.time;
    }

    private void SpawnNewCircle() {
        GameObject circleInstance = Instantiate(circleRedPrefab, baseRed.position, Quaternion.identity);
        currentCircleRigidBody = circleInstance.GetComponent<Rigidbody2D>();
    }
}
