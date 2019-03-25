using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ButtonData", menuName = "Button")]
public class ButtonData : ScriptableObject
{
    [Header("Button Image")]
    public Texture2D ButtonImage;
    [Header("Button Audio Clips")]
    public AudioClip[] ButtonAudioClips;
    public enum buttonType { Basic, Premium }
    [Header("Button Type")]
    public buttonType ButtonType;
}
