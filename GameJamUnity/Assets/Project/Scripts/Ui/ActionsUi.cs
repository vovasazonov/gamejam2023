using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Ui
{
    public class ActionsUi : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _timerInput;
        [SerializeField] private TextMeshProUGUI _timeViewText;
        [SerializeField] private Slider _volume;
        private int _lastTime;

        [SerializeField] GameObject PausePanel;
        [SerializeField] GameObject WinPanel;

        [SerializeField] TextMeshProUGUI winnerNameTMP;
        [SerializeField] TextMeshProUGUI loserNameTMP;

        public void Quit()
        {
            Application.Quit();
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
        }
        
        public void UpdateTimer()
        {
            if (Int32.TryParse(_timerInput.text, out var result))
            {
                if (result <= 0)
                {
                    result = 1;
                }
                
                Timer.Instance.SetTime(result);
            }
        }

        public void UpdateVolume()
        {
            AudioManager.Instance.Volume = _volume.value;
        }

        private void Update()
        {
            UpdateTimeView();
        }

        public void DoPauseGame()
        {
            //Debug.Log("in");

            PausePanel.SetActive(true);

            Time.timeScale = 0;
        }

        public void DoGoBackToGame()
        {
            PausePanel.SetActive(false);

            Time.timeScale = 1;
        }

        public void DoShowEndGameScreen(string winName, string loseName)
        {
            WinPanel.SetActive(true);

            winnerNameTMP.text = winName;
            loserNameTMP.text = loseName;
        }

        public void DoQuitGame()
        {
            Application.Quit();
        }

        private void UpdateTimeView()
        {
            var passedTime = Timer.Instance.ShowHowMuchTimePassed();
            
            if (_lastTime != passedTime)
            {
                _lastTime = passedTime;
                
                if (_lastTime <= 0)
                {
                    _lastTime = 0;
                }
                
                _timeViewText.text = _lastTime.ToString();
            }
        }
    }
}