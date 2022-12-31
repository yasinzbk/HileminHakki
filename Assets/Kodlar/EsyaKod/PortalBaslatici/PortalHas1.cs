using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHas1 : MonoBehaviour
{
    static PortalHas1 buHasBirKarakterdir;
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
