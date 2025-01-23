using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlane))]
public class CustomPlane : MonoBehaviour
{
    /*public TMP_Text txtSize;
    ARPlane plane;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plane = GetComponent<ARPlane>();
        plane.boundaryChanged += plane_boundaryChanged;
    }

    // Update is called once per frame
    void Update()
    {
        float size = plane.size.x * plane.size.y;
        txtSize.text = size.ToString();
    }*/
}
