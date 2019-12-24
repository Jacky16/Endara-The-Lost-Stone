// GENERATED AUTOMATICALLY FROM 'Assets/Inputs Player/PlayerGamepadInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerGamepadInputs : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @PlayerGamepadInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerGamepadInputs"",
    ""maps"": [
        {
            ""name"": ""Gamplay"",
            ""id"": ""e4580587-6727-4d84-b04e-df87282912db"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""94cce2b3-b46d-4e78-8886-f0d889733c43"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""ffe72b99-7cae-48cc-9d0d-0e062624f55f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e435c134-9f15-4f76-ac05-9a130d4d6c68"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a0ffefb-25b3-4b31-94bb-6a041cb694f4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gamplay
        m_Gamplay = asset.FindActionMap("Gamplay", throwIfNotFound: true);
        m_Gamplay_Jump = m_Gamplay.FindAction("Jump", throwIfNotFound: true);
        m_Gamplay_Movement = m_Gamplay.FindAction("Movement", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gamplay
    private readonly InputActionMap m_Gamplay;
    private IGamplayActions m_GamplayActionsCallbackInterface;
    private readonly InputAction m_Gamplay_Jump;
    private readonly InputAction m_Gamplay_Movement;
    public struct GamplayActions
    {
        private @PlayerGamepadInputs m_Wrapper;
        public GamplayActions(@PlayerGamepadInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gamplay_Jump;
        public InputAction @Movement => m_Wrapper.m_Gamplay_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Gamplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamplayActions set) { return set.Get(); }
        public void SetCallbacks(IGamplayActions instance)
        {
            if (m_Wrapper.m_GamplayActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GamplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamplayActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_GamplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GamplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GamplayActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_GamplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public GamplayActions @Gamplay => new GamplayActions(this);
    public interface IGamplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
}
