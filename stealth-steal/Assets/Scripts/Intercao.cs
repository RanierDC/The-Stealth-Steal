using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Intercao : MonoBehaviour
{
    public TMP_Text mensagem;
    public BoxCollider colisor;
    private bool interagivel;
    private Ray ray;
    private RaycastHit hitData;
    public Transform point;

    private int angulo1;
    private int angulo2;

    private Quaternion rotacao1;
    private Quaternion rotacao2;

    public Transform porta1;
    public Transform porta2;


    // Update is called once per frame
    void Update()
    {
        DesenharRaio();
        AbrirPorta();
    }

    public void AbrirPorta()
    {
        rotacao1 = Quaternion.Euler(270, 0, angulo1);
        rotacao2 = Quaternion.Euler(270, 0, angulo2);
        porta1.rotation = Quaternion.Slerp(porta1.rotation, rotacao1, Time.deltaTime * 5);
        porta2.rotation = Quaternion.Slerp(porta2.rotation, rotacao2, Time.deltaTime * 5);

        if (interagivel == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                colisor.enabled = false;

                if(angulo1 == 90 && angulo2 == -90)
                {
                    angulo1 = 0;
                    angulo2 = 0;
                }
                else
                {
                    angulo1 = 90;
                    angulo2 = -90;
                }
                SceneManager.LoadScene(2);
            }
        }
    }

    public void DesenharRaio()
    {
        ray = new Ray(point.position, transform.forward );

        if (Physics.Raycast(ray, out hitData, 5))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            string tag = hitData.collider.tag;
            Debug.Log("Você acertou um " + tag);

            if (tag == "Interagivel")
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
            Debug.DrawRay(ray.origin, ray.direction , Color.magenta);
        }
    }
}
