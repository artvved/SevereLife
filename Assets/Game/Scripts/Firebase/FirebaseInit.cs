using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase;
using UnityEngine;
using Firebase.Analytics;

public class FirebaseInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
