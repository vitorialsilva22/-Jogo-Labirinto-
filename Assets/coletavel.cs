using UnityEngine;

public class coletavel : MonoBehaviour
{
    public void Coletar()
    {
        Debug.Log($"Coletado {gameObject.name}");
        Destroy(this.gameObject);
    }
}
