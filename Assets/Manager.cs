using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.Boarshroom.Butterfly
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] int level;
        public bool end;
        public bool lose;
        [SerializeField] GameObject loseScreen;
        [SerializeField] GameObject winScreen;

        private void Update()
        {
            if(end)
            {
                if (lose) { loseScreen.SetActive(true); }
                else { winScreen.SetActive(true); }
            }
        }

        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void NextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
