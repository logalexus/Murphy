using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Sound", order = 1)]
public class Sounds : ScriptableObject
{
    [SerializeField] private AudioClip _mainTheme;
    [SerializeField] private AudioClip _dog;
    [SerializeField] private AudioClip _explosion;
    [SerializeField] private AudioClip _click;


    public AudioClip MainTheme => _mainTheme;
    public AudioClip Dog => _dog;

}
