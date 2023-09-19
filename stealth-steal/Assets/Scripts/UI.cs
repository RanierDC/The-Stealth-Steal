using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject guiDerrota;
    private bool perdeu;

    public GameObject opcoes;
    public Transform menu;

    public TransicaoCena carregarCena;
    public GameObject pause;
    public GameObject load;

    // Start is called before the first frame update
    void Start()
    {
        inimigos.CasoInimigoEncontrouJogador += MostarGuiDerrota;
    }

    // Update is called once per frame
    void Update()
    {
        AbrirOpcoes();
        if (perdeu)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                carregarCena.Transicao(0);
                load.SetActive(true);
            }
        }
        
    }

    void AbrirOpcoes()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.gameObject.activeSelf)
            {
                opcoes.SetActive(false);
                pause.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pause.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    void MostarGuiDerrota()
    {
        GameOver(guiDerrota);
    }

    void GameOver (GameObject gameOverUI)
    {
        gameOverUI.SetActive(true);
        perdeu = true;
        inimigos.CasoInimigoEncontrouJogador += MostarGuiDerrota;
    }

    public void Voltar()
    {
        opcoes.SetActive(false);
        menu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void abrirOpcoes()
    {
        opcoes.SetActive(true);
        pause.SetActive(false);
    }

    public void fecharOpcoes()
    {
        opcoes.SetActive(false);
        pause.SetActive(true);
    }

    public void VoltarMenu()
    {
        carregarCena.Transicao(0);
        pause.SetActive(false);
        load.SetActive(true);
    }
}

