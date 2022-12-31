using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaziDenetleyici : MonoBehaviour
{
    public GameObject buObje;
    public Yazi yazi;
    MeshRenderer cumle;


    private void Awake()
    {
        cumle = buObje.GetComponent<MeshRenderer>();
        buObje.GetComponent<TextMesh>().text = yazi.cumleler;
        
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
