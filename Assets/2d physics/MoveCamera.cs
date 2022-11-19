using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float targrtY = 0 ;

    private void Update ( )
    {
        Vector3 pos
            =transform.position;

        pos. y=Mathf. Lerp ( transform. position. y, targrtY, 1*Time. deltaTime );
        transform. position=pos;
    }
}
