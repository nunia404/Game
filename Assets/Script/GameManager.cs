using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static instance for easy access from other scripts
    public static GameManager Instance { get; private set; }

    // Game state variables
    public int playerScore = 0;
    public int playerLives = 3;
    public bool isGameOver = false;

    // Called before the first frame update
    private void Awake()
    {
        // Singleton pattern to ensure only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager
        }
    }

    // Method to start the game
    public void StartGame()
    {
        playerScore = 0;
        playerLives = 3;
        isGameOver = false;
        // Additional setup can go here
        Debug.Log("Game Started");
    }

    // Method to end the game
    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over");
        // Additional game-over logic (e.g., load game-over scene)
    }

    // Method to update the score
    public void AddScore(int points)
    {
        playerScore += points;
        Debug.Log("Score: " + playerScore);
    }

    // Method to lose a life
    public void LoseLife()
    {
        playerLives--;
        Debug.Log("Lives: " + playerLives);

        if (playerLives <= 0)
        {
            GameOver();
        }
    }
    public void CardFlipped(CardController c)
    {
        
    }
    public bool CanFlip()
    {
        return true;
    }
}

