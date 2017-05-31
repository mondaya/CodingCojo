using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{

    float speed = 10f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // What is the player doing with the controls?
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"), 0);

        // Update the bat position each frame
        transform.position += move
            * speed * Time.deltaTime;

    }
}
