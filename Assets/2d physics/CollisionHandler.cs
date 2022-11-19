using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D (  )
    {
        Vector3 camPos = Camera.main.transform.position;
        if ( camPos. y<transform. position. y )
        {
            Camera. main. GetComponent<MoveCamera> ( ). targrtY=transform. position. y;
        }
    }
}
