using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_TextRPG.Data
{
    enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    internal class Stage
    {
        public string name;
        public int requiredDefense;
        public int baseReward;
        public Difficulty difficulty;
        public string description;
        public int rewardExp;
    }
}