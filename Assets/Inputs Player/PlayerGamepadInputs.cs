// GENERATED AUTOMATICALLY FROM 'Assets/Inputs Player/PlayerGamepadInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerGamepadInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
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
                },
                {
                    ""name"": ""Catch Object"",
                    ""type"": ""Button"",
                    ""id"": ""c7c3297a-fbe2-4ea3-b753-46a98bcdd4f2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d1ce0838-4af2-4f1d-be8e-1de2e3a8749c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrowObject"",
                    ""type"": ""Button"",
                    ""id"": ""f9b8bcbe-b6b6-4fe6-a11e-5ceee6a37512"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""fe567242-effb-42be-ad9c-ea97a0622e4f"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""c6992a9d-a549-481f-812d-b0d74045f542"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Catch Object"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19cc08c9-f94c-447d-a8e1-0d17f52b701e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89426743-2527-4dba-8a46-01341ca88ac6"",
                    ""path"": ""<Mouse>/clickCount"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrowObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea415ee7-140c-4735-b316-40a8179ae89a"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
                },
                {
                    ""name"": ""CatchObject"",
                    ""type"": ""Button"",
                    ""id"": ""fd6865e5-8797-49ed-b4ed-97fe641f047a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ThrowObject"",
                    ""type"": ""Button"",
                    ""id"": ""5d359124-116d-44dc-84a8-d7ab9054639b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a3a0f1d1-ea38-4afd-b24f-6d39a3df409f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
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
                },
                {
                    ""name"": """",
                    ""id"": ""05b3e80d-feba-41de-a244-3f77325e81a6"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""CatchObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbfe6761-a658-4d54-a58b-d3cdf0443684"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06ab5507-affd-4531-a23a-e3cd19189f7b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
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
        m_Player_Keyboard_CatchObject = m_Player_Keyboard.FindAction("Catch Object", throwIfNotFound: true);
        m_Player_Keyboard_Jump = m_Player_Keyboard.FindAction("Jump", throwIfNotFound: true);
        m_Player_Keyboard_TrowObject = m_Player_Keyboard.FindAction("TrowObject", throwIfNotFound: true);
        m_Player_Keyboard_Aim = m_Player_Keyboard.FindAction("Aim", throwIfNotFound: true);
        // Player_GamepadXbox
        m_Player_GamepadXbox = asset.FindActionMap("Player_GamepadXbox", throwIfNotFound: true);
        m_Player_GamepadXbox_Movement = m_Player_GamepadXbox.FindAction("Movement", throwIfNotFound: true);
        m_Player_GamepadXbox_CameraMovement = m_Player_GamepadXbox.FindAction("CameraMovement", throwIfNotFound: true);
        m_Player_GamepadXbox_CatchObject = m_Player_GamepadXbox.FindAction("CatchObject", throwIfNotFound: true);
        m_Player_GamepadXbox_ThrowObject = m_Player_GamepadXbox.FindAction("ThrowObject", throwIfNotFound: true);
        m_Player_GamepadXbox_Jump = m_Player_GamepadXbox.FindAction("Jump", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Keyboard_CatchObject;
    private readonly InputAction m_Player_Keyboard_Jump;
    private readonly InputAction m_Player_Keyboard_TrowObject;
    private readonly InputAction m_Player_Keyboard_Aim;
    public struct Player_KeyboardActions
    {
        private @PlayerGamepadInputs m_Wrapper;
        public Player_KeyboardActions(@PlayerGamepadInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Keyboard_Movement;
        public InputAction @CatchObject => m_Wrapper.m_Player_Keyboard_CatchObject;
        public InputAction @Jump => m_Wrapper.m_Player_Keyboard_Jump;
        public InputAction @TrowObject => m_Wrapper.m_Player_Keyboard_TrowObject;
        public InputAction @Aim => m_Wrapper.m_Player_Keyboard_Aim;
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
                @CatchObject.started -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnCatchObject;
                @CatchObject.performed -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnCatchObject;
                @CatchObject.canceled -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnCatchObject;
                @Jump.started -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnJump;
                @TrowObject.started -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnTrowObject;
                @TrowObject.performed -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnTrowObject;
                @TrowObject.canceled -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnTrowObject;
                @Aim.started -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_Player_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @CatchObject.started += instance.OnCatchObject;
                @CatchObject.performed += instance.OnCatchObject;
                @CatchObject.canceled += instance.OnCatchObject;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @TrowObject.started += instance.OnTrowObject;
                @TrowObject.performed += instance.OnTrowObject;
                @TrowObject.canceled += instance.OnTrowObject;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public Player_KeyboardActions @Player_Keyboard => new Player_KeyboardActions(this);

    // Player_GamepadXbox
    private readonly InputActionMap m_Player_GamepadXbox;
    private IPlayer_GamepadXboxActions m_Player_GamepadXboxActionsCallbackInterface;
    private readonly InputAction m_Player_GamepadXbox_Movement;
    private readonly InputAction m_Player_GamepadXbox_CameraMovement;
    private readonly InputAction m_Player_GamepadXbox_CatchObject;
    private readonly InputAction m_Player_GamepadXbox_ThrowObject;
    private readonly InputAction m_Player_GamepadXbox_Jump;
    public struct Player_GamepadXboxActions
    {
        private @PlayerGamepadInputs m_Wrapper;
        public Player_GamepadXboxActions(@PlayerGamepadInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_GamepadXbox_Movement;
        public InputAction @CameraMovement => m_Wrapper.m_Player_GamepadXbox_CameraMovement;
        public InputAction @CatchObject => m_Wrapper.m_Player_GamepadXbox_CatchObject;
        public InputAction @ThrowObject => m_Wrapper.m_Player_GamepadXbox_ThrowObject;
        public InputAction @Jump => m_Wrapper.m_Player_GamepadXbox_Jump;
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
                @CatchObject.started -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnCatchObject;
                @CatchObject.performed -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnCatchObject;
                @CatchObject.canceled -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnCatchObject;
                @ThrowObject.started -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnThrowObject;
                @ThrowObject.performed -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnThrowObject;
                @ThrowObject.canceled -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnThrowObject;
                @Jump.started -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnJump;
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
                @CatchObject.started += instance.OnCatchObject;
                @CatchObject.performed += instance.OnCatchObject;
                @CatchObject.canceled += instance.OnCatchObject;
                @ThrowObject.started += instance.OnThrowObject;
                @ThrowObject.performed += instance.OnThrowObject;
                @ThrowObject.canceled += instance.OnThrowObject;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
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
        void OnCatchObject(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnTrowObject(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
    public interface IPlayer_GamepadXboxActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
        void OnCatchObject(InputAction.CallbackContext context);
        void OnThrowObject(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
