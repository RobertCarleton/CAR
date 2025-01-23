using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPointCloud))]
[RequireComponent(typeof(ParticleSystem))]
public class CustomCloudVisualiser : MonoBehaviour
{
    ARPointCloud pointCloud;
    new ParticleSystem particleSystem;
    int numberOfPoints;
    Dictionary<ulong, Vector3> points = new Dictionary<ulong, Vector3>();
    ParticleSystem.Particle[] particles;
    
    void Awake()
    {
        pointCloud = GetComponent<ARPointCloud>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    void SetParticlePosition(int index, Vector3 position)
    {
        particles[index].startColor = particleSystem.main.startColor.color;
        particles[index].startSize = particleSystem.main.startSize.constant;
        particles[index].position = position;
        particles[index].remainingLifetime = 1f;
    }

    void OnEnable()
    {
        pointCloud.updated += PointCloud_updated;
    }

    private void PointCloud_updated(ARPointCloudUpdatedEventArgs obj)
    {
        if(!pointCloud.positions.HasValue)
            return;
        var positions = pointCloud.positions.Value;
        if(pointCloud.identifiers.HasValue)
        {
            var identifiers = pointCloud.identifiers.Value;
            for(int i =0; i < positions.Length; ++i)
            {
                points[identifiers[i]] = positions[i];
            }
        }

        int numParticles = points.Count;

        if(particles == null || particles.Length < numParticles)
        {
            particles = new ParticleSystem.Particle[numParticles];
        }

        int particleIndex = 0;
        foreach (var kvp in points)
        {
            SetParticlePosition(particleIndex++, kvp.Value);
        }

        for (int i = numParticles; i < numberOfPoints; ++i)
        {
        }

        particleSystem.SetParticles(particles, System.Math.Max(numParticles, numberOfPoints));
        numberOfPoints = numParticles;
    }

    IEnumerator Save()
    {
        PointCloudSave save = new PointCloudSave();
        foreach (var kvp in points)
        {
            save.Points.Add(kvp.Value);
        }

        string json = JsonUtility.ToJson(save, true);
        System.IO.File.WriteAllText($"{Application.dataPath}/Points.json", json);
        yield return null;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            StartCoroutine(Save());
    }
}

[System.Serializable]
public class PointCloudSave
{
    public List<Vector3> Points = new List<Vector3>();

    
}