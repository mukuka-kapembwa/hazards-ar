using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GPSCore : MonoBehaviour
{
    public float[] Lat;
    public float[] Lon;
    internal int PointCounter = 0; // The number of points that will be checked in the GPS process
    private double _distance; // Current position derived from comparing the _targetPosition and _originalPosition
    private Vector3 _targetPosition;
    private Vector3 _originalPosition;
    public float Radius = 5f; // Range in meters for target function to start
    public float TimeUpdate = 3f; // Frequency in seconds to compare current coordinates with the target coordinates
    private string _newlat;
    private string _newlon;
    float lat;
    float lon;
    public GameObject[] PointObjects; // The list of objects for every point that is to shown
    public GameObject[] TargetPopUp; // The popup UI pages when the user reaches the target position
    public bool HasTargetPopUp = false; // To check that the popup appears only once when in range of the target and not always
    public UnityEvent EventStartGPS; // This event will work when the GPS system starts to work
    public UnityEvent EventReachGPSPointRange; // This event will work when the user reaches the GPS point
    public UnityEvent EventOutGPSPointRange; // This event will work when the user is out of the GPS point range
    public GameObject NoGPSPopUp; // The popup UI page when the device location services are not enabled by the user
    public bool HasEventOutGPSPointRange = false; // To check that the event is triggered only once and not always

    private void Start()
    {
        // Calls the GPS connection in native device and attempts to connect to the satellite
        Input.location.Start();
        StartCoroutine("GPSProcess");

        if (EventStartGPS != null)
        {
            EventStartGPS.Invoke();
        }
    }

    public IEnumerator GPSProcess()
    {
        // Compares the current location with the target location using lat and long. First, attempts to get the current lat and long and converts them to the target position vector 3, x y z, and attempts to get the distance between the current location and the target location. Finally, determines if the popup will appear or not. The GPS process is the core of the system.
        while (true)
        {
            yield return new WaitForSeconds(TimeUpdate);
            if (Input.location.isEnabledByUser == true) // Checks if the device location services are enabled by the user
            {
                Input.location.Start();
                lat = Input.location.lastData.latitude;
                _newlat = lat.ToString();
                lon = Input.location.lastData.longitude;
                _newlon = lon.ToString();
                Calc(Lat[PointCounter],Lon[PointCounter], lat, lon);
            }

            if (Input.location.isEnabledByUser == false) // If the device location services are not enabled by the user
            {
                NoGPSPopUp.SetActive(true);
                HasTargetPopUp = true;
            }
        }
    }

    public void Calc(float lat1, float lon1, float lat2, float lon2)
    {
        // Comparison system using lat and long to calculate the distance from the current position and the target position
        var R = 6378.137; // Radius of earth in KM
        var dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
        var dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
            Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
            Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        _distance = R * c;
        _distance = _distance * 1000f;
        float distanceFloat = (float)_distance;
        _targetPosition = _originalPosition - new Vector3(0, 0, distanceFloat * 12);
        
        if (_distance < Radius)
        {
            if (HasTargetPopUp == false)
            {
                for (int i = 0; i < TargetPopUp.Length; i++)
                {
                    TargetPopUp[i].SetActive(false);
                    PointObjects[i].SetActive(false);
                }

                TargetPopUp[PointCounter].SetActive(true);
                PointObjects[PointCounter].SetActive(true);
                HasEventOutGPSPointRange = false;

                if (EventReachGPSPointRange != null)
                {
                    EventReachGPSPointRange.Invoke();
                }
            }
        }
        if (_distance > Radius)
        {
            for (int i = 0; i < TargetPopUp.Length; i++)
            {
                TargetPopUp[i].SetActive(false);
                PointObjects[i].SetActive(false);
            }

            PointCounter++;

            if (PointCounter == Lat.Length)
            {
                PointCounter = 0;
            }

            if (EventOutGPSPointRange != null && HasEventOutGPSPointRange == false)
            {
                EventOutGPSPointRange.Invoke();
                HasEventOutGPSPointRange = true;
            }
        }
    }

    public void HideTargetPopUp()   
    {
        TargetPopUp[PointCounter].SetActive(false);
        HasTargetPopUp = true;
    }

    public void HideNoGPSPopUp()
    {
        NoGPSPopUp.SetActive(false);
    }
}