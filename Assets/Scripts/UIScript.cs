using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class UIScript : MonoBehaviour
{
    //El jugador
    public Rigidbody2D player;
    //El NPC lider
    public Rigidbody2D NPC1;
    //El otro NPC
    public Rigidbody2D NPC2;
    //La imagen que determina la posicion del NPC lider en x
    public Image NPCpos;
    //La imagen que determina la posicion del otro NPC en x
    public Image NPCpos2;
    //La imagen que determina la posicion del jugador en y
    public Image playerPos;
    //La imagen que determina la posicion del NPC lider en y
    public Image progPosNPC1;
    //La imagen que determina la posicion del otro NPC en y
    public Image progPosNPC2;
    //public Image shield;
    //public Image doubleJump;
    //public Image CanTrap;
    //Las imagenes que se usan en los botones para colocar trampas
    public Image TrapL;
    public Image TrapC;
    public Image TrapR;
    //Las imagenes que se usan en los botones para lanzar bolas de energia simple
    public Image EnergyL;
    public Image EnergyC;
    public Image EnergyR;
    //Las imagenes que se usan en los botones para lanzar bolas de energia oscura
    public Image DarkL;
    public Image DarkC;
    public Image DarkR;
    //La imagen de la niebla
    public Image FogOfWar;
    //La imagen del boton para activar la niebla
    public Image FogButton;
    //Los textos de los menús
    public Text continueP;
    public Text menuP;
    public Text restartP;
    public Text exitP;
    public Text menuE;
    public Text restartE;
    public Text exitE;
    public Text nextLevelE;
    public Text loadingM;
    public Text initials;
    public Text Hcongrats;
    public Text Hinitials;
    public Text Hsave;
    public EndlessController endController;
    public GameObject top10;
    public Button returnButton;
    //El nivel actual de la niebla
    public float fogLevel = 0.0f;
    //Varaible para getionar el tiempo que lleva activa la niebla
    private float fogTime;
    //Variable para mirar si el nivel esta pausado o no
    public bool Paused = false;
    //El menu de pausa
    public GameObject pauseMenu;
    //El audio source del nivel
    public AudioSource Source;
    //Lejania del NPC1 respecto al jugador por arriba
    private float topDiffNPC1;
    //Lejania del NPC1 respecto al jugador por abajo
    private float botDiffNPC1;
    //Lejania del NPC2 respecto al jugador por arriba
    private float topDiffNPC2;
    //Lejania del NPC2 respecto al jugador por abajo
    private float botDiffNPC2;
    //Tiempo en el que se ha empezado el nivel
    private float timeStart;
    //La cuenta atras
    public GameObject countdownMenu;
    //Texto donde se escriben la cuenta atras
    public Text countdown;
    //pantalla de carga
    public GameObject Loading;
    //imagen de doble salto
    public Image doubleJump;
    public Image doubleJumpShade;
    //animacion del boss
    public GameObject bossAnim;
    //Textos del tutorial
    public GameObject tutorial;
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial3;
    public GameObject tutorial4;
    public GameObject tutorial5;
    //Botones que se usan para saltar
    public GameObject left;
    public GameObject center;
    public GameObject right;


    private bool time1, time2, time3 = false;

    void Start()
    {        
        if (NPC1.GetComponent<NPCScript>().playingLevel < 30) AnalyticsEvent.LevelStart("level_index", NPC1.GetComponent<NPCScript>().playingLevel + 1);
        timeStart = Time.fixedTime;
        Paused = true;
        Source.Stop();
        if (PlayerPrefs.GetInt("Language") == 0)
        {
            continueP.text = "Continuar";
            menuP.text = "Menú";
            restartP.text = "Reiniciar";
            exitP.text = "Salir";
            menuE.text = "Menú";
            restartE.text = "Reiniciar";
            exitE.text = "Salir";
            nextLevelE.text = "Siguiente nivel";
            loadingM.text = "Cargando...";
            if (NPC1.GetComponent<NPCScript>().playingLevel == 31)
            {
                Hcongrats.text = "Has conseguido entrar en el top 10. \n¡Felicidades!";
                Hinitials.text = "3 iniciales";
                Hsave.text = "Guardar";
            }
        }
        else if (PlayerPrefs.GetInt("Language") == 1)
        {
            continueP.text = "Continue";
            menuP.text = "Menu";
            restartP.text = "Restart";
            exitP.text = "Exit";
            menuE.text = "Menu";
            restartE.text = "Restart";
            exitE.text = "Exit";
            nextLevelE.text = "Next level";
            loadingM.text = "Loading...";
            if (NPC1.GetComponent<NPCScript>().playingLevel == 31)
            {
                Hcongrats.text = "You entered the top 10. \nCongratulations!";
                Hinitials.text = "3 initials";
                Hsave.text = "Save";
            }
        }
        else if (PlayerPrefs.GetInt("Language") == 2) 
        {
            continueP.text = "Jarraitu";
            menuP.text = "Menua";
            restartP.text = "Berrabiatu";
            exitP.text = "Irten";
            menuE.text = "Menua";
            restartE.text = "Berrabiatu";
            exitE.text = "Irten";
            nextLevelE.text = "Hurrengo nibela";
            loadingM.text = "Kargatzen...";
            if (NPC1.GetComponent<NPCScript>().playingLevel == 31)
            {
                Hcongrats.text = "Top 10ean sartzea lortu duzu. \nZorionak!";
                Hinitials.text = "3 inizial";
                Hsave.text = "Gorde";
            }
        }
    }
   

    //Funcion para pausar el juego y reanudarlo
    public void PauseGame()
    {
        if (Paused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    //Funcion para reanudar el juego
    public void Resume()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        Source.volume *= 2.0f;
    }
    //Funcion para pausar el juego
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        Source.volume *= 0.5f;
    }
    //Funcion para volver al menu
    public void LoadMenu()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        Paused = false;
        Loading.SetActive(true);
        SceneManager.LoadScene(0);
    }
    //Funcion para reiniciar el nivel
    public void Retry()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        Paused = false;
        Loading.SetActive(true);
        SceneManager.LoadScene(NPC1.GetComponent<NPCScript>().playingLevel + 1);
    }
    //Funcion para ir al siguiente nivel
    public void NextLevel()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        Paused = false;
        Loading.SetActive(true);
        if (NPC1.GetComponent<NPCScript>().playingLevel != 30)
        {
            SceneManager.LoadScene(NPC1.GetComponent<NPCScript>().playingLevel + 2);
        }
        else SceneManager.LoadScene(1);


    }
    //Funcion para salir del juego
    public void QuitGame()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    //Funcion para actualizar la tabla de highscore
    public void UpdateHighscore()
    {
        HighScoreTableScript highScoreTableScript = new HighScoreTableScript();
        highScoreTableScript.AddHighScoreEntry(endController.plat, initials.text.ToUpper());
        top10.SetActive(false);
    }
    public void firstTutorial()
    {
        tutorial.SetActive(false);
        tutorial1.SetActive(false);
    }
    public void secondTutorial()
    {
        tutorial.SetActive(false);
        tutorial2.SetActive(false);
    }
    public void thirdTutorial()
    {
        tutorial.SetActive(false);
        tutorial3.SetActive(false);
    }
    public void fourthTutorial()
    {
        tutorial.SetActive(false);
        tutorial4.SetActive(false);
        center.SetActive(false);
        right.SetActive(false);
    }
    public void fifthTutorial()
    {
        tutorial.SetActive(false);
        tutorial5.SetActive(false);
        left.SetActive(true);
        center.SetActive(true);
        right.SetActive(true);
        timeStart = Time.fixedTime;
        countdownMenu.SetActive(true);
    }

    void Update()
    {
        if (NPC1.GetComponent<NPCScript>().playingLevel == 31)
        {
            if (initials.text.Length == 3)
            {
                returnButton.interactable = true;
            }
        }
        if (countdownMenu.activeSelf)
        { 
            if ((Time.fixedTime - timeStart < 3.0f))
            {
                Source.Stop();
                if (Time.fixedTime - timeStart < 1.0f)
                {
                    if (!time3)
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().Play();
                        time3 = true;
                    }
                    countdown.text = "3";

                }
                else if (Time.fixedTime - timeStart < 2.0f)
                {
                    if (!time2)
                    {
                        if (NPC1.GetComponent<NPCScript>().bossNumb != 0)
                            bossAnim.SetActive(true);
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().Play();
                        time2 = true;
                    }
                    countdown.text = "2";
                }
                else
                {
                    if (!time1)
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().Play();
                        time1 = true;
                    }
                    countdown.text = "1";
                }
            }
            else if ((Time.fixedTime - timeStart > 3.0f) && (Time.fixedTime - timeStart < 3.1f) && countdownMenu.activeSelf)
            {
                countdownMenu.SetActive(false);
                Source.Play();
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                Paused = false;
            }
        }
        //Valores actuales de anchura y altura de la pantalla
        float w = Screen.width;
        float h = Screen.height;
        topDiffNPC1 = NPC1.position.y - player.position.y;
        botDiffNPC1 = player.position.y - NPC1.position.y;
        topDiffNPC2 = NPC2.position.y - player.position.y;
        botDiffNPC2 = player.position.y - NPC2.position.y;

        if (player.GetComponent<PlayerScript>().doubleJump)
        {
            doubleJump.gameObject.SetActive(true);
            if (player.GetComponent<PlayerScript>().remainingJumps == 3) doubleJumpShade.GetComponent<Image>().fillAmount = 0;
            if (player.GetComponent<PlayerScript>().remainingJumps == 2 && doubleJumpShade.GetComponent<Image>().fillAmount < 0.33f)
                doubleJumpShade.GetComponent<Image>().fillAmount += 0.01f;
            if (player.GetComponent<PlayerScript>().remainingJumps == 1 && doubleJumpShade.GetComponent<Image>().fillAmount < 0.66f)
                doubleJumpShade.GetComponent<Image>().fillAmount += 0.01f;
        }
        else if(doubleJumpShade.GetComponent<Image>().fillAmount < 1.0f)
            doubleJumpShade.GetComponent<Image>().fillAmount += 0.01f;
        else doubleJump.gameObject.SetActive(false);
        
        if (Math.Abs(topDiffNPC1)> Math.Abs(topDiffNPC2))
        {
            if (NPCpos.transform.GetSiblingIndex() > NPCpos2.transform.GetSiblingIndex())
            {
                NPCpos.transform.SetSiblingIndex(NPCpos2.transform.GetSiblingIndex());
            }
        }
        else
        {
            if (NPCpos.transform.GetSiblingIndex() < NPCpos2.transform.GetSiblingIndex())
            {
                NPCpos2.transform.SetSiblingIndex(NPCpos.transform.GetSiblingIndex());
            }
        }

        //Controlamos que el NPC1 este dentro de la pantalla y si no es así lo dibujamos abajo o arriba en su X correspondiente y cambiando el tamaño según a la distancia a la que se encuentre
        if (topDiffNPC1 <= 7.9f && botDiffNPC1 <= 5.1f)
            NPCpos.enabled = false;
        else if (topDiffNPC1 > 7.9f)
        {
            NPCpos.enabled = true;
            NPCpos.rectTransform.anchoredPosition = new Vector3(NPC1.position.x * (110.0f / 1.85f) * (w/358), 268.5f * (h/637) , 0.0f);            
            NPCpos.transform.localScale = new Vector3(7.9f / (NPC1.position.y - player.position.y), 7.9f / (NPC1.position.y - player.position.y), 1.0f);
        }
        else if (botDiffNPC1 > 5.1f)
        {
            NPCpos.enabled = true;
            NPCpos.rectTransform.anchoredPosition = new Vector3(NPC1.position.x * (110.0f / 1.85f) * (w / 358), -268.5f * (h / 637), 0.0f);
            NPCpos.transform.localScale = new Vector3(5.1f/(player.position.y - NPC1.position.y), 5.1f / (player.position.y - NPC1.position.y), 1.0f);
        }
        //Controlamos que el NPC2 este dentro de la pantalla y si no es así lo dibujamos abajo o arriba en su X correspondiente y cambiando el tamaño según a la distancia a la que se encuentre
        if (topDiffNPC2 <= 7.9f && botDiffNPC2 <= 5.1f)
            NPCpos2.enabled = false;
        else if (topDiffNPC2 > 7.9f)
        {
            NPCpos2.enabled = true;
            NPCpos2.rectTransform.anchoredPosition = new Vector3(NPC2.position.x * (110.0f / 1.85f) * (w / 358), 268.5f * (h / 637), 0.0f);
            NPCpos2.transform.localScale = new Vector3(7.9f / (NPC2.position.y - player.position.y), 7.9f / (NPC2.position.y - player.position.y), 1.0f);
        }
        else if (botDiffNPC2 > 5.1f)
        {
            NPCpos2.enabled = true;
            NPCpos2.rectTransform.anchoredPosition = new Vector3(NPC2.position.x * (110.0f / 1.85f) * (w / 358), -268.5f * (h / 637), 0.0f);
            NPCpos2.transform.localScale = new Vector3(5.1f / (player.position.y - NPC2.position.y), 5.1f / (player.position.y - NPC2.position.y), 1.0f);
        }
        //Dibujamos la posicion en Y del jugador para que este sepa cuanto queda de nivel
        playerPos.rectTransform.anchoredPosition = new Vector3(playerPos.rectTransform.anchoredPosition.x, ((player.position.y + 3.1f)* 3.2f + 21.72f) * (h / 637), 0.0f);
        progPosNPC1.rectTransform.anchoredPosition = new Vector3(progPosNPC1.rectTransform.anchoredPosition.x, ((NPC1.position.y + 3.1f) * 3.2f + 21.72f) * (h / 637), 0.0f);
        if (NPC1.GetComponent<NPCScript>().bossNumb == 0)
        {
            progPosNPC2.gameObject.SetActive(true);
            progPosNPC2.rectTransform.anchoredPosition = new Vector3(progPosNPC2.rectTransform.anchoredPosition.x, ((NPC2.position.y + 3.1f) * 3.2f + 21.72f) * (h / 637), 0.0f);
        }
        /*if (player.GetComponent<PlayerScript>().shielded) shield.enabled = true;
    else shield.enabled = false;
    if (player.GetComponent<PlayerScript>().doubleJump) doubleJump.enabled = true;
    else doubleJump.enabled = false;
    if (player.GetComponent<PlayerScript>().canTrap) CanTrap.enabled = true;
    else CanTrap.enabled = false;*/
        //Si el jugador tiene el power up de trampa se activaran los botones siempre que en la fila de abajo en la columna correspondiente se disponga de una plataforma sin trampa
        if (player.GetComponent<PlayerScript>().canTrap && player.GetComponent<PlayerScript>().numPlat >= 2 && player.GetComponent<PlayerScript>().ground)
        {
            if (NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, player.GetComponent<PlayerScript>().numPlat - 2, 0] == 1) TrapL.enabled = true;
            else TrapL.enabled = false;
            if (NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, player.GetComponent<PlayerScript>().numPlat - 2, 1] == 1) TrapC.enabled = true;
            else TrapC.enabled = false;
            if (NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, player.GetComponent<PlayerScript>().numPlat - 2, 2] == 1) TrapR.enabled = true;
            else TrapR.enabled = false;
        }
        else
        {
            TrapL.enabled = false;
            TrapC.enabled = false;
            TrapR.enabled = false;
        }
        //Si el jugador tiene el power up de bola de energia simple y esta en el suelo se activara el boton de lanzar la bola en la columna en la que este el jugador
        if (player.GetComponent<PlayerScript>().energySimple && player.GetComponent<PlayerScript>().ground)
        {
            if (player.GetComponent<PlayerScript>().pos == 0) EnergyL.enabled = true;
            else EnergyL.enabled = false;
            if (player.GetComponent<PlayerScript>().pos == 1) EnergyC.enabled = true;
            else EnergyC.enabled = false;
            if (player.GetComponent<PlayerScript>().pos == 2) EnergyR.enabled = true;
            else EnergyR.enabled = false;
        }
        else
        {
            EnergyL.enabled = false;
            EnergyC.enabled = false;
            EnergyR.enabled = false;
        }
        //Si el jugador tiene el power up de bola de energia oscura y esta en el suelo se activara el boton de lanzar la bola en la columna en la que este el jugador
        if (player.GetComponent<PlayerScript>().darkEnergy && player.GetComponent<PlayerScript>().ground)
        {
            if (player.GetComponent<PlayerScript>().pos == 0) DarkL.enabled = true;
            else DarkL.enabled = false;
            if (player.GetComponent<PlayerScript>().pos == 1) DarkC.enabled = true;
            else DarkC.enabled = false;
            if (player.GetComponent<PlayerScript>().pos == 2) DarkR.enabled = true;
            else DarkR.enabled = false;
        }
        else
        {
            DarkL.enabled = false;
            DarkC.enabled = false;
            DarkR.enabled = false;
        }
        //Si el jugador tiene el power up de niebla y esta en el suelo se activara el boton de activar la niebla
        if (player.GetComponent<PlayerScript>().canFog && player.GetComponent<PlayerScript>().ground)
        {
            FogButton.enabled = true;
        }
        else FogButton.enabled = false;
        //Cuando el jugador sea afectado por la niebla 
        if (fogLevel > 0.0f)
        {
            //La niebla cambiará de posicion segun donde este el jugador, para que se le pueda ver a este pero no a su alrededor
            FogOfWar.rectTransform.anchoredPosition = new Vector3(player.position.x * (105.0f / 1.85f) * (w / 358), FogOfWar.rectTransform.anchoredPosition.y);
            //Con el paso del tiempo la opacidad de la niebla ira cambiando, primero se volvera opaca rapidamente, luego se quedara asi durante un segundo y luego se ira volviendo transparente poco a poco
            FogOfWar.color = new Color(FogOfWar.color.r, FogOfWar.color.g, FogOfWar.color.b, 1.0f - Math.Abs(1.0f - fogLevel));
            if (fogLevel > 1.0f)
            {
                fogLevel -= 0.03f;
                fogTime = Time.fixedTime;
            }
            else if ((Time.fixedTime - fogTime) > 1.0f)
                fogLevel -= 0.0025f;
        }
    }
}
