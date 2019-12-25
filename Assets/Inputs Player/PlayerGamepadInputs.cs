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
            ""name"": ""Player_Keyboard"",
            ""id"": ""e4580587-6727-4d84-b04e-df87282912db"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""ffe72b99-7cae-48cc-9d0d-0e062624f55f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""39120b5d-0db7-47dc-82d4-36b164818ba8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dc111d3d-6945-4d69-ae74-b9673c78b9fc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bc7d6b6d-f168-4105-b6b4-a5fdd3f5d133"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""15ef4a36-ee75-4621-94e2-e2d38af7ee72"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""84c77a64-37eb-49cb-91b5-33c353354ec9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Player_GamepadXbox"",
            ""id"": ""84fd66fd-2008-4a5c-9adf-dd884a6679ea"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""30d60f97-bb3c-4ebb-8605-9fba17631b0b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""Value"",
                    ""id"": ""dace94d2-0304-4bc6-86ec-c3aae8d47ffc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""40e013eb-1278-4ff9-9289-1a58e676404d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11a4b08e-b8e2-4a09-af2f-bb034fd2d266"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": ""New control scheme"",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player_Keyboard
        m_Player_Keyboard = asset.FindActionMap("Player_Keyboard", throwIfNotFound: true);
        m_Player_Keyboard_Movement = m_Player_Keyboard.FindAction("Movement", throwIfNotFound: true);
        // Player_GamepadXbox
        m_Player_GamepadXbox = asset.FindActionMap("Player_GamepadXbox", throwIfNotFound: true);
        m_Player_GamepadXbox_Movement = m_Player_GamepadXbox.FindAction("Movement", throwIfNotFound: true);
        m_Player_GamepadXbox_CameraMovement = m_Player_GamepadXbox.FindAction("CameraMovement", throwIfNotFound: true);
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

    // Player_Keyboard
    private readonly InputActionMap m_Player_Keyboard;
    private IPlayer_KeyboardActions m_Player_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Player_Keyboard_Movement;
    public struct Player_KeyboardActions
    {
        private @PlayerGamepadInputs m_Wrapper;
        public Player_KeyboardActions(@PlayerGamepadInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Keyboard_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Player_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_KeyboardActions instance)
        {
            if (m_Wrapper.m_Player_KeyboardActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_Player_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public Player_KeyboardActions @Player_Keyboard => new Player_KeyboardActions(this);

    // Player_GamepadXbox
    private readonly InputActionMap m_Player_GamepadXbox;
    private IPlayer_GamepadXboxActions m_Player_GamepadXboxActionsCallbackInterface;
    private readonly InputAction m_Player_GamepadXbox_Movement;
    private readonly InputAction m_Player_GamepadXbox_CameraMovement;
    public struct Player_GamepadXboxActions
    {
        private @PlayerGamepadInputs m_Wrapper;
        public Player_GamepadXboxActions(@PlayerGamepadInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_GamepadXbox_Movement;
        public InputAction @CameraMovement => m_Wrapper.m_Player_GamepadXbox_CameraMovement;
        public InputActionMap Get() { return m_Wrapper.m_Player_GamepadXbox; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_GamepadXboxActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_GamepadXboxActions instance)
        {
            if (m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnMovement;
                @CameraMovement.started -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.performed -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.canceled -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnCameraMovement;
            }
            m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @CameraMovement.started += instance.OnCameraMovement;
                @CameraMovement.performed += instance.OnCameraMovement;
                @CameraMovement.canceled += instance.OnCameraMovement;
            }
        }
    }
    public Player_GamepadXboxActions @Player_GamepadXbox => new Player_GamepadXboxActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface IPlayer_KeyboardActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IPlayer_GamepadXboxActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
    }
}
