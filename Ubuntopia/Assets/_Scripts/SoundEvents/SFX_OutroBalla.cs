using System;
using UnityEngine;

public class SFX_OutroBalla : MonoBehaviour {
    private string name = "SFX_OutroBalla_";
    
    // References.
    private AudioManager _audioManager = AudioManager.instance;

    private void PlaySFX() {
        string newName = name;
        
        // Get language from audio manager.
        Enum language = _audioManager.GetLanguage();
        
        // Switch.
        switch (language) {
            case language.English:
                newName += "ENG";
                break;
            case language.Dutch:
                newName += "DUT";
                break;
        }

        // What is new name?
        print(newName);
        
        // Play sfx.
        _audioManager.Play(newName);
    }
}
