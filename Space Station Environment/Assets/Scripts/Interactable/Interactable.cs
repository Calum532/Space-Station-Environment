using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float throwForce;
    private Vector3 objectPos;
    private float distance;

    private GameObject item;
    public GameObject tempParent;
    public bool isHolding;
    private bool toggle;

    private bool lookingAtObject;
    public GameObject Outline;

    private bool audioPlayed;

    void Awake()
    {
        item = gameObject;
        item.GetComponent<Rigidbody>().isKinematic = true; // physics de-activated
    }

    void Update()
    {
        if (lookingAtObject)
        {
            Outline.SetActive(true);
        }
        else
        {
            Outline.SetActive(false);
        }

        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);

        if (distance >= 6f)
        {
            isHolding = false;
            Outline.SetActive(false);
        }

        // check if holding
        if (isHolding)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if (!toggle)
            {
                audioPlayed = false;
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    void OnMouseOver()
    {
        if (distance <= 6f)
        {
            // outline/glow
            lookingAtObject = true;
            // e to pick up, e again to throw
            if (Input.GetKeyDown(KeyCode.E))
            {
                // PlayAudio();
                toggle = !toggle;
                item.GetComponent<Rigidbody>().isKinematic = false; // use physics
            }
        }

        if (toggle) // picked up
        {
            audioPlayed = true;
            lookingAtObject = false;
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
    }

    void OnMouseExit()
    {
        lookingAtObject = false;
        isHolding = false;
        Outline.SetActive(false);
        toggle = false;
    }
}
