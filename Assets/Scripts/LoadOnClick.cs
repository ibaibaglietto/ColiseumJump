using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour
{

    public GameObject LevelSelect;
    public GameObject Configuration;
    public GameObject Loading;
    public AudioMixer mixer;
    public GameObject Tutorial;
    public GameObject Endless;
    public GameObject EndlessMenu;
    public GameObject Highscore;
    public GameObject Basis;
    public GameObject PowerUps;
    public GameObject Prev;
    public GameObject Next;
    public GameObject FPrev;
    public GameObject FNext;
    public GameObject CPrev;
    public GameObject CNext;
    public GameObject FImg1;
    public GameObject FImg2;
    public GameObject Shield;
    public GameObject DoubleJump;
    public GameObject EnergyBall;
    public GameObject Trap;
    public GameObject Fog;
    public GameObject DarkEnergyBall;
    public GameObject Credits;
    public Text Basis1;
    public Text Basis2;
    int targetFloor;
    int actualFloor;
    float floorPos;
    public Text history;
    public Text endless;
    public Text configuration;
    public Text credits;
    public Text exit;
    public Text configurationMenu;
    public Text language;
    public Text sound;
    public Text master;
    public Text music;
    public Text effects;
    public Text backConf;
    public Text howToPlay;
    public Text backHTP;
    public Text HTP;
    public Text HTPbasis;
    public Text HTPendless;
    public Text HTPpowerUps;
    public Text HTPtutorial;
    public Text BTitle;
    public Text BText1;
    public Text BText2;
    public Text BReturn;
    public Text ETitle;
    public Text EText;
    public Text EReturn;
    public Text PTitle;
    public Text PShield;
    public Text PDoubleJump;
    public Text PEnergyBall;
    public Text PTrap;
    public Text PFog;
    public Text PDarkEnergyBall;
    public Text PReturn;
    public Text EMTitle;
    public Text EMPlay;
    public Text EMLeaderBoards;
    public Text EMReturn;
    public Text STitle;
    public Text SText;
    public Text SReturn;
    public Text DTitle;
    public Text DText;
    public Text DReturn;
    public Text EBTitle;
    public Text EBText;
    public Text EBReturn;
    public Text TTitle;
    public Text TText;
    public Text TReturn;
    public Text FTitle;
    public Text FText1;
    public Text FText2;
    public Text FReturn;
    public Text DETitle;
    public Text DEText;
    public Text DEReturn;
    public Text CTitle;
    public Text CText1;
    public Text CText2;
    public Text CReturn;
    public Text Lvl1;
    public Text Lvl2;
    public Text Lvl3;
    public Text Lvl4;
    public Text Lvl5;
    public Text Lvl6;
    public Text Lvl7;
    public Text Lvl8;
    public Text Lvl9;
    public Text Lvl10;
    public Text Lvl11;
    public Text Lvl12;
    public Text Lvl13;
    public Text Lvl14;
    public Text Lvl15;
    public Text Lvl16;
    public Text Lvl17;
    public Text Lvl18;
    public Text Lvl19;
    public Text Lvl20;
    public Text Lvl21;
    public Text Lvl22;
    public Text Lvl23;
    public Text Lvl24;
    public Text Lvl25;
    public Text Lvl26;
    public Text Lvl27;
    public Text Lvl28;
    public Text Lvl29;
    public Text Lvl30;
    public Text f1;
    public Text f2;
    public Text f3;
    public Text f4;
    public Text f5;
    public Text f6;
    public Text b1;
    public Text b2;
    public Text b3;
    public Text b4;
    public Text b5;
    public Text b6;
    public Text loadingM;
    public Text highscoreTitle;
    public Text pointsTitle;
    public Text nameTitle;
    public Text Hreturn;

    public GameObject floor2;
    public GameObject floor3;
    public GameObject floor4;
    public GameObject floor5;
    public GameObject floor6;
    public GameObject selectLanguageMenu;
    public Text selectLanguageText;
    public Text saveLanguage;

    private float h = Screen.height;

    void Start()
    {
        if (!PlayerPrefs.HasKey("languageSelected"))
        {
            selectLanguageMenu.SetActive(true);
        }
        HighScoreTableScript highScoreTableScript = new HighScoreTableScript();

        if (!PlayerPrefs.HasKey("highscoreTable"))
        {
            string json = JsonUtility.ToJson("");
            PlayerPrefs.SetString("highscoreTable", json);
            highScoreTableScript.AddHighScoreEntry(1000, "GOD");
            highScoreTableScript.AddHighScoreEntry(800, "IBA");
            highScoreTableScript.AddHighScoreEntry(720, "ACL");
            highScoreTableScript.AddHighScoreEntry(600, "AIT");
            highScoreTableScript.AddHighScoreEntry(420, "JUL");
            highScoreTableScript.AddHighScoreEntry(300, "IZA");
            highScoreTableScript.AddHighScoreEntry(200, "XAB");
            highScoreTableScript.AddHighScoreEntry(100, "AND");
            highScoreTableScript.AddHighScoreEntry(50, "JOE");
            highScoreTableScript.AddHighScoreEntry(20, "JOS");
            PlayerPrefs.SetInt("lastScore", 20);
            PlayerPrefs.Save();
        }
        floor2.transform.GetComponent<RectTransform>().anchorMax = new Vector2(1, 2);
        floor2.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        floor2.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        floor3.transform.GetComponent<RectTransform>().anchorMax = new Vector2(1, 3);
        floor3.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0, 2);
        floor3.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        floor4.transform.GetComponent<RectTransform>().anchorMax = new Vector2(1, 4);
        floor4.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0, 3);
        floor4.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        floor5.transform.GetComponent<RectTransform>().anchorMax = new Vector2(1, 5);
        floor5.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0, 4);
        floor5.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        floor6.transform.GetComponent<RectTransform>().anchorMax = new Vector2(1, 6);
        floor6.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0, 5);
        floor6.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        targetFloor = 0;
        actualFloor = 0;
        floorPos = LevelSelect.transform.position.y;
        if (!PlayerPrefs.HasKey("Master")) PlayerPrefs.SetFloat("Master", 1);
        if (!PlayerPrefs.HasKey("Efects")) PlayerPrefs.SetFloat("Efects", 1);
        if (!PlayerPrefs.HasKey("Music")) PlayerPrefs.SetFloat("Music", 1);
        mixer.SetFloat("VolMaster", Mathf.Log10(PlayerPrefs.GetFloat("Master")) * 20);
        mixer.SetFloat("VolEfects", Mathf.Log10(PlayerPrefs.GetFloat("Efects")) * 20);
        mixer.SetFloat("VolMusic", Mathf.Log10(PlayerPrefs.GetFloat("Music")) * 20);        
    }
    public void LanguageSelected()
    {
        PlayerPrefs.SetInt("languageSelected", 1);
        selectLanguageMenu.SetActive(false);
    }

    //Funcion para abrir el selector de nivel
    public void LoadLevelSelector()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        if (PlayerPrefs.HasKey("Tutorial") || PlayerPrefs.HasKey("Lvl"))
        {
            LevelSelect.SetActive(true);
        }
        else
        {
            Loading.SetActive(true);
            SceneManager.LoadScene(31);
        }
    }
    //Funcion para abrir la configuracion
    public void LoadConfiguration()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Configuration.SetActive(true);
    }
    //Funcion para salir del selector de nivel
    public void ExitLevelSelector()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        LevelSelect.SetActive(false);
    }
    //Funcion para salir del selector de nivel
    public void ExitConfiguration()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Configuration.SetActive(false);
    }
    //Funcion para elegir el piso
    public void SelectFloor(int floor)
    {
        targetFloor = floor;
    }
    //Funcion para cargar una escena metiendole un int
    public void LoadScene(int level)
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Loading.SetActive(true);
        SceneManager.LoadScene(level);
    }
    //Funcion para abrir el tutorial
    public void LoadTutorial()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Tutorial.SetActive(true);
    }
    //Funcion para salir del tutorial
    public void ExitTutorial()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Tutorial.SetActive(false);
    }
    //Funcion para abrir el tutorial
    public void LoadBasis()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Basis.SetActive(true);
    }
    //Funcion para salir del tutorial
    public void ExitBasis()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Basis.SetActive(false);
    }
    //Funcion para pasar el texto
    public void NextBasis()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Basis1.enabled =false;
        Basis2.enabled = true;
        Next.SetActive(false);
        Prev.SetActive(true);
    }
    //Funcion para volver al anterior texto
    public void PrevBasis()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Basis1.enabled = true;
        Basis2.enabled = false;
        Next.SetActive(true);
        Prev.SetActive(false);
    }
    //Funcion para abrir el tutorial
    public void LoadEndless()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Endless.SetActive(true);
    }
    //Funcion para salir del tutorial
    public void ExitEndless()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Endless.SetActive(false);
    }
    //Funcion para abrir el modo sin fin
    public void LoadEndlessMenu()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        EndlessMenu.SetActive(true);
    }
    //Funcion para salir del modo sin fin
    public void ExitEndlessMenu()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        EndlessMenu.SetActive(false);
    }
    //Funcion para abrir la tabla de puntuaciones
    public void LoadHighscores()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Highscore.SetActive(true);
    }
    //Funcion para salir del modo sin fin
    public void ExitHighscores()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Highscore.SetActive(false);
    }
    //Funcion para abrir el tutorial
    public void LoadPowerUps()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        PowerUps.SetActive(true);
    }
    //Funcion para salir del tutorial
    public void ExitPowerUps()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        PowerUps.SetActive(false);
    }
    //Funcion para abrir el tutorial
    public void LoadShield()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Shield.SetActive(true);
    }
    //Funcion para salir del tutorial
    public void ExitShield()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Shield.SetActive(false);
    }
    //Funcion para abrir el tutorial
    public void LoadDoubleJump()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        DoubleJump.SetActive(true);
    }
    //Funcion para salir del tutorial
    public void ExitDoubleJump()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        DoubleJump.SetActive(false);
    }
    //Funcion para abrir el tutorial
    public void LoadEnegyBall()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        EnergyBall.SetActive(true);
    }
    //Funcion para salir del tutorial
    public void ExitEnergyBall()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        EnergyBall.SetActive(false);
    }
    //Funcion para abrir el tutorial
    public void LoadTrap()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Trap.SetActive(true);
    }
    //Funcion para salir del tutorial
    public void ExitTrap()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Trap.SetActive(false);
    }
    //Funcion para abrir el tutorial
    public void LoadFog()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Fog.SetActive(true);
    }
    //Funcion para salir del tutorial
    public void ExitFog()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Fog.SetActive(false);
    }
    //Funcion para pasar el texto
    public void NextFog()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        FText1.enabled = false;
        FText2.enabled = true;
        FImg1.SetActive(false);
        FImg2.SetActive(true);
        FNext.SetActive(false);
        FPrev.SetActive(true);
    }
    //Funcion para volver al anterior texto
    public void PrevFog()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        FText1.enabled = true;
        FText2.enabled = false;
        FImg1.SetActive(true);
        FImg2.SetActive(false);
        FNext.SetActive(true);
        FPrev.SetActive(false);
    }
    //Funcion para abrir el tutorial
    public void LoadDarkEnergyBall()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        DarkEnergyBall.SetActive(true);
    }
    //Funcion para salir del tutorial
    public void ExitDarkEnergyBall()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        DarkEnergyBall.SetActive(false);
    }
    //Funcion para abrir los creditos
    public void LoadCredits()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Credits.SetActive(true);
    }
    //Funcion para salir de los creditos
    public void ExitCredits()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Credits.SetActive(false);
    }
    //Funcion para pasar el texto
    public void NextCredits()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        CText1.enabled = false;
        CText2.enabled = true;
        CNext.SetActive(false);
        CPrev.SetActive(true);
    }
    //Funcion para volver al anterior texto
    public void PrevCredits()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        CText1.enabled = true;
        CText2.enabled = false;
        CNext.SetActive(true);
        CPrev.SetActive(false);
    }
    //Funcion para salir del juego
    public void QuitGame()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    void Update()
    {
        if (targetFloor > actualFloor)
        {
            
            if(floorPos- Mathf.Abs(targetFloor-actualFloor)* Screen.height == LevelSelect.transform.position.y)
            {
                floorPos = LevelSelect.transform.position.y;
                actualFloor = targetFloor;
            }
            else if (floorPos - Mathf.Abs(targetFloor - actualFloor) * Screen.height > (LevelSelect.transform.position.y - 30.0f))
            {
                LevelSelect.transform.position = new Vector2(LevelSelect.transform.position.x, LevelSelect.transform.position.y - (LevelSelect.transform.position.y - (floorPos - Mathf.Abs(targetFloor - actualFloor) * Screen.height)));
            }
            else LevelSelect.transform.position = new Vector2(LevelSelect.transform.position.x, LevelSelect.transform.position.y - 30.0f);
        }
        else if (targetFloor < actualFloor)
        {
            if (floorPos + Mathf.Abs(targetFloor - actualFloor)* Screen.height == LevelSelect.transform.position.y)
            {
                floorPos = LevelSelect.transform.position.y;
                actualFloor = targetFloor;
            }
            else if (floorPos + Mathf.Abs(targetFloor - actualFloor) * Screen.height < (LevelSelect.transform.position.y + 30.0f))
            {
                Debug.Log("ola");
                LevelSelect.transform.position = new Vector2(LevelSelect.transform.position.x, LevelSelect.transform.position.y + ((floorPos + Mathf.Abs(targetFloor - actualFloor) * Screen.height)- LevelSelect.transform.position.y));
            }
            else LevelSelect.transform.position = new Vector2(LevelSelect.transform.position.x, LevelSelect.transform.position.y + 30.0f);
        }
        if (PlayerPrefs.GetInt("Language") == 0)
        {
            history.text = "Historia";
            endless.text = "Sin fin";
            configuration.text = "Configuración";
            credits.text = "Créditos";
            exit.text = "Salir";
            configurationMenu.text = "Configuración";
            language.text = "Idioma";
            sound.text = "Sonido";
            master.text = "Maestro";
            music.text = "Música";
            effects.text = "Efectos";
            backConf.text = "Atrás";
            Lvl1.text = "Nivel 1";
            Lvl2.text = "Nivel 2";
            Lvl3.text = "Nivel 3";
            Lvl4.text = "Nivel 4";
            Lvl5.text = "Nivel 5";
            Lvl6.text = "Nivel 1";
            Lvl7.text = "Nivel 2";
            Lvl8.text = "Nivel 3";
            Lvl9.text = "Nivel 4";
            Lvl10.text = "Nivel 5";
            Lvl11.text = "Nivel 1";
            Lvl12.text = "Nivel 2";
            Lvl13.text = "Nivel 3";
            Lvl14.text = "Nivel 4";
            Lvl15.text = "Nivel 5";
            Lvl16.text = "Nivel 1";
            Lvl17.text = "Nivel 2";
            Lvl18.text = "Nivel 3";
            Lvl19.text = "Nivel 4";
            Lvl20.text = "Nivel 5";
            Lvl21.text = "Nivel 1";
            Lvl22.text = "Nivel 2";
            Lvl23.text = "Nivel 3";
            Lvl24.text = "Nivel 4";
            Lvl25.text = "Nivel 5";
            Lvl26.text = "Nivel 1";
            Lvl27.text = "Nivel 2";
            Lvl28.text = "Nivel 3";
            Lvl29.text = "Nivel 4";
            Lvl30.text = "Nivel 5";
            f1.text = "Piso 1";
            f2.text = "Piso 2";
            f3.text = "Piso 3";
            f4.text = "Piso 4";
            f5.text = "Piso 5";
            f6.text = "Piso 6";
            b1.text = "Volver";
            b2.text = "Volver";
            b3.text = "Volver";
            b4.text = "Volver";
            b5.text = "Volver";
            b6.text = "Volver";
            loadingM.text = "Cargando...";
            howToPlay.text = "Cómo jugar";
            backHTP.text = "Volver";
            HTP.text = "Cómo jugar";
            HTPbasis.text = "Bases";
            HTPendless.text = "Modo sin fin";
            HTPpowerUps.text = "Poderes";
            HTPtutorial.text = "Tutorial";
            BTitle.text = "Bases";
            BText1.text = "Al empezar un nivel verás una cuenta atrás, cuando esta se termine podrás empezar a jugar. Cuando empiece la carrera tendrás que elegir a que lado de la pantalla saltar tocando en ese sitio, pudiendo elegir entre la izquierda, el centro y la derecha. \nDeBerás esquivar los pinchos, ya que estos te dejarán dos segundos sin poder moverte.";
            BText2.text = "TamBién te podrás encontrar diferentes poderes esparcidos por el nivel, los cuales se irán desBloqueando al pasar de piso. Estos poderes podrán ser usados por los rivales tamBién. El oBjetivo principal será llegar al final del nivel antes que tus contrincantes. Podrás ver cuanto te falta a ti y a tus rivales en la Barra de la derecha, tamBién pudiendo ver su posición exacta en la parte de aBajo de la pantalla.";
            BReturn.text = "Volver";
            ETitle.text = "Modo sin fin";
            EText.text = "En este modo tu oBjetivo será llegar lo más alto posiBle mientras escapas de un extraño líquido. Las trampas te atraparán durante menos tiempo y solo dispondrás del escudo y del salto doBle.";
            EReturn.text = "Volver";
            PTitle.text = "Poderes";
            PShield.text = "Escudo";
            PDoubleJump.text = "SALTO DOBLE";
            PEnergyBall.text = "BOLA DE ENERGÍA";
            PTrap.text = "TRAMPA";
            PFog.text = "NIEBLA";
            PDarkEnergyBall.text = "BOLA DE ENERGÍA OSCURA";
            PReturn.text = "Volver";
            STitle.text = "Escudo";
            SText.text = "ESTE PODER TE PERMITIRÁ RECIBIR DAÑO UNA VEZ SIN QUE ESTE TE DEJE SIN PODER MOVERTE. \nESTE PODER ESTA DESBLOQUEADO DESDE EL PRINCIPIO DEL JUEGO.";
            SReturn.text = "Volver";
            DTitle.text = "SALTO DOBLE";
            DText.text = "ESTE PODER TE PERMITIRA REALIZAR UN SALTO EL DOBLE DE GRANDE DEL NORMAL.\nESTE PODER SE DESBLOQUEA AL PASAR AL SEGUNDO PISO.";
            DReturn.text = "Volver";
            EBTitle.text = "BOLA DE ENERGÍA";
            EBText.text = "ESTE PODER TE PERMITIRÁ LANZAR UNA BOLA DE ENERGÍA HACIA DELANTE, explotando al chocar contra un enemigo y dejandolo parado dos segundos. \nESTE PODER SE DESBLOQUEA AL PASAR EL SEGUNDO PISO.";
            EBReturn.text = "Volver";
            TTitle.text = "TRAMPA";
            TText.text = "ESTE PODER TE PERMITIRÁ PONER UNA TRAMPA EN UNA DE LAS PLATAFORMAS SIN TRAMPA DEL NIVEL INFERIOR. \nESTE PODER SE DESBLOQUEA AL PASAR EL TERCER PISO.";
            TReturn.text = "Volver";
            FTitle.text = "NIEBLA";
            FText1.text = "ESTE PODER TE PERMITIRÁ CEGAR A LOS ENEMIGOS POR TRES SEGUNDOS, HACIENDO QUE SALTEN DE FORMA ALEATORIA.";
            FText2.text = "SI ELLOS ACTIVAN EL PODER SOLO VERÁS A TU PERSONAJE POR TRES SEGUNDOS.\nESTE PODER SE DESBLOQUEA AL PASAR EL CUARTO PISO.";
            FReturn.text = "Volver";
            DETitle.text = "BOLA DE ENERGÍA \nOSCURA";
            DEText.text = "ESTE PODER TE PERMITIRÁ LANZAR UNA BOLA DE ENERGÍA HACIA DELANTE, PERO ESTA VEZ PERSEGUIRÁ AL RIVAL MÁS CERCANO, NO FALLANDO NUNCA. \nESTE PODER SE DESBLOQUEA AL PASAR EL QUINTO PISO.";
            DEReturn.text = "Volver";
            CTitle.text = "Créditos";
            CReturn.text = "Volver";
            EMTitle.text = "Modo sin fin";
            EMPlay.text = "Jugar";
            EMLeaderBoards.text = "TaBla de puntuaciones";
            EMReturn.text = "Volver";
            pointsTitle.text = "Puntos";
            nameTitle.text = "NomBre";
            Hreturn.text = "Volver";
            selectLanguageText.text = "Selecciona el idimoa en el que quieres jugar. Puedes cambiarlo cuando quieras en el menú de configuración.";
            saveLanguage.text = "Guardar";
        }
        else if (PlayerPrefs.GetInt("Language") == 1)
        {
            history.text = "Story";
            endless.text = "Endless";
            configuration.text = "Configuration";
            credits.text = "Credits";
            exit.text = "Exit";
            configurationMenu.text = "Configuration";
            language.text = "Language";
            sound.text = "Sound";
            master.text = "Master";
            music.text = "Music";
            effects.text = "Effects";
            backConf.text = "Back";
            Lvl1.text = "Level 1";
            Lvl2.text = "Level 2";
            Lvl3.text = "Level 3";
            Lvl4.text = "Level 4";
            Lvl5.text = "Level 5";
            Lvl6.text = "Level 1";
            Lvl7.text = "Level 2";
            Lvl8.text = "Level 3";
            Lvl9.text = "Level 4";
            Lvl10.text = "Level 5";
            Lvl11.text = "Level 1";
            Lvl12.text = "Level 2";
            Lvl13.text = "Level 3";
            Lvl14.text = "Level 4";
            Lvl15.text = "Level 5";
            Lvl16.text = "Level 1";
            Lvl17.text = "Level 2";
            Lvl18.text = "Level 3";
            Lvl19.text = "Level 4";
            Lvl20.text = "Level 5";
            Lvl21.text = "Level 1";
            Lvl22.text = "Level 2";
            Lvl23.text = "Level 3";
            Lvl24.text = "Level 4";
            Lvl25.text = "Level 5";
            Lvl26.text = "Level 1";
            Lvl27.text = "Level 2";
            Lvl28.text = "Level 3";
            Lvl29.text = "Level 4";
            Lvl30.text = "Level 5";
            f1.text = "Floor 1";
            f2.text = "Floor 2";
            f3.text = "Floor 3";
            f4.text = "Floor 4";
            f5.text = "Floor 5";
            f6.text = "Floor 6";
            b1.text = "Return";
            b2.text = "Return";
            b3.text = "Return";
            b4.text = "Return";
            b5.text = "Return";
            b6.text = "Return";
            loadingM.text = "Loading...";
            howToPlay.text = "How to play";
            backHTP.text = "Return";
            HTP.text = "How to play";
            HTPbasis.text = "Basis";
            HTPendless.text = "Endless";
            HTPpowerUps.text = "Power Ups";
            HTPtutorial.text = "Tutorial";
            BTitle.text = "Basis";
            BText1.text = "When you play a level you will see a countdown, when this reaches zero you can start playing. When the race starts you will need to choose which side of the screen you want to jump to touching in that side, having to choose Between the left, the center and the right. \nYou will need to dodge the spikes, Because this spikes will stun you for two seconds.";
            BText2.text = "You will also encounter some power-ups when racing, some of which will unlock when you arrive to the next floor. This power-ups can Be used By the enemies also. Reaching the end of the level Before the other runners will Be the main oBjective. You will see the remaining of the level to all the runners, also Beeing allowed to see the exact position of the other runners at the Bottom side of the screen.";
            BReturn.text = "Return";
            ETitle.text = "Endless";
            EText.text = "In this game mode your oBjective will Be to reach the highest you can while escaping from an extrange liquid. The spikes will stun you for less time and you will only have the shield and the douBle jump.";
            EReturn.text = "Return";
            PTitle.text = "Power Ups";
            PShield.text = "SHIELD";
            PDoubleJump.text = "DOUBLE JUMP";
            PEnergyBall.text = "ENERGY BALL";
            PTrap.text = "TRAP";
            PFog.text = "FOG";
            PDarkEnergyBall.text = "DARK ENERGY BALL";
            PReturn.text = "Return";
            STitle.text = "Shield";
            SText.text = "THIS POWER WILL ALLOW YOU TO TAKE DAMAGE ONE TIME WITHOUT BEING STUNNED. \nTHIS POWER IS UNLOCKED SINCE THE START OF THE GAME.";
            SReturn.text = "Return";
            DTitle.text = "DOUBLE JUMP";
            DText.text = "THIS POWER WILL ALLOW YOU TO DOUBLE YOUR JUMP LENGTH. \nTHIS POWER IS UNLOCKED WHEN YOU PASS THE FIRST FLOOR.";
            DReturn.text = "Return";
            EBTitle.text = "ENERGY BALL";
            EBText.text = "THIS POWER WILL ALLOW YOU TO SHOOT FORWARD AN ENERGY BALL, EXPLODING WHEN IT HITS AN ENEMY AND LETTING IT STUNNED FOR TWO SECONDS. \nTHIS POWER IS UNLOCKED WHEN YOU PASS THE SECOND FLOOR.";
            EBReturn.text = "Return";
            TTitle.text = "TRAP";
            TText.text = "THIS POWER WILL ALLOW YOU TO PUT A TRAP ON ONE OF THE PLATFORMS WITHOUT TRAP BELOW. \nTHIS POWER IS UNLOCKED WHEN YOU PASS THE THIRD FLOOR.";
            TReturn.text = "Return";
            FTitle.text = "FOG";
            FText1.text = "THIS POWER WILL ALLOW YOU TO BLIND THE ENEMIES FOR THREE SECONDS, MAKING THEM TO JUMP RANDOMNLY.";
            FText2.text = "IF THEY ACTIVATE THE POWER YOU WILL ONLY SEE YOUR CHARACTER FOR THREE SECONDS. \nTHIS POWER IS UNLOCKED WHEN YOU PASS THE FOURTH FLOOR.";
            FReturn.text = "Return";
            DETitle.text = "DARK \nENERGY BALL";
            DEText.text = "THIS POWER WILL ALLOW YOU TO SHOOT FORWARD AN ENERGY BALL, BUT THIS TIME THE BALL WILL FOLLOW THE NEAREST ENEMY, NEVER FAILING. \nTHIS POWER IS UNLOCKED WHEN YOU PASS THE FIFTH FLOOR.";
            DEReturn.text = "Return";
            CTitle.text = "Credits";
            CReturn.text = "Return";
            EMTitle.text = "Endless";
            EMPlay.text = "Play";
            EMLeaderBoards.text = "LeaderBoard";
            EMReturn.text = "Return";
            pointsTitle.text = "Score";
            nameTitle.text = "Name";
            Hreturn.text = "Return";
            selectLanguageText.text = "Select the language you want the game to be. You can change it whenever you want on the configuration menu.";
            saveLanguage.text = "Save";
        }
        else if (PlayerPrefs.GetInt("Language") == 2)
        {
            history.text = "Historia";
            endless.text = "AmaigaBe";
            configuration.text = "Konfigurazioa";
            credits.text = "Kredituak";
            exit.text = "Irten";
            configurationMenu.text = "Konfigurazioa";
            language.text = "Hizkuntza";
            sound.text = "Soinua";
            master.text = "Nagusia";
            music.text = "Musika";
            effects.text = "Efektuak";
            backConf.text = "Atzera";
            Lvl1.text = "1. nibela";
            Lvl2.text = "2. nibela";
            Lvl3.text = "3. nibela";
            Lvl4.text = "4. nibela";
            Lvl5.text = "5. nibela";
            Lvl6.text = "1. nibela";
            Lvl7.text = "2. nibela";
            Lvl8.text = "3. nibela";
            Lvl9.text = "4. nibela";
            Lvl10.text = "5. nibela";
            Lvl11.text = "1. nibela";
            Lvl12.text = "2. nibela";
            Lvl13.text = "3. nibela";
            Lvl14.text = "4. nibela";
            Lvl15.text = "5. nibela";
            Lvl16.text = "1. nibela";
            Lvl17.text = "2. nibela";
            Lvl18.text = "3. nibela";
            Lvl19.text = "4. nibela";
            Lvl20.text = "5. nibela";
            Lvl21.text = "1. nibela";
            Lvl22.text = "2. nibela";
            Lvl23.text = "3. nibela";
            Lvl24.text = "4. nibela";
            Lvl25.text = "5. nibela";
            Lvl26.text = "1. nibela";
            Lvl27.text = "2. nibela";
            Lvl28.text = "3. nibela";
            Lvl29.text = "4. nibela";
            Lvl30.text = "5. nibela";
            f1.text = "1. solairua";
            f2.text = "2. solairua";
            f3.text = "3. solairua";
            f4.text = "4. solairua";
            f5.text = "5. solairua";
            f6.text = "6. solairua";
            b1.text = "Itzuli";
            b2.text = "Itzuli";
            b3.text = "Itzuli";
            b4.text = "Itzuli";
            b5.text = "Itzuli";
            b6.text = "Itzuli";
            loadingM.text = "Kargatzen...";
            howToPlay.text = "Nola jokatu";
            backHTP.text = "Itzuli";
            HTP.text = "Nola jokuatu";
            HTPbasis.text = "Oinarriak";
            HTPendless.text = "AmaigaBe";
            HTPpowerUps.text = "Botereak";
            HTPtutorial.text = "Tutoriala";
            BTitle.text = "Oinarriak";
            BText1.text = "NiBel Bat hasterakoan, hau Bukatzerakoan jokatzen hasi ahalko zara. Karrera hasterakoan pantailako zer aldetara salto egin nahi duzun eraBaki Beharko duzu, ezker, erdi eta eskuinaren artean eraBakiz. \nTranpak saiherstu Beharko dituzu, hauek Bi segundo mugitu ezinik utziko Baitzaituzte.";
            BText2.text = "NiBelen zehar Botere desBerdinak aurkitu ahalko dituzu, solairuz pasatakoan desBlokeatzen joango direnak. Etsaiek ere eraBili ahal dituzte Botere hauek. BeteBehar nagusia niBelaren amaierara Beste korrikalariak Baino lehenago iristea izango da. Zuri eta Beste korrikalariei niBelaren zenBat falta zaien ikusi ahalko duzu eskuineko Barran, Besteen posizio zehatza pantailaren Behekaldean ikusteko ahalmenarekin.";
            BReturn.text = "Itzuli";
            ETitle.text = "AmaigaBe";
            EText.text = "Modu honetan zure helBurua ahalik eta altuen heltzea izango da, likido arraro Batetas ihes egiten duzun Bitartean. Tranpek denBora gutxiago geldituko zaituzte eta eskudoa eta salto Bikoitza Bakarrik izango dituzu eskuragarri.";
            EReturn.text = "Itzuli";
            PTitle.text = "BOTEREAK";
            PShield.text = "EZKUTUA";
            PDoubleJump.text = "SALTO BIKOITZA";
            PEnergyBall.text = "ENERGI BOLA";
            PTrap.text = "TRANPA";
            PFog.text = "BEHE-LAINOA";
            PDarkEnergyBall.text = "ENERGIA BELTZEKO BOLA";
            PReturn.text = "Itzuli";
            STitle.text = "Ezkutua";
            SText.text = "BOTERE HONEK GELDI GELDITU GABE MIN HARTZEA AHALBIDETZEN DU. \nBOTERE HAU JOKO HASIERATIK DAGO ESKURAGARRI.";
            SReturn.text = "Itzuli";
            DTitle.text = "SALTO BIKOITZA";
            DText.text = "BOTERE HONEK ZURE SALTOAREN LUZERA BIKOITZEN DU.\nBOTEREA LEHEN PISUA PASATZERAKOAN DESBLOKEATZEN DA.";
            DReturn.text = "Itzuli";
            EBTitle.text = "ENERGI BOLA";
            EBText.text = "BOTERE HONEK ENERGI BOLA BAT AURRERUNTZ BOTATZEN AHALBIDETUKO DIZU , ETSAI BAT AURKITZERAKOAN LEHERTUZ ETA GELDI UTZIZ BI SEGUNDUZ. \nBOTERE HAU BIGARREN PISUA PASATZERAKOAN DESBLOKEATZEN DA.";
            EBReturn.text = "Itzuli";
            TTitle.text = "TRANPA";
            TText.text = "BOTERE HONEK BEHEKO TRANPA GABEKO PLATAFORMA BATEAN TRANPA BAT IPINTZEN AHALBIDETUKO DIZU. \nBOTERE HAU HIRUGARREN PISUA PASATZERAKOAN DESBLOKEATZEN DA.";
            TReturn.text = "Itzuli";
            FTitle.text = "BEHE-LAINOA";
            FText1.text = "BOTERE HONEK ETSAIAK ITSUTZEN AHALBIDETUKO DIZU, HAUEK ERA ALEATORIOAN SALTARARAZIZ.";
            FText2.text = "BERAIEK AKTIBATZEN BADUTE BOTEREA ZURE PERTSONAIA BAKARRIK IKUSIKO DUZU HIRU SEGUNDUZ.\nBOTERE HAU LAUGARREN PISUA PASATZERAKOAN DESBLOKEATZEN DA.";
            FReturn.text = "Itzuli";
            DETitle.text = "ENERGIA BELTZEKO \nBOLA";
            DEText.text = "BOTERE HONEK ENEGI BOLA BAT AURRERUNTZ BOTATZEN AHALBIDETUKO DIZU, BAINA ORAINGOAN ETSAI URBILENA JARRAITUKO DU, INOIZ EZ HUTS EGINIZ. \nBOTERE HAU BOSTGARREN PISUA PASATZERAKOAN DESBLOKEATZEN DA.";
            DEReturn.text = "Itzuli";
            CTitle.text = "Kredituak";
            CReturn.text = "Itzuli";
            EMTitle.text = "AmaigaBe";
            EMPlay.text = "Jokatu";
            EMLeaderBoards.text = "Puntuazio taBla";
            EMReturn.text = "Itzuli";
            pointsTitle.text = "Puntuak";
            nameTitle.text = "Izena";
            Hreturn.text = "Itzuli";
            selectLanguageText.text = "Erabaki zein hizkuntzan nahi duzun jolastea. Nahi duzunean alda dezakezu konfigurazio menuan.";
            saveLanguage.text = "Gorde";
        }
    }
}
