using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class AssemblyManager : MonoBehaviour
{
    AssemblyStateManager stateManager;

    [SerializeField] GameObject[] parts;

    [Space]

    [SerializeField] GameObject[] moveableParts;

    [Space]

    [SerializeField] Transform parentTransform;
    public Transform ParentTransform { get { return parentTransform; } }

    private int currentPart;

    // Start is called before the first frame update
    void Start()
    {
        stateManager = AssemblyStateManager.Instance;

        foreach(GameObject moveable in moveableParts)
        {
            moveable.AddComponent<PartBehaviour>();

            PartBehaviour partAction = moveable.GetComponent<PartBehaviour>();
            Throwable throwAction = moveable.GetComponent<Throwable>();

            throwAction.onDetachFromHand.AddListener(partAction.BackToPosition);
        }

        currentPart = 0;
        stateManager.SwitchState(1);
        EnablePlacementPart(currentPart);
    }

    void EnablePlacementPart(int part)
    {
        if (parts[part] != null)
        {
            Debug.Log("Part to be Assembled : " + parts[part].name);
            parts[part].SetActive(true);
        }  
    }

    public void PlacementDone()
    {
        int state = stateManager.CurrentState();

        state++;
        Debug.Log("State Value after Placing : " + state);

        currentPart++;
        
        if (state < 18)
        {
            EnablePlacementPart(currentPart);
            stateManager.SwitchState(state);
        }
        else
        {
            stateManager.SwitchState(state);
        }
    }
}
