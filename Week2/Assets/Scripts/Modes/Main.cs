using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Main : MonoBehaviour
{
    [SerializeField]
    ARPlaneManager planeManager;
    bool isToggledOn = true;
    private void OnEnable()
    {
        UIManager.Instance.ShowScreen("Main");
    }

    private void OnDisable()
    {
        
    }

    public void TogglePlanes()
    {
        //bool toggle = planeManager.planePrefab.activeSelf;

        isToggledOn = !isToggledOn;

        planeManager.planePrefab.SetActive(!isToggledOn);

        foreach (ARPlane plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(!isToggledOn);
        }
    }
}
