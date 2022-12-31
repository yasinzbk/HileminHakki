using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaslangicPanelAcici : MonoBehaviour
{
    private bool paneli1KezActiMi = false;

    public GameObject englishPanel;
    public GameObject turkishPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PanelAc();
    }

    public void PanelAc()
    {
        if (!paneli1KezActiMi)
        {
        if (FindObjectOfType<DilYoneticisi>().turkceMi)
        {
            turkishPanel.SetActive(true);
        }
        else
        {
            englishPanel.SetActive(true);
        }


            paneli1KezActiMi = true;

        }



    }

}
