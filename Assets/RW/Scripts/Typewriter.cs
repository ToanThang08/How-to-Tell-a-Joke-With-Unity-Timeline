using System.Collections;
using UnityEngine;
//1
using TMPro;

public class Typewriter : MonoBehaviour
{
    //1
    private TMP_Text textBox;
    //2
    private float timePerCharacter = 0.05f;

    private void Awake()
    {
        //1
        textBox = GetComponent<TMP_Text>();
        //2
        textBox.enableWordWrapping = true;
        //3
        textBox.maxVisibleCharacters = 0;
    }

    //for testing only
    /*
    private void OnEnable()
    {
        StartCoroutine(Reveal(0));
    }
    */

    public IEnumerator Reveal(int startLetterIndex)
    {

        //1
        // Force an update of the mesh to get valid information.
        textBox.ForceMeshUpdate();

        //2
        // Get # of Visible Characters in text object
        int totalVisibleCharacters = textBox.textInfo.characterCount;

        //3
        for (int i = startLetterIndex; i < totalVisibleCharacters; i++)
        {
            // How many characters should TextMeshPro display?
            textBox.maxVisibleCharacters = i + 1;

            yield return new WaitForSeconds(timePerCharacter);
        }

        //4
        textBox.maxVisibleCharacters = totalVisibleCharacters;
        yield break;
    }

    public void AddDialog(Dialog message)
    {
        //1
        timePerCharacter = message.PausePerLetter;

        //2
        //clear and start new
        if (message.NewPage)
        {
            textBox.maxVisibleCharacters = 0;
            textBox.text = message.Quote;
            StartCoroutine(Reveal(0));
        }

        //3
        //append to existing
        else
        {
            //4
            int currentLetterIndex = textBox.maxVisibleCharacters;

            //5
            if (message.NewLine)
            {
                textBox.text = string.Concat(textBox.text, "\n", message.Quote);
            }
            else
            {
                textBox.text = string.Concat(textBox.text, " ", message.Quote);
            }

            //6
            StartCoroutine(Reveal(currentLetterIndex));
        }
    }
}

public class Dialog
{
    //1
    public string Quote;
    //2
    public float PausePerLetter;
    //3
    public bool NewPage;
    //4
    public bool NewLine;
}