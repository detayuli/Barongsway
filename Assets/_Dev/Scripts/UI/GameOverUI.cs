using System;
using Barongslay.Core.VictoryDefeat;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public CanvasGroup gameOverUI;
    void OnEnable()
    {
        VictoryDefeatManager.Instance.OnDefeat += HandleDefeat;
    }
    void OnDisable()
    {
        VictoryDefeatManager.Instance.OnDefeat -= HandleDefeat;
    }
    void Start()
    {
        gameOverUI.alpha = 0;
        gameOverUI.interactable = false;
        gameOverUI.blocksRaycasts = false;
    }
    void HandleDefeat()
    {
        Debug.Log("[GameOverUI] HandleDefeat");
        gameOverUI.alpha = 1;
        gameOverUI.interactable = true;
        gameOverUI.blocksRaycasts = true;
    }
}