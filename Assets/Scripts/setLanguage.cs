using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setLanguage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Dropdown>().value = PlayerPrefs.GetInt("Language");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Language", GetComponent<Dropdown>().value);
    }
}
