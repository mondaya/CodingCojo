using UnityEngine;
using System.Collections;

public class HandleCollision : MonoBehaviour
{

    public AudioClip clip;

    void OnCollisionEnter2D(Collision2D coll)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);

    }
}
