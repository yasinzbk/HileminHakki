using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Yeni Esya", menuName = "Envanter/Portal")]
public class Portal : Esya
{
    public override void Kullan()
    {
        base.Kullan();





        if (FindObjectOfType<KarakterHareket>() == null)
        {
            Debug.Log("karakter bulunamadi");

        }
        else
        {

            FindObjectOfType<KarakterHareket>().Portal();
           


        }
    }
}
