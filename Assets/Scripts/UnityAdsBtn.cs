using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


[RequireComponent(typeof(Button))]
public class UnityAdsBtn : MonoBehaviour {

	ColorBlock newColorBlock = new ColorBlock();
	public Color green = new Color(0.1F, 0.8F, 0.1F, 1.0F);


	// 观看视频广告后获得的硬币奖励
	public Text m_CoinText;
	// Game ID
	public Text m_GameIDText;
	// Placement ID
	public Text m_PlacementIDText;
	// Stats输出信息
	public Text m_StatsText;
	// 奖励视频按钮提示
	public Text m_ButtonText;

	// 奖励视频按钮
	Button m_Button;
	// 奖励硬币
	int m_RewardedCoin = 0;
	// 奖励视频是否可用
	bool m_IsVideoAvailable = false;

	void Start ()
	{  
		m_CoinText.text = m_RewardedCoin.ToString ();
		m_GameIDText.text = Advertisement.gameId;
		m_PlacementIDText.text = Configuration.unskippablePlacementId;
		m_StatsText.gameObject.SetActive(false);

		m_Button = GetComponent<Button>();
		if (m_Button) m_Button.onClick.AddListener(ShowAd);
	}

	void Update ()
	{
		if (m_Button) {
			m_IsVideoAvailable = Advertisement.IsReady(Configuration.unskippablePlacementId);

			m_Button.interactable = m_IsVideoAvailable;
			m_ButtonText.text = m_IsVideoAvailable ? Configuration.videoAvailable : Configuration.videoUnavailable; 
		}
	}

	void ShowAd ()
	{
		var options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show(Configuration.unskippablePlacementId, options);
	}

	void RewardPlayer()
	{
		m_RewardedCoin += Configuration.rewardedCoinAmount;
		m_CoinText.text = m_RewardedCoin.ToString ();
	}

	void HandleShowResult (ShowResult result)
	{
		m_StatsText.gameObject.SetActive(true);
		if(result == ShowResult.Finished) {
			RewardPlayer ();
			m_StatsText.text = Configuration.videoCompleted;

		}else if(result == ShowResult.Skipped) {

			m_StatsText.text = Configuration.videoSkipped;

		}else if(result == ShowResult.Failed) {
			m_StatsText.text = Configuration.videoError;
		}
	}
}
