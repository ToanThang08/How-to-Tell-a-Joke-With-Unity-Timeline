

using UnityEngine;
//1
using UnityEngine.Playables;
using UnityEngine.Timeline;

//2
public class JokeMarker : Marker, INotification
{
    //1
    [SerializeField]
    private string quote = "";
    //2
    [SerializeField]
    private float pausePerLetter = 0.1f;
    //3
    [SerializeField]
    private bool startNewPage;
    //4
    [SerializeField]
    private bool startNewLine;

    public string Quote => quote;

    public float PausePerLetter => pausePerLetter;

    public bool StartNewPage => startNewPage;

    public bool StartNewLine => startNewLine;

    public PropertyName id => new PropertyName();
}