using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;

public class Tracking : MonoBehaviour
{
    //public Text mainText;
    //public Text debugText;
    float lat;
    float lon;
    public GameObject player;

    IEnumerator Start()
    {
        //debugText.text = ("Got to Start");
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            //debugText.text = ("Location Not Enabled");
            yield break;
        }
            

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
           // debugText.text = ("Got to waitTime");
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            //debugText.text = ("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            //debugText.text = ("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            //mainText.text = ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

            /*lat = Input.location.lastData.latitude;
            lon = Input.location.lastData.longitude;
            transform.localPosition = map.GeoToWorldPosition(LocationProvider.CurrentLocation.LatitudeLongitude);
            player.transform(0,lat,0)*/
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
        //debugText.text = ("Location service stopped");
    }
}