using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepoNpc : MonoBehaviour
{
    private bool telefonuZatenVerdin = false;

    private bool icerdeMi = false;

    private bool TurkceMi;

    public GameObject sarjMakinesi;


    public Text ekranBilgiText;
    public GameObject panelBilgi;


    private void Update()
    {
        if (!telefonuZatenVerdin && (Input.GetKeyDown(KeyCode.E) || FindObjectOfType<ButonKlavye>().butonaBasildiMi) && icerdeMi)
        {
            sarjMakinesi.GetComponent<SarjMakinesi>().TelefonuVer();

            ekranBilgiText.color = Color.black;
            panelBilgi.SetActive(true);


            if (TurkceMi)
            {

            
                ekranBilgiText.text = "Telefonu şarj edecek bir yer ara";
            }
            else
            {
                ekranBilgiText.text = "Find a place to charge the phone";
            }


            telefonuZatenVerdin = true;

            FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        icerdeMi = true;

        TurkceMi = FindObjectOfType<DilYoneticisi>().turkceMi;

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        icerdeMi = false;

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = false;

        FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;
    }

}
