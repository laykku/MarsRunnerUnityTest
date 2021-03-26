using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MarsRunner
{
    public class GameOverScreen : UIScreen
    {
        public Text ScoreLabel;

        public void SetScore(int score)
        {
            int highScore = 0;
            if (PlayerPrefs.HasKey(Configuration.HighScoreToken))
            {
                highScore = PlayerPrefs.GetInt(Configuration.HighScoreToken);
            }

            ScoreLabel.text = $"Best score: {highScore}\nYour score: {score}";
        }

        public void OnRestatrtClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}