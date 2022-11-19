using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    private void OnGUI ( )
    {
        GUI. color=Color. black;
        GUI. Label ( new Rect ( 0, 0, 300, 150 ), "Score:"+score );
    }
}
