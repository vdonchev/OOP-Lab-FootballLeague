namespace FootballLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utils;

    public class Team
    {
        private const int MinStringLength = 5;

        private string name;
        private string nickName;
        private readonly List<Player> players;

        public Team(string name, string nickName, DateTime dateFounded)
        {
            this.Name = name;
            this.NickName = nickName;
            this.DateFounded = dateFounded;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException(string.Format(MsgConstants.StringCantBeNullOrEmpty, "Team name"));
                }

                if (value.Length < MinStringLength)
                {
                    throw new ArgumentException(string.Format(MsgConstants.StringShouldBeAtLeast, "Team name", MinStringLength));
                }

                this.name = value;
            }
        }

        private string NickName
        {
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException(string.Format(MsgConstants.StringCantBeNullOrEmpty, "Team nickname"));
                }

                if (value.Length < MinStringLength)
                {
                    throw new ArgumentException(string.Format(MsgConstants.StringShouldBeAtLeast, "Team nickname", MinStringLength));
                }

                this.nickName = value;
            }
        }

        private DateTime DateFounded { get;}

        private IEnumerable<Player> Players => this.players;

        public void AddPlayer(Player player)
        {
            if (this.CheckIfPlayerExist(player))
            {
                throw new InvalidOperationException(MsgConstants.PlayerExistsInTeam);
            }

            this.players.Add(player);
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.DateFounded.Year})";
        }

        private bool CheckIfPlayerExist(Player player)
        {
            return this.Players.Any(p => p.FirstName == player.FirstName &&
                                         p.LastName == player.LastName);
        }
    }
}