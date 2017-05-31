using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{

    public GameObject particle;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
            SpawnParticle();

    }

    void SpawnParticle()
    {

        // Where should we spawn Bob?
        Vector3 clickPosition =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        clickPosition.z = 0;

        // Now we can actually spawn a bob object
        Instantiate(particle, clickPosition, Quaternion.identity);

    }
}