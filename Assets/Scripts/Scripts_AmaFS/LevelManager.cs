using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State
{
    Start,
    Poems,
    Levels,
    Play,
    End,
}

public class LevelManager : MonoBehaviour
{

    [SerializeField] AudioSource themeSong;
    [SerializeField] State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Start;
        themeSong.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if     (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 3" || SceneManager.GetActiveScene().name == "Level 4" || SceneManager.GetActiveScene().name == "Level 5")
        {
            state = State.Play;
        }

        if(SceneManager.GetActiveScene().name == "LevelSelect")
        {
            state = State.Levels;
        }

        if (state == State.Play)
        {
            themeSong.Stop();
        }
    }
}
