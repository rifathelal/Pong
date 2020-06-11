using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed;
    public Transform ball;

    private Vector3 lastPosition;
    private float nextLocation = 0;
    private bool nextLocKnown = false;
    private float height;
    private float offset;
    private float ballRadius;

    // Start is called before the first frame update
    void Start()
    {
        height = GetComponent<BoxCollider2D>().size.y / 2f;
        offset = height / 2f;
        ballRadius = ball.GetComponent<CircleCollider2D>().bounds.size.y / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = ball.position - lastPosition;
        if (velocity.x > 0 && !nextLocKnown) {
            var posY = ball.position.y + ((transform.position.x - ball.position.x) / velocity.x) * velocity.y;
            while (Mathf.Abs(posY) > 5-ballRadius) {
                posY = Mathf.Sign(posY)*2*(5-ballRadius) - posY;
            }
            if (!nextLocKnown) nextLocation = posY;
            else nextLocation = (nextLocation + posY)/2f;
            nextLocKnown = true;
        }

        if (velocity.x < 0) nextLocKnown = false;

        if (nextLocKnown && (nextLocation < transform.position.y - offset || nextLocation > transform.position.y + offset)) {
            var moveDirection = Vector3.up * Mathf.Sign(nextLocation - transform.position.y);
            if (moveDirection.y * transform.position.y < 4)
                transform.position = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        }

        lastPosition = ball.position;
    }
}
