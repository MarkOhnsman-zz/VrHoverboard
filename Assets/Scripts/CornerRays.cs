using UnityEngine;
using System.Collections;

public class CornerRays : MonoBehaviour {
    public HoverEngine engineScript;
	
	// Update is called once per frame
	void FixedUpdate () {
    
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            engineScript.fireEngine(hit.distance);
        };
        }
}
