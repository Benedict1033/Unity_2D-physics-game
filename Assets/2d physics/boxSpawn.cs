using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxSpawn : MonoBehaviour
{
    public GameObject [] boxPrefabs;

    public float fireDelay =3f;

    public float nextFire =1f;

    public float fireVelocity =10;

    private void FixedUpdate ( )
    {
        if ( GameObject. FindObjectOfType<DeathTrigger> ( ). hasLost )
        {
            return;
        }

        nextFire-=Time. deltaTime;

        if ( nextFire<=0 )
        {
            nextFire=fireDelay;

            GameObject boxGo = (GameObject) Instantiate(boxPrefabs[Random.Range(0,boxPrefabs.Length)],transform.position,transform.rotation);

            boxGo. GetComponent<Rigidbody2D> ( ). velocity=transform. rotation*new Vector2 ( 0, fireVelocity );

            GameObject. FindObjectOfType<ScoreManager> ( ). score++;


        }
    }
}
