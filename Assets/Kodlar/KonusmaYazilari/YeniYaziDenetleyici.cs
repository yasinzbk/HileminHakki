using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeniYaziDenetleyici : MonoBehaviour
{
    public GameObject buObje;
    public Dialog yazi;
    MeshRenderer cumle;

    public bool dilTurkceMi = true;

    private void Start()
    {
        

        cumle = buObje.GetComponent<MeshRenderer>();



       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dilTurkceMi = GameObject.FindObjectOfType<DilYoneticisi>().turkceMi;

        if (dilTurkceMi)
        {
            for (int i = 0; i < yazi.cumleler.Length; i++)
            {
                buObje.GetComponent<TextMesh>().text = yazi.cumleler[i];
            }
        }
        else
        {
            for (int i = 0; i < yazi.cumlelerENG.Length; i++)
            {
                buObje.GetComponent<TextMesh>().text = yazi.cumlelerENG[i];
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        cumle.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cumle.enabled = false;
    }
}
