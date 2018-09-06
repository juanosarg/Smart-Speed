using System;
using Verse;

namespace SmartSpeed.Detouring
{
    internal class TickManager
    {
        public float TickRateMultiplier
        {
            get
            {
                var slower = Find.TickManager.slower;
                var currTimeSpeed = Find.TickManager.CurTimeSpeed;
                if (!slower.ForcedNormalSpeed)
                {
                    return this.TickRate(currTimeSpeed);
                }
                if (currTimeSpeed == 0)
                {
                    return 0f;
                }
                switch (AcSmartSpeed.currSetting)
                {
                    case AcSmartSpeed.Option.Slow:
                        return 0.5f;
                    case AcSmartSpeed.Option.Normal:
                        return 1f;
                    case AcSmartSpeed.Option.Fast:
                        return 2f;
                    case AcSmartSpeed.Option.Half:
                        return this.TickRate(currTimeSpeed) / 2f;
                    case AcSmartSpeed.Option.Ignore:
                        return this.TickRate(currTimeSpeed);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private float TickRate(TimeSpeed currTimeSpeed)
        {
            switch ((int)currTimeSpeed)
            {
                case 0:
                    return 0f;
                case 1:
                    return 1f;
                case 2:
                    return 3f;
                case 3:
                    if (Find.get_VisibleMap() == null)
                    {
                        return 150f;
                    }
                    if (this.NothingHappeningInGame())
                    {
                        return 12f;
                    }
                    return 6f;
                case 4:
                    if (Find.get_VisibleMap() == null)
                    {
                        return 250f;
                    }
                    return 15f;
                default:
                    return -1f;
            }
        }

        private bool NothingHappeningInGame()
        {
            Log.Message("This message never show up");
            return true;
        }
    }
}