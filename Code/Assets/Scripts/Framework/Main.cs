﻿using UnityEngine;
using System.Collections;
using FootStudio.Framework;
using FootStudio.Util;
using System.Collections.Generic;
using FootStudio.StateManagement;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Main : MainBase {

	public static Main Instance
	{
		get;
		private set;
	}

	public EventBus EventBus
	{
		get;
		private set;
	}

	public AppSession AppSession
	{
		get;
		private set;
	}

    public SceneStateManager SceneStateManager
	{
		get;
		private set;
	}

	public TableManager TableManager {
		get;
		private set;
	}

    public SDKManager SDKManager
    {
        get;
        private set;
    }

    public ShareManager ShareManager
    {
        get;
        private set;
    }

    public UserManager UserManager
    {
        get;
        private set;
    }

    public GameNetwork GameNetwork
    {
        get;
        private set;
    }

    public PurchaseManager PurchaseManager
    {
        get;
        private set;
    }

	protected override void Awake() {
		base.Awake ();

		Main.Instance = this;
		this.InstantiateObjects();
		this.ApplyProperties();
		this.InitObjects();

        GameLog.Level = GameLog.LogLevel.DEBUG;
	}

	private void InstantiateObjects()
	{
        AssetManager.Initialize();

		this.TableManager = new TableManager ();
		this.EventBus = new EventBus ();
		this.AppSession = new AppSession ();
        this.SceneStateManager = new SceneStateManager();
        this.SDKManager = new SDKManager();
        this.ShareManager = new ShareManager();
        this.UserManager = new UserManager();
        this.GameNetwork = new GameNetwork();
        this.PurchaseManager = new PurchaseManager();
	}

    private void InitObjects()
    {
        this.AppSession.Init();
        this.SceneStateManager.Init();

        //初始化顺序不能变
        this.TableManager.Init();
        this.SDKManager.Init();
        this.ShareManager.Init();
        this.UserManager.Init();
        this.GameNetwork.Init();
        this.PurchaseManager.Init();

        PrefabPathInfo.InitPrefabPath();
    }

	private void ApplyProperties()
	{
		this.AppSession.EventBus = this.EventBus;

        SceneManager.sceneLoaded += OnLevelLoaded;
        //SceneManager.activeSceneChanged += OnLevelActive;
	}



	protected override void OnAppStart ()
	{
	}

	protected override void OnAppResume ()
	{
		this.AppSession.OnAppResume ();
		this.SceneStateManager.OnAppResume();
		this.EventBus.FireEvent (EventId.APP_RESUME);
	}

	protected override void OnAppPause (bool quitting)
	{
		this.SceneStateManager.OnAppPause();
		this.AppSession.OnAppPause ();
		this.EventBus.FireEvent (EventId.APP_PAUSE, quitting);
	}

	protected override void OnBackPress ()
	{
		this.SceneStateManager.OnBackPress();
	}

	protected override void Update()
	{
		base.Update ();
		this.SceneStateManager.OnUpdate();
        TimerManager.Update(Time.deltaTime);
	}

	public void ClearPrefs()
	{
		AppSession.ClearPrefs ();
		UserPrefs.Save ();
	}

	protected void LateUpdate()
	{
		StateManager.AfterUpdate();
	}

    protected void  OnLevelLoaded(Scene s, LoadSceneMode m) {
        Debug.LogError("Scene Name = " + s.name + " | " + "LoadSceneMode = " + m);

        this.SceneStateManager.OnLevelWasLoaded(s.buildIndex);
    }

    protected void OnLevelActive(Scene previous, Scene current)
    {
        Debug.LogError("OnLevelActive" + previous.name + " | " + current.name);

        this.SceneStateManager.OnLevelWasLoaded(current.buildIndex);
    }

}
