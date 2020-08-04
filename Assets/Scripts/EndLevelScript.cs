using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class EndLevelScript : MonoBehaviour
{
    //El jugador
    public Rigidbody2D player;
    //El NPC lider
    public Rigidbody2D NPC1;
    //El otro NPC
    public Rigidbody2D NPC2;
    //El texto que se escribe al terminar el nivel
    public Text endText;
    //Variables para determinar si el jugador ha ganado o no
    bool playerWin, NPCWin;
    //El menu de final del nivel
    public GameObject endMenu;
    //boton de proximo nivel
    public GameObject nextLevel;


    private void OnTriggerStay2D(Collider2D collision)
    {
        //Cuando el que llega al final es el jugador miramos si algun NPC ha llegado antes. Si es asi mostramos el texto de derrota y si llega el primero mostramos el texto de victoria
        if ((collision.attachedRigidbody == player.GetComponent<Rigidbody2D>()) && player.GetComponent<PlayerScript>().ground)
        {
            player.GetComponent<PlayerScript>().ended = true;
            if (!NPCWin)
            {
                if (!playerWin)
                {
                    playerWin = true;
                    if (PlayerPrefs.GetInt("Language") == 0) endText.text = "Has ganado, ¡enhorabuena!";
                    else if (PlayerPrefs.GetInt("Language") == 1) endText.text = "You won, congratulations!";
                    else if (PlayerPrefs.GetInt("Language") == 2) endText.text = "Irabazi duzu, zorionak!";
                    if (NPC1.GetComponent<NPCScript>().playingLevel != 29) nextLevel.SetActive(true);
                    if ((PlayerPrefs.GetInt("Lvl") < (NPC1.GetComponent<NPCScript>().playingLevel + 1)) && (NPC1.GetComponent<NPCScript>().playingLevel < 30))
                    {
                        PlayerPrefs.SetInt("Lvl", NPC1.GetComponent<NPCScript>().playingLevel + 1);
                        AnalyticsEvent.LevelComplete("level_index", NPC1.GetComponent<NPCScript>().playingLevel + 1);
                    }
                    if (NPC1.GetComponent<NPCScript>().playingLevel == 30)
                    {
                        PlayerPrefs.SetInt("Tutorial", 1);
                    }
                    AdController.instance.ShowVideoOrINterstitialAD();
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Language") == 0) endText.text = "Has perdido, la proxima vez será.";
                else if (PlayerPrefs.GetInt("Language") == 1) endText.text = "You lost, you will do it the next time.";
                else if (PlayerPrefs.GetInt("Language") == 2) endText.text = "Galdu duzu, hurrengoan lortuko duzu.";
            }
            endMenu.SetActive(true);
        }
        //Cuando el que llega es un NPC marcamos que ha llegado y si el jugador no ha llegado todavia se marca que el ganador es un NPC
        if ((collision.attachedRigidbody == NPC1.GetComponent<Rigidbody2D>()) && NPC1.GetComponent<NPCScript>().ground && NPC1.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            NPC1.GetComponent<NPCScript>().ended = true;
            if (!playerWin)
            {
                NPCWin = true;                
            }
            
        }
        if ((collision.attachedRigidbody == NPC2.GetComponent<Rigidbody2D>()) && NPC2.GetComponent<NPCScript>().ground && NPC2.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            NPC2.GetComponent<NPCScript>().ended = true;
            if (!playerWin)
            {
                NPCWin = true;
            }

        }
    }
}
