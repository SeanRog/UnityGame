using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRedHandler : MonoBehaviour
{
    [SerializeField] private GameObject circleRedObject;
		[SerializeField] private Rigidbody2D baseRed;
    [SerializeField] private float deltaTimeSpawn = 1.0f;
    [SerializeField] private float previousTimeSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNewCircle();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnNewCircleIfShouldSpawn();
    }

    private void SpawnNewCircleIfShouldSpawn() {
        if (Time.time - deltaTimeSpawn < previousTimeSpawn) {
            return;
        }
        
        SpawnNewCircle();
        previousTimeSpawn += deltaTimeSpawn;
    }

    private void SpawnNewCircle() {
        GameObject circleInstance = Instantiate(circleRedObject, baseRed.position, Quaternion.identity);
        // currentCircleRigidBody = circleInstance.GetComponent<Rigidbody2D>();
    }
}
