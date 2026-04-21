using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int scoreAmount = 10;



    private int levelNumber = 0;
    private int score = 0;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(levelNumber);
    }


    public void IncreaseScore()
    {
        score += scoreAmount;
        Debug.Log(score);
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(levelNumber);
    }


    public void LoadNextLevel()
    {
        int totalLevel = SceneManager.sceneCount;
        if (totalLevel < levelNumber + 1)
        {
            Debug.Log("this was last level");
            return;
        }
        levelNumber++;
        SceneManager.LoadScene(levelNumber);

    }



    public float GetLevelTime()
    {
        float time = 0f;
        switch (levelNumber)
        {
            case 0:
                time = 30f;
                break;
            case 1:
                time = 40f;
                break;
            default:
                time = 35f;
                break;
        }
        return time;


    }




}
