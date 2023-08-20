using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typewriter : MonoBehaviour
{
    //1
    private TMP_Text textBox;
    //2
    private float timePerCharacter = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        //1
        textBox = GetComponent<TMP_Text>();
        //2
        textBox.enableWordWrapping = true;
        //3
        textBox.maxVisibleCharacters = 0;
    }

    public IEnumerator Reveal(int startLetterIndex)
    {
        //1
        textBox.ForceMeshUpdate();

        //2
        int totalVisibleCharacters = textBox.textInfo.characterCount;

        //3
        for (int i = startLetterIndex; i < totalVisibleCharacters; i++)
        {
            textBox.maxVisibleCharacters = i + 1;

            yield return new WaitForSeconds(timePerCharacter);
        }

        //4
        textBox.maxVisibleCharacters = totalVisibleCharacters;
        yield break;
    }
    private void OnEnable()
    {
        StartCoroutine(Reveal(0));
    }
}
