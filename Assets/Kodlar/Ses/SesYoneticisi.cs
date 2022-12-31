using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SesYoneticisi : MonoBehaviour
{
    public bool sesAcikMi = true;

    public Ses[] Sesler;

    public static SesYoneticisi ornek;

    public GameObject sesButonObj;
    public Sprite sesAcikSp;
    public Sprite sesKapaliSp;

    private void Awake()
    {
        if (ornek == null)
            ornek = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        foreach (Ses s in Sesler)
        {
            s.sesKaynagi = gameObject.AddComponent<AudioSource>();
            s.sesKaynagi.clip = s.klip;

            s.sesKaynagi.volume = s.siddeti;
            s.sesKaynagi.pitch = s.perde;
            s.sesKaynagi.loop = s.dongu;
        }
    }

    private void Start()
    {
        Oynat("AnaMuzik");
    }


    private void Update()
    {
        if (!sesAcikMi)
        {
            foreach (Ses s in Sesler)
            {
                s.sesKaynagi.mute = true;

            }
        }
        else
        {
            foreach (Ses s in Sesler)
            {
                s.sesKaynagi.mute = false;

            }
        }
    }


    public void Oynat(string Ad)
    {
        Ses s = Array.Find(Sesler, ses => ses.Ad == Ad);

        if (s == null)
        {
            Debug.LogWarning("Ses: " + Ad + " Bulunamadı");
            return;
        }

        s.sesKaynagi.Play();
        
    }

    public void Durdur(string Ad)
    {
        Ses s = Array.Find(Sesler, ses => ses.Ad == Ad);

        if (s == null)
        {
            Debug.LogWarning("Ses: " + Ad + " Bulunamadı");
            return;
        }

            s.sesKaynagi.Stop();

    }



    public void sesAcKapat()
    {
        if (sesAcikMi)
        {
            sesButonObj.GetComponent<Image>().sprite = sesKapaliSp;

            sesAcikMi = false;
        }
        else
        {
            sesButonObj.GetComponent<Image>().sprite = sesAcikSp;

            sesAcikMi = true;
        }


    }


}
