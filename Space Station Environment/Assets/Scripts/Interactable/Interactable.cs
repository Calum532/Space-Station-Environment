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
    private Outline _outline;

    private bool audioPlayed;
    

    void Awake()
    {
        item = gameObject;
        item.GetComponent<Rigidbody>().isKinematic = true; // physics de-activated
        _outline = gameObject.GetComponent<Outline>();
        _outline.OutlineWidth = 0;
    }

    void Update()
    {
        if (lookingAtObject)
        {
            _outline.OutlineWidth = 10;
        }
        else
        {
            _outline.OutlineWidth = 0;
        }

        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);

        if (distance >= 6f)
        {
            isHolding = false;
            _outline.OutlineWidth = 0;
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
        _outline.OutlineWidth = 0;
        toggle = false;
    }
}
