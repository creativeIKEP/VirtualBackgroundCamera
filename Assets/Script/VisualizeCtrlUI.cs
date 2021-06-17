using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizeCtrlUI : MonoBehaviour
{
    [SerializeField] Texture defaultBackTexture;
    [SerializeField] Dropdown backTextureSelect;
    [SerializeField] Slider thresholdSlider;
    [SerializeField] Text thresholdValueText;


    [System.NonSerialized] public Texture backGroundTexture;
    [System.NonSerialized] public float threshold = 0.95f;
    
    readonly string loadedImagePath = "/LoadedImages";

    void Start(){
        backGroundTexture = defaultBackTexture;
        threshold = thresholdSlider.value;
        thresholdValueText.text = threshold.ToString("F2");
        CreateImageOptions();
    }

    void CreateImageOptions(){
        if(!Directory.Exists(Application.dataPath + loadedImagePath)){
            Directory.CreateDirectory(Application.dataPath + loadedImagePath);
        }
        var imagePathes = Directory.GetFiles(Application.dataPath + loadedImagePath, "*.png");
        
        var backTextureSelectOptions = new List<string>();
        backTextureSelectOptions.Add(defaultBackTexture.name);
        foreach(var path in imagePathes){
            backTextureSelectOptions.Add(Path.GetFileName(path));
        }
        backTextureSelect.ClearOptions();
        backTextureSelect.AddOptions(backTextureSelectOptions);
    }

    public void ChangeBackTexture(){
        var filename = backTextureSelect.options[backTextureSelect.value].text;
        if(filename == defaultBackTexture.name){
            backGroundTexture = defaultBackTexture;
            return;
        }

        byte[] bytes = File.ReadAllBytes(Application.dataPath + loadedImagePath + "/" + filename);
        Texture2D texture = new Texture2D(1, 1);
        bool isLoadSuccess = texture.LoadImage(bytes);
        if(!isLoadSuccess) return;

        backGroundTexture = texture;
    }

    public void NewImageLoad(){
        string path = OpenFileName.ShowDialog();
        byte[] bytes = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(1, 1);
        bool isLoadSuccess = texture.LoadImage(bytes);
        var extension = Path.GetExtension(path).ToLower();
        bool isImageFile = (extension == ".png" || extension == ".jpg" || extension == ".jpeg");
        if(!isLoadSuccess || !isImageFile) return;

        backGroundTexture = texture;

        var filename = Path.GetFileNameWithoutExtension(path) + ".png";
        var savePath = Application.dataPath + loadedImagePath + "/" + filename;
        File.WriteAllBytes(savePath, texture.EncodeToPNG());

        var option = new Dropdown.OptionData();
        option.text = filename;
        backTextureSelect.options.Add(option);
        backTextureSelect.value = backTextureSelect.options.Count - 1;
    }

    public void ThresholdChanged(){
        threshold = thresholdSlider.value;
        thresholdValueText.text = thresholdSlider.value.ToString("F2");
    }
}
