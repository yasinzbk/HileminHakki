using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DilDegistirStat : MonoBehaviour
{
    private bool yakinindaMi = false;

    public string HangiDil;

    public MeshRenderer stantYazi;


    public GameObject bilgiPanel;
    public Text ekranBilgiText;



    private void Update()
    {


        if (yakinindaMi && (Input.GetKeyDown(KeyCode.E) || FindObjectOfType<ButonKlavye>().butonaBasildiMi))
        {
           
            FindObjectOfType<DilYoneticisi>().DilDegistir(HangiDil);

            if (HangiDil == "Turkce")
            {
                ekranBilgiText.color = Color.black;
                bilgiPanel.SetActive(true);

                ekranBilgiText.text = "Dil: Türkçe";
            }
            else
            {
                ekranBilgiText.color = Color.black;
                bilgiPanel.SetActive(true);

                ekranBilgiText.text = "Language: English";
            }


            FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;
        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        yakinindaMi = true;

        stantYazi.enabled = true;

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        yakinindaMi = false;

        stantYazi.enabled = false;

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = false;
    }
}
