using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialPowerupScript : MonoBehaviour
{
    //El jugador
    public Rigidbody2D player;
    //Variable para ver si el jugador ya ha visto el tutorial
    private bool tutorialEnabled = false;
    //Los botones de salto
    public GameObject left;
    public GameObject center;
    public GameObject right;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.attachedRigidbody == player.GetComponent<Rigidbody2D>()) && player.GetComponent<PlayerScript>().ground && !tutorialEnabled)
        {
            left.SetActive(false);
            center.SetActive(true);
            right.SetActive(false);
            tutorialEnabled = true;
        }
    }
}
