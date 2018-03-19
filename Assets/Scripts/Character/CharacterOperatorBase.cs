using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Iso.Character {
	public class CharacterOperatorBase : MonoBehaviour {
		[SerializeField] string m_StateName;     //現在の状態
		string m_DefaultState;  //Defaultの状態

		// Use this for initialization
		void Awake () {
			m_StateName    = "None";
			m_DefaultState = "None";
		}
		
		/// <summary>
		/// 状態をDefaultの状態へ
		/// </summary>
		public void ChangeDefault() {
			m_StateName = m_DefaultState;
		}

		/// <summary>
		/// 状態を変化させる
		/// </summary>
		/// <param name="Name">変更したい状態名</param>
		public void SetStateName(string Name) {
			m_StateName = Name;
		}

		/// <summary>
		/// Defaultの状態を設定
		/// </summary>
		/// <param name="Name">Default状態の名前</param>
		public void SetDefaultState(string Name) {
			m_StateName = m_DefaultState = Name;
		}

		/// <summary>
		/// 現在の状態を取得
		/// </summary>
		/// <returns></returns>
		public string GetStateName() {
			return m_StateName;
		}
	}
}
