using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChaveController : MonoBehaviour
{
    public static int chaveContador;

    public static bool interagivel;

    public TMP_Text mensagem;
    private Ray ray;
    private RaycastHit hitData;
    public Transform point;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chaveContador == 2)
        {
            LiberarElevador();
        }
    }

    public static void ColetarChave(Ray ray, Transform point, Transform player, RaycastHit hitData, TMP_Text mensagem)
    {
        ray = new Ray(point.position, player.forward);

        if (Physics.Raycast(ray, out hitData, 5))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            string tag = hitData.collider.tag;
            Debug.Log("Você acertou um " + tag);

            if (tag == "Interagivel")
            {
                interagivel = true;
                mensagem.text = "Pressione 'E' para pegar";
                
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

    void LiberarElevador()
    {
        ray = new Ray(point.position, transform.forward);

        if (Physics.Raycast(ray, out hitData, 5))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            string tag = hitData.collider.tag;
            Debug.Log("Você acertou um " + tag);

            if (tag == "Elevador")
            {
                mensagem.text = "Pressione 'E' para passar de fase";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(3);
                }
            }
            else
            {
                mensagem.text = "";
            }
        }
    }
}
