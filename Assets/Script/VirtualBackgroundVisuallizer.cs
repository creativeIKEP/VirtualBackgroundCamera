using UnityEngine;
using UnityEngine.UI;
using Mediapipe.SelfieSegmentation;

public class VirtualBackgroundVisuallizer : MonoBehaviour
{
    [SerializeField] WebCamCtrlUI webCamCtrlUI;
    [SerializeField] VisualizeCtrlUI visualizeCtrlUI;
    [SerializeField] RawImage compositeImage;
    [SerializeField] SelfieSegmentationResource resource;
    [SerializeField] Shader shader;
    [SerializeField] Texture noInputTexture;

    SelfieSegmentation segmentation;
    Material material;

    void Start(){
        material = new Material(shader);
        compositeImage.material = material;

        segmentation = new SelfieSegmentation(resource);
    }

    void LateUpdate(){
        if(webCamCtrlUI.webCamImage == null){
            compositeImage.material = null;
            compositeImage.texture = noInputTexture;
            return;
        }

        if(visualizeCtrlUI.backGroundTexture == null){
            compositeImage.material = null;
            compositeImage.texture = webCamCtrlUI.webCamImage;
            return;
        }

        compositeImage.material = material;

        // Predict segmentation by neural network model.
        segmentation.ProcessImage(webCamCtrlUI.webCamImage);
        
        //Set segmentation texutre to `_MainTex` variable of shader.
        compositeImage.texture = segmentation.texture;
        material.SetTexture("_inputImage", webCamCtrlUI.webCamImage);
        material.SetTexture("_backImage", visualizeCtrlUI.backGroundTexture);
    } 

    void OnApplicationQuit(){
        segmentation.Dispose();
    }
}
