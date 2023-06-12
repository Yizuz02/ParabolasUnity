using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public static int levelCounter = 1;
    
    public string nextScene;
    public string actualScene;
    public GameObject nextLevelButton;
    public GameObject restartButton;
    public GameObject cannon;
    public TextMeshProUGUI numEnemiesText;

    private GameObject[] _enemies;
    private bool _levelFinish=false;

    void Awake()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        nextLevelButton.SetActive(false);
        restartButton.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numEnemiesText.text = "X " + _enemies.Length;
        if (_enemies.Length==0 && !_levelFinish){
            _levelFinish=true;
            nextLevelButton.SetActive(true);
            levelCounter++;
        }
        if (_enemies.Length>0 && cannon.GetComponent<ShootProjectile>().numBullets == 0){
            restartButton.SetActive(true);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene("Level "+ levelCounter.ToString());
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
