namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Linq;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.DEAD_PLAYER);
            }

            if (attackPlayer is Beginner) //attackPlayer.GetType() == typeof(Beginner)
            {
                this.BoostBeginnerPlayer(attackPlayer);
            }

            if (enemyPlayer is Beginner)
            {
                this.BoostBeginnerPlayer(enemyPlayer);
            }

            this.BoostPlayer(attackPlayer);

            this.BoostPlayer(enemyPlayer);

            int attackerPlayerDamage = this.SumDamagePointsFromEachCard(attackPlayer);

            int enemyPlayerDamage = this.SumDamagePointsFromEachCard(enemyPlayer);

            while (true)
            {
                enemyPlayer.TakeDamage(attackerPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayerDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private int SumDamagePointsFromEachCard(IPlayer player)
        {
            return player
                .CardRepository
                .Cards
                .Sum(c => c.DamagePoints);
        }

        private void BoostPlayer(IPlayer player)
        {
            int playerBonusHealth = player.CardRepository.Cards.Sum(c => c.HealthPoints);
            player.Health += playerBonusHealth;
        }

        private void BoostBeginnerPlayer(IPlayer player)
        {
            player.Health += 40;

            foreach (ICard card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}
