using UnityEngine;

public class WeatherSystem : MonoBehaviour
{
    public GameObject rainPrefab;
    public GameObject snowPrefab;
    public GameObject lightningPrefab;

    private ParticleSystem rainParticles;
    private ParticleSystem snowParticles;
    private Light lightningLight;

    void Start()
    {
        rainParticles = Instantiate(rainPrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        snowParticles = Instantiate(snowPrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        lightningLight = Instantiate(lightningPrefab, transform.position, Quaternion.identity).GetComponent<Light>();

        // Disable all weather effects by default
        rainParticles.gameObject.SetActive(false);
        snowParticles.gameObject.SetActive(false);
        lightningLight.gameObject.SetActive(false);
    }

    void Update()
    {
        // Example code to switch between weather effects
        int weather = Random.Range(0, 3);
        if (weather == 0)
        {
            rainParticles.gameObject.SetActive(true);
            snowParticles.gameObject.SetActive(false);
            lightningLight.gameObject.SetActive(false);
        }
        else if (weather == 1)
        {
            rainParticles.gameObject.SetActive(false);
            snowParticles.gameObject.SetActive(true);
            lightningLight.gameObject.SetActive(false);
        }
        else
        {
            rainParticles.gameObject.SetActive(false);
            snowParticles.gameObject.SetActive(false);
            lightningLight.gameObject.SetActive(true);
        }
    }
}
