using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{
    // Este m�todo se llama autom�ticamente cuando otro Collider entra en el Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Puedes verificar si el objeto es el jugador u otro espec�fico si lo deseas
        // Por ejemplo: if (other.CompareTag("Player"))
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Verifica que la siguiente escena exista
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No hay m�s escenas para cargar.");
        }
    }
}
