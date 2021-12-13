using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameMenu : MonoBehaviour
{
    [SerializeField] Button StartGameButton;

    private CanvasGroup canvasGroup;
    private float alpha;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        alpha = 1;
        StartGameButton.gameObject.SetActive(true);
    }

    private void Fade()
    {
        canvasGroup.alpha = 0;
    }
}
