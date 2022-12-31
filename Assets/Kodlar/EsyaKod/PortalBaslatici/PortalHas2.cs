using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHas2 : MonoBehaviour
{
    static PortalHas2 buHasBirKarakterdir;
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
