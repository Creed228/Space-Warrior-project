using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;

    public bool gameActive;

    void Start()
    {
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        StartGame();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        gameActive = true;
    }

    public void LoseGame()
    {
        losePanel.SetActive(true);
        FindObjectOfType<Tutorial>().gameObject.SetActive(false);
        gameActive = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
        FindObjectOfType<Tutorial>().gameObject.SetActive(false);
        gameActive = false;
    }
}
