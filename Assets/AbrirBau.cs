using UnityEngine;

public class AbrirBau : MonoBehaviour
{
    Animator anim;

    // Abrir quando o jogador chega perto do bau
    // Trocar animação
    // Destruir baú

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

}

   
