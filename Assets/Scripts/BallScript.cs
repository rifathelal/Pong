using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public float moveSpeed;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        var rnd = new System.Random();
        direction = new Vector2(rnd.Next(0,2)*2 - 1, Random.value).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + direction * moveSpeed * Time.deltaTime;
        // print("Ball location: " + transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D col) {
        var speed = direction.magnitude;
        if (col.gameObject.tag == "Player") {
            var yForce = (col.GetContact(0).point.y - col.gameObject.transform.position.y);
            direction = new Vector3(-direction.x, direction.y + yForce, direction.z).normalized * speed * 1.01f;
        } else if (col.gameObject.tag == "Wall") {
            direction = new Vector3(direction.x, -direction.y, direction.z);
        }
    }
}
