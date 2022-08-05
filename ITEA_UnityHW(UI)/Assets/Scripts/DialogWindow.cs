using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogWindow : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _ResolutionsDropdown;
    [SerializeField] private TMP_Dropdown _QualityDropdown;
    [SerializeField] private Toggle _FullScreenToggle;
    [SerializeField] private Slider _MasterVolumeSlider;
    [SerializeField] private Slider _MusicVolumeSlider;
    [SerializeField] private Toggle _SoundsInBGToggle;
    [SerializeField] private Toggle _EnableChallengingToggle;
    [SerializeField] private Toggle _AllowFriendsToggle;
    [SerializeField] private Button _CreditButton;
    [SerializeField] private Button _CinematicButton;

    private System.Action _onResolutionsDropdownCallBack;
    private System.Action _onQualityDropdownCallBack;
    private System.Action _onFullScreenToggleCallBack;
    private System.Action _onMasterVolumeCallback;
    private System.Action _onMusicVolumeCallback;
    private System.Action _onSoundsInBGToggleCallBack;
    private System.Action _onEnableChallengingToggleCallBack;
    private System.Action _onAllowFriendsToggleCallBack;
    private System.Action _onCreditCallback;
    private System.Action _onCinematicCallback;

    public void InitializeCallback(System.Action onResolutionsDropdownCallBack, 
        System.Action onQualityDropdownCallBack, System.Action onFullScreenToggleCallBack, 
        System.Action onMasterVolumeCallback, System.Action onMusicVolumeCallback, 
        System.Action onSoundsInBGToggleCallBack, System.Action onEnableChallengingToggleCallBack, 
        System.Action onAllowFriendsToggleCallBack,System.Action onCreditCallback, 
        System.Action onCinematicCallback)
    {
        _onResolutionsDropdownCallBack = onResolutionsDropdownCallBack;
        _onQualityDropdownCallBack = onQualityDropdownCallBack;
        _onFullScreenToggleCallBack = onFullScreenToggleCallBack;
        _onMasterVolumeCallback = onMasterVolumeCallback;
        _onMusicVolumeCallback = onMusicVolumeCallback;
        _onSoundsInBGToggleCallBack = onSoundsInBGToggleCallBack;
        _onEnableChallengingToggleCallBack = onEnableChallengingToggleCallBack;
        _onEnableChallengingToggleCallBack = onAllowFriendsToggleCallBack;
        _onCreditCallback = onCreditCallback;
        _onCinematicCallback = onCinematicCallback;
    }

    void Start()
    {
        _ResolutionsDropdown.onValueChanged.AddListener(delegate { OnResolutionsDropdownClickHandler(); });
        _QualityDropdown.onValueChanged.AddListener(delegate { OnQualityDropdownClickHandler(); });
        _FullScreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggleClickHandler(); });
        _MasterVolumeSlider.onValueChanged.AddListener(delegate { OnMasterVolumeClickHandler(); });
        _MusicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeClickHandler(); });
        _SoundsInBGToggle.onValueChanged.AddListener(delegate { OnSoundsInBGToggleClickHandler(); });
        _EnableChallengingToggle.onValueChanged.AddListener(delegate { OnEnableChallengingToggleClickHandler(); });
        _AllowFriendsToggle.onValueChanged.AddListener(delegate { OnAllowFriendsToggleClickHandler(); });
        _CreditButton.onClick.AddListener(OnCreditButtonClickHandler);
        _CinematicButton.onClick.AddListener(OnCinematicButtonClickHandler);

    }

    private void OnResolutionsDropdownClickHandler()
    {
        Debug.Log($"[OnResolutionsDropdownClickHandler] ResolutionsDropdown " +
            $"{_ResolutionsDropdown.options[_ResolutionsDropdown.value].text}");
        _onResolutionsDropdownCallBack?.Invoke();
    }

    private void OnQualityDropdownClickHandler()
    {
        Debug.Log($"[OnQualityDropdownClickHandler] QualityDropdown " +
            $"{_QualityDropdown.options[_QualityDropdown.value].text}");
        _onQualityDropdownCallBack?.Invoke();
    }

    private void OnFullScreenToggleClickHandler()
    {
        Debug.Log($"[OnFullScreenToggleClickHandler] FullScreen {_FullScreenToggle.isOn}");
        _onFullScreenToggleCallBack?.Invoke();
    }

    private void OnMasterVolumeClickHandler()
    {
        Debug.Log($"[OnMasterVolumeClickHandler] MasterVolume {_MasterVolumeSlider.value}");
        _onMasterVolumeCallback?.Invoke();
    }

    private void OnMusicVolumeClickHandler()
    {
        Debug.Log($"[OnMusicVolumeClickHandler] MasterVolume {_MusicVolumeSlider.value}");
        _onMusicVolumeCallback?.Invoke();
    }

    private void OnSoundsInBGToggleClickHandler()
    {
        Debug.Log($"[OnSoundsInBGToggleClickHandler] FullScreen {_SoundsInBGToggle.isOn}");
        _onSoundsInBGToggleCallBack?.Invoke();
    }

    private void OnEnableChallengingToggleClickHandler()
    {
        Debug.Log($"[OnEnableChallengingToggleClickHandler] EnableChallenging {_EnableChallengingToggle.isOn}");
        _onEnableChallengingToggleCallBack?.Invoke();
    }
    private void OnAllowFriendsToggleClickHandler()
    {
        Debug.Log($"[OnAllowFriendsToggleClickHandler] AllowFriends {_AllowFriendsToggle.isOn}");
        _onAllowFriendsToggleCallBack?.Invoke();
    }

    private void OnCreditButtonClickHandler()
    {
        Debug.Log("[OnCreditButtonClickHandler] Credit");
        _onCreditCallback?.Invoke();
    }

    private void OnCinematicButtonClickHandler()
    {
        Debug.Log("[OnCinematicButtonClickHandler] Cinematic");
        _onCinematicCallback?.Invoke();
    }
}
