using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{

    static WebCamTexture backCam;
    private bool camAvaiable;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    void Start()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.LogError("No Camera Detected");
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            //  if(!devices[i].isFrontFacing)
            //  {
            backCam = new WebCamTexture(devices[0].name, Screen.width, Screen.height);
            // }
        }

        if (backCam == null)
        {
            Debug.LogError("Unable to find camera");
            return;

        }

        backCam.Play();
        background.texture = backCam;

        camAvaiable = true;

        //GetComponent<Renderer>().material.mainTexture = backCam;

        //if (!backCam.isPlaying)
        //    backCam.Play();

    }

    private void Update()
    {
        if (!camAvaiable)
            return;

        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1, scaleY, 1);

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }

    public void StartOver()
    {
        SceneManager.LoadScene(0);
    }
}