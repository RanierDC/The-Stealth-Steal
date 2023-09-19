using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncontrarInimigo : MonoBehaviour
{
    public static event System.Action CasoInimigoEncontrouJogador;

    public float tempoEncontrarJogador = .5f;
    private float tempoVisivelJogador;

    public Light pontoLuz;
    public float distanciaVisao;
    public LayerMask maskVisao;
    private float anguloVisao;
    private Color corOriginalLuz;

    private Transform jogador;
    public GameObject guiDerrota;

    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        anguloVisao = pontoLuz.spotAngle;
        corOriginalLuz = pontoLuz.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (verJogador())
        {
            tempoVisivelJogador += Time.deltaTime;
        }
        else
        {
            tempoVisivelJogador -= Time.deltaTime;
        }
        tempoVisivelJogador = Mathf.Clamp(tempoVisivelJogador, 0, tempoEncontrarJogador);
        pontoLuz.color = Color.Lerp(corOriginalLuz, Color.red, tempoVisivelJogador / tempoEncontrarJogador);

        if (tempoVisivelJogador >= tempoEncontrarJogador)
        {
            UIFase2.MostarGuiDerrota(guiDerrota);
            ConfirmarDerrota();
        }
    }

    void ConfirmarDerrota()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
    }

    bool verJogador()
    {
        if (Vector3.Distance(transform.position, jogador.position) < distanciaVisao)
        {
            Vector3 dirJogador = (jogador.position - transform.position).normalized;
            float anguloEntreJogadorGuarda = Vector3.Angle(transform.forward, dirJogador);
            if (anguloEntreJogadorGuarda < anguloVisao / 2f)
            {
                if (!Physics.Linecast(transform.position, jogador.position, maskVisao))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
