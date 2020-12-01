using UnityEngine;
using Valve.VR.InteractionSystem;

public class PartBehaviour : MonoBehaviour
{
    AssemblyManager manager;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 startScale;

    private GameObject otherGameObject;
    private bool isPlaced;

    void Start()
    {
        manager = FindObjectOfType<AssemblyManager>();

        startPosition = transform.position;
        startRotation = transform.rotation;
        startScale = transform.localScale;

        isPlaced = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == gameObject.tag)
        {
            isPlaced = true;
            otherGameObject = other.gameObject;
        }
        else
        {
            isPlaced = false;
        }
    }

    public void BackToPosition()
    {
        if (!isPlaced)
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
            transform.localScale = startScale;
        }
        else
        {
            Debug.Log("Object Is Placed");

            transform.parent = manager.ParentTransform;
            startPosition = transform.position = otherGameObject.transform.position;
            startRotation = transform.rotation = otherGameObject.transform.rotation;
            startScale = transform.localScale = otherGameObject.transform.localScale;

            /*int children = otherGameObject.transform.childCount;

            for (int i = 0; i < children; i++)
            {
                Transform thisChild = transform.GetChild(i);
                Transform otherChild = otherGameObject.transform.GetChild(i);

                thisChild.position = otherChild.position;
                thisChild.rotation = otherChild.rotation;
                thisChild.localScale = otherChild.localScale;
            }*/

            if (otherGameObject != null)
            {
                otherGameObject.gameObject.SetActive(false);
            }

            manager.PlacementDone();

            Destroy(GetComponent<Throwable>());
            Destroy(GetComponent<VelocityEstimator>());
            Destroy(GetComponent<Interactable>());
        }
    }
}
