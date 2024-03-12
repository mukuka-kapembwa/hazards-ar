using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;
public class ARManager : MonoBehaviour
{
    public PlaneFinderBehaviour Finder;
    SmartTerrain smartTerrain;
    PositionalDeviceTracker positionalDeviceTracker;
    ContentPositioningBehaviour contentPositioningBehaviour;
    AnchorBehaviour planeAnchor, midAirAnchor, placementAnchor;
    StateManager stateManager;
    float touchesPrePosDifference, touchesCurPosDifference, zoomModifier;
    Vector2 test, firstTouchPrevPos, secondTouchPrevPos;
    public GameObject Obj; // The 3D model that is to be shown on the position
    public bool ShowModelState = false;

    public void LaunchModel()
    {
        Finder.PerformHitTest(test);
        ShowModel();
    }

    public void ShowModel()
    {
        Obj.SetActive(true);
        ShowModelState = true;
    }

    public void HideModel()
    {
        Obj.SetActive(false);
        ShowModelState = false;
    }
    
    public void ResetTrackers()
    {
        this.smartTerrain = TrackerManager.Instance.GetTracker<SmartTerrain>();
        this.positionalDeviceTracker = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();
        this.smartTerrain.Stop();
        this.positionalDeviceTracker.Reset();
        this.smartTerrain.Start();
    }
}