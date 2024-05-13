using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    MainMenu mainMenu;
    int checkPointCount;
    GameObject player;
    public int index;
    [SerializeField] GameObject checkPointPrefab;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] public GameObject[] cars;
    [SerializeField] TextMeshProUGUI gameOverText; 
    private GameObject[] characterPrefabs;
    private Vector3[][] coordArray = {
        new Vector3[]{new Vector3(64.39f, 0.19f, 44.02f), new Vector3(185.57f, 0.176f, 45.03f), new Vector3(73.52057f, 0.176f, 165.4696f), 
                      new Vector3(93.25545f, 0.369947f, 207.8114f), new Vector3(214.01f, 0.176f, 165.1f),
                      new Vector3(46.07f, 0.1699463f, 107.9f), new Vector3(222.2603F, 0.1699463f, 100.7862f)},
        new Vector3[]{new Vector3(0, 0, 0), new Vector3(0,0,0), new Vector3(0, -90,0), new Vector3(0, 0, 0), new Vector3(0, -90, 0),
                      new Vector3(0, -90, 0), new Vector3(0, 0, 0)}
    };
    private int currentCoords = -1;
    private int coordinatesChoice = -1;
    private int characterChoice;
    public int goalScore = 100;
    private int currentScore = 0;
    private int timeLeft = 210;
    public float timeRemaining = 0;
    public bool timeIsRunning;

    public void Start()
    {

        index = PlayerPrefs.GetInt("carIndex"); // Get the selected car name
        GameObject carPrefab = Instantiate(cars[index], new Vector3(60.2f, 0.2f, 15.85f), Quaternion.identity);

        player = GameObject.FindGameObjectWithTag("Player");
        timeIsRunning = true;
        StartCoroutine(Timer());
    }   
    
    IEnumerator ReturnToMainMenuAfterDelay(float delay)
        { 
        yield return new WaitForSeconds(delay);

        // Return to the main menu scene
        SceneManager.LoadScene("Menu");
    }
    IEnumerator Timer()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(3);
            if (timeIsRunning)
            {
                timeLeft--;
                int minutes = (int)(timeLeft / 60);
                int seconds = (int)(timeLeft % 60);
                timer.SetText("{0:00} : {1:00}", minutes, seconds);
            }
        }
    }

    public void Update()
    {
        if(GameObject.FindGameObjectWithTag("CheckPoint") == null)
        {
            GenerateCheckpoint();
        }
        bool isColliding = player.GetComponent<Player>().getColliding();
        if (isColliding == true)
        {
            timeIsRunning = false;
        }
        else
        {
            timeIsRunning = true;
        }
        if (timeLeft == 0)
        {
            GameOver(false);
        }
    }

    public void GenerateCheckpoint()
    {
        while (currentCoords == coordinatesChoice)
        {
            coordinatesChoice = (Random.Range(0, coordArray[0].Length));
        }
        currentCoords = coordinatesChoice;
        GameObject newCheckpoint = Instantiate(checkPointPrefab, coordArray[0][coordinatesChoice], Quaternion.identity);
        newCheckpoint.transform.rotation = Quaternion.Euler(coordArray[1][coordinatesChoice]);
        if ((checkPointCount % 2 == 0)) {
            if(checkPointCount > 0)
            {
                currentScore += 30;
            }
            if (currentScore >= 100)
            {
                scoreText.color = Color.green;
                GameOver(true);
            }
            
            scoreText.SetText("Current Score: {0}/{1}", currentScore, goalScore);
            characterPrefabs = GameObject.FindGameObjectsWithTag("NPC");
            characterChoice = (Random.Range(0, characterPrefabs.Length));
            GameObject newCharacter = Instantiate(characterPrefabs[characterChoice], newCheckpoint.transform.position, Quaternion.identity);
            newCharacter.tag = "ActiveNPC";
            newCharacter.transform.rotation = newCheckpoint.transform.rotation;
            newCharacter.transform.Rotate(0, -90, 0);
            if (newCheckpoint.transform.rotation != Quaternion.Euler(0, -90, 0))
            {
                newCharacter.transform.position = new Vector3(newCharacter.transform.position.x + 3, newCharacter.transform.position.y, newCharacter.transform.position.z);
            }
            else
            {
                newCharacter.transform.position = new Vector3(newCharacter.transform.position.x, newCharacter.transform.position.y, newCharacter.transform.position.z + 3);
            }
        }
        checkPointCount++;
    }

    public void GameOver(bool isWin)
    {
        if (isWin)
        {
            gameOverText.SetText("You won!");
        }
        gameOverText.gameObject.SetActive(true);
        StartCoroutine(ReturnToMainMenuAfterDelay(15));
    }

    public int getScore()
    {
        return currentScore;
    }
    public void setScore(int score)
    {
        if((currentScore + score) < 0)
        {
            currentScore = 0;
        }
        else {
            currentScore += score;
        }
    }
}
