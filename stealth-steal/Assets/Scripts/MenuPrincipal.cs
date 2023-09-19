using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject opcoes;

    public TransicaoCena carregarCena;
    public GameObject canva;
    public GameObject load;

    public void AbrirPrimeiraCena()
    {
        carregarCena.Transicao(1);
        canva.SetActive(false);
        load.SetActive(true);
    }

    public void AbrirOpcoes()
    {
        opcoes.SetActive(true);
        canva.SetActive(false);
    }

    public void FecharOpcoes()
    {
        opcoes.SetActive(false);
        canva.SetActive(true);
    }

    public void SairGame()
    {
        Application.Quit();
    }
}
