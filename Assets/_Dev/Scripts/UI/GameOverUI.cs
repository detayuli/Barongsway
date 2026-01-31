using System;
using Barongslay.Core.VictoryDefeat;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverUI;
    void OnEnable()
    {
        VictoryDefeatManager.Instance.OnDefeat += HandleDefeat;
    }
    void OnDisable()
    {
        VictoryDefeatManager.Instance.OnDefeat -= HandleDefeat;
    }
    void HandleDefeat()
    {
        gameOverUI.SetActive(true);
    }
}