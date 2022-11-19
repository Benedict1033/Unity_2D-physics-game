using System. Collections;
using System. Collections. Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public bool useSpring = false;

    Rigidbody2D grabbObject = null;
    SpringJoint2D springJoint = null;

    public float dragSpeed=4;

    public LineRenderer dragLine;

    float velocityRatio =4;

    private void Update ( )
    {
        if ( Input. GetMouseButtonDown ( 0 ) )
        {
            Vector3 mouseWorldPos3D =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D =new Vector2(mouseWorldPos3D.x,mouseWorldPos3D.y);

            Vector2 dir =Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D,dir);

            if ( hit. collider!=null )
            {

                if ( hit. collider. attachedRigidbody!=null )
                {
                  
                    grabbObject=hit. collider. attachedRigidbody;
                    if ( useSpring )
                    {
                        springJoint=grabbObject. gameObject. AddComponent<SpringJoint2D> ( );
                        Vector3 localHItPoint = grabbObject.transform.InverseTransformPoint(hit.point);
                        springJoint. anchor=localHItPoint;
                        springJoint. connectedAnchor=mouseWorldPos3D;
                        springJoint. distance=0.25f;
                        springJoint. dampingRatio=1;
                        springJoint. frequency=5;

                        springJoint. enableCollision=true;

                        springJoint. connectedBody=null;
                    }
                    else
                    {
                        grabbObject. gravityScale=0;
                    }

                    dragLine. enabled=true;
                }
            }

        }

        if ( Input. GetMouseButtonUp ( 0 )&&grabbObject!=null )
        {
            if ( useSpring )
            {
                Destroy ( springJoint );
      
                springJoint. connectedBody=null;
            }
            else
            {
                grabbObject. gravityScale=1;
            }

            grabbObject=null;
            dragLine. enabled=false;
        }

        if ( springJoint!=null )
        {
            Vector3 mouseWorldPos3D =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            springJoint. connectedAnchor=mouseWorldPos3D;
        }
    }

    private void FixedUpdate ( )
    {
        if ( grabbObject!=null )
        {
            Vector2 mouseWorldPos2D =Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if ( useSpring )
            {
                springJoint. connectedAnchor=mouseWorldPos2D;
            }
            else
            {
                grabbObject. velocity=( mouseWorldPos2D-grabbObject. position )*velocityRatio;
            }
           
           

        }
    }

    private void LateUpdate ( )
    {
        if ( grabbObject!=null )
        {
            if ( useSpring )
            {
                Vector3 worldAnchor =grabbObject.transform.TransformPoint(springJoint.anchor);
                dragLine. SetPosition ( 0, new Vector3 ( worldAnchor. x, worldAnchor. y, -1 ) );
                dragLine. SetPosition ( 1, new Vector3 ( springJoint. connectedAnchor. x, springJoint. connectedAnchor. y, -1 ) );
            }
            else
            {
                Vector3 mouseWorldPos3D =Camera.main.ScreenToWorldPoint(Input.mousePosition);
                dragLine. SetPosition ( 0, new Vector3 ( grabbObject.position. x, grabbObject. position.y, -1 ) );
                dragLine. SetPosition ( 1, new Vector3 ( mouseWorldPos3D. x, mouseWorldPos3D. y, -1 ) );
            }

           
        }

    }
}
