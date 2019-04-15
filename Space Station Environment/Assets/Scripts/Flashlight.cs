using UnityEngine;

public class Flashlight : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FindObjectOfType<AudioManager>().Play("Flashlight");

            if (GetComponent<Light>().enabled)
            {
                GetComponent<Light>().enabled = false;
            }
            else
            {
                GetComponent<Light>().enabled = true;
            }
        }
    }
}
