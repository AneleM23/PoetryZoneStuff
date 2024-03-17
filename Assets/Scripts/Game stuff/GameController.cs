using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text textBubble;
    public Text[] answerButtons;
    public int maxLives = 3;

    private int currentLevel = 0;
    private int currentLives;
    private List<string> poemLines = new List<string>();

    private string[,] options = new string[4, 2]; 

    // Start is called before the first frame update
    void Start()
    {
        LoadPoem();

        
        StartLevel();
    }

    void LoadPoem()
    {
        
        poemLines.Add("You are clear O rose, cut in rock, hard as the descent of hail.");
        poemLines.Add("I could scrape the colour from the petals like spilt dye from a rock.");
        poemLines.Add("You are clear O rose, cut in rock, hard as the descent of hail.");
        poemLines.Add("I could scrape the colour from the petals like spilt dye from a rock.");
        poemLines.Add("You are clear O rose, cut in rock, hard as the descent of hail.");
        poemLines.Add("I could scrape the colour from the petals like spilt dye from a rock.");
        poemLines.Add("You are clear O rose, cut in rock, hard as the descent of hail.");
        poemLines.Add("I could scrape the colour from the petals like spilt dye from a rock.");

    }

    void StartLevel()
    {
        // Reset lives
        currentLives = maxLives;

        // Display poem line
        textBubble.text = poemLines[currentLevel];

        // Generate options
        GenerateOptions();

        // Display options
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].text = options[i, 0]; // Display word
        }
    }

    void GenerateOptions()
    {
        // Logic to generate options with similar or rhyming words
        
        for (int i = 0; i < 4; i++)
        {
            options[i, 0] = "Option " + i; // Placeholder for random word
            options[i, 1] = "Rhyme " + i; // Placeholder for rhyme
        }
    }

    public void OptionSelected(int optionIndex)
    {
        // Check if the selected option is correct
        if (options[optionIndex, 0] == "Correct Word")
        {
            // Proceed to the next level
            currentLevel++;
            if (currentLevel < poemLines.Count)
            {
                StartLevel();
            }
            else
            {
                // Player wins the game
                Debug.Log("Congratulations! You completed the poem.");
            }
        }
        else
        {
            // Incorrect option selected
            currentLives--;

            if (currentLives <= 0)
            {
                // Player loses the game
                Debug.Log("Game Over! You ran out of lives.");
            }
            else
            {
                // Display remaining lives or any other feedback
                Debug.Log("Incorrect word. Lives remaining: " + currentLives);
            }
        }
    }
}





