using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocukOzellestirici : MonoBehaviour
{
    static CocukOzellestirici buHasBirKarakterdir;

    public bool oyununBasiMi = true;


    void Awake()
    {


        if (buHasBirKarakterdir != null)
        {
            Destroy(this.gameObject);
            return;
        }

        buHasBirKarakterdir = this;
        GameObject.DontDestroyOnLoad(this.gameObject);


        if (oyununBasiMi)
        {
           
            gameObject.SetActive(false);
            oyununBasiMi = false;
        }
    }






}
