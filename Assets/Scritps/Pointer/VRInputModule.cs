using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class VRInputModule : BaseInputModule
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private SteamVR_Input_Sources targetSources;
    [SerializeField]
    private SteamVR_Action_Boolean clickAction;

    private GameObject currentGameObject = null;
    private PointerEventData data = null;

    protected override void Awake()
    {
        base.Awake();
        data = new PointerEventData(eventSystem);
    }

    public override void Process()
    {
        //reset data, set camera
        data.Reset();
        data.position = new Vector2(camera.scaledPixelWidth / 2, camera.scaledPixelHeight / 2);

        //raycast
        eventSystem.RaycastAll(data, m_RaycastResultCache);
        data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        currentGameObject = data.pointerCurrentRaycast.gameObject;

        //clear raycast
        m_RaycastResultCache.Clear();

        //hover
        HandlePointerExitAndEnter(data, currentGameObject);

        //press
        if (clickAction.GetStateDown(targetSources))
        {
            ProcessPress(data);
        }

        //release
        if (clickAction.GetStateUp(targetSources))
        {
            ProcessRelease(data);
        }
    }

    public PointerEventData GetData()
    {
        return data;
    }

    private void ProcessPress(PointerEventData _data)
    {

    }

    private void ProcessRelease(PointerEventData _data)
    {

    }
}
