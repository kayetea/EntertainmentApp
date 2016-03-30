using UnityEngine;
using System.Collections;

public class GATrack : MonoBehaviour {

	public GoogleAnalyticsV4 googleAnalytics;

	void Start(){
		googleAnalytics.StartSession ();
	}
}
