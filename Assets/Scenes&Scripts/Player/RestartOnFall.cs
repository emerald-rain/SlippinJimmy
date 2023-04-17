using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnFall : MonoBehaviour
{
    public GameObject player;
    public float fallDistance = 50f;

    private float maxYPosition;

    void Start()
    {
        maxYPosition = player.transform.position.y;
    }

    void Update()
    {
        float currentY = player.transform.position.y;

        if (currentY > maxYPosition)
        {
            maxYPosition = currentY;
        }

        if (maxYPosition - currentY > fallDistance)
        {
            RestartScene();
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
