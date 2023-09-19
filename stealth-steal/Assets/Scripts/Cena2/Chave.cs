using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chave : MonoBehaviour
{
    public GameObject chave;

    public TMP_Text mensagem;
    private Ray ray;
    private RaycastHit hitData;
    public Transform point;
    public Transform jogador;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ChaveController.chaveContador<2)
        {
            ChaveController.ColetarChave(ray, point, jogador, hitData, mensagem);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(chave);
                ChaveController.chaveContador = 2;
                mensagem.text = "";
            }
        }
    }
}
