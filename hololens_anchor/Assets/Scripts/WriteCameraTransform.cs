using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

#if WINDOWS_UWP
using Windows.Storage;
using Windows.System;
using System.Threading.Tasks;
using Windows.Storage.Streams;
#endif

public class WriteCameraTransform : MonoBehaviour
{


    public static WriteCameraTransform Instance { get; private set; }

    //define filePath
#if WINDOWS_UWP
    Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
#endif

    private static string fileName = "cameracoordinates.txt";

    //private save counter
    private static bool firstSave = true;

    public GameObject anchor;

    void Awake()
    {
        Instance = this;
        anchor = GameObject.Find("WorldAnchor");
    }

#if WINDOWS_UWP
    async void WriteData(string saveInformation)
    {
        if (firstSave){
        StorageFile sampleFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        await FileIO.AppendTextAsync(sampleFile, saveInformation + "\r\n");
        firstSave = false;
        }
    else{
        StorageFile sampleFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
        await FileIO.AppendTextAsync(sampleFile, saveInformation + "\r\n");
    }
    }
#endif

    public void SaveCameraTransform(string filename)
    {
        //string picfilename = string.Format(@"CapturedImage{0}_n.jpg", Time.time);
        Quaternion rotation = Quaternion.Inverse(anchor.transform.rotation) * Camera.main.transform.rotation;
        Vector3 position = anchor.transform.InverseTransformPoint(Camera.main.transform.position) / 10.0f ;

        string rotation_info = rotation.x + " " + rotation.y + " " + rotation.z + " " + rotation.w;
        string position_info = position.x + " " + position.y + " " + position.z;
        string info = filename + "\r\n" + rotation_info + "\r\n" + position_info + "\r\n";
#if WINDOWS_UWP
        WriteData(info);
#endif

    }

}