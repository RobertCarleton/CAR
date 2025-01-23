using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Loader : MonoBehaviour
{
    new ParticleSystem particleSystem;
    ParticleSystem.Particle[] particles;

    void SetParticlePosition(int index, Vector3 position)
    {
        particles[index].startColor = particleSystem.main.startColor.color;
        particles[index].startSize = particleSystem.main.startSize.constant;
        particles[index].position = position;
        particles[index].remainingLifetime = 1f;
    }

    private void Load()
    {
        string json = System.IO.File.ReadAllText($"{Application.dataPath}/Points.json");
        PointCloudSave save = JsonUtility.FromJson<PointCloudSave>(json);

        particles = new ParticleSystem.Particle[save.Points.Count];

        int particleIndex = 0;
        foreach (var point in save.Points)
        {
            SetParticlePosition(particleIndex++, point);
        }

        particleSystem.SetParticles(particles, save.Points.Count);
    }

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        Load();
    }
}
