using UnityEngine;

public class LightSystem : MonoBehaviour
{
    public Light mainLight;

    void Start()
    {
        mainLight = GetComponent<Light>();
    }

    void Update()
    {
        float intensity = Mathf.Lerp(mainLight.intensity, 0.5f, Time.deltaTime);
        mainLight.intensity = intensity;
    }
}
