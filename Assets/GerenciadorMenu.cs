using UnityEngine;
using UnityEngine.UI; // Necessário para usar o componente Button
using UnityEngine.SceneManagement; // Necessário para carregar cenas

public class GerenciadorMenu : MonoBehaviour
{
    [Header("Configurações do Botão")]
    [SerializeField] private Button botaoJogar;
    [SerializeField] private string nomeDaCenaJogavel;

    private void Start()
    {
        // Verifica se o botão foi atribuído no Inspector antes de registrar o evento
        if (botaoJogar != null)
        {
            botaoJogar.onClick.AddListener(IniciarJogo);
        }
        else
        {
            Debug.LogError("Por favor, atribua o Botão Jogar no Inspector!", this);
        }
    }

    private void IniciarJogo()
    {
        // Verifica se o nome da cena não está vazio
        if (!string.IsNullOrEmpty(nomeDaCenaJogavel))
        {
            SceneManager.LoadScene(nomeDaCenaJogavel);
        }
        else
        {
            Debug.LogWarning("O nome da cena jogável não foi definido no Inspector!");
        }
    }

    private void OnDestroy()
    {
        // Boa prática: remove o listener quando o objeto é destruído para evitar vazamento de memória
        if (botaoJogar != null)
        {
            botaoJogar.onClick.RemoveListener(IniciarJogo);
        }
    }
}