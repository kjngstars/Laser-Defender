using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    enum Direction
    {
        left,
        right
    }

    public GameObject enemyPrefab;

    public float width = 10.0f;
    public float height = 5.0f;

    public float speed = 5.0f;
    Direction direction = Direction.right;

    float xMin = 0, xMax = 0;
    
	// Use this for initialization
    void Start()
    {

        foreach (Transform item in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, item.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = item.transform;
        }

        var distance = transform.position.z - Camera.main.transform.position.z;
        var leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xMin = leftMost.x;
        xMax = rightMost.x;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

	// Update is called once per frame
	void Update () {

        restrictMoving();
        if (direction == Direction.right) 
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
	}

    void restrictMoving()
    {
        if (transform.position.x < (xMin + width/2))
        {
            direction = Direction.right;
        }
        else if (transform.position.x > (xMax - width/2)) 
        {
            direction = Direction.left;
        }
        
    }
}
