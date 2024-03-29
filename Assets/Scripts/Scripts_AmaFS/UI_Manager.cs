using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Slider slider;

    GameController game;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameController").GetComponent<GameController>();
        slider.maxValue = game.lives;
    }

    // Update is called once per frame
    void Update()
    {
        Slider(game.lives);
    }

    void Slider    (int hp)
    {
     slider.value = hp;
    }
}
