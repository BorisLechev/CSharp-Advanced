using _8.MilitaryElite.Enumerations;

namespace _8.MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
