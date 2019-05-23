using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Vuforia;

public class EventHandler2 : MonoBehaviour, ITrackableEventHandler
{
    public UnityAction OnTrackingFound;
    public UnityAction OnTrackingLost;
    private TrackableBehaviour mTrackableBehaviour = null;

    public GameObject[] animais;
    public int animalIndex;

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
        print("awake eventHandler2");
    }

    private void OnDestroy()
    {
        mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        print("TrackableStateChanged");
        // if tracking found
        foreach (TrackableBehaviour.Status trackedStatus in mTrackingFound)
        {
            if (newStatus == trackedStatus)
            {
                if (OnTrackingFound != null)
                    OnTrackingFound();
                print("mark2 found");
                Main.mark2 = true;
                
                if (Main.mark1)
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
                print("mark2 lost");
                Main.mark2 = false;
                Main.animais[Main.animalIndex].SetActive(false);
                if (Main.mark1 && Main.animalIndex > 0)
                {
                    Main.animalIndex--;
                }
                return;
            }
        }
    }
}
