using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class TextSpawnForFinal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private string[] _sentences;
    

    private int _index;
    private float _dialogueSpeed = 0.05f;
    private bool _isTyping = false;

    private void Start()
    {
        NextSentence();
    }
    

    void NextSentence()
    {
        if (_index <= _sentences.Length - 1)
        {
            if (!_isTyping)
            {
                _dialogueText.text = "";
                _isTyping = true;
                StartCoroutine(WriteSentence());
            }
        }
    }

    IEnumerator WriteSentence()
    {
        foreach (char character in _sentences[_index].ToCharArray())
        {
            _dialogueText.text += character;
            yield return new WaitForSeconds(_dialogueSpeed);
        }
        _index++;
        _isTyping = false;
    }
    
}
