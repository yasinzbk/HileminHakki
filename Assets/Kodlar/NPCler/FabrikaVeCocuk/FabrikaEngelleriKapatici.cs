using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabrikaEngelleriKapatici : MonoBehaviour
{
    public GameObject[] engeller;

    

    public void EngelKapat()
    {
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i].GetComponent<EngelKarakterKontrol>().EngelKapat();

        }
    }




}
