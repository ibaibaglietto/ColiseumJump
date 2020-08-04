using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //El canvas del nivel
    public GameObject canvas;
    public Rigidbody2D Player;
    float v;
    float dif;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //0.05 v min
    //0.125 v max

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canvas.GetComponent<UIScript>().Paused)
        {
            if ((Player.position.y - transform.position.y) > 20.0f)
            {
                dif = (Player.position.y - transform.position.y) / 15.0f;
            }
            else if ((Player.position.y - transform.position.y) < -2.75f) dif = 0.0f;
            else dif = 1.0f;
            if (Player.position.y < 70.0f) v = 0.05f;
            else if (Player.position.y < 140.0f) v = 0.06f;
            else if (Player.position.y < 210.0f) v = 0.07f;
            else if (Player.position.y < 280.0f) v = 0.08f;
            else if (Player.position.y < 350.0f) v = 0.09f;
            else if (Player.position.y < 420.0f) v = 0.10f;
            else if (Player.position.y < 490.0f) v = 0.11f;
            else if (Player.position.y < 560.0f) v = 0.12f;
            else if (Player.position.y < 780.0f) v = 0.121f;
            else if (Player.position.y < 1000.0f) v = 0.123f;
            else v = 0.125f;
            transform.position = new Vector2(transform.position.x, transform.position.y + v * dif);

        }
    }
}
