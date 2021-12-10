// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""game"",
            ""id"": ""b3ff3a48-c304-45af-94be-d1cb91a43185"",
            ""actions"": [
                {
                    ""name"": ""interact"",
                    ""type"": ""Button"",
                    ""id"": ""d865f6b1-3e22-41bc-9d5c-72e1162f36ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""submit"",
                    ""type"": ""Button"",
                    ""id"": ""15170e93-04a5-4360-ab3b-2c3ace7a8215"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""0d2ae061-3888-47b0-b48f-e979446aaea2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8ebb5146-098b-43c8-bef0-2cf0f92c7f2f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b3133de-b4fc-4ce6-8d68-4cb23f4ef692"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27e76cd4-9b60-4a9c-ad77-87cf94210abe"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // game
        m_game = asset.FindActionMap("game", throwIfNotFound: true);
        m_game_interact = m_game.FindAction("interact", throwIfNotFound: true);
        m_game_submit = m_game.FindAction("submit", throwIfNotFound: true);
        m_game_Quit = m_game.FindAction("Quit", throwIfNotFound: true);
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

    // game
    private readonly InputActionMap m_game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_game_interact;
    private readonly InputAction m_game_submit;
    private readonly InputAction m_game_Quit;
    public struct GameActions
    {
        private @Controls m_Wrapper;
        public GameActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @interact => m_Wrapper.m_game_interact;
        public InputAction @submit => m_Wrapper.m_game_submit;
        public InputAction @Quit => m_Wrapper.m_game_Quit;
        public InputActionMap Get() { return m_Wrapper.m_game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @interact.started -= m_Wrapper.m_GameActionsCallbackInterface.OnInteract;
                @interact.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnInteract;
                @interact.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnInteract;
                @submit.started -= m_Wrapper.m_GameActionsCallbackInterface.OnSubmit;
                @submit.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnSubmit;
                @submit.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnSubmit;
                @Quit.started -= m_Wrapper.m_GameActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @interact.started += instance.OnInteract;
                @interact.performed += instance.OnInteract;
                @interact.canceled += instance.OnInteract;
                @submit.started += instance.OnSubmit;
                @submit.performed += instance.OnSubmit;
                @submit.canceled += instance.OnSubmit;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public GameActions @game => new GameActions(this);
    public interface IGameActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
}
