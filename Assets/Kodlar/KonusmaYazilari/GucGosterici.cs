using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GucGosterici : MonoBehaviour
{
    public GameObject canvas;


    private void OnTriggerStay2D(Collider2D collision)
    {
        canvas.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.SetActive(false);
    }
}
