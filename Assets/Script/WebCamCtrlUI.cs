using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamCtrlUI : MonoBehaviour
{
    [SerializeField] Dropdown webcamSelect;

    public Texture webCamImage{
        get{
            if(webCam != null) return webCam.inputImageTexture;
            return null;
        }
    }

    WebCamInput webCam;
    
    void Start()
    {
        var devices = WebCamTexture.devices;
        var webcamSelectOptions = new List<string>();
        foreach(var d in devices){
            if(d.name != "Unity Video Capture") webcamSelectOptions.Add(d.name);
        }
        webcamSelect.ClearOptions();
        webcamSelect.AddOptions(webcamSelectOptions);
    }

    void Update(){
        if(webCam != null) webCam.UpdateTexture();
    }

    public void CaptureSwitch(){
        if(webCam != null) {
            webCam.CaptureStop();
            webCam = null;
            return;
        }

        var webCamName = webcamSelect.options[webcamSelect.value].text;
        webCam = new WebCamInput(webCamName);
        webCam.CaptureStart();
    }

    void OnApplicationQuit(){
        if(webCam != null) webCam.CaptureStop();
    }
}
