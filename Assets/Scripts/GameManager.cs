using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    [SerializeField] private GameObject uiManagerObject;
    private UIManager _uiManager;

    private int _score;

    public bool IsGameOver => _isGameOver;
    private bool _isGameOver = true;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _uiManager = uiManagerObject.GetComponent<UIManager>();
    }

    public void IncrementScore()
    {
        _score++;
        _uiManager.UpdateScore(_score);
    }

    public void SetGameOver()
    {
        _isGameOver = true;
        _uiManager.SetVisibleGameOverUi(true);
    }

    public void StartGame()
    {
        _score = 0;
        _uiManager.UpdateScore(_score);
        _isGameOver = false;
        _uiManager.SetVisibleGameOverUi(false);
        _uiManager.SetVisibleGameStartUi(false);
    }
}