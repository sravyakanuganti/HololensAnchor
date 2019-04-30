using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldAnchorSettings : MonoBehaviour, IManipulationHandler
{

    public string AnchorName = "WorldAnchor";

    private Vector3 SavedPosition;

    private bool isCalibrationEnabled;

    [SerializeField]
    float DragSpeed = 1.5f;

    [SerializeField]
    float DragScale = 1.5f;

    [SerializeField]
    float MaxDragDistance = 3f;



    void Awake()
    {
        isCalibrationEnabled = false;
        SavedPosition = this.gameObject.transform.position;

        WorldAnchorManager.Instance.AttachAnchor(this.gameObject, AnchorName);
        Debug.Log("Anchor attached for: " + this.gameObject.name + " - AnchorID: " + AnchorName);
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        if (isCalibrationEnabled)
        {
            WorldAnchorManager.Instance.RemoveAnchor(this.gameObject);
            InputManager.Instance.PushModalInputHandler(this.gameObject);
            SavedPosition = transform.position;
        }
        Debug.Log("OnManipulationStarted - Anchor Removed");
        //OldPosition = SavedPosition;
        //OldRotation = SavedRotation;
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        if (isCalibrationEnabled)
        {
            var targetPosition = SavedPosition + eventData.CumulativeDelta * DragScale;
            if (Vector3.Distance(SavedPosition, targetPosition) <= MaxDragDistance)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, DragSpeed);
            }
        }
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        //OldPosition = SavedPosition;
        //OldRotation = SavedRotation;
        WorldAnchorManager.Instance.AttachAnchor(this.gameObject, AnchorName);
        Debug.Log("OnManipulationCompleted - Anchor Attached");
    }

    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        WorldAnchorManager.Instance.AttachAnchor(this.gameObject, AnchorName);
        Debug.Log("OnManipulationCompleted - Anchor Attached");
    }

    public void AttachAnchor()
    {
        isCalibrationEnabled = false;
        WorldAnchorManager.Instance.AttachAnchor(this.gameObject, AnchorName);
    }

    public void MoveAnchor()
    {
        isCalibrationEnabled = true;
    }

    public void RotateAnchor()
    {
        WorldAnchorManager.Instance.RemoveAnchor(this.gameObject);
        //InputManager.Instance.PushModalInputHandler(this.gameObject);
        transform.Rotate(Vector3.up, 90.0f);
        WorldAnchorManager.Instance.AttachAnchor(this.gameObject, AnchorName);
    }
}
