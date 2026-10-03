using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float speed = 2f;
    public GameObject killWall;
    public GameObject GameOver;

    public bool win;
    public bool lose;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Camera.main.transform.Translate(Vector3.right * Time.deltaTime * speed);
        killWall.transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    public void Lose()
    {
        lose = true;
        GameOver.SetActive(true);
    }

    public void Restart()
    {
        lose = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
