using System.Collections;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private Light light;
    public float waitTime = 0.5f;

    void Awake()
    {
        light = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            light.enabled = !light.enabled;
        }
    }
}
