using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showTutorial : MonoBehaviour
{
    //El jugador
    public Rigidbody2D player;
    //Variable para ver si el jugador ya ha visto el tutorial
    private bool tutorialDisplayed = false;
    //Los textos del tutorial
    public GameObject tutorialMenu;
    public GameObject tutorialText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.attachedRigidbody == player.GetComponent<Rigidbody2D>()) && player.GetComponent<PlayerScript>().ground && !tutorialDisplayed)
        {
            tutorialMenu.SetActive(true);
            tutorialText.SetActive(true);
            tutorialDisplayed = true;
        }
    }
}
