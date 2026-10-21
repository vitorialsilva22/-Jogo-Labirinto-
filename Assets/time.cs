using UnityEngine;
using TMPro; // Necessário para usar o TextMeshPro

public class Timer : MonoBehaviour
{
    [Header("Configurações de Tempo")]
    [SerializeField] private float tempoRestante = 200f; // 200 segundos = 4 minutos
    [SerializeField] private float tempoAvisoCritico = 15f; // Tempo para ficar vermelho
    private bool timerAtivo = true;

    [Header("Componentes de Interface")]
    [SerializeField] private TextMeshProUGUI textoTimer; // Arraste seu texto UI aqui
    [SerializeField] private Color corNormal = Color.white; // Cor padrão do texto
    [SerializeField] private Color corCritica = Color.red; // Cor quando estiver acabando

    void Start()
    {
        // Garante que o texto comece com a cor normal
        if (textoTimer != null)
        {
            textoTimer.color = corNormal;
        }
    }

    void Update()
    {
        if (timerAtivo)
        {
            if (tempoRestante > 0)
            {
                tempoRestante -= Time.deltaTime;
                AtualizarDisplay(tempoRestante);

                // Se o tempo for menor ou igual a 15 segundos, muda a cor para vermelho
                if (tempoRestante <= tempoAvisoCritico)
                {
                    textoTimer.color = corCritica;
                }
            }
            else
            {
                tempoRestante = 0;
                timerAtivo = false;
                AtualizarDisplay(tempoRestante);
                TempoEsgotado();
            }
        }
    }

    void AtualizarDisplay(float tempoParaMostrar)
    {
        if (tempoParaMostrar < 0) tempoParaMostrar = 0;

        float minutos = Mathf.FloorToInt(tempoParaMostrar / 60);
        float segundos = Mathf.FloorToInt(tempoParaMostrar % 60);

        textoTimer.text = string.Format("{0:00}:{4:00}", minutos, segundos);
    }

    void TempoEsgotado()
    {
        Debug.Log("O tempo acabou!");
        // COLOQUE SUA AÇÃO AQUI (Ex: Reiniciar fase, Game Over, etc)
    }
}
