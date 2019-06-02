using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Vuforia;

public class EventHandler : MonoBehaviour, ITrackableEventHandler
{
    public UnityAction OnTrackingFound;
    public UnityAction OnTrackingLost;
    private TrackableBehaviour mTrackableBehaviour = null;

    private readonly List<TrackableBehaviour.Status> mTrackingFound = new List<TrackableBehaviour.Status>
    {
        TrackableBehaviour.Status.DETECTED,
        TrackableBehaviour.Status.TRACKED,

        TrackableBehaviour.Status.EXTENDED_TRACKED
    };

    private readonly List<TrackableBehaviour.Status> mTrackingLost = new List<TrackableBehaviour.Status>
    {
        TrackableBehaviour.Status.TRACKED,
        TrackableBehaviour.Status.NO_POSE
    };

    private void Awake()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        mTrackableBehaviour.RegisterTrackableEventHandler(this);        
    }

    private void OnDestroy()
    {
        mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        // if tracking found
        foreach (TrackableBehaviour.Status trackedStatus in mTrackingFound)
        {
            if(newStatus == trackedStatus)
            {
                if (OnTrackingFound != null)
                    OnTrackingFound();
                Main.mark1 = true;
                print("beforePlayVideo");
                //Main.videoPlayer.Play();
                if (Main.mark2)
                {
                    Main.animais[Main.animalIndex].SetActive(true);
                }
                return;
            }
        }
        // if tracking lost
        foreach (TrackableBehaviour.Status trackedStatus in mTrackingLost)
        {
            if (newStatus == trackedStatus)
            {
                if (OnTrackingLost != null)
                    OnTrackingLost();
                
                Main.mark1 = false;
                print("perdeFoco1");
                if (Main.animais.Length > 0)
                {
                    print("beoreSetFalse1");
                    Main.animais[Main.animalIndex].SetActive(false);
                }

                if (Main.mark2 && Main.animalIndex < 9)
                {
                    Main.animalIndex++;
                }
                return;
            }
        }
    }
}
