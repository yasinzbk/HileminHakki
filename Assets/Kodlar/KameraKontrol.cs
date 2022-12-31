using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class KameraKontrol : MonoBehaviour
{


    public GameObject eskiTakipEdilenObje;
    public GameObject kameraObje;

    


    private void Start()
    {
        eskiTakipEdilenObje = GameObject.Find("Karakter");
    }

    public void TakipEdilenKisiyiDegistir(GameObject takipEdilecekObje, float kameraDegistirmeSuresi)
    {
       

        StartCoroutine(KameraTakipDegistir(takipEdilecekObje, kameraDegistirmeSuresi));


    }



      IEnumerator KameraTakipDegistir(GameObject takipEdilecekObje, float kameraDegismeSuresi)
    {

        
        kameraObje.GetComponent<CinemachineVirtualCamera>().Follow = takipEdilecekObje.transform;

        yield return new WaitForSeconds(kameraDegismeSuresi);
        kameraObje.GetComponent<CinemachineVirtualCamera>().Follow = eskiTakipEdilenObje.transform;
    }

    

}
