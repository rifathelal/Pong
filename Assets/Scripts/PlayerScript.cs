using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float moveSpeed;

    void Start()
    {
        
    }


    void Update() {
        float direction = Input.GetAxisRaw("Vertical");
        if (direction * transform.position.y < 4)
            transform.position = transform.position + (Vector3.up * direction * moveSpeed * Time.deltaTime);
    }
}
