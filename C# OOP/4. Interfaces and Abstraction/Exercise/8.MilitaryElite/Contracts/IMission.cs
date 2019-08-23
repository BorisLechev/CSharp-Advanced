using _8.MilitaryElite.Enumerations;

namespace _8.MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
