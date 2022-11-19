using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    public bool hasLost = false;

    private void OnTriggerEnter2D (  )
    {
        hasLost=true;
    }

    private void OnGUI ( )
    {
        if ( hasLost)
        {
            GUI. color=Color. black;
            GUI.Label(new Rect(Screen.width/2-50,Screen.height/2-25,300,150),"Game Over");
           if( GUI.Button(new Rect ( Screen. width/2-50, Screen. height/2-25+55, 100 ,50), "Restart" ))
            {
                SceneManager. LoadScene ( "2d physics" );
            }
        }
    }
}
