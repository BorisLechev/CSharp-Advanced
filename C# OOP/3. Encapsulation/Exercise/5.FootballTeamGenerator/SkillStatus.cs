using System;
using System.Collections.Generic;
using System.Text;

namespace _5.FootballTeamGenerator
{
    public class SkillStatus
    {
        private int endurance;

        private int sprint;

        private int dribble;

        private int passing;

        private int shooting;

        public SkillStatus(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }

            private set
            {
                string name = "Endurance";
                Validator.ValidateCurrentSkillStatus(value, name);
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }

            private set
            {
                string name = "Sprint";
                Validator.ValidateCurrentSkillStatus(value, name);
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }

            private set
            {
                string name = "Dribble";
                Validator.ValidateCurrentSkillStatus(value, name);
                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }

            private set
            {
                string name = "Passing";
                Validator.ValidateCurrentSkillStatus(value, name);
                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }

            private set
            {
                string name = "Shooting";
                Validator.ValidateCurrentSkillStatus(value, name);
                this.shooting = value;
            }
        }
    }
}
