using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mediapipe.SelfieSegmentation;

public class VisualizeCtrlUI : MonoBehaviour
{
    public bool isBackGroundTexture = false;
    public Texture backGroundTexture;
    public Color backGroundColor = Color.green;
    [Range(0, 1)] public float threshold = 0.95f;


    void Start(){
        
    }

    void Update(){
        
    } 
}
