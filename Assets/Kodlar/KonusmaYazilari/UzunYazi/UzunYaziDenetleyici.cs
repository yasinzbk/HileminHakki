using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UzunYaziDenetleyici : MonoBehaviour
{

    public Text dialogText;

	public GameObject textObje;

    private Queue<string> cumleler;

	public bool dilTurkceMi = true;

	void Start()
	{
		cumleler = new Queue<string>();
		

	}

	public void StartDialogue(Dialog dialog)
	{
		dilTurkceMi = GameObject.FindObjectOfType<DilYoneticisi>().turkceMi;


		cumleler.Clear();

        if (dilTurkceMi)
        {
			foreach (string cumle in dialog.cumleler)
			{
				cumleler.Enqueue(cumle);
			}

        }
        else
        {
			foreach (string cumle in dialog.cumlelerENG)
			{
				cumleler.Enqueue(cumle);
			}
		}




		DisplayNextSentence();

	}

	public void DisplayNextSentence()
	{
		Debug.Log("diger cumleye gecti");
		if (cumleler.Count == 0)
		{
			EndDialogue();
			return;
		}

		string cumle = cumleler.Dequeue();
        StopAllCoroutines();
		StartCoroutine(DaktiloCumle(cumle));
    }

    IEnumerator DaktiloCumle(string cumle)
    {
        dialogText.text = "";
        foreach (char harf in cumle.ToCharArray())
        {
            dialogText.text += harf;
            yield return new WaitForSeconds(0.1f);
        }
		yield return new WaitForSeconds(1f);
		DisplayNextSentence();
    }




    void EndDialogue()
	{
		
		Debug.Log("cumleler bitti");
		//cumle bitince ne olcaksa yap
	}
}
