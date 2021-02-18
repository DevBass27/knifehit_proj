using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRotation : MonoBehaviour
{
    [SerializeField] float speed=0.1f;


    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
