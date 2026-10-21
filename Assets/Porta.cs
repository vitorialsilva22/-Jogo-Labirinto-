using UnityEngine;
using UnityEngine.SceneManagement;


public class Porta : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

     public void OnTriggerEnter(Collider other)
    {
        Debug.Log("to colidindo");
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("cena dentro da casa");
            Debug.Log("passei na porta");
        }
    }
}
