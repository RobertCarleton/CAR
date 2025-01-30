using UnityEngine;

public class Start : MonoBehaviour
{
    private void OnEnable()
    {
        UIManager.Instance.ShowScreen("Start");
    }

    private void OnDisable()
    {
        
    }
}
