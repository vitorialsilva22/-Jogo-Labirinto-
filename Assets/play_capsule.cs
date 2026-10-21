using UnityEngine;
using UnityEngine.InputSystem;

public class RaioInteracao : MonoBehaviour
{
    Color original;
    GameObject obj;
    bool interacao = true;
    private void FixedUpdate()
    {
        // Coleta as informações de colisão
        RaycastHit hit;

        if (Physics.Raycast(transform.position + new Vector3(1.2f, 0, 0), transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            // Mudar a cor do raio para roxo
            Debug.DrawRay(transform.position + new Vector3(1.2f, 0, 0), transform.TransformDirection(Vector3.forward) * hit.distance, Color.violet);

            obj = hit.collider.gameObject;
            // Pegar cor atual 
            // original = hit.collider.GetComponent<MeshRenderer>().material.color;

            // obj.GetComponent<MeshRenderer>().material.color = Color.red;

            // Destruir Objeto 
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue);
            obj.GetComponent<Collider>().GetComponent<MeshRenderer>().material.color = original;
        }

        // RayCast(origem, direção, distancia, layer, trigger) -> retorna bool
    }
}
