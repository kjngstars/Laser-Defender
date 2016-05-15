using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    float speed = 15.0f;
    float xMin = 0, xMax = 0;
    float padding = 1.0f;
	// Use this for initialization
	void Start () {
        var distance = transform.position.z - Camera.main.transform.position.z;
        var leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xMin = leftMost.x + padding;
        xMax = rightMost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        var restrictX = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(restrictX, transform.position.y, transform.position.z);
	}
}
