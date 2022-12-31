using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Yeni Esya", menuName = "Envanter/Kostum")]
public class Kostum : Esya
{
    override public void Kullan()
    {







        if (FindObjectOfType<ErkekHalterYarismasi>() == null)
        {
            Debug.Log("sarki yarismasi bulunamadi");

        }
        else
        {

            FindObjectOfType<ErkekHalterYarismasi>().KostumKullanKullanma();
        }




        if (FindObjectOfType<KarakterHareket>() == null)
        {
            Debug.Log("sarki yarismasi bulunamadi");

        }
        else
        {

            FindObjectOfType<KarakterHareket>().CinsiyetDegis();

        }
    }
}
