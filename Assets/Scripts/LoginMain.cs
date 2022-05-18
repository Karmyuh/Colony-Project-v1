using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;


public class LoginMain : MonoBehaviour
{
    
    [SerializeField] InputField _emailRegister, _passwordRegister, _usernameRegister, _repeatPasswordRegister;
    [SerializeField] InputField _passwordLogin, _usernameAndEmailLogin;
    [SerializeField] Text _resultText;
    [SerializeField] Button _loginButton, _registerButton;
    [Header("Guest Login Settings")]
    [SerializeField] bool _guestLoginActive;
    [SerializeField] GameObject _registerPanel, _loginPanel;
    [SerializeField] Animator _animator;



    private void Start()
    {
        SwitchLoginOrRegister();
    }


    void LoginEmail()
    {
        //PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest() {Email=_usernameAndEmailLogin.text,Password=_passwordLogin.text },
        //    Result => { Debug.Log("Giris Basarili"); },
        //    Error => { Debug.Log("Giris Basarisiz!"); });

        Debug.Log("aaaaa");
    }
    public void LoginUsername()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest() { Username = _usernameAndEmailLogin.text, Password = _passwordLogin.text },
          Result => 
          {
              _animator.Play("Success");
              Debug.Log("Giris Basarili"); 
          
          },
          Error => 
          {
              _animator.Play("Fail");

          });
    }

    public void SwitchLoginType()
    {
        if (_usernameAndEmailLogin.text.IndexOf('@')>0)
        
            LoginEmail();
        
        else
        
            LoginUsername();
        
    }

    public void RegisterOnClick()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest() { Username = _usernameRegister.text,Email=_emailRegister.text, Password = _passwordRegister.text },
         Result => { _animator.Play("Success"); },
         Error => { _animator.Play("Fail"); });
    }

   public void RememberMe()
    {
        
    }

    public void PlayGuest()
    {
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest() {CreateAccount= _guestLoginActive, AndroidDeviceId= SystemInfo.deviceUniqueIdentifier },
            Result => { _animator.Play("Success"); },
         Error => { _animator.Play("Fail"); 
    });
    }

    public void SwitchLoginOrRegister()
    {

        switch (_registerPanel.activeInHierarchy)
        {
            case true:
                _loginPanel.SetActive(true);
                _registerPanel.SetActive(false);
                break;

            default:
                _loginPanel.SetActive(false);
                _registerPanel.SetActive(true);
                break;
        }




    }







}
