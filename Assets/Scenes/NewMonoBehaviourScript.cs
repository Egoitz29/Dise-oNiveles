using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{
    // Este método se llama automáticamente cuando otro Collider entra en el Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Puedes verificar si el objeto es el jugador u otro específico si lo deseas
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
            Debug.LogWarning("No hay más escenas para cargar.");
        }
    }
}
