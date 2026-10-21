using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Estado do jogo")]
    public int pontuacaoInicial = 50;
    public float tempoInicial = 120f;

    [Header("Pontuação dos baús")]
    public int pontosBauComum = 20;
    public int pontosBauSupremo = 200;

    [Header("Bônus de tempo")]
    public float bonusTempo = 10f;

    [Header("Penalidade por demora")]
    public float intervaloPenalidade = 15f;
    public int pontosPerdidos = 5;

    [Header("Interface")] 
    public TMP_Text textoPontuacao;
    public TMP_Text textoTempo;
    public GameObject telaGameOver;
    public GameObject telaVitoria;

    private int pontuacao;
    private float tempoRestante;
    private float tempoSemBau;
    private bool jogoAtivo;
    private bool venceu;

    public bool JogoAtivo => jogoAtivo;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        IniciarJogo();
    }

    private void Update()
    {
        if (!jogoAtivo)
            return;

        tempoRestante -= Time.deltaTime;
        tempoSemBau += Time.deltaTime;

        // Penalidade a cada intervalo sem encontrar baus.
        while (tempoSemBau >= intervaloPenalidade)
        {
            tempoSemBau -= intervaloPenalidade;
            pontuacao = Mathf.Max(0, pontuacao - pontosPerdidos);
        }

        if (tempoRestante <= 0f)
        {
            tempoRestante = 0f;
            AtualizarInterface();
            EncerrarJogo(false);
            return;
        }

        AtualizarInterface();
    }

    public void EncontrouBau(bool supremo)
    {
        if (!jogoAtivo)
            return;

        if (supremo)
        {
            pontuacao += pontosBauSupremo;
        }
        else
        {
            pontuacao += pontosBauComum;
        }

        tempoRestante += bonusTempo;

        // Zera o tempo acumulado sem encontrar baus.
        tempoSemBau = 0f;

        AtualizarInterface();

        if (supremo)
        {
            EncerrarJogo(true);
        }
    }

    private void AtualizarInterface()
    {
        if (textoPontuacao != null)
            textoPontuacao.text = "Pontos: " + pontuacao;

        if (textoTempo != null)
        {
            int segundos = Mathf.CeilToInt(tempoRestante);
            int minutos = segundos / 60;
            segundos %= 60;

            textoTempo.text = string.Format(
                "Tempo: {0:00}:{1:00}",
                minutos,
                segundos
            );
        }
    }

    private void EncerrarJogo(bool ganhou)
    {
        jogoAtivo = false;
        venceu = ganhou;

        if (telaGameOver != null)
            telaGameOver.SetActive(!ganhou);

        if (telaVitoria != null)
            telaVitoria.SetActive(ganhou);

        AtualizarInterface();

        Debug.Log(ganhou
            ? "Vitória! Baú supremo encontrado."
            : "Game Over! O tempo acabou.");
    }

    public void IniciarJogo()
    {
        pontuacao = pontuacaoInicial;
        tempoRestante = tempoInicial;
        tempoSemBau = 0f;
        jogoAtivo = true;
        venceu = false;

        if (telaGameOver != null)
            telaGameOver.SetActive(false);

        if (telaVitoria != null)
            telaVitoria.SetActive(false);

        AtualizarInterface();
    }

    public void ReiniciarJogo()
    {
        IniciarJogo();
    }
}