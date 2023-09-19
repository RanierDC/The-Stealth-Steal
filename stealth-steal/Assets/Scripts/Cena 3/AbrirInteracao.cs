using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class AbrirInteracao : MonoBehaviour
{
    public GameObject guiVitoria;

    public TMP_Text mensagem;
    public BoxCollider colisor;
    public BoxCollider colisorPasta;
    private bool interagivel;
    private Ray ray;
    private RaycastHit hitData;
    public Transform point;

    private int angulo;

    private Quaternion rotacao;

    public Transform portaCofre;

    private void Start()
    {
        colisorPasta.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        DesenharRaio();
        AbrirCofre();
        if(colisor.enabled == false && colisorPasta.enabled == true)
        {
            PegarPasta();
        }
    }

    public void AbrirCofre()
    {
        rotacao = Quaternion.Euler(270, 0, angulo);
        portaCofre.rotation = Quaternion.Slerp(portaCofre.rotation, rotacao, Time.deltaTime * 5);

        if (interagivel == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                colisor.enabled = false;

                mensagem.enabled = false;
                if (angulo == -90)
                {
                    angulo = 0;
                    
                }
                else
                {
                    angulo = -90;
                    
                }
                
            }
        }
        colisorPasta.enabled = true;
    }

    public void DesenharRaio()
    {
        ray = new Ray(point.position, point.forward);

        if (Physics.Raycast(ray, out hitData, 10))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            string tag = hitData.collider.tag;
            Debug.Log("Você acertou um " + tag);

            if (tag == "Cofre")
            {
                mensagem.text = "Pressione 'E' para abrir";
                interagivel = true;
            }
            else
            {
                mensagem.text = "";
                interagivel = false;
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.magenta);
        }
    }

    public void PegarPasta()
    {
        if (Physics.Raycast(ray, out hitData, 10))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            string tag = hitData.collider.tag;
            Debug.Log("Você acertou um " + tag);

            if (tag == "Pasta")
            {
                mensagem.text = "Pressione 'E' para abrir";
                interagivel = true;
            }
            else
            {
                mensagem.text = "";
                interagivel = false;
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.magenta);
        }

        if (interagivel == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 1f;
                guiVitoria.SetActive(true);
            }
        }
    }

    public void VoltarMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
}
