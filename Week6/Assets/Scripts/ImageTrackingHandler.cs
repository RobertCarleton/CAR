using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTrackingHandler : MonoBehaviour
{
    [SerializeField]
    private ARTrackedImageManager imageManager;

    public GameObject PosterPrefab;

    private void OnEnable()
    {
        imageManager.trackablesChanged.AddListener(OnTrackedImagesChanged);
    }

    private void OnDisable()
    {
        imageManager.trackablesChanged.RemoveListener(OnTrackedImagesChanged);
    }

    void OnTrackedImagesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach(var image in eventArgs.added)
        {
            Debug.Log($"Image Added:{image.referenceImage.name}");

            GameObject instance = Instantiate(PosterPrefab, image.transform.position, Quaternion.Euler(0, 90, 0));
        }
        /*
        foreach (var image in eventArgs.updated)
        {
            Debug.Log($"Image Updated:{image.referenceImage.name}");
        }
        */
        foreach (var image in eventArgs.removed)
        {
            Debug.Log($"Image Removed:{image.Value.referenceImage.name}");
        }
    }
}
