using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SahneGecisKorumaUI : MonoBehaviour
{
    static SahneGecisKorumaUI buHasBirKarakterdir;

    void Awake()
    {


        if (buHasBirKarakterdir == null)
        {
            buHasBirKarakterdir = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        else if (buHasBirKarakterdir != null)
        {
            Destroy(gameObject);
            Debug.Log("canvastan 1 den fazla ornek bulundu");
        }


    }
}
