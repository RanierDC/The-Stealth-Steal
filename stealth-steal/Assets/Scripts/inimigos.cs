using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inimigos : MonoBehaviour
{
    public static event System.Action CasoInimigoEncontrouJogador;
    public Transform pathHolder;
    

    public float tempoEncontrarJogador = .5f;
    private float tempoVisivelJogador;

    public Light pontoLuz;
    public float distanciaVisao;
    public LayerMask maskVisao;
    private float anguloVisao;
    private Color corOriginalLuz;

    public float velocidade = 5f;
    public float tempoEspera = .3f;
    public float velocidadeGiro = 90f;

    private Transform jogador;

    public AudioSource passo1;
    public AudioSource passo2;

    private void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        anguloVisao = pontoLuz.spotAngle;
        corOriginalLuz = pontoLuz.color;

        Vector3[] caminho = new Vector3[pathHolder.childCount];
        for(int i = 0; i < caminho.Length; i++)
        {
            caminho[i] = pathHolder.GetChild(i).position;
        }
        StartCoroutine(FollowPath(caminho));
    }

    private void Update()
    {
        if(verJogador())
        {
            tempoVisivelJogador += Time.deltaTime;
        }
        else
        {
            tempoVisivelJogador -= Time.deltaTime;
        }
        tempoVisivelJogador = Mathf.Clamp(tempoVisivelJogador, 0, tempoEncontrarJogador);
        pontoLuz.color = Color.Lerp(corOriginalLuz, Color.red, tempoVisivelJogador / tempoEncontrarJogador);

        if(tempoVisivelJogador >= tempoEncontrarJogador)
        {
            if(CasoInimigoEncontrouJogador != null)
            {
                CasoInimigoEncontrouJogador();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    bool verJogador()
    {
        if(Vector3.Distance(transform.position, jogador.position) < distanciaVisao)
        {
            Vector3 dirJogador = (jogador.position - transform.position).normalized;
            float anguloEntreJogadorGuarda = Vector3.Angle(transform.forward, dirJogador);
            if (anguloEntreJogadorGuarda < anguloVisao / 2f)
            {
                if(!Physics.Linecast(transform.position, jogador.position, maskVisao))
                {
                    return true;
                }
            }
        }
        return false;
    }

    IEnumerator FollowPath(Vector3[] caminho)
    {
        transform.position = caminho[0];

        int indexProximoPonto = 1;
        Vector3 proximoPonto = caminho[indexProximoPonto];
        transform.LookAt(proximoPonto);

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, proximoPonto, velocidade * Time.deltaTime);
            if(transform.position == proximoPonto)
            {
                indexProximoPonto = (indexProximoPonto + 1) % caminho.Length;
                proximoPonto = caminho[indexProximoPonto];

                yield return new WaitForSeconds(tempoEspera);
                yield return StartCoroutine(Girar(proximoPonto));
            }
            yield return null;
        }    
    }

    IEnumerator Girar(Vector3 pontoParaOlhar)
    {
        Vector3 dirPontoParaOlhar = (pontoParaOlhar - transform.position).normalized;
        float anguloPonto = 90 - Mathf.Atan2(dirPontoParaOlhar.z, dirPontoParaOlhar.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, anguloPonto)) > 0.05f)
        {
            float angulo = Mathf.MoveTowardsAngle(transform.eulerAngles.y, anguloPonto, velocidadeGiro * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angulo;
            yield return null;
        }
    }

    void OnDrawGizmos()
    {
        Vector3 posicaoInicial = pathHolder.GetChild(0).position;
        Vector3 posicaoAnterior = posicaoInicial;
        foreach(Transform point in pathHolder)
        {
            Gizmos.DrawSphere(point.position, .2f);
            Gizmos.DrawLine(posicaoAnterior, point.position);
            posicaoAnterior = point.position;
        }
        Gizmos.DrawLine(posicaoAnterior, posicaoInicial);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * distanciaVisao);
    }

    public void Passo1()
    {
        passo1.Play();
    }

    public void Passo2()
    {
        passo2.Play();
    }
}
