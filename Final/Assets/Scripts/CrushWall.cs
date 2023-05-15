using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushWall : MonoBehaviour
{
    public float speed = 1;
    public Rigidbody rb;
    public GameStats gameStats;

    private void FixedUpdate() {
        rb.velocity = new Vector3(0f,0f, +gameStats.wallSpeed);
    }
}
