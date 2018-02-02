using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuration {

	/// <summary>
	/// Replacement ID
	/// </summary>
	public static string skippablePlacementId = "video";
	public static string unskippablePlacementId = "rewardedVideo";

	/// <summary>
	/// Video Stats
	/// </summary>
	public static string videoCompleted = "Video completed - Offer a reward to the player";
	public static string videoSkipped = "Video was skipped - Do NOT reward the player";
	public static string videoError = "Video failed to show";
	public static string videoAvailable = "Get free coins";
	public static string videoUnavailable = "Free coins not available yet";

	/// <summary>
	/// The rewarded coin amount.
	/// </summary>
	public static int rewardedCoinAmount = 7;

}
