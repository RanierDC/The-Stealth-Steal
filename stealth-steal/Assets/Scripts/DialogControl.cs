using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogControl : MonoBehaviour
{
    [Header("Componentes")]
    public GameObject dialogObj;
    public Image actorImg;
    public TMP_Text speechText;
    public TMP_Text actorName;


    public void Fala(Sprite p, string txt, string name)
    {
        dialogObj.SetActive(true);
        actorImg.sprite = p;
        speechText.text = txt;
        actorName.text = name;
    }

    public void FecharFala()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogObj.SetActive(false);
        }
    }
}
