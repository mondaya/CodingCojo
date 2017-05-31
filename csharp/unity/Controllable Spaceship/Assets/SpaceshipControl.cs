using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipControl : MonoBehaviour {

    float speed = 10f;
    // Use this for initialization
    void Start () {


		
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"), 0);

        // Update the ships position each frame
        transform.position += move
            * speed * Time.deltaTime;


    }
}
