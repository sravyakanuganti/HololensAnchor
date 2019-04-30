using System;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.VR.WSA.WebCam;
using System.Linq;

public class TestWorldAnchor : MonoBehaviour, IManipulationHandler, ISpeechHandler {

	
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
        //OldRotation = SavedRotation = this.gameObject.transform.rotation;

        WorldAnchorManager.Instance.AttachAnchor(this.gameObject, AnchorName);
        Debug.Log("Anchor attached for: " + this.gameObject.name + " - AnchorID: " + AnchorName);
    }
		
	
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        if (isCalibrationEnabled)
        {
            WorldAnchorManager.Instance.RemoveAnchor(this.gameObject);
            InputManager.Instance.PushModalInputHandler(gameObject);
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

    void ISpeechHandler.OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        if (eventData.RecognizedText.ToLower().Equals("move anchor"))
        {
            isCalibrationEnabled = true;
        }
        else if (eventData.RecognizedText.ToLower().Equals("attach anchor"))
        {
            isCalibrationEnabled = false;
            WorldAnchorManager.Instance.AttachAnchor(this.gameObject, AnchorName);
        }
        else if(eventData.RecognizedText.ToLower().Equals("take photo"))
        {
           // HololensPhotoCapture.Instance.TakePhoto();
        }
        else
        {
            return;
        }

        eventData.Use();
    }

    PhotoCapture photoCaptureObject = null;
    private string filePath;

    public void TakePhoto()
    {
        Debug.Log("TakePhoto");
        PhotoCapture.CreateAsync(true, OnPhotoCaptureCreated);
    }

    void OnPhotoCaptureCreated(PhotoCapture captureObject)
    {
        photoCaptureObject = captureObject;

        Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();

        CameraParameters c = new CameraParameters();
        c.hologramOpacity = 0.0f;
        c.cameraResolutionWidth = cameraResolution.width;
        c.cameraResolutionHeight = cameraResolution.height;
        c.pixelFormat = CapturePixelFormat.BGRA32;

        captureObject.StartPhotoModeAsync(c, OnPhotoModeStarted);
    }

    void OnStoppedPhotoMode(PhotoCapture.PhotoCaptureResult result)
    {
        photoCaptureObject.Dispose();
        photoCaptureObject = null;
    }

    private void OnPhotoModeStarted(PhotoCapture.PhotoCaptureResult result)
    {
        if (result.success)
        {
            string filename = string.Format(@"CapturedImage{0}_n.jpg", Time.time);
            filePath = System.IO.Path.Combine(Application.persistentDataPath, filename);

            photoCaptureObject.TakePhotoAsync(filePath, PhotoCaptureFileOutputFormat.JPG, OnCapturedPhotoToDisk);
        }
        else
        {
            Debug.LogError("Unable to start photo mode!");
        }
    }

    void OnCapturedPhotoToDisk(PhotoCapture.PhotoCaptureResult result)
    {
        if (result.success)
        {
            photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
        }
        else
        {
            Debug.Log("Failed to save Photo to disk");
        }
    }
}
