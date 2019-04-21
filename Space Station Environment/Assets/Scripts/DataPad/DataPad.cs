using UnityEngine;

public class DataPad : MonoBehaviour
{
    public GameObject datapadUI;

    private bool lookingAtObject;
    private Outline _outline;

    private bool toggle;
    private float distance;
    private GameObject player;

    private bool audioPlayed;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _outline = gameObject.GetComponent<Outline>();
        _outline.OutlineWidth = 0;
    }

    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (lookingAtObject)
        {
            _outline.OutlineWidth = 10;
        }
        else
        {
            _outline.OutlineWidth = 0;
        }     

        if (distance >= 6f)
        {
            lookingAtObject = false;
        }


        else if (!toggle) // drop note
        {
            audioPlayed = false;
            datapadUI.SetActive(false);
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
            }
        }

        if (toggle) // read note
        {
            audioPlayed = true;
            lookingAtObject = false;
            datapadUI.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        lookingAtObject = false;
        toggle = false;
    }
}
