
namespace MilitaryElite.Models
{
    using System;

    using MilitaryElite.Enums;
    using MilitaryElite.Exceptions;

    public class Mission
    {
        private string codeName;
        private MissionState missionState;

        public Mission(string codeName, string missionState)
        {
            CodeName = codeName;
            MissionState state;
            if (!Enum.TryParse<MissionState>(missionState, out state))
            {
                throw new MissionStateException();
            }
            MissionState = state; ;
        }

        public string CodeName
        {
            get { return codeName; }
            private set
            {
                codeName = value;
            }
        }
        public MissionState MissionState
        {
            get { return missionState; }
            private set
            {
                missionState = value;
            }
        }

        public override string ToString()
        {
            return $"Code Name: {codeName} State: {MissionState}";
        }
    }
}
