using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameStartUi;
    [SerializeField] private GameObject gameOverUi;

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void SetVisibleGameStartUi(bool isVisible)
    {
        gameStartUi.SetActive(isVisible);
    }
    
    public void SetVisibleGameOverUi(bool isVisible)
    {
        gameOverUi.SetActive(isVisible);
    }
}
