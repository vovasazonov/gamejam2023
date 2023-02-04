using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEditor.UI;
using UnityEditor.UIElements;
using TMPro;

public class UIControllerSC : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject WinPanel;
    [SerializeField] TextMeshProUGUI winnerTMP;
    [SerializeField] TextMeshProUGUI loserTMP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void DoPauseGame()
    {
        PausePanel.SetActive(true);

        Time.timeScale = 0;
    }

    public void DoGoBackToGame()
    {
        PausePanel.SetActive(false);

        Time.timeScale = 1;
    }

    public void DoShowWinScreen(string winnerName, string loserName)
    {
        WinPanel.SetActive(true);

        winnerTMP.text = winnerName;
        loserTMP.text = loserName;

    }

    public void DoQuitGame()
    {
        Application.Quit();
    }

}
