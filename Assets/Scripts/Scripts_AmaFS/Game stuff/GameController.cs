using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text textBubble;
    public Text[] answerButtons;
    public int lives = 3; 
    public string[] stanza0Options; 
    public string[] stanza1Options; 
    public string[] stanza2Options;
    public string[] stanza3Options;
    public string[] stanza4Options;
    public string[] stanza5Options;
    public string[] stanza6Options;
    public string[] stanza7Options;

    public string answer;
    public string selectedAnswer;

    private int currentStanza = 1; // Tracks the current stanza
    private string[] stanzas = new string[8]; // Stores all stanzas
    private string[][] stanzaOptions = new string[8][];

    // Start is called before the first frame update
    void Start()
    {
       
        LoadPoem();

        DisplayStanza(currentStanza);
    }

    void Update()
    {
        switch (currentStanza)
        {
            case 1:   answer = "Cheap";
                break;
            case 2:
                answer = "Silence";
                break;
            case 3:
                answer = "Cancer";
                break;
            case 4:
                answer = "Callous";
                break;
            case 5:
                answer = "Clapping";
                break;
            case 6:
                answer = "Colonized";
                break;
            case 7:
                answer = "Timid";
                break;
            case 8:
                answer = "Tempted";
                break;
        }
    }

    void LoadPoem()
    {
        // Load all stanzas of the poem
        stanzas[0] = "Oh, hanging Messiah of a fallen Jerusalem. \r\nYour sons have cut holes beneath our rib cages with their razor-sharp tongues and talk is '...'. \r\nWe have called your name at the sounding of the horn. \r\nWhen barbaric lairds were nailing our goddesses to the cross. \r\nThighs loosely hung from wilting bodies; the swaying of skeletal bones imitate a praying mantis. \r\nOur father. \r\nWe are bearing petals of roses.\r\n";
        stanzas[1] = "Dying at the hands of a trying love, slaves of sinister passion. \r\nMy people have distanced their faith from their God because gold has us believing that minds bind us in community. \r\nYou are my property. \r\nWe breathe in '...', in sync. \r\nWe are braving brutal bruises from all sorts of abuse.\r\n";
        stanzas[2] = "Our souls. \r\nI stacking those grieving bodies drunk on brewing storms a nation brought to its knees but will inhale. \r\nThis burning sticks of “...” like dust will never settle. \r\nOur scores fail to pass. \r\n";
        stanzas[3] = "Laws have never cast us out of formal settlements like spells. \r\nYet we have become eloquent in raging rallies and freedom. \r\nSongs sung from these wheezing chests. \r\nOur shacks are caving. \r\nIs thy name hallowed when we scream. \r\nTragedy of a clumsy, untied tube. Spilling infants to death. \r\nThe curse of a “...” uterus. \r\nSeen to face the blight of womb.\r\n";
        stanzas[4] = "Stripping our women bare. \r\nSo, when their bodies collapse.\r\nLike two waves at a crash. \r\nThunder “...” the earth. \r\nWatching a body of water quaking at its feet.\r\nWill mercy serve their enemies junk better served sweet turns our teens into immovable trunks, obese and obscene.\r\n";
        stanzas[5] = "Stationed at a corner where freedom doesn't reign.\r\nWe haven't stopped dying at the hands of each other.\r\nBlood spill still quenches our thirst. A country laying like sleeping dogs.\r\nOur beds are made of lying leaders with ink-stained thumbs and “...” minds. We are living virtual lives as shallow dreams are made vivid on cyber screams at demise.\r\n";
        stanzas[6] = "“...” selling a short at the hands of nudity, while purity sex us at the umbilical, scraping our cowardice from the pavements a struggle still calls us by name.\r\nThy will is still done. \r\nMany have died in your name.\r\nLiving only on toasted crumbs.\r\nBread is far-fetched, but we have walked for much less.\r\nWe've seen it on the news.\r\n";
        stanzas[7] = "Innocent kids trespassed against, silenced and left for dead albinos skinned and sacrificed.\r\nAre you making a mockery of our beliefs? I imagine their screams sounding like Bible pages turned in aggression, and I'm “...” to do unto others as it is done unto our mothers, who have died many a times for their sons and daughters, and still wear their crowns of thorns with bloody pride.\r\nI'm swallowing my prayers back into my chest here our mothers instead and deliver them from our sins.\r\n";


        // Add more stanzas as needed
        stanzaOptions[0] = new string[] { "Sweep", "Deep", "Leap", "Cheap" };
        stanzaOptions[1] = new string[] { "Violence", "Silence", "Alliance", "Nuisance" };
        stanzaOptions[2] = new string[] { "Dancer", "Answer", "Cancer", "Enhancer" };
        stanzaOptions[3] = new string[] { "Ballast", "Gallus", "Malice", "Callous" };
        stanzaOptions[4] = new string[] { "Mapping", "Clapping", "Tapping", "Slapping" };
        stanzaOptions[5] = new string[] { "Idiolized", "Colonized", "Harmonized", "Patronized" };
        stanzaOptions[6] = new string[] { "Limpid", "Timed", "Timed", "Midst" };
        stanzaOptions[7] = new string[] { "Tempered", "Tempted", "Attempted", "Tented" };
    }

    void DisplayStanza(int stanzaNumber)
    {
        // Display the stanza text
        textBubble.text = stanzas[stanzaNumber - 1];

        // Display options based on the current stanza
        //switch (stanzaNumber)
        //{
        //   case 1:
        //     DisplayOptions(stanza1Options);
        //    break;
        // case 2:
        //     DisplayOptions(stanza2Options);
        //    break;
        //case 3:
        //    DisplayOptions(stanza3Options);
        //    break;
        // Add more cases for additional stanzas
        // default:
        //    Debug.LogError("Invalid stanza number.");
        //    break;
        // }

        DisplayOptions(stanzaOptions[stanzaNumber - 1]);
    }

    void DisplayOptions(string[] options)
    {
        // Shuffle options to randomize their order
        ShuffleArray(options);

        // Display options on answer buttons
       // for (int i = 0; i < answerButtons.Length; i++)
       // {
        //    answerButtons[i].text = options[i];
       // }

        string correctAnswer = options[3]; 
        foreach(Text button in answerButtons)
        {
            button.text = options[0];
            if (button.text == correctAnswer)
            {
                button.gameObject.tag = "CorrectAnswer";
            }
            options = options.Skip(1).ToArray();
        }
    }

    void ShuffleArray<T>(T[] array)
    {
        // Fisher-Yates shuffle algorithm - look into this my guy
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    //public void CheckAnswer(int buttonIndex)
    //{
    // Find the selected button
    // GameObject selectedButton = EventSystem.current.currentSelectedGameObject;
    // if (selectedButton != null)
    // {
    // Check if the selected button has the tag "CorrectAnswer"
    //   if (selectedButton.CompareTag("CorrectAnswer"))
    //  {
    // Move to the next stanza
    //     currentStanza++;
    //    if (currentStanza <= stanzas.Length)
    //  {
    //      DisplayStanza(currentStanza);
    //}
    //  else
    // {
    // Player wins
    //    Debug.Log("Congratulations! You completed the poem.");
    //  }
    // }
    // else
    //{
    // Incorrect option selected, decrease lives
    //   lives--;
    // if (lives <= 0)
    // {
    // Player loses
    //Debug.Log("Game Over! You ran out of lives.");
    // }
    // else
    //  {
    // Display remaining lives or any other feedback
    //     Debug.Log("Incorrect word. Lives remaining: " + lives);
    // }
    //}
    // }
    // else
    // {
    //  Debug.LogError("No button selected.");
    // }

    //string selectedword = answerbuttons[buttonindex].text;
    //if (answerbuttons[buttonindex].tag == "correctanswer")

    //{
    //    currentstanza++;
    //    if (currentstanza <= stanzas.length)
    //    {
    //        displaystanza(currentstanza);
    //    }
    //    else
    //    {
    //        debug.log("congratulations! you completed the poem.");
    //    }
    //}
    //else
    //{
    //    lives--;
    //    if (lives <= 0)
    //    {
    //        debug.log("game over! you ran out of lives.");
    //    }
    //    else
    //    {
    //        debug.log("incorrect word. lives remaining: " + lives);
    //    }
    //}


    //}

    public void CheckAnswer()
    {
                if(answer == selectedAnswer)
        {
            //Move to the next...
            MoveToNextStanza();

        }
        else
        {
            //Decrease lives...
            DecreaseLives();

        }

    }

    private void MoveToNextStanza()
    {
        currentStanza++;
        if (currentStanza <= stanzas.Length)
        {
            // Display the next stanza
            DisplayStanza(currentStanza);
        }
        else
        {
            
            Debug.Log("Congratulations! You completed the poem.");
            
        }
    }

    private void DecreaseLives()
    {
        lives--;
        if (lives <= 0)
        {
          
            Debug.Log("Game Over! You ran out of lives.");
           
        }
        else
        {
            
            Debug.Log("Incorrect word. Lives remaining: " + lives);
        }
    }

    public void A()
    {
            // Get the current stanza's options
            string[] currentStanzaOptions = stanzaOptions[currentStanza - 1];

            // Assign the first option as the answer
            if (currentStanzaOptions.Length > 0)
            {
            selectedAnswer = currentStanzaOptions[0];
                Debug.Log(selectedAnswer);
            }
            else
            {
                Debug.LogError("No options available for the current stanza.");
            }

            CheckAnswer();
    }

    public void B()
    {
        // Get the current stanza's options
        string[] currentStanzaOptions = stanzaOptions[currentStanza - 1];

        // Assign the second option as the answer
        if (currentStanzaOptions.Length > 1)
        {
            selectedAnswer = currentStanzaOptions[1];
            Debug.Log(selectedAnswer);
        }
        else
        {
            Debug.LogError("Not enough options available for the current stanza to assign as answer.");
        }

        CheckAnswer();

    }

    public void C()
    {
        // Get the current stanza's options
        string[] currentStanzaOptions = stanzaOptions[currentStanza - 1];

        // Assign the third option as the answer
        if (currentStanzaOptions.Length > 2)
        {
            selectedAnswer = currentStanzaOptions[2];
            Debug.Log(selectedAnswer);
        }
        else
        {
            Debug.LogError("Not enough options available for the current stanza to assign as answer.");
        }
        CheckAnswer();

    }

    public void D()
    {
        // Get the current stanza's options
        string[] currentStanzaOptions = stanzaOptions[currentStanza - 1];

        // Assign the fourth option as the answer
        if (currentStanzaOptions.Length > 3)
        {
            selectedAnswer = currentStanzaOptions[3];
            Debug.Log(selectedAnswer);
        }
        else
        {
            Debug.LogError("Not enough options available for the current stanza to assign as answer.");
        }
        CheckAnswer();

    }

}







