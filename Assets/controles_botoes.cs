using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // 1. Função para o Botão Iniciar
    public void IniciarJogo()
    {
        SceneManager.LoadScene("Iniciou!"); // Substitua pelo nome da sua fase
    }


    // 2. Função para o Botão Sair
    public void SairDoJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}