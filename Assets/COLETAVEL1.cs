using UnityEngine;

public class COLETAVEL : MonoBehaviour
{
    private Animator anim;
    private bool jaColetado = false;

    [Header("Configuração do Baú")]
    [SerializeField] private bool bauSupremo = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (jaColetado)
            return;

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager não encontrado na cena!");
            return;
        }

        if (!GameManager.Instance.JogoAtivo)
            return;

        jaColetado = true;

        // Executa a animação de abertura.
        if (anim != null)
            anim.SetTrigger("open");

        // Atualiza a pontuação e o tempo na interface.
        GameManager.Instance.EncontrouBau(bauSupremo);

        // Destrói o baú após a animação.
        Destroy(gameObject, 2f);
    }
}