﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 巡游
/// </summary>
public class IdleState : BaseCharacterState {

    CharacterBase character;
    Vector3 size;
    Vector3 des;
    float baseSpeed;
    
    public IdleState(CharacterStateManager mgr) 
        : base(mgr) {
        
        character = this.CharacterStateManager.CharacterBase;
        baseSpeed = character.Speed;
    }

    public override void OnEnter(BaseCharacterState previousState, object data) {
        base.OnEnter(previousState, data);

        size = character.Room.Size;
        ReFreshDes();
    }

    void ReFreshDes()
    {
        float randomX = Random.Range(0, size.x);
        float randomY = Random.Range(0, size.y);
        float randomZ = Random.Range(0, size.z);

        des = new Vector3(randomX, randomY > size.y/2 ? size.y /3 * 2 : size.y / 3, randomZ);

        character.Speed = baseSpeed + Random.Range(-3, 3);
    }

    public override void OnUpdate() {

        if (!character.Model.IsAtPosition(des))
        {
            character.Model.Move(des, Time.deltaTime);
        }
        else
        {
            //ChangeState(this.CharacterStateManager.EscapeState);
            ReFreshDes();
        }
        
        base.OnUpdate();
    }

}

/// <summary>
/// 受惊逃跑
/// </summary>
public class EscapeState : BaseCharacterState {
    private CharacterBase character;

    private Vector3 farAway = new Vector3(0, 0, 100);
    public EscapeState(CharacterStateManager mgr) 
        : base(mgr) {
            character = this.CharacterStateManager.CharacterBase;
    }

    public override void OnEnter(BaseCharacterState previousState, object data) {
        base.OnEnter(previousState, data);
        character.Speed = 30;
    }

    public override void OnUpdate() {
        if (!character.Model.IsAtPosition(farAway))
        {
            character.Model.Move(farAway, Time.deltaTime);
        }
        else
        {
            ChangeState(this.CharacterStateManager.IdleState);
        }

        base.OnUpdate();
    }


}

/// <summary>
/// 放松玩耍
/// </summary>
public class PlayingState : BaseCharacterState {

    public PlayingState(CharacterStateManager mgr)
        : base(mgr) {

    }

}

/// <summary>
/// 寻找食物
/// </summary>
public class FindSthToEatState : BaseCharacterState {

    public FindSthToEatState(CharacterStateManager mgr)
        : base(mgr) {

    }
}

/// <summary>
/// 吃 (饲料/小鱼)
/// </summary>
public class EatState : BaseCharacterState {

    public EatState(CharacterStateManager mgr)
        : base(mgr) {

    }

}

/// <summary>
/// 捕猎小鱼
/// </summary>
public class HuntState : BaseCharacterState {

    public HuntState(CharacterStateManager mgr)
        : base(mgr) {

    }
}
