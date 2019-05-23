using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;

public class TargetManager : MonoBehaviour
{
    public string mDatabaseName = "";
    private List<TrackableBehaviour> mAllTargets = new List<TrackableBehaviour>();

    private void Awake()
    {
        //print("passou2");
        //VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
    }

    private void OnDestroy()
    {
        VuforiaARController.Instance.UnregisterVuforiaStartedCallback(OnVuforiaStarted);
    }

    private void OnVuforiaStarted()
    {
        LoadDatabase(mDatabaseName);

        mAllTargets = GetTargets();

        SetupTargets(mAllTargets);
    }

    private void LoadDatabase(string setName)
    {
        ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();

        objectTracker.Stop();

        if(DataSet.Exists(setName))
        {
            DataSet dataSet = objectTracker.CreateDataSet();

            dataSet.Load(setName);
            objectTracker.ActivateDataSet(dataSet);
        }

        objectTracker.Start();
    }

    private List<TrackableBehaviour> GetTargets()
    {
        List<TrackableBehaviour> allTrackables = new List<TrackableBehaviour>();
        allTrackables = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours().ToList();

        return allTrackables;
    }

    private void SetupTargets(List<TrackableBehaviour> allTargets)
    {
        foreach(TrackableBehaviour target in allTargets)
        {
            target.gameObject.transform.parent = transform;

            target.gameObject.name = target.TrackableName;

            target.gameObject.AddComponent<EventHandler>();

            Debug.Log(target.TrackableName + " " + "Created"); 
        }
    }
}
