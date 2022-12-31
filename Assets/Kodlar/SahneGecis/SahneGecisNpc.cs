using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class SahneGecisNpc : MonoBehaviour
{
    public string lvl;


    private bool yakinindaMi = false;



    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || FindObjectOfType<ButonKlavye>().butonaBasildiMi) && yakinindaMi)
        {

            FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;


            FindObjectOfType<KosuSonuclandirici>().ReklamsizEkranYukle();

            //SceneManager.LoadScene(lvl);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        yakinindaMi = true;

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        yakinindaMi = false;

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = false;
    }




}
