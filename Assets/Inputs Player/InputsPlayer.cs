// GENERATED AUTOMATICALLY FROM 'Assets/Inputs Player/InputsPlayer.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputsPlayer : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputsPlayer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputsPlayer"",
    ""maps"": [
        {
            ""name"": ""PlayerInputs"",
            ""id"": ""a6ba3404-f012-4bda-8c35-13c30322d1cf"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""5f99b9c4-5446-404c-a98f-a55f8ba899b5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""19502128-2746-4414-91c7-579919f8f028"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.001)""
                },
                {
                    ""name"": ""ThrowObject"",
                    ""type"": ""Button"",
                    ""id"": ""fac6d349-c336-41fa-8817-f9a440eb5686"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CatchObject"",
                    ""type"": ""Button"",
                    ""id"": ""edfc5c6a-fedd-4b7b-b6f6-e251f4f036b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotationObject_L"",
                    ""type"": ""Button"",
                    ""id"": ""425e9e4c-b750-468e-a849-b6cb95a67102"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""RotationObject_R"",
                    ""type"": ""Button"",
                    ""id"": ""08cd62a5-4e14-4109-b040-5ea8bdcf3ec3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""52be8462-97e2-4051-bf40-4fee0f95a8c6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""MovementCamera"",
                    ""type"": ""Value"",
                    ""id"": ""e33c4fb5-e5dd-4bc6-aa94-92eb03345af2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2,StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""625a9260-2378-4450-a9f2-adcd6c1f8051"",
                    ""expectedControlType"": """",
                    ""processors"": ""NormalizeVector2,StickDeadzone"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""87e76f3e-935b-484b-8199-ebbeecaa1adb"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2f08a9b-431c-42f0-bf94-09876a33d824"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""9f52b5fb-a21e-4134-a466-6a2233398cda"",
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
                    ""id"": ""f6528e2b-7724-4416-a103-47f26e952abb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f4d9c8c7-63ff-41d0-875a-e2c3512078a6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c773e144-ebcd-4b61-9d43-39c3e78a6450"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""65d375c0-c17f-4077-ae33-92c1c63935c1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""85335682-80ec-4f48-b2f7-bdccec2bdd68"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df542030-2ece-42e3-a0b0-eb6f35c275f1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c96b937-cb9a-47bd-bb78-3615626e844c"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9904412-a1fb-469d-94a7-36a305ff42ec"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""ThrowObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81a2aeca-7aa5-41ca-9efe-0ca79e1864e1"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""ThrowObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbc7bb94-e685-4587-9a21-dda44f1a9a67"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""ThrowObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d432e041-8285-45d3-b719-2f22d86b2a22"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""CatchObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bd23f8b-1668-4c70-b08a-961fa710a0a8"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""CatchObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5eaf761-398f-496c-8ec6-42844f7d11d0"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""CatchObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a503af34-eccd-440a-9a22-1e30297544bd"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""RotationObject_L"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""edfb982e-eac2-4f36-af37-0d103ea30f32"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""RotationObject_L"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2959a42-b0f4-4fa7-8601-4bfd118cd57e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""RotationObject_L"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2ce479e-ef7c-4bff-b873-0d32b29f6efb"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""RotationObject_R"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60f43c41-1750-4c6b-91db-654de6bd4807"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""RotationObject_R"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ea67e24-5f47-49f8-9d3f-a627d2d51dd6"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""RotationObject_R"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c9c4b28-9878-4f2f-9243-014763dfe592"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""324cdb94-9210-4f56-8bc8-272b695c6696"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca156f07-bcdb-4a17-94f8-746ee96aed3f"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f02c6bb-1bc6-41b5-85cd-5c0de3cf8276"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""MovementCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f96e14d0-592a-4309-9df2-08aaac76f030"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""MovementCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb99160b-9ce2-4495-8212-253e08658caf"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""MovementCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b323e1c-0afb-4203-ab01-82a11b3372d0"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7bb15c5-b88c-4fec-b922-baa45c178fd9"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79046fd5-9bec-486e-a527-27afa66ef494"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""864a1579-66af-487f-a439-eae0a976b137"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Xbox"",
            ""bindingGroup"": ""Xbox"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""PS4"",
            ""bindingGroup"": ""PS4"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerInputs
        m_PlayerInputs = asset.FindActionMap("PlayerInputs", throwIfNotFound: true);
        m_PlayerInputs_Movement = m_PlayerInputs.FindAction("Movement", throwIfNotFound: true);
        m_PlayerInputs_Jump = m_PlayerInputs.FindAction("Jump", throwIfNotFound: true);
        m_PlayerInputs_ThrowObject = m_PlayerInputs.FindAction("ThrowObject", throwIfNotFound: true);
        m_PlayerInputs_CatchObject = m_PlayerInputs.FindAction("CatchObject", throwIfNotFound: true);
        m_PlayerInputs_RotationObject_L = m_PlayerInputs.FindAction("RotationObject_L", throwIfNotFound: true);
        m_PlayerInputs_RotationObject_R = m_PlayerInputs.FindAction("RotationObject_R", throwIfNotFound: true);
        m_PlayerInputs_Attack = m_PlayerInputs.FindAction("Attack", throwIfNotFound: true);
        m_PlayerInputs_MovementCamera = m_PlayerInputs.FindAction("MovementCamera", throwIfNotFound: true);
        m_PlayerInputs_Pause = m_PlayerInputs.FindAction("Pause", throwIfNotFound: true);
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

    // PlayerInputs
    private readonly InputActionMap m_PlayerInputs;
    private IPlayerInputsActions m_PlayerInputsActionsCallbackInterface;
    private readonly InputAction m_PlayerInputs_Movement;
    private readonly InputAction m_PlayerInputs_Jump;
    private readonly InputAction m_PlayerInputs_ThrowObject;
    private readonly InputAction m_PlayerInputs_CatchObject;
    private readonly InputAction m_PlayerInputs_RotationObject_L;
    private readonly InputAction m_PlayerInputs_RotationObject_R;
    private readonly InputAction m_PlayerInputs_Attack;
    private readonly InputAction m_PlayerInputs_MovementCamera;
    private readonly InputAction m_PlayerInputs_Pause;
    public struct PlayerInputsActions
    {
        private @InputsPlayer m_Wrapper;
        public PlayerInputsActions(@InputsPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerInputs_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerInputs_Jump;
        public InputAction @ThrowObject => m_Wrapper.m_PlayerInputs_ThrowObject;
        public InputAction @CatchObject => m_Wrapper.m_PlayerInputs_CatchObject;
        public InputAction @RotationObject_L => m_Wrapper.m_PlayerInputs_RotationObject_L;
        public InputAction @RotationObject_R => m_Wrapper.m_PlayerInputs_RotationObject_R;
        public InputAction @Attack => m_Wrapper.m_PlayerInputs_Attack;
        public InputAction @MovementCamera => m_Wrapper.m_PlayerInputs_MovementCamera;
        public InputAction @Pause => m_Wrapper.m_PlayerInputs_Pause;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInputsActions instance)
        {
            if (m_Wrapper.m_PlayerInputsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnJump;
                @ThrowObject.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnThrowObject;
                @ThrowObject.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnThrowObject;
                @ThrowObject.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnThrowObject;
                @CatchObject.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnCatchObject;
                @CatchObject.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnCatchObject;
                @CatchObject.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnCatchObject;
                @RotationObject_L.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnRotationObject_L;
                @RotationObject_L.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnRotationObject_L;
                @RotationObject_L.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnRotationObject_L;
                @RotationObject_R.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnRotationObject_R;
                @RotationObject_R.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnRotationObject_R;
                @RotationObject_R.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnRotationObject_R;
                @Attack.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnAttack;
                @MovementCamera.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMovementCamera;
                @MovementCamera.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMovementCamera;
                @MovementCamera.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMovementCamera;
                @Pause.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerInputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ThrowObject.started += instance.OnThrowObject;
                @ThrowObject.performed += instance.OnThrowObject;
                @ThrowObject.canceled += instance.OnThrowObject;
                @CatchObject.started += instance.OnCatchObject;
                @CatchObject.performed += instance.OnCatchObject;
                @CatchObject.canceled += instance.OnCatchObject;
                @RotationObject_L.started += instance.OnRotationObject_L;
                @RotationObject_L.performed += instance.OnRotationObject_L;
                @RotationObject_L.canceled += instance.OnRotationObject_L;
                @RotationObject_R.started += instance.OnRotationObject_R;
                @RotationObject_R.performed += instance.OnRotationObject_R;
                @RotationObject_R.canceled += instance.OnRotationObject_R;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @MovementCamera.started += instance.OnMovementCamera;
                @MovementCamera.performed += instance.OnMovementCamera;
                @MovementCamera.canceled += instance.OnMovementCamera;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerInputsActions @PlayerInputs => new PlayerInputsActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_XboxSchemeIndex = -1;
    public InputControlScheme XboxScheme
    {
        get
        {
            if (m_XboxSchemeIndex == -1) m_XboxSchemeIndex = asset.FindControlSchemeIndex("Xbox");
            return asset.controlSchemes[m_XboxSchemeIndex];
        }
    }
    private int m_PS4SchemeIndex = -1;
    public InputControlScheme PS4Scheme
    {
        get
        {
            if (m_PS4SchemeIndex == -1) m_PS4SchemeIndex = asset.FindControlSchemeIndex("PS4");
            return asset.controlSchemes[m_PS4SchemeIndex];
        }
    }
    public interface IPlayerInputsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnThrowObject(InputAction.CallbackContext context);
        void OnCatchObject(InputAction.CallbackContext context);
        void OnRotationObject_L(InputAction.CallbackContext context);
        void OnRotationObject_R(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnMovementCamera(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
