using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KosuBaslatici : MonoBehaviour
{
    private float sure;

    private bool yarismaBittiMi = false;

    public float gecmesiGerekenSure;

    public float kosucu1Hizi, kosucu2Hizi;

    public GameObject kosucu1;

    public GameObject kosucu2;



    public Animator Kosucu1Anim;

    public Animator Kosucu2Anim;


    public int x;

    void Start()
    {
        sure = Time.time;

        RasgeleHiz();
        
        
    }

    private void Update()
    {
        if (Time.time >= sure + gecmesiGerekenSure && !yarismaBittiMi)
        {


            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            Kosucu1Anim.SetBool("YuruyorMu", true);
            Kosucu2Anim.SetBool("YuruyorMu", true);

            kosucu1.transform.position = new Vector3(kosucu1.transform.position.x + kosucu1Hizi * Time.deltaTime, kosucu1.transform.position.y, kosucu1.transform.position.z);
            kosucu2.transform.position = new Vector3(kosucu2.transform.position.x + kosucu2Hizi * Time.deltaTime, kosucu2.transform.position.y, kosucu2.transform.position.z);
        }
     
    }

    void RasgeleHiz()
    {
        x = Random.Range(1, 3);

        Debug.Log(x.ToString());

        switch (x)
        {
            case 1:
                kosucu1Hizi = 6f;
                kosucu2Hizi = 4f;

                break;

            case 2:
                kosucu1Hizi = 4f;
                kosucu2Hizi = 6f;
                break;


        }
    }


    public void KosuculariDurdur()
    {
        yarismaBittiMi = true;

        Kosucu1Anim.SetBool("YuruyorMu", false);
        Kosucu2Anim.SetBool("YuruyorMu", false);
    }
}
