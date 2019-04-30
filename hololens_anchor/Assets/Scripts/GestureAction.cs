using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

/// <summary>
/// GestureAction performs custom actions based on
/// which gesture is being performed.
/// </summary>
public class GestureAction : MonoBehaviour, IManipulationHandler
{
    public static GestureAction Instance { get; private set; }

    private bool isCalibrationEnabled = false;
    public bool IsCalibrationEnabled
    {
        get { return isCalibrationEnabled; }
        set { isCalibrationEnabled = value; }
    }

    private Vector3 manipulationOriginalPosition = Vector3.zero;

    
    void IManipulationHandler.OnManipulationStarted(ManipulationEventData eventData)
    {
        if (isCalibrationEnabled)
        {
            InputManager.Instance.PushModalInputHandler(gameObject);

            manipulationOriginalPosition = transform.position;
        }
    }

    void IManipulationHandler.OnManipulationUpdated(ManipulationEventData eventData)
    {
        if (isCalibrationEnabled)
        {
            /* TODO: DEVELOPER CODING EXERCISE 4.a */

            // 4.a: Make this transform's position be the manipulationOriginalPosition + eventData.CumulativeDelta
            transform.position = manipulationOriginalPosition + eventData.CumulativeDelta;
        }
    }

    void IManipulationHandler.OnManipulationCompleted(ManipulationEventData eventData)
    {
        InputManager.Instance.PopModalInputHandler();
    }

    void IManipulationHandler.OnManipulationCanceled(ManipulationEventData eventData)
    {
        InputManager.Instance.PopModalInputHandler();
    }

    internal void enableCalibration()
    {
        isCalibrationEnabled = true;
    }

    public void disableCalibration()
    {
        isCalibrationEnabled = false;
    }
}