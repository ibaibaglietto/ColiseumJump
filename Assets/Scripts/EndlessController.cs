using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessController : MonoBehaviour
{
    public Rigidbody2D Player;
    public GameObject muerte;
    public GameObject platform;
    public GameObject trap;
    public GameObject shield;
    public GameObject doubleJump;
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    //El objeto que nos permite saber si el personaje esta en el suelo
    public Transform groundCheck;
    //La layer que se detectara como suelo por el groundCheck
    public LayerMask Platforms;
    //La imagen que determina la posicion del jugador en y
    public Image playerPos;
    //La imagen que determina la posicion de la muerte en y
    public Image diePos;
    //El texto que se escribe la puntuacion
    public Text scoreText;
    //El texto puntuacion
    public Text score;
    public int plat;
    float high;
    int r;
    int[] platRow;
    int[] trapRow;
    int[] shieldRow;
    int[] doubleJumpRow;
    int powerUp;
    GameObject[] FirstRow;
    GameObject[] SecondRow;
    GameObject[] ThirdRow;
    GameObject[] FourthRow;
    GameObject[] FifthRow;
    GameObject[] SixthRow;
    GameObject[] SeventhRow;
    GameObject[] EighthRow;
    GameObject[] NinthRow;
    GameObject[] TenthRow;
    float y;
    float backgroundY;

    float dieHeight;

    private float h = Screen.height;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Language") == 0) score.text = "Puntuación:";
        else if (PlayerPrefs.GetInt("Language") == 1) score.text = "Score:";
        else if (PlayerPrefs.GetInt("Language") == 2) score.text = "Puntuazioa:";

        dieHeight = diePos.rectTransform.sizeDelta.y;
        plat = 0;
        high = Player.position.y;
        platRow = new int[3];
        trapRow = new int[3];
        shieldRow = new int[3];
        doubleJumpRow = new int[3];
        FirstRow = new GameObject[3];
        SecondRow = new GameObject[3];
        ThirdRow = new GameObject[3];
        FourthRow = new GameObject[3];
        FifthRow = new GameObject[3];
        SixthRow = new GameObject[3];
        SeventhRow = new GameObject[3];
        EighthRow = new GameObject[3];
        NinthRow = new GameObject[3];
        TenthRow = new GameObject[3];
        //primera fila
        if (Random.Range(0, 100) < 50)
        {
            FourthRow[0] = Instantiate(platform, new Vector3(-1.85f, -1.23f, 0.0f), Quaternion.identity);
            platRow[0] = 1;
        }
        else platRow[0] = 0;
        if (Random.Range(0, 100) < 50)
        {
            FourthRow[1] = Instantiate(platform, new Vector3(0.0f, -1.23f, 0.0f), Quaternion.identity);
            platRow[1] = 1;            
        }
        else platRow[1] = 0;
        if ((Random.Range(0, 100) < 50) || (platRow[0] + platRow[1] == 0))
        {
            FourthRow[2] = Instantiate(platform, new Vector3(1.85f, -1.23f, 0.0f), Quaternion.identity);
            platRow[2] = 1;            
        } 
        else platRow[2] = 0;
        if (Random.Range(0, 100) < 40 && (platRow[0]+platRow[1]+platRow[2] > 1) && platRow[0]==1)
        {
            Instantiate(trap, new Vector3(-1.85f, -0.73f, 0.0f), Quaternion.identity, FourthRow[0].transform);
            trapRow[0] = 1;
        }
        else trapRow[0] = 0;
        if (Random.Range(0, 100) < 40 && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] > 1) && platRow[1] == 1)
        {
            Instantiate(trap, new Vector3(0.0f, -0.73f, 0.0f), Quaternion.identity, FourthRow[1].transform);
            trapRow[1] = 1;
        }
        else trapRow[1] = 0;
        if ((Random.Range(0, 100) < 40) && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] - trapRow[1] > 1) && platRow[2] == 1)
        {
            Instantiate(trap, new Vector3(1.85f, -0.73f, 0.0f), Quaternion.identity, FourthRow[2].transform);
            trapRow[2] = 1;
        }
        else trapRow[2] = 0;
        if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0)
        {
            Instantiate(shield, new Vector3(-1.85f, -0.45f, 0.0f), Quaternion.identity, FourthRow[0].transform);
            shieldRow[0] = 1;
        }
        else shieldRow[0] = 0;
        if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] == 0)
        {
            Instantiate(shield, new Vector3(0.0f, -0.45f, 0.0f), Quaternion.identity, FourthRow[1].transform);
            shieldRow[1] = 1;
        }
        else shieldRow[1] = 0;
        if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] == 0)
        {
            Instantiate(shield, new Vector3(1.85f, -0.45f, 0.0f), Quaternion.identity, FourthRow[2].transform);
            shieldRow[2] = 1;
        }
        else shieldRow[2] = 0;
        if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0)
        {
            Instantiate(doubleJump, new Vector3(-1.85f, -0.45f, 0.0f), Quaternion.identity, FourthRow[0].transform);
            doubleJumpRow[0] = 1;
        }
        else doubleJumpRow[0] = 0;
        if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] == 0)
        {
            Instantiate(doubleJump, new Vector3(0.0f, -0.45f, 0.0f), Quaternion.identity, FourthRow[1].transform);
            doubleJumpRow[1] = 1;
        }
        else doubleJumpRow[1] = 0;
        if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] + doubleJumpRow[1] == 0)
        {
            Instantiate(doubleJump, new Vector3(1.85f, -0.45f, 0.0f), Quaternion.identity, FourthRow[2].transform);
            doubleJumpRow[2] = 1;
        }
        else doubleJumpRow[2] = 0;
        if ((shieldRow[0] + shieldRow[1] + shieldRow[2] + doubleJumpRow[0] + doubleJumpRow[1] + doubleJumpRow[2]) > 0 || powerUp != 0) powerUp += 1;
        //segunda fila
        if (Random.Range(0, 100) < 50)
        {
            ThirdRow[0] = Instantiate(platform, new Vector3(-1.85f, 1.84f, 0.0f), Quaternion.identity);
            platRow[0] = 1;
        }
        else platRow[0] = 0;
        if (Random.Range(0, 100) < 50)
        {
            ThirdRow[1] = Instantiate(platform, new Vector3(0.0f, 1.84f, 0.0f), Quaternion.identity);
            platRow[1] = 1;
        }
        else platRow[1] = 0;
        if ((Random.Range(0, 100) < 50) || (platRow[0] + platRow[1] == 0))
        {
            ThirdRow[2] = Instantiate(platform, new Vector3(1.85f, 1.84f, 0.0f), Quaternion.identity);
            platRow[2] = 1;
        }
        else platRow[2] = 0;
        if (Random.Range(0, 100) < 40 && (platRow[0] + platRow[1] + platRow[2] > 1) && platRow[0] == 1)
        {
            Instantiate(trap, new Vector3(-1.85f, 2.34f, 0.0f), Quaternion.identity, ThirdRow[0].transform);
            trapRow[0] = 1;
        }
        else trapRow[0] = 0;
        if (Random.Range(0, 100) < 40 && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] > 1) && platRow[1] == 1)
        {
            Instantiate(trap, new Vector3(0.0f, 2.34f, 0.0f), Quaternion.identity, ThirdRow[1].transform);
            trapRow[1] = 1;
        }
        else trapRow[1] = 0;
        if ((Random.Range(0, 100) < 40) && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] - trapRow[1] > 1) && platRow[2] == 1)
        {
            Instantiate(trap, new Vector3(1.85f, 2.34f, 0.0f), Quaternion.identity, ThirdRow[2].transform);
            trapRow[2] = 1;
        }
        else trapRow[2] = 0;
        if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0 && powerUp == 0)
        {
            Instantiate(shield, new Vector3(-1.85f, 2.62f, 0.0f), Quaternion.identity, ThirdRow[0].transform);
            shieldRow[0] = 1;
        }
        else shieldRow[0] = 0;
        if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] == 0 && powerUp == 0)
        {
            Instantiate(shield, new Vector3(0.0f, 2.62f, 0.0f), Quaternion.identity, ThirdRow[1].transform);
            shieldRow[1] = 1;
        }
        else shieldRow[1] = 0;
        if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] == 0 && powerUp == 0)
        {
            Instantiate(shield, new Vector3(1.85f, 2.62f, 0.0f), Quaternion.identity, ThirdRow[2].transform);
            shieldRow[2] = 1;
        }
        else shieldRow[2] = 0;
        if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && powerUp == 0)
        {
            Instantiate(doubleJump, new Vector3(-1.85f, 2.62f, 0.0f), Quaternion.identity, ThirdRow[0].transform);
            doubleJumpRow[0] = 1;
        }
        else doubleJumpRow[0] = 0;
        if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] == 0 && powerUp == 0)
        {
            Instantiate(doubleJump, new Vector3(0.0f, 2.62f, 0.0f), Quaternion.identity, ThirdRow[1].transform);
            doubleJumpRow[1] = 1;
        }
        else doubleJumpRow[1] = 0;
        if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] + doubleJumpRow[1] == 0 && powerUp == 0)
        {
            Instantiate(doubleJump, new Vector3(1.85f, 2.62f, 0.0f), Quaternion.identity, ThirdRow[2].transform);
            doubleJumpRow[2] = 1;
        }
        else doubleJumpRow[2] = 0;
        if ((shieldRow[0] + shieldRow[1] + shieldRow[2] + doubleJumpRow[0] + doubleJumpRow[1] + doubleJumpRow[2]) > 0 || powerUp != 0) powerUp += 1;
        //tercera fila
        if (Random.Range(0, 100) < 50)
        {
            SecondRow[0] = Instantiate(platform, new Vector3(-1.85f, 4.91f, 0.0f), Quaternion.identity);
            platRow[0] = 1;
        }
        else platRow[0] = 0;
        if (Random.Range(0, 100) < 50)
        {
            SecondRow[1] =  Instantiate(platform, new Vector3(0.0f, 4.91f, 0.0f), Quaternion.identity);
            platRow[1] = 1;
        }
        else platRow[1] = 0;
        if ((Random.Range(0, 100) < 50) || (platRow[0] + platRow[1] == 0))
        {
            SecondRow[2] = Instantiate(platform, new Vector3(1.85f, 4.91f, 0.0f), Quaternion.identity);
            platRow[2] = 1;
        }
        else platRow[2] = 0;
        if (Random.Range(0, 100) < 40 && (platRow[0] + platRow[1] + platRow[2] > 1) && platRow[0] == 1)
        {
            Instantiate(trap, new Vector3(-1.85f, 5.41f, 0.0f), Quaternion.identity, SecondRow[0].transform);
            trapRow[0] = 1;
        }
        else trapRow[0] = 0;
        if (Random.Range(0, 100) < 40 && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] > 1) && platRow[1] == 1)
        {
            Instantiate(trap, new Vector3(0.0f, 5.41f, 0.0f), Quaternion.identity, SecondRow[1].transform);
            trapRow[1] = 1;
        }
        else trapRow[1] = 0;
        if ((Random.Range(0, 100) < 40) && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] - trapRow[1] > 1) && platRow[2] == 1)
        {
            Instantiate(trap, new Vector3(1.85f, 5.41f, 0.0f), Quaternion.identity, SecondRow[2].transform);
            trapRow[2] = 1;
        }
        else trapRow[2] = 0;
        if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0 && powerUp == 0)
        {
            Instantiate(shield, new Vector3(-1.85f, 5.69f, 0.0f), Quaternion.identity, SecondRow[0].transform);
            shieldRow[0] = 1;
        }
        else shieldRow[0] = 0;
        if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] == 0 && powerUp == 0)
        {
            Instantiate(shield, new Vector3(0.0f, 5.69f, 0.0f), Quaternion.identity, SecondRow[1].transform);
            shieldRow[1] = 1;
        }
        else shieldRow[1] = 0;
        if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] == 0 && powerUp == 0)
        {
            Instantiate(shield, new Vector3(1.85f, 5.69f, 0.0f), Quaternion.identity, SecondRow[2].transform);
            shieldRow[2] = 1;
        }
        else shieldRow[2] = 0;
        if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && powerUp == 0)
        {
            Instantiate(doubleJump, new Vector3(-1.85f, 5.69f, 0.0f), Quaternion.identity, SecondRow[0].transform);
            doubleJumpRow[0] = 1;
        }
        else doubleJumpRow[0] = 0;
        if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] == 0 && powerUp == 0)
        {
            Instantiate(doubleJump, new Vector3(0.0f, 5.69f, 0.0f), Quaternion.identity, SecondRow[1].transform);
            doubleJumpRow[1] = 1;
        }
        else doubleJumpRow[1] = 0;
        if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] + doubleJumpRow[1] == 0 && powerUp == 0)
        {
            Instantiate(doubleJump, new Vector3(1.85f, 5.69f, 0.0f), Quaternion.identity, SecondRow[2].transform);
            doubleJumpRow[2] = 1;
        }
        else doubleJumpRow[2] = 0;
        if ((shieldRow[0] + shieldRow[1] + shieldRow[2] + doubleJumpRow[0] + doubleJumpRow[1] + doubleJumpRow[2]) > 0 || powerUp != 0) powerUp += 1;
        //cuarta fila
        if (Random.Range(0, 100) < 50)
        {
            FirstRow[0] = Instantiate(platform, new Vector3(-1.85f, 7.98f, 0.0f), Quaternion.identity);
            platRow[0] = 1;
        }
        else platRow[0] = 0;
        if (Random.Range(0, 100) < 50)
        {
            FirstRow[1] = Instantiate(platform, new Vector3(0.0f, 7.98f, 0.0f), Quaternion.identity);
            platRow[1] = 1;
        }
        else platRow[1] = 0;
        if ((Random.Range(0, 100) < 50) || (platRow[0] + platRow[1] == 0))
        {
            FirstRow[2] = Instantiate(platform, new Vector3(1.85f, 7.98f, 0.0f), Quaternion.identity);
            platRow[2] = 1;
        }
        else platRow[2] = 0;
        if (Random.Range(0, 100) < 40 && (platRow[0] + platRow[1] + platRow[2] > 1) && platRow[0] == 1)
        {
            Instantiate(trap, new Vector3(-1.85f, 8.48f, 0.0f), Quaternion.identity, FirstRow[0].transform);
            trapRow[0] = 1;
        }
        else trapRow[0] = 0;
        if (Random.Range(0, 100) < 40 && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] > 1) && platRow[1] == 1)
        {
            Instantiate(trap, new Vector3(0.0f, 8.48f, 0.0f), Quaternion.identity, FirstRow[1].transform);
            trapRow[1] = 1;
        }
        else trapRow[1] = 0;
        if ((Random.Range(0, 100) < 40) && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] - trapRow[1] > 1) && platRow[2] == 1)
        {
            Instantiate(trap, new Vector3(1.85f, 8.48f, 0.0f), Quaternion.identity, FirstRow[2].transform);
            trapRow[2] = 1;
        }
        else trapRow[2] = 0;
        if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0 && powerUp == 0)
        {
            Instantiate(shield, new Vector3(-1.85f, 8.76f, 0.0f), Quaternion.identity, FirstRow[0].transform);
            shieldRow[0] = 1;
        }
        else shieldRow[0] = 0;
        if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] == 0 && powerUp == 0)
        {
            Instantiate(shield, new Vector3(0.0f, 8.76f, 0.0f), Quaternion.identity, FirstRow[1].transform);
            shieldRow[1] = 1;
        }
        else shieldRow[1] = 0;
        if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] == 0 && powerUp == 0)
        {
            Instantiate(shield, new Vector3(1.85f, 8.76f, 0.0f), Quaternion.identity, FirstRow[2].transform);
            shieldRow[2] = 1;
        }
        else shieldRow[2] = 0;
        if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && powerUp == 0)
        {
            Instantiate(doubleJump, new Vector3(-1.85f, 8.76f, 0.0f), Quaternion.identity, FirstRow[0].transform);
            doubleJumpRow[0] = 1;
        }
        else doubleJumpRow[0] = 0;
        if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] == 0 && powerUp == 0)
        {
            Instantiate(doubleJump, new Vector3(0.0f, 8.76f, 0.0f), Quaternion.identity, FirstRow[1].transform);
            doubleJumpRow[1] = 1;
        }
        else doubleJumpRow[1] = 0;
        if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] + doubleJumpRow[1] == 0 && powerUp == 0)
        {
            Instantiate(doubleJump, new Vector3(1.85f, 8.76f, 0.0f), Quaternion.identity, FirstRow[2].transform);
            doubleJumpRow[2] = 1;
        }
        else doubleJumpRow[2] = 0;
        if ((shieldRow[0] + shieldRow[1] + shieldRow[2] + doubleJumpRow[0] + doubleJumpRow[1] + doubleJumpRow[2]) > 0 || powerUp != 0) powerUp += 1;
        y = 7.98f;
        backgroundY = 37.3f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPos.rectTransform.anchoredPosition = new Vector3(playerPos.rectTransform.anchoredPosition.x, (Player.position.y - muerte.transform.position.y) * 3.0f, 0.0f);
        diePos.rectTransform.anchoredPosition = new Vector3(diePos.rectTransform.anchoredPosition.x, (muerte.transform.position.y - Player.position.y) * h * 0.0025f, 0.0f);
        diePos.rectTransform.sizeDelta = new Vector2(diePos.rectTransform.sizeDelta.x, dieHeight + (muerte.transform.position.y - Player.position.y) * h * 0.005f);
        if (Player.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0) && (Player.position.y >= (high + 5.8f)))
        {
            plat += 2;
            if (TenthRow[0] != null) Destroy(TenthRow[0], 0.0f);
            if (TenthRow[1] != null) Destroy(TenthRow[1], 0.0f);
            if (TenthRow[2] != null) Destroy(TenthRow[2], 0.0f);
            if (NinthRow[0] != null) Destroy(NinthRow[0], 0.0f);
            if (NinthRow[1] != null) Destroy(NinthRow[1], 0.0f);
            if (NinthRow[2] != null) Destroy(NinthRow[2], 0.0f);
            TenthRow[0] = EighthRow[0];
            TenthRow[1] = EighthRow[1];
            TenthRow[2] = EighthRow[2];
            NinthRow[0] = SeventhRow[0];
            NinthRow[1] = SeventhRow[1];
            NinthRow[2] = SeventhRow[2];
            EighthRow[0] = SixthRow[0];
            EighthRow[1] = SixthRow[1];
            EighthRow[2] = SixthRow[2];
            SeventhRow[0] = FifthRow[0];
            SeventhRow[1] = FifthRow[1];
            SeventhRow[2] = FifthRow[2];
            SixthRow[0] = FourthRow[0];
            SixthRow[1] = FourthRow[1];
            SixthRow[2] = FourthRow[2];
            FifthRow[0] = ThirdRow[0];
            FifthRow[1] = ThirdRow[1];
            FifthRow[2] = ThirdRow[2];
            FourthRow[0] = SecondRow[0];
            FourthRow[1] = SecondRow[1];
            FourthRow[2] = SecondRow[2];
            ThirdRow[0] = FirstRow[0];
            ThirdRow[1] = FirstRow[1];
            ThirdRow[2] = FirstRow[2];
            SecondRow[0] = null;
            SecondRow[1] = null;
            SecondRow[2] = null;
            FirstRow[0] = null;
            FirstRow[1] = null;
            FirstRow[2] = null;
            y = y + 3.07f;
            high = Player.position.y;
            if (Random.Range(0, 100) < 50)
            {
                SecondRow[0] = Instantiate(platform, new Vector3(-1.85f, y, 0.0f), Quaternion.identity);
                platRow[0] = 1;
            }
            else platRow[0] = 0;
            if (Random.Range(0, 100) < 50)
            {
                SecondRow[1] = Instantiate(platform, new Vector3(0.0f, y, 0.0f), Quaternion.identity);
                platRow[1] = 1;
            }
            else platRow[1] = 0;
            if ((Random.Range(0, 100) < 50) || (platRow[0] + platRow[1] == 0))
            {
                SecondRow[2] = Instantiate(platform, new Vector3(1.85f, y, 0.0f), Quaternion.identity);
                platRow[2] = 1;
            }
            else platRow[2] = 0;
            if (Random.Range(0, 100) < 40 && (platRow[0] + platRow[1] + platRow[2] > 1) && platRow[0] == 1)
            {
                Instantiate(trap, new Vector3(-1.85f, y + 0.5f, 0.0f), Quaternion.identity, SecondRow[0].transform);
                trapRow[0] = 1;
            }
            else trapRow[0] = 0;
            if (Random.Range(0, 100) < 40 && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] > 1) && platRow[1] == 1)
            {
                Instantiate(trap, new Vector3(0.0f, y + 0.5f, 0.0f), Quaternion.identity, SecondRow[1].transform);
                trapRow[1] = 1;
            }
            else trapRow[1] = 0;
            if ((Random.Range(0, 100) < 40) && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] - trapRow[1] > 1) && platRow[2] == 1)
            {
                Instantiate(trap, new Vector3(1.85f, y + 0.5f, 0.0f), Quaternion.identity, SecondRow[2].transform);
                trapRow[2] = 1;
            }
            else trapRow[2] = 0;
            if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0 && powerUp == 0)
            {
                Instantiate(shield, new Vector3(-1.85f, y + 0.78f, 0.0f), Quaternion.identity, SecondRow[0].transform);
                shieldRow[0] = 1;
            }
            else shieldRow[0] = 0;
            if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] == 0 && powerUp == 0)
            {
                Instantiate(shield, new Vector3(0.0f, y + 0.78f, 0.0f), Quaternion.identity, SecondRow[1].transform);
                shieldRow[1] = 1;
            }
            else shieldRow[1] = 0;
            if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] == 0 && powerUp == 0)
            {
                Instantiate(shield, new Vector3(1.85f, y + 0.78f, 0.0f), Quaternion.identity, SecondRow[2].transform);
                shieldRow[2] = 1;
            }
            else shieldRow[2] = 0;
            if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && powerUp == 0)
            {
                Instantiate(doubleJump, new Vector3(-1.85f, y + 0.78f, 0.0f), Quaternion.identity, SecondRow[0].transform);
                doubleJumpRow[0] = 1;
            }
            else doubleJumpRow[0] = 0;
            if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] == 0 && powerUp == 0)
            {
                Instantiate(doubleJump, new Vector3(0.0f, y + 0.78f, 0.0f), Quaternion.identity, SecondRow[1].transform);
                doubleJumpRow[1] = 1;
            }
            else doubleJumpRow[1] = 0;
            if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] + doubleJumpRow[1] == 0 && powerUp == 0)
            {
                Instantiate(doubleJump, new Vector3(1.85f, y + 0.78f, 0.0f), Quaternion.identity, SecondRow[2].transform);
                doubleJumpRow[2] = 1;
            }
            else doubleJumpRow[2] = 0;
            if ((shieldRow[0] + shieldRow[1] + shieldRow[2] + doubleJumpRow[0] + doubleJumpRow[1] + doubleJumpRow[2]) > 0 || powerUp != 0) powerUp += 1;
            if (powerUp == 10) powerUp = 0;
            y = y + 3.07f;
            if (Random.Range(0, 100) < 50)
            {
                FirstRow[0] = Instantiate(platform, new Vector3(-1.85f, y, 0.0f), Quaternion.identity);
                platRow[0] = 1;
            }
            else platRow[0] = 0;
            if (Random.Range(0, 100) < 50)
            {
                FirstRow[1] = Instantiate(platform, new Vector3(0.0f, y, 0.0f), Quaternion.identity);
                platRow[1] = 1;
            }
            else platRow[1] = 0;
            if ((Random.Range(0, 100) < 50) || (platRow[0] + platRow[1] == 0))
            {
                FirstRow[2] = Instantiate(platform, new Vector3(1.85f, y, 0.0f), Quaternion.identity);
                platRow[2] = 1;
            }
            else platRow[2] = 0;
            if (Random.Range(0, 100) < 40 && (platRow[0] + platRow[1] + platRow[2] > 1) && platRow[0] == 1)
            {
                Instantiate(trap, new Vector3(-1.85f, y + 0.5f, 0.0f), Quaternion.identity, FirstRow[0].transform);
                trapRow[0] = 1;
            }
            else trapRow[0] = 0;
            if (Random.Range(0, 100) < 40 && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] > 1) && platRow[1] == 1)
            {
                Instantiate(trap, new Vector3(0.0f, y + 0.5f, 0.0f), Quaternion.identity, FirstRow[1].transform);
                trapRow[1] = 1;
            }
            else trapRow[1] = 0;
            if ((Random.Range(0, 100) < 40) && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] - trapRow[1] > 1) && platRow[2] == 1)
            {
                Instantiate(trap, new Vector3(1.85f, y + 0.5f, 0.0f), Quaternion.identity, FirstRow[2].transform);
                trapRow[2] = 1;
            }
            else trapRow[2] = 0;
            if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0 && powerUp == 0)
            {
                Instantiate(shield, new Vector3(-1.85f, y + 0.78f, 0.0f), Quaternion.identity, FirstRow[0].transform);
                shieldRow[0] = 1;
            }
            else shieldRow[0] = 0;
            if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] == 0 && powerUp == 0)
            {
                Instantiate(shield, new Vector3(0.0f, y + 0.78f, 0.0f), Quaternion.identity, FirstRow[1].transform);
                shieldRow[1] = 1;
            }
            else shieldRow[1] = 0;
            if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] == 0 && powerUp == 0)
            {
                Instantiate(shield, new Vector3(1.85f, y + 0.78f, 0.0f), Quaternion.identity, FirstRow[2].transform);
                shieldRow[2] = 1;
            }
            else shieldRow[2] = 0;
            if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && powerUp == 0)
            {
                Instantiate(doubleJump, new Vector3(-1.85f, y + 0.78f, 0.0f), Quaternion.identity, FirstRow[0].transform);
                doubleJumpRow[0] = 1;
            }
            else doubleJumpRow[0] = 0;
            if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] == 0 && powerUp == 0)
            {
                Instantiate(doubleJump, new Vector3(0.0f, y + 0.78f, 0.0f), Quaternion.identity, FirstRow[1].transform);
                doubleJumpRow[1] = 1;
            }
            else doubleJumpRow[1] = 0;
            if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] + doubleJumpRow[1] == 0 && powerUp == 0)
            {
                Instantiate(doubleJump, new Vector3(1.85f, y + 0.78f, 0.0f), Quaternion.identity, FirstRow[2].transform);
                doubleJumpRow[2] = 1;
            }
            else doubleJumpRow[2] = 0;
            if ((shieldRow[0] + shieldRow[1] + shieldRow[2] + doubleJumpRow[0] + doubleJumpRow[1] + doubleJumpRow[2]) > 0 || powerUp != 0) powerUp += 1;
            if (powerUp == 10) powerUp = 0;
        }
        else if (Player.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0) && (Player.position.y >= (high + 2.9f)))
        {
            plat += 1;
            if(TenthRow[0] != null) Destroy(TenthRow[0], 0.0f);
            if (TenthRow[1] != null) Destroy(TenthRow[1], 0.0f);
            if (TenthRow[2] != null) Destroy(TenthRow[2], 0.0f);
            TenthRow[0] = NinthRow[0];
            TenthRow[1] = NinthRow[1];
            TenthRow[2] = NinthRow[2];
            NinthRow[0] = EighthRow[0];
            NinthRow[1] = EighthRow[1];
            NinthRow[2] = EighthRow[2];
            EighthRow[0] = SeventhRow[0];
            EighthRow[1] = SeventhRow[1];
            EighthRow[2] = SeventhRow[2];
            SeventhRow[0] = SixthRow[0];
            SeventhRow[1] = SixthRow[1];
            SeventhRow[2] = SixthRow[2];
            SixthRow[0] = FifthRow[0];
            SixthRow[1] = FifthRow[1];
            SixthRow[2] = FifthRow[2];
            FifthRow[0] = FourthRow[0];
            FifthRow[1] = FourthRow[1];
            FifthRow[2] = FourthRow[2];
            FourthRow[0] = ThirdRow[0];
            FourthRow[1] = ThirdRow[1];
            FourthRow[2] = ThirdRow[2];
            ThirdRow[0] = SecondRow[0];
            ThirdRow[1] = SecondRow[1];
            ThirdRow[2] = SecondRow[2];
            SecondRow[0] = FirstRow[0];
            SecondRow[1] = FirstRow[1];
            SecondRow[2] = FirstRow[2];
            FirstRow[0] = null;
            FirstRow[1] = null;
            FirstRow[2] = null;
            y = y + 3.07f;
            high = Player.position.y;
            if (Random.Range(0, 100) < 50)
            {
                FirstRow[0] = Instantiate(platform, new Vector3(-1.85f, y, 0.0f), Quaternion.identity);
                platRow[0] = 1;
            }
            else platRow[0] = 0;
            if (Random.Range(0, 100) < 50)
            {
                FirstRow[1] = Instantiate(platform, new Vector3(0.0f, y, 0.0f), Quaternion.identity);
                platRow[1] = 1;
            }
            else platRow[1] = 0;
            if ((Random.Range(0, 100) < 50) || (platRow[0] + platRow[1] == 0))
            {
                FirstRow[2] = Instantiate(platform, new Vector3(1.85f, y, 0.0f), Quaternion.identity);
                platRow[2] = 1;
            }
            else platRow[2] = 0;
            if (Random.Range(0, 100) < 40 && (platRow[0] + platRow[1] + platRow[2] > 1) && platRow[0] == 1)
            {
                Instantiate(trap, new Vector3(-1.85f, y + 0.5f, 0.0f), Quaternion.identity, FirstRow[0].transform);
                trapRow[0] = 1;
            }
            else trapRow[0] = 0;
            if (Random.Range(0, 100) < 40 && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] > 1) && platRow[1] == 1)
            {
                Instantiate(trap, new Vector3(0.0f, y + 0.5f, 0.0f), Quaternion.identity, FirstRow[1].transform);
                trapRow[1] = 1;
            }
            else trapRow[1] = 0;
            if ((Random.Range(0, 100) < 40) && (platRow[0] + platRow[1] + platRow[2] - trapRow[0] - trapRow[1] > 1) && platRow[2] == 1)
            {
                Instantiate(trap, new Vector3(1.85f, y + 0.5f, 0.0f), Quaternion.identity, FirstRow[2].transform);
                trapRow[2] = 1;
            }
            else trapRow[2] = 0;
            if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0 && powerUp == 0)
            {
                Instantiate(shield, new Vector3(-1.85f, y + 0.78f, 0.0f), Quaternion.identity, FirstRow[0].transform);
                shieldRow[0] = 1;
            }
            else shieldRow[0] = 0;
            if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] == 0 && powerUp == 0)
            {
                Instantiate(shield, new Vector3(0.0f, y + 0.78f, 0.0f), Quaternion.identity, FirstRow[1].transform);
                shieldRow[1] = 1;
            }
            else shieldRow[1] = 0;
            if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] == 0 && powerUp == 0)
            {
                Instantiate(shield, new Vector3(1.85f, y + 0.78f, 0.0f), Quaternion.identity, FirstRow[2].transform);
                shieldRow[2] = 1;
            }
            else shieldRow[2] = 0;
            if (Random.Range(0, 100) < 5 && platRow[0] == 1 && trapRow[0] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && powerUp == 0)
            {
                Instantiate(doubleJump, new Vector3(-1.85f, y + 0.78f, 0.0f), Quaternion.identity, FirstRow[0].transform);
                doubleJumpRow[0] = 1;
            }
            else doubleJumpRow[0] = 0;
            if (Random.Range(0, 100) < 5 && platRow[1] == 1 && trapRow[1] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] == 0 && powerUp == 0)
            {
                Instantiate(doubleJump, new Vector3(0.0f, y + 0.78f, 0.0f), Quaternion.identity, FirstRow[1].transform);
                doubleJumpRow[1] = 1;
            }
            else doubleJumpRow[1] = 0;
            if (Random.Range(0, 100) < 5 && platRow[2] == 1 && trapRow[2] == 0 && shieldRow[0] + shieldRow[1] + shieldRow[2] == 0 && doubleJumpRow[0] + doubleJumpRow[1] == 0 && powerUp == 0)
            {
                Instantiate(doubleJump, new Vector3(1.85f, y + 0.78f, 0.0f), Quaternion.identity, FirstRow[2].transform);
                doubleJumpRow[2] = 1;
            }
            else doubleJumpRow[2] = 0;
            if ((shieldRow[0] + shieldRow[1] + shieldRow[2] + doubleJumpRow[0] + doubleJumpRow[1] + doubleJumpRow[2]) > 0 || powerUp != 0) powerUp += 1;
            if (powerUp == 10) powerUp = 0;
        }
        
        if (Player.position.y > backgroundY)
        {
            backgroundY += 18.17f;
            if (background1.transform.position.y > background2.transform.position.y)
            {
                if(background2.transform.position.y > background3.transform.position.y)
                {
                    background3.transform.position = new Vector3(0.04f, backgroundY, 0.0f);
                }
                else background2.transform.position = new Vector3(0.04f, backgroundY, 0.0f);
            }
            else
            {
                if (background1.transform.position.y > background3.transform.position.y)
                {
                    background3.transform.position = new Vector3(0.04f, backgroundY, 0.0f);
                }
                else background1.transform.position = new Vector3(0.04f, backgroundY, 0.0f);
            }            
        }
        scoreText.text = plat.ToString();
    }
}
