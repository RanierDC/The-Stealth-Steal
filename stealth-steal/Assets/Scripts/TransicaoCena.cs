using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoCena : MonoBehaviour
{
    public Animator animacaoTransicao;

    public void Transicao(int sceneNumber)
    {
        StartCoroutine(CarregarCena(sceneNumber));
    }

    IEnumerator CarregarCena(int sceneNumber)
    {
        animacaoTransicao.SetTrigger("Comeco");

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneNumber);
        
    }
}
