using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCircle : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Vector2 To;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(To * 5f, ForceMode2D.Impulse);
        Destroy(GetComponent<PolygonCollider2D>());
    }
}
