using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SahneGecisObjeKoruma : MonoBehaviour
{
    static SahneGecisObjeKoruma buHasBirKarakterdir;

    void Awake()
    {
        

        if (buHasBirKarakterdir != null)
        {
            Destroy(this.gameObject);
            return;
        }

        buHasBirKarakterdir = this;
        GameObject.DontDestroyOnLoad(this.gameObject);

    }
}
