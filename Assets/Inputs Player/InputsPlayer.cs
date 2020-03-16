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
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
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
                    ""interactions"": """",
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
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""af5d0f16-9e08-40af-804e-8edc58930085"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d0ec9454-b9ec-4768-9a01-4553615c5c81"",
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
                    ""id"": ""ad1a376e-b9ec-4d51-8c21-85d9e4fc907a"",
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
                    ""id"": ""2267cd2b-08b7-4641-8736-636c6deca6cb"",
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
                    ""id"": ""1e1473bb-c3c3-4523-86f7-5c25a8609629"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""09cfa700-1039-47d8-8fda-a9856a4d3cad"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""LeftJostyck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8740359c-834b-4b1f-989f-5ee3a475eadf"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightJostyck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerInputs"",
            ""id"": ""a6ba3404-f012-4bda-8c35-13c30322d1cf"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5f99b9c4-5446-404c-a98f-a55f8ba899b5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""19502128-2746-4414-91c7-579919f8f028"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ThrowObject"",
                    ""type"": ""Button"",
                    ""id"": ""fac6d349-c336-41fa-8817-f9a440eb5686"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CatchObject"",
                    ""type"": ""Button"",
                    ""id"": ""edfc5c6a-fedd-4b7b-b6f6-e251f4f036b2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotationObject_L"",
                    ""type"": ""Button"",
                    ""id"": ""425e9e4c-b750-468e-a849-b6cb95a67102"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
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
                    ""interactions"": """"
                },
                {
                    ""name"": ""MovementCamera"",
                    ""type"": ""Value"",
                    ""id"": ""e33c4fb5-e5dd-4bc6-aa94-92eb03345af2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
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
                    ""name"": ""2D Vector"",
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
                    ""id"": ""a2ce479e-ef7c-4bff-b873-0d32b29f6efb"",
                    ""path"": ""<Keyboard>/r"",
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
                },
                {
                    ""devicePath"": ""<VirtualMouse>"",
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
                },
                {
                    ""devicePath"": ""<XboxOneGampadiOS>"",
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
                },
                {
                    ""devicePath"": ""<DualShock4GampadiOS>"",
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
        private @InputsPlayer m_Wrapper;
        public Player_KeyboardActions(@InputsPlayer wrapper) { m_Wrapper = wrapper; }
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
        private @InputsPlayer m_Wrapper;
        public Player_GamepadXboxActions(@InputsPlayer wrapper) { m_Wrapper = wrapper; }
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
    }
}
