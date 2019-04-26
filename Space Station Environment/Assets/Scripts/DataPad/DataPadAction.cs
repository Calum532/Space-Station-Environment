using UnityEngine;

public class DataPadAction : MonoBehaviour
{
    public GameObject datapadUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Interact");
            datapadUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Interact");
            datapadUI.SetActive(false);
        }
    }
}
