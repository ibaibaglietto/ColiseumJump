using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockLevel : MonoBehaviour
{
    public GameObject Lvl2;
    public GameObject Lvl3;
    public GameObject Lvl4;
    public GameObject Lvl5;
    public GameObject Lvl6;
    public GameObject Lvl7;
    public GameObject Lvl8;
    public GameObject Lvl9;
    public GameObject Lvl10;
    public GameObject Lvl11;
    public GameObject Lvl12;
    public GameObject Lvl13;
    public GameObject Lvl14;
    public GameObject Lvl15;
    public GameObject Lvl16;
    public GameObject Lvl17;
    public GameObject Lvl18;
    public GameObject Lvl19;
    public GameObject Lvl20;
    public GameObject Lvl21;
    public GameObject Lvl22;
    public GameObject Lvl23;
    public GameObject Lvl24;
    public GameObject Lvl25;
    public GameObject Lvl26;
    public GameObject Lvl27;
    public GameObject Lvl28;
    public GameObject Lvl29;
    public GameObject Lvl30;
    public GameObject f2;
    public GameObject f3;
    public GameObject f4;
    public GameObject f5;
    public GameObject f6;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;
    public GameObject s6;
    public GameObject t4;
    public GameObject t5;
    public GameObject t6;
    public GameObject fo5;
    public GameObject fo6;
    public GameObject fi6;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Lvl") < 1) Lvl2.SetActive(false);
        else Lvl2.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 2) Lvl3.SetActive(false);
        else Lvl3.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 3) Lvl4.SetActive(false);
        else Lvl4.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 4) Lvl5.SetActive(false);
        else Lvl5.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 5) Lvl6.SetActive(false);
        else
        {
            Lvl6.SetActive(true);
            f2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Lvl") < 6) Lvl7.SetActive(false);
        else Lvl7.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 7) Lvl8.SetActive(false);
        else Lvl8.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 8) Lvl9.SetActive(false);
        else Lvl9.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 9) Lvl10.SetActive(false);
        else Lvl10.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 10) Lvl11.SetActive(false);
        else
        {
            Lvl11.SetActive(true);
            f3.SetActive(true);
            s3.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Lvl") < 11) Lvl12.SetActive(false);
        else Lvl12.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 12) Lvl13.SetActive(false);
        else Lvl13.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 13) Lvl14.SetActive(false);
        else Lvl14.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 14) Lvl15.SetActive(false);
        else Lvl15.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 15) Lvl16.SetActive(false);
        else
        {
            Lvl16.SetActive(true);
            f4.SetActive(true);
            s4.SetActive(true);
            t4.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Lvl") < 16) Lvl17.SetActive(false);
        else Lvl17.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 17) Lvl18.SetActive(false);
        else Lvl18.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 18) Lvl19.SetActive(false);
        else Lvl19.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 19) Lvl20.SetActive(false);
        else Lvl20.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 20) Lvl21.SetActive(false);
        else
        {
            Lvl21.SetActive(true);
            f5.SetActive(true);
            s5.SetActive(true);
            t5.SetActive(true);
            fo5.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Lvl") < 21) Lvl22.SetActive(false);
        else Lvl22.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 22) Lvl23.SetActive(false);
        else Lvl23.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 23) Lvl24.SetActive(false);
        else Lvl24.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 24) Lvl25.SetActive(false);
        else Lvl25.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 25) Lvl26.SetActive(false);
        else
        {
            Lvl26.SetActive(true);
            f6.SetActive(true);
            s6.SetActive(true);
            t6.SetActive(true);
            fo6.SetActive(true);
            fi6.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Lvl") < 26) Lvl27.SetActive(false);
        else Lvl27.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 27) Lvl28.SetActive(false);
        else Lvl28.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 28) Lvl29.SetActive(false);
        else Lvl29.SetActive(true);
        if (PlayerPrefs.GetInt("Lvl") < 29) Lvl30.SetActive(false);
        else Lvl30.SetActive(true);

    }


}
