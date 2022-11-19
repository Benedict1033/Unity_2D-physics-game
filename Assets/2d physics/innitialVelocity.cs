using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class innitialVelocity : MonoBehaviour
{
    public Vector3 initVelocity;

    Rigidbody2D rb;

    private void Start ( )
    {
        rb=this. gameObject. GetComponent<Rigidbody2D> ( );
        rb. velocity=initVelocity;
        
    }
}
