using UnityEngine;

public class Bau : MonoBehaviour
{
    Animator anim;

    // Detectar quando o jogador chega perto do bau
    // Trocar animação
    // Destruir baú

    [Header("Configurações do Baú")]
    [SerializeField] private bool ehOBauSupremo = false;
    [SerializeField] private int pontosRecompensa = 20;
    [SerializeField] private float tempoRecompensa = 10f; // Quanto tempo adiciona (ex: 10 segundos)

    private bool jaFoiAberto = false;

    // Detecta quando o jogador encosta no baú
    private void OnTriggerEnter(Collider other)
    {
        // Certifique-se de que o seu objeto do Jogador tenha a Tag "Player" configurada na Unity
        if (other.CompareTag("Player") && !jaFoiAberto)
        {
            jaFoiAberto = true;
            AbreOBau();
        }
    }

    void AbreOBau()
    {
        if (ehOBauSupremo)
        {
            // Ativa o fim de jogo com vitória

        }
        else
        {
            // Dá pontos e tempo ao jogador
            GameManager.Instance.EncontrouBau(ehOBauSupremo);


        }



    }
        
          
        

       private void OnopenEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("open");

            Destroy(this.gameObject, 2);
        }
    }
}
