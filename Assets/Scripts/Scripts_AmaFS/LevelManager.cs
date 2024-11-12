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

    GameController game;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Start;

        if(themeSong != null) 
        themeSong.Play();

        game = GameObject.Find("GameController").GetComponent<GameController>();

        anim.SetBool("isTalking1", true);
        anim.SetBool("isTalking2", false);
        anim.SetBool("isSilent", false);
        anim.SetBool("Lost", false);
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
            if (themeSong != null)
                themeSong.Stop();
        }

         if     (game.lives <= 0)
        {
            anim.SetBool("Lost", true);
        }
    }
}
