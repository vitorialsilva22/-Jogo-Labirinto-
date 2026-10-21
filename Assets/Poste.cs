using UnityEngine;

public class Poste : MonoBehaviour
{
   public Light luz;

    private void Start ()
    {
        luz.GetComponent<Light>();
    }    
 public void LigaDesliga (bool taLigada)
    {
        // Se taLigada == true, a intensidade da luz será 5.45
        if (taLigada)
        {
            luz.intensity = 5.45f;
            luz.intensity = 0.0f;
         }
        // Se taLigada == false, a intensidade da luz será 0.0
    }

}
