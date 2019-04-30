using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MarkerTransform : MonoBehaviour {

	private GameObject _crossmarks;
    
    private GameObject _crossmark1;
    private GameObject _crossmark2;
    private GameObject _crossmark3;
    private GameObject _crossmark4;
    private GameObject _crossmark5;
    private GameObject _crossmark6;
    private GameObject _crossmark7;
    private GameObject _crossmark8;

    private Quaternion crossMark1;
    private Quaternion crossMark2;
    private Quaternion crossMark3;
    private Quaternion crossMark4;
    private Quaternion crossMark5;
    private Quaternion crossMark6;
    private Quaternion crossMark7;
    private Quaternion crossMark8;

    private Vector3 crossMark1Transform;
    private Vector3 crossMark2Transform;
    private Vector3 crossMark3Transform;
    private Vector3 crossMark4Transform;
    private Vector3 crossMark5Transform;
    private Vector3 crossMark6Transform;
    private Vector3 crossMark7Transform;
    private Vector3 crossMark8Transform;

    private bool setCrossMarks_enabled = false;

    public GameObject anchor;

    public void Update()
	{


        if (!setCrossMarks_enabled)
            return;
        if (_crossmark1 == null)
		{
			_crossmark1 = GameObject.Find("Marker1");
			return;
		}

		_crossmark1.transform.position = crossMark1Transform;

        if (_crossmark2 == null)
        {
            _crossmark2 = GameObject.Find("Marker2");
            return;
        }

        _crossmark2.transform.position = crossMark2Transform;

        if (_crossmark3 == null)
        {
            _crossmark3 = GameObject.Find("Marker3");
            return;
        }

        _crossmark3.transform.position = crossMark3Transform;

        if (_crossmark4 == null)
        {
            _crossmark4 = GameObject.Find("Marker4");
            return;
        }

        _crossmark4.transform.position = crossMark4Transform;

        if (_crossmark5 == null)
        {
            _crossmark5 = GameObject.Find("Marker5");
            return;
        }

        _crossmark5.transform.localPosition = crossMark5Transform;

        if (_crossmark6 == null)
        {
            _crossmark6 = GameObject.Find("Marker6");
            return;
        }

        _crossmark6.transform.localPosition = crossMark6Transform;

        if (_crossmark7 == null)
        {
            _crossmark7 = GameObject.Find("Marker7");
            return;
        }

        _crossmark7.transform.localPosition = crossMark7Transform;

        if (_crossmark8 == null)
        {
            _crossmark8 = GameObject.Find("Marker8");
            return;
        }

        _crossmark8.transform.localPosition = crossMark8Transform;




    }

	private void load_matrices()
	{
		try
		{
            //crossMark1 = new Quaternion(-0.127146f, -0.0235317f, 0.0271851f, 0.991239f);
            //crossMark1Transform = new Vector3(-0.227326f, -0.395322f, 0.229821f);
            //crossMark1Transform = crossMark1 * crossMark1Transform;
            //crossMark1Transform = crossMark1Transform + new Vector3(0.216582f, -0.397299f, 2.56703f);
            //crossMark1Transform.x *= -1;

            crossMark1Transform = new Vector3(0.0417801f, -0.137801f, 2.73669f);
            crossMark1Transform = anchor.transform.rotation * crossMark1Transform;
            crossMark1Transform = crossMark1Transform + anchor.transform.position;


            //crossMark2 = new Quaternion(-0.127146f, -0.0235317f, 0.0271851f, 0.991239f);
            //crossMark2Transform = new Vector3(-0.227326f, -0.395322f, -0.215119f);
            //crossMark2Transform = crossMark2 * crossMark2Transform;
            //crossMark2Transform = crossMark2Transform + new Vector3(0.216582f, -0.397299f, 2.56703f);
            //crossMark2Transform.x *= -1;

            crossMark2Transform = new Vector3(0.0165459f, -0.155947f, 2.28134f);
            crossMark2Transform = anchor.transform.rotation * crossMark2Transform;
            crossMark2Transform = crossMark2Transform + anchor.transform.position;

            //crossMark3 = new Quaternion(-0.127146f, -0.0235317f, 0.0271851f, 0.991239f);
            //crossMark3Transform = new Vector3(0.229874f, -0.395322f, -0.215119f);
            //crossMark3Transform = crossMark3 * crossMark3Transform;
            //crossMark3Transform = crossMark3Transform + new Vector3(0.216582f, -0.397299f, 2.56703f);
            //crossMark3Transform.x *= -1;

            crossMark3Transform = new Vector3(-0.455606f, -0.127602f, 2.30015f);
            crossMark3Transform = anchor.transform.rotation * crossMark3Transform;
            crossMark3Transform = crossMark3Transform + anchor.transform.position;


            //crossMark4 = new Quaternion(-0.127146f, -0.0235317f, 0.0271851f, 0.991239f);
            //crossMark4Transform = new Vector3(0.229874f, -0.395322f, 0.229821f);
            //crossMark4Transform = crossMark4 * crossMark4Transform;
            //crossMark4Transform = crossMark4Transform + new Vector3(0.216582f, -0.397299f, 2.56703f);
            //crossMark4Transform.x *= -1;

            crossMark4Transform = new Vector3(-0.430372f, -0.19456f, 2.7555f);
            crossMark4Transform = anchor.transform.rotation * crossMark4Transform;
            crossMark4Transform = crossMark4Transform + anchor.transform.position;

            //crossMark5 = new Quaternion(-0.127146f, -0.0235317f, 0.0271851f, 0.991239f);
            //crossMark5Transform = new Vector3(-0.227326f, -0.395322f, 0.229821f);
            //crossMark5Transform = crossMark5 * crossMark5Transform;
            //crossMark5Transform = crossMark5Transform + new Vector3(0.216582f, -0.397299f, 2.56703f);
            //crossMark5Transform.x *= -1;

            crossMark5Transform = new Vector3(-0.0417801f, -0.5137801f, 2.73669f);
            crossMark5Transform = anchor.transform.rotation * crossMark5Transform;
            crossMark5Transform = crossMark5Transform + anchor.transform.position;


            //crossMark6 = new Quaternion(-0.127146f, -0.0235317f, 0.0271851f, 0.991239f);
            //crossMark6Transform = new Vector3(-0.227326f, -0.395322f, -0.215119f);
            //crossMark6Transform = crossMark6 * crossMark6Transform;
            //crossMark6Transform = crossMark6Transform + new Vector3(0.216582f, -0.397299f, 2.56703f);
            //crossMark6Transform.x *= -1;

            crossMark6Transform = new Vector3(-0.0165459f, -0.5255947f, 2.28134f);
            crossMark6Transform = anchor.transform.rotation * crossMark6Transform;
            crossMark6Transform = crossMark6Transform + anchor.transform.position;

            //crossMark7 = new Quaternion(-0.127146f, -0.0235317f, 0.0271851f, 0.991239f);
            //crossMark7Transform = new Vector3(0.229874f, -0.395322f, -0.215119f);
            //crossMark7Transform = crossMark7 * crossMark7Transform;
            //crossMark7Transform = crossMark7Transform + new Vector3(0.216582f, -0.397299f, 2.56703f);
            //crossMark7Transform.x *= -1;

            //crossMark7Transform = new Vector3(0.455606f, -0.5227602f, 2.30015f);
            //crossMark7Transform = anchor.transform.rotation * crossMark7Transform;
            //crossMark7Transform = crossMark7Transform + anchor.transform.position;


            //crossMark8 = new Quaternion(-0.127146f, -0.0235317f, 0.0271851f, 0.991239f);
            //crossMark8Transform = new Vector3(0.229874f, -0.395322f, 0.229821f);
            //crossMark8Transform = crossMark8 * crossMark8Transform;
            //crossMark8Transform = crossMark8Transform + new Vector3(0.216582f, -0.397299f, 2.56703f);
            //crossMark8Transform.x *= -1;

            //crossMark8Transform = new Vector3(0.430372f, -0.5109456f, 2.7555f);
            //crossMark8Transform = anchor.transform.rotation * crossMark8Transform;
            //crossMark8Transform = crossMark8Transform + anchor.transform.position;


        }
		catch (Exception e)
		{
			Debug.Log(e);
		}


	}

	public void EnableMarkers()
	{
        
        load_matrices();
        setCrossMarks_enabled = true;


    }

    public void DisableMarkers()
    {
        setCrossMarks_enabled = false;
    }

	public void Start()
	{
        //Action = MsgAction.NONE;

        anchor = GameObject.Find("WorldAnchor");

        _crossmarks = GameObject.Find("Marker");
		if (_crossmarks == null)
		{
			Debug.LogError("[Correction] - Cannot find game object Crossmarks.");
		}






		// Those are most likely not ready at this location
		_crossmark1 = _crossmarks.transform.Find("Marker1").gameObject;
        _crossmark2 = _crossmarks.transform.Find("Marker2").gameObject;
        _crossmark3 = _crossmarks.transform.Find("Marker3").gameObject;
        _crossmark4 = _crossmarks.transform.Find("Marker4").gameObject;
        _crossmark5 = _crossmarks.transform.Find("Marker5").gameObject;
        _crossmark6 = _crossmarks.transform.Find("Marker6").gameObject;
        _crossmark7 = _crossmarks.transform.Find("Marker7").gameObject;
        _crossmark8 = _crossmarks.transform.Find("Marker8").gameObject;
        
    }
}

