using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizeCtrlUI : MonoBehaviour
{
    [SerializeField] Texture defaultBackTexture;
    [SerializeField] Dropdown backTextureSelect;
    [SerializeField] Toggle mirrorModeToggle;
    [SerializeField] Toggle unityCaptureToggle;
    [SerializeField] Toggle spoutToggle;


    [System.NonSerialized] public Texture backGroundTexture;
    
    readonly string loadedImagePath = "/LoadedImages";
    readonly string backOffName = "None";

    void Start(){
        backGroundTexture = defaultBackTexture;
        
        CreateImageOptions();
        UnityCaptureSwitched();
    }

    void CreateImageOptions(){
        if(!Directory.Exists(Application.dataPath + loadedImagePath)){
            Directory.CreateDirectory(Application.dataPath + loadedImagePath);
        }
        var imagePathes = Directory.GetFiles(Application.dataPath + loadedImagePath, "*.png");
        
        var backTextureSelectOptions = new List<string>();
        backTextureSelectOptions.Add(defaultBackTexture.name);
        backTextureSelectOptions.Add(backOffName);
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

        if(filename == backOffName){
            backGroundTexture = null;
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

    public void MirrorModeSwitched(){
        var unityCapture = Camera.main.GetComponent<UnityCapture>();
        unityCapture.MirrorMode = mirrorModeToggle.isOn ? UnityCapture.EMirrorMode.MirrorHorizontally : UnityCapture.EMirrorMode.Disabled;
    }

    public void UnityCaptureSwitched(){
        var unityCapture = Camera.main.GetComponent<UnityCapture>();
        unityCapture.enabled = unityCaptureToggle.isOn;
    }
}
