using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

    public Transform playerCamera;
    public Transform portal2;
    public Transform portal1;
	
	// Update is called once per frame
	void Update () {
        Vector3 playerOffsetFromPortal = playerCamera.position - portal1.position; //jarak player dengan portal didepannya
        transform.position = portal2.position + playerOffsetFromPortal; //memposisikan camera2
        /*jadi kamera2 akan terus meng-update berdasarkan posisi aslinya yang ditambah dengan jarak player dengan
        portal1. portal1 berada pada posisi 0,0,0;*/

        //setting camera2 agar mengikuti rotasi player;
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal2.rotation, portal1.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);//set camera2 rotation
	}
}
