using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public Sprite actorImg;
    public string speechText;
    public string actorName;

    private DialogControl dc;

    public void Start()
    {
        dc = FindObjectOfType<DialogControl>();
        Interacao();
    }

    private void Update()
    {
        FecharInteracao();
    }

    public void Interacao()
    {
        dc.Fala(actorImg, speechText, actorName);
    }

    public void FecharInteracao()
    {
        dc.FecharFala();
    }
}
