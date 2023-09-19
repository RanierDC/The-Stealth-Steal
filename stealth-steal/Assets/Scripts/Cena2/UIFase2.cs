using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFase2 : MonoBehaviour
{
    public GameObject guiDerrota;
    private bool perdeu;

    public GameObject opcoes;
    public Transform menu;

    public GameObject pause;
    public GameObject load;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AbrirOpcoes();
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

    public static void MostarGuiDerrota(GameObject gameOverUI)
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);

        
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
        pause.SetActive(false);
        load.SetActive(true);
    }
}