using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public int sceneNum;
    public string Scene;
    private static int _level;

    void Awake()
    {
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _level = NextLevel.levelCounter;
        if (_level>=sceneNum){
            gameObject.SetActive(true);
        } else
        {
            gameObject.SetActive(false);
        }
    }

    public void gotToLevel()
    {
        SceneManager.LoadScene(Scene);
        Debug.Log(_level);
    }
}
