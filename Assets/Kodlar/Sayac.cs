using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sayac : MonoBehaviour
{

    public Text sayacTxt;


    public void SayacTxt2()
    {
        sayacTxt.text = "2";
        FindObjectOfType<SesYoneticisi>().Oynat("TikSesi1");
    }


    public void SayacTxt1()
    {
        sayacTxt.text = "1";

        FindObjectOfType<SesYoneticisi>().Oynat("TikSesi1");
    }


    public void TikSesi2()
    {
        FindObjectOfType<SesYoneticisi>().Oynat("TikSesi2");
    }
}
