
using UnityEngine;
using UnityEngine.Playables;

public class JokeReceiver : MonoBehaviour, INotificationReceiver
{
    [SerializeField]
    private Typewriter dialogAnimator;

    //1
    public void OnNotify(Playable origin, INotification notification, object context)
    {
        //2
        if (notification is JokeMarker dialog && dialogAnimator != null)
        {
            //3
            var newdialog = new Dialog
            {
                //4
                Quote = dialog.Quote,
                PausePerLetter = dialog.PausePerLetter,
                NewPage = dialog.StartNewPage,
                NewLine = dialog.StartNewLine
            };

            //5
            dialogAnimator.AddDialog(newdialog);
        }
    }

}
