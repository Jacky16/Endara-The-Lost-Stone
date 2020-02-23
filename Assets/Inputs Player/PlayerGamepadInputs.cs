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
                    ""interactions"": ""Press""
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
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Button"",
                    ""id"": ""f9af53d7-376b-4e88-a8f5-75e9e0d92fed"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""7ddda294-3f27-4556-b0c7-b5a555b10279"",
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
                    ""interactions"": ""Tap"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""01722395-6935-4c79-a8bf-997d07e6b30c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press(pressPoint=0.5)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""037ef079-320c-439d-9546-6d02d12b9e14"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
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
                    ""name"": ""LeftJostyck"",
                    ""type"": ""Value"",
                    ""id"": ""30d60f97-bb3c-4ebb-8605-9fba17631b0b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightJostyck"",
                    ""type"": ""Value"",
                    ""id"": ""dace94d2-0304-4bc6-86ec-c3aae8d47ffc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""fd6865e5-8797-49ed-b4ed-97fe641f047a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RT"",
                    ""type"": ""Button"",
                    ""id"": ""5d359124-116d-44dc-84a8-d7ab9054639b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""a3a0f1d1-ea38-4afd-b24f-6d39a3df409f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""RE"",
                    ""type"": ""Button"",
                    ""id"": ""3a2d1a27-4410-4216-93d0-069618aae35c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""LB"",
                    ""type"": ""Button"",
                    ""id"": ""cca3d4f8-8635-4020-8afc-10a2eb982ebe"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""07e0def7-d11f-4ffd-8a0a-6cff6d3f9b25"",
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
                    ""action"": ""LeftJostyck"",
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
                    ""action"": ""RightJostyck"",
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
                    ""action"": ""X"",
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
                    ""action"": ""RT"",
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
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""916ff0ec-dd27-4672-90d0-4aefe05fd432"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f48e1112-4033-41bf-b751-e6f0ba44ef48"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df02995f-1756-4563-b7bb-4f484f143101"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""B"",
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
        m_Player_Keyboard_Rotation = m_Player_Keyboard.FindAction("Rotation", throwIfNotFound: true);
        m_Player_Keyboard_Attack = m_Player_Keyboard.FindAction("Attack", throwIfNotFound: true);
        // Player_GamepadXbox
        m_Player_GamepadXbox = asset.FindActionMap("Player_GamepadXbox", throwIfNotFound: true);
        m_Player_GamepadXbox_LeftJostyck = m_Player_GamepadXbox.FindAction("LeftJostyck", throwIfNotFound: true);
        m_Player_GamepadXbox_RightJostyck = m_Player_GamepadXbox.FindAction("RightJostyck", throwIfNotFound: true);
        m_Player_GamepadXbox_X = m_Player_GamepadXbox.FindAction("X", throwIfNotFound: true);
        m_Player_GamepadXbox_RT = m_Player_GamepadXbox.FindAction("RT", throwIfNotFound: true);
        m_Player_GamepadXbox_A = m_Player_GamepadXbox.FindAction("A", throwIfNotFound: true);
        m_Player_GamepadXbox_RE = m_Player_GamepadXbox.FindAction("RE", throwIfNotFound: true);
        m_Player_GamepadXbox_LB = m_Player_GamepadXbox.FindAction("LB", throwIfNotFound: true);
        m_Player_GamepadXbox_B = m_Player_GamepadXbox.FindAction("B", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Keyboard_Rotation;
    private readonly InputAction m_Player_Keyboard_Attack;
    public struct Player_KeyboardActions
    {
        private @PlayerGamepadInputs m_Wrapper;
        public Player_KeyboardActions(@PlayerGamepadInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Keyboard_Movement;
        public InputAction @CatchObject => m_Wrapper.m_Player_Keyboard_CatchObject;
        public InputAction @Jump => m_Wrapper.m_Player_Keyboard_Jump;
        public InputAction @TrowObject => m_Wrapper.m_Player_Keyboard_TrowObject;
        public InputAction @Aim => m_Wrapper.m_Player_Keyboard_Aim;
        public InputAction @Rotation => m_Wrapper.m_Player_Keyboard_Rotation;
        public InputAction @Attack => m_Wrapper.m_Player_Keyboard_Attack;
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
                @Rotation.started -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnRotation;
                @Attack.started -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_Player_KeyboardActionsCallbackInterface.OnAttack;
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
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public Player_KeyboardActions @Player_Keyboard => new Player_KeyboardActions(this);

    // Player_GamepadXbox
    private readonly InputActionMap m_Player_GamepadXbox;
    private IPlayer_GamepadXboxActions m_Player_GamepadXboxActionsCallbackInterface;
    private readonly InputAction m_Player_GamepadXbox_LeftJostyck;
    private readonly InputAction m_Player_GamepadXbox_RightJostyck;
    private readonly InputAction m_Player_GamepadXbox_X;
    private readonly InputAction m_Player_GamepadXbox_RT;
    private readonly InputAction m_Player_GamepadXbox_A;
    private readonly InputAction m_Player_GamepadXbox_RE;
    private readonly InputAction m_Player_GamepadXbox_LB;
    private readonly InputAction m_Player_GamepadXbox_B;
    public struct Player_GamepadXboxActions
    {
        private @PlayerGamepadInputs m_Wrapper;
        public Player_GamepadXboxActions(@PlayerGamepadInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftJostyck => m_Wrapper.m_Player_GamepadXbox_LeftJostyck;
        public InputAction @RightJostyck => m_Wrapper.m_Player_GamepadXbox_RightJostyck;
        public InputAction @X => m_Wrapper.m_Player_GamepadXbox_X;
        public InputAction @RT => m_Wrapper.m_Player_GamepadXbox_RT;
        public InputAction @A => m_Wrapper.m_Player_GamepadXbox_A;
        public InputAction @RE => m_Wrapper.m_Player_GamepadXbox_RE;
        public InputAction @LB => m_Wrapper.m_Player_GamepadXbox_LB;
        public InputAction @B => m_Wrapper.m_Player_GamepadXbox_B;
        public InputActionMap Get() { return m_Wrapper.m_Player_GamepadXbox; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_GamepadXboxActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_GamepadXboxActions instance)
        {
            if (m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface != null)
            {
                @LeftJostyck.started -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnLeftJostyck;
                @LeftJostyck.performed -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnLeftJostyck;
                @LeftJostyck.canceled -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnLeftJostyck;
                @RightJostyck.started -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnRightJostyck;
                @RightJostyck.performed -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnRightJostyck;
                @RightJostyck.canceled -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnRightJostyck;
                @X.started -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnX;
                @RT.started -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnRT;
                @RT.performed -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnRT;
                @RT.canceled -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnRT;
                @A.started -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnA;
                @RE.started -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnRE;
                @RE.performed -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnRE;
                @RE.canceled -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnRE;
                @LB.started -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnLB;
                @LB.performed -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnLB;
                @LB.canceled -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnLB;
                @B.started -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface.OnB;
            }
            m_Wrapper.m_Player_GamepadXboxActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftJostyck.started += instance.OnLeftJostyck;
                @LeftJostyck.performed += instance.OnLeftJostyck;
                @LeftJostyck.canceled += instance.OnLeftJostyck;
                @RightJostyck.started += instance.OnRightJostyck;
                @RightJostyck.performed += instance.OnRightJostyck;
                @RightJostyck.canceled += instance.OnRightJostyck;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @RT.started += instance.OnRT;
                @RT.performed += instance.OnRT;
                @RT.canceled += instance.OnRT;
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @RE.started += instance.OnRE;
                @RE.performed += instance.OnRE;
                @RE.canceled += instance.OnRE;
                @LB.started += instance.OnLB;
                @LB.performed += instance.OnLB;
                @LB.canceled += instance.OnLB;
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
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
        void OnRotation(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
    public interface IPlayer_GamepadXboxActions
    {
        void OnLeftJostyck(InputAction.CallbackContext context);
        void OnRightJostyck(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnRT(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnRE(InputAction.CallbackContext context);
        void OnLB(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
    }
}
