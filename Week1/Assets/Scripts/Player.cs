using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.XR.ARSubsystems;
public class Player : MonoBehaviour
{
    Vector2 cursorPostion;
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GameObject PrefabToSpawn;
    public float offset = 1.25f;
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    public void OnInteract()
    {
        if(raycastManager.Raycast(cursorPostion, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            Vector3 position = hitPose.position + (hitPose.up * offset);
            Instantiate(PrefabToSpawn, hitPose.position, hitPose.rotation);
        }
    }

    public void OnCursorPosition(InputValue inputValue)
    {
        cursorPostion = inputValue.Get<Vector2>();
    }


}
