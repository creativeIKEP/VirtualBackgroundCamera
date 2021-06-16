using UnityEngine;
using UnityEngine.UI;
using Mediapipe.SelfieSegmentation;

public class VirtualBackgroundVisuallizer : MonoBehaviour
{
    [SerializeField] WebCamInput webCamInput;
    [SerializeField] RawImage compositeImage;
    [SerializeField] SelfieSegmentationResource resource;
    [SerializeField] Shader shader;
    [SerializeField] bool isBackGroundTexture = false;
    [SerializeField] Texture backGroundTexture;
    [SerializeField] Color backGroundColor = Color.green;
    [SerializeField, Range(0, 1)] float threshold = 0.95f;

    SelfieSegmentation segmentation;
    Material material;

    void Start(){
        material = new Material(shader);
        compositeImage.material = material;

        segmentation = new SelfieSegmentation(resource);
    }

    void LateUpdate(){
        // Predict segmentation by neural network model.
        segmentation.ProcessImage(webCamInput.inputImageTexture);
        
        //Set segmentation texutre to `_MainTex` variable of shader.
        compositeImage.texture = segmentation.texture;
        material.SetTexture("_inputImage", webCamInput.inputImageTexture);
        material.SetInt("_isBackGroundTexture", isBackGroundTexture?1:0);
        material.SetTexture("_backImage", backGroundTexture);
        material.SetVector("_backGroundColor", backGroundColor);
        material.SetFloat("_threshold", threshold);
    } 

    void OnApplicationQuit(){
        segmentation.Dispose();
    }
}
