using UnityEngine;
using UnityEngine.UI;
using Mediapipe.SelfieSegmentation;

public class VirtualBackgroundVisuallizer : MonoBehaviour
{
    [SerializeField] WebCamInput webCamInput;
    [SerializeField] RawImage compositeImage;
    [SerializeField] SelfieSegmentationResource resource;
    [SerializeField] Shader shader;
    [SerializeField] Texture backGroundTexture;
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
        material.SetTexture("_backImage", backGroundTexture);
        material.SetFloat("_threshold", threshold);
    } 

    void OnApplicationQuit(){
        segmentation.Dispose();
    }
}
