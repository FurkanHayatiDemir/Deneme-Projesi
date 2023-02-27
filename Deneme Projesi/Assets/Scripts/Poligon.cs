using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Poligon : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "red" || collision.gameObject.tag == "green" || collision.gameObject.tag == "blue")
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(0);
    }
}
