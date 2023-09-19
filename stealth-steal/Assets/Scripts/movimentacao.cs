using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentacao : MonoBehaviour
{
    private CharacterController personagem;
    private Animator animator;
    private Vector3 inputs;

    private float velocidade = 3.4f;
    private bool encontrado;


    // Start is called before the first frame update
    void Start()
    {
        personagem = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        inimigos.CasoInimigoEncontrouJogador += Encontrar;
    }

    // Update is called once per frame
    void Update()
    {
        if (!encontrado)
        {
            Movimentar();
        }
        
    }

    void Encontrar()
    {
        encontrado = true;
    }

    private void OnDestroy()
    {
        inimigos.CasoInimigoEncontrouJogador -= Encontrar;
    }

    void Movimentar()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        personagem.Move(inputs * Time.deltaTime * velocidade);
        personagem.Move(Vector3.down * Time.deltaTime);



        if (inputs != Vector3.zero)
        {
            animator.SetBool("andando", true);
            transform.forward = Vector3.Slerp(transform.forward, inputs, Time.deltaTime * 10);
        }
        else
        {
            animator.SetBool("andando", false);

        }
    }

    
}
