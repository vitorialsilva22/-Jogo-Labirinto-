using UnityEngine;

public class ControleBau : MonoBehaviour
{
    private Animator animator;
    private bool jaAbriu = false;

    // Variável para guardar os pontos do jogador de forma simples
    public static int pontosDoJogador = 0;

    void Start()
    {
        // Pega o componente Animator anexado ao baú
        animator = GetComponent<Animator>();
    }

    // Detecta a colisão física
    private void OnCollisionEnter(Collision collision)
    {
        // 1. Sabe se quem entrou na colisão é o player (e se o baú ainda não abriu)
        if (collision.gameObject.CompareTag("Player") && !jaAbriu)
        {
            jaAbriu = true;

            // 2. Se o animator existir, troca o Trigger como verdadeiro (ativa o "abrir")
            if (animator != null)
            {
                animator.SetTrigger("abrir");
            }

            // 3. Depois aumenta os pontos do jogador
            pontosDoJogador += 10;
            Debug.Log("Pontos aumentados! Total: " + pontosDoJogador);

            // Desativa o colisor para o player conseguir passar por onde o baú estava
            if (GetComponent<Collider>() != null)
            {
                GetComponent<Collider>().enabled = false;
            }

            // 4. Destrói o baú após 2 segundos (tempo para a animação terminar)
            Destroy(gameObject, 2f);
        }
    }
}
