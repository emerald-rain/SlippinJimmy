using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnFall : MonoBehaviour
{
    public Transform player;
    public Camera mainCamera;

    void Update()
    {
        if (player.position.y < mainCamera.transform.position.y - mainCamera.orthographicSize)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
