using System;
using UnityEngine;
using Verse;

namespace SmartSpeed
{
    [StaticConstructorOnStartup]
    internal class AlternateButtons
    {
        public static readonly Texture2D[] SpeedButtonTextures = new Texture2D[5]
        {
            ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Pause"),
            ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Normal"),
            ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Fast"),
            ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Superfast"),
            ContentFinder<Texture2D>.Get("UI/TimeControls/TimeSpeedButton_Ultrafast")
        };





    }
}