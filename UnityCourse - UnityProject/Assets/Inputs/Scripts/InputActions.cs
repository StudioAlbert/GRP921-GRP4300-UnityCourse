// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""BasicMovement"",
            ""id"": ""62b2df6c-d6dc-4b6a-88d9-3bf0617470a4"",
            ""actions"": [
                {
                    ""name"": ""UpDwon"",
                    ""type"": ""Value"",
                    ""id"": ""441c0d6c-f44e-4439-8dcc-4d1ada88e9eb"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""LeftRight"",
                    ""type"": ""Value"",
                    ""id"": ""45659f4f-d339-4451-ba7d-32f72e9eb190"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""b126c274-08f2-4499-bd8a-46421aad5c72"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDwon"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""14458c91-214a-4555-a9fc-0a6e6f3890cf"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDwon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8852024b-9145-4666-91d2-cd82baab54d0"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDwon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""d2c5478d-2a18-411f-abd5-ddf495eda8ea"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""15ee6757-31fe-480b-881b-1230cf35f85b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2ba16d5f-d04b-4473-b700-4ff1f9a020d9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BasicMovement
        m_BasicMovement = asset.FindActionMap("BasicMovement", throwIfNotFound: true);
        m_BasicMovement_UpDwon = m_BasicMovement.FindAction("UpDwon", throwIfNotFound: true);
        m_BasicMovement_LeftRight = m_BasicMovement.FindAction("LeftRight", throwIfNotFound: true);
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

    // BasicMovement
    private readonly InputActionMap m_BasicMovement;
    private IBasicMovementActions m_BasicMovementActionsCallbackInterface;
    private readonly InputAction m_BasicMovement_UpDwon;
    private readonly InputAction m_BasicMovement_LeftRight;
    public struct BasicMovementActions
    {
        private @InputActions m_Wrapper;
        public BasicMovementActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @UpDwon => m_Wrapper.m_BasicMovement_UpDwon;
        public InputAction @LeftRight => m_Wrapper.m_BasicMovement_LeftRight;
        public InputActionMap Get() { return m_Wrapper.m_BasicMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicMovementActions set) { return set.Get(); }
        public void SetCallbacks(IBasicMovementActions instance)
        {
            if (m_Wrapper.m_BasicMovementActionsCallbackInterface != null)
            {
                @UpDwon.started -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnUpDwon;
                @UpDwon.performed -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnUpDwon;
                @UpDwon.canceled -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnUpDwon;
                @LeftRight.started -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnLeftRight;
                @LeftRight.performed -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnLeftRight;
                @LeftRight.canceled -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnLeftRight;
            }
            m_Wrapper.m_BasicMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UpDwon.started += instance.OnUpDwon;
                @UpDwon.performed += instance.OnUpDwon;
                @UpDwon.canceled += instance.OnUpDwon;
                @LeftRight.started += instance.OnLeftRight;
                @LeftRight.performed += instance.OnLeftRight;
                @LeftRight.canceled += instance.OnLeftRight;
            }
        }
    }
    public BasicMovementActions @BasicMovement => new BasicMovementActions(this);
    public interface IBasicMovementActions
    {
        void OnUpDwon(InputAction.CallbackContext context);
        void OnLeftRight(InputAction.CallbackContext context);
    }
}
