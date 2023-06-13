using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRedHandler : MonoBehaviour
{
    [SerializeField] private GameObject circleRedObject;
    [SerializeField] private GameObject triangleRedObject;
    [SerializeField] private Rigidbody2D baseRed;
    [SerializeField] private float deltaTimeSpawn = 1.0f;
    [SerializeField] private float previousTimeSpawn = 0.0f;

	private int spawnCount = 0;
		
    void Start()
    {
        SpawnNewCircle();
    }

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
        if (spawnCount % 3 == 0) {
            GameObject circleInstance = Instantiate(circleRedObject, baseRed.position, Quaternion.identity);
            circleInstance.tag = "CircleRed";
            SpriteRenderer circleSprite = circleInstance.GetComponent<SpriteRenderer>();
            circleSprite.color = Color.yellow;

        } else if (spawnCount % 3 == 1){
            GameObject triangleInstance = Instantiate(triangleRedObject, baseRed.position, Quaternion.identity);
        } else {
            GameObject squareInstance = Instantiate(triangleRedObject, baseRed.position, Quaternion.identity);
            SpriteRenderer sqaureSprite = squareInstance.GetComponent<SpriteRenderer>();
            sqaureSprite.sprite = Sprite.Create(new Texture2D(100, 75), new Rect(0, 0, 100, 75), Vector2.one * 0.5f);
            sqaureSprite.color = Color.blue;
        }
        spawnCount++;
    }
}
