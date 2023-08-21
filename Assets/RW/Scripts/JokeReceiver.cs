

using UnityEngine;
//1
using UnityEngine.Playables;

//2
public class JokeReceiver : MonoBehaviour, INotificationReceiver
{
    //1
    [SerializeField]
    private Typewriter dialogAnimator;

    //1
    public void OnNotify(Playable origin, INotification notification, object context)
    {
        //2
        if (notification is JokeMarker dialogue && dialogAnimator != null)
        {
            //3
            var newDialogue = new Dialog
            {
                //4
                Quote = dialogue.Quote,
                PausePerLetter = dialogue.PausePerLetter,
                NewPage = dialogue.StartNewPage,
                NewLine = dialogue.StartNewLine
            };

            //5
            dialogAnimator.AddDialog(newDialogue);
        }
    }
}
