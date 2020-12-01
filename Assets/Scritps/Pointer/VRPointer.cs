using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;
using Valve.VR;


public class VRPointer : MonoBehaviour
{
    [SerializeField]
    private float defaultLength;
    [SerializeField]
    private GameObject dot;

    private LineRenderer lineRenderer = null;

    [SerializeField]
    private SteamVR_Input_Sources targetSources;
    [SerializeField]
    private SteamVR_Action_Boolean shootRay;
    [SerializeField]
    private SteamVR_Action_Boolean clickAction;
    [SerializeField]
    private bool click = false;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        shootRay.AddOnStateDownListener(DrawRay, targetSources);
        shootRay.AddOnStateUpListener(DrawRayStop, targetSources);
        clickAction.AddOnStateDownListener(Click, targetSources);
        clickAction.AddOnStateUpListener(ClickComplete, targetSources);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DrawRay(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Draw Ray");
        UpdateLine();
    }

    public void DrawRayStop(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Draw Ray");
    }

    public void Click(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        click = true;
    }

    public void ClickComplete(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        click = false;
    }

    void UpdateLine()
    {
        //use default or distance
        float targetLength = defaultLength;
        //raycast
        RaycastHit hit = CreateRaycast(targetLength);
        //default
        Vector3 endpos = transform.position + (transform.forward * targetLength);
        //if hit update dot pos
        if (hit.collider != null)
        {
            endpos = hit.point;

            if(hit.collider.tag == "button" && click)
            {
                Debug.Log("Button Hit");
                //Button button = hit.collider.gameObject.GetComponent<Button>();
                
            }
        }

        dot.transform.position = endpos;
        //set pos of line renderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endpos);

        //click = false;
    }

    RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);

        return hit;
    }
}
