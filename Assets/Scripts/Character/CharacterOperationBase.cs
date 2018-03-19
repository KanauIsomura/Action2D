using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Iso.Character {
	public abstract class CharacterOperationBase : MonoBehaviour {
		[SerializeField, Tooltip("操作管理スクリプト、同じオブジェクトについている場合はセットしなくていい")]
		protected CharacterOperatorBase m_OperatorScript;                                //操作管理スクリプトを持っておく
		[SerializeField, Tooltip("処理に入っていい状態のリスト")]
		protected List<string>          m_StartProcessingStateList = new List<string>(); //処理に入っていい状態のリスト
		[SerializeField, Tooltip("処理に入ったときの自分の状態")]
		protected string                m_MyState;

		void Awake() {
			if(m_OperatorScript != null)
				return;
			m_OperatorScript = GetComponent<CharacterOperatorBase>();
			m_StartProcessingStateList.Add(m_MyState);
		}

		void Update() {
			string State = m_OperatorScript.GetStateName();
			for(int nCount = 0; nCount < m_StartProcessingStateList.Count; ++nCount) {
				//処理に入っていい状態か
				if(State == m_StartProcessingStateList[nCount])
					break;//確認終了して操作処理へ
				//処理に入っていい状態が見つからずに最後まで末尾に到達したか
				if(nCount == m_StartProcessingStateList.Count - 1)
					return;//処理から抜ける
			}

			//操作処理
			Operation();
		}

		/// <summary>
		/// 操作関数、継承側はこれに上書きをする
		/// </summary>
		protected abstract void Operation();
	}
}
