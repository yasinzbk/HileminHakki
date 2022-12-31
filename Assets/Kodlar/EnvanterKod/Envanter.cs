using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envanter : MonoBehaviour
{
    #region Singleton
    public static Envanter ornek;

    private void Awake()
    {
        //if(ornek != null)
        //{
        //    Debug.LogWarning("Envanterden 1 den fazla ornek bulundu");
        //    Destroy(ornek.gameObject);

        //    return;
        //}
        //ornek = this;

        if (ornek == null)
        {
            ornek = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (ornek != null)
        {
            Debug.LogWarning("Esya Birlestiriciden 1 den fazla ornek bulundu");
        }
    }
    #endregion

    public delegate void EsyaDegistiginde();
    public EsyaDegistiginde esyaDegistigindeGeriCagir;

    public int bosYer = 10;

    public List<Esya> esyalar = new List<Esya>();



    public bool Ekle ( Esya esya)
    {
        if (esyalar.Count >= bosYer)
        {
            Debug.Log(" Yer Yok");
            return false;
        }
        esyalar.Add(esya);

        if (esyaDegistigindeGeriCagir != null)
        {
        esyaDegistigindeGeriCagir.Invoke();
        }

        return true;
    }

    public void Kaldir(Esya esya)
    {
        esyalar.Remove(esya);

        if (esyaDegistigindeGeriCagir != null)
        {
            esyaDegistigindeGeriCagir.Invoke();
        }
    }
}
