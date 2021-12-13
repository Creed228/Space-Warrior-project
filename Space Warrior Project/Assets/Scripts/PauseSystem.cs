using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour {

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private bool isPaused;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }
}
