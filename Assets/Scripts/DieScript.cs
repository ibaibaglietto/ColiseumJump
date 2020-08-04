using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieScript : MonoBehaviour
{
    //El rigidbody del jugador
    public Rigidbody2D player;
    //El menu de final del nivel
    public GameObject endMenu;
    //El texto que se escribe al terminar el nivel
    public Text endText;
    //boton de proximo nivel
    public GameObject nextLevel;
    public GameObject puntuacion;
    public GameObject top10;

    public EndlessController endController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == player && endMenu.activeSelf==false)
        {
            AdController.instance.ShowVideoOrINterstitialAD();
            if (PlayerPrefs.GetInt("Language") == 0) endText.text = "Puntuación final: " + endController.plat.ToString();
            else if (PlayerPrefs.GetInt("Language") == 1) endText.text = "Final score: " + endController.plat.ToString();
            else if (PlayerPrefs.GetInt("Language") == 2) endText.text = "Puntuazio finala: " + endController.plat.ToString();
            if (PlayerPrefs.GetInt("lastScore") < endController.plat) top10.SetActive(true);
            endMenu.SetActive(true);
            nextLevel.SetActive(false);
            puntuacion.SetActive(false);
        }
    }
}
