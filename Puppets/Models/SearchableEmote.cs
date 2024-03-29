﻿using Lumina.Excel.GeneratedSheets;
using System;

namespace Puppets.Models
{
    public class SearchableEmote : IEquatable<SearchableEmote>
    {
        public string Command { get; init; }
        public string ShortCommand { get; init; }
        public string Alias { get; init; }
        public string ShortAlias { get; init; }
        public uint UnlockLink { get; init; }

        public SearchableEmote(Emote emote)
        {
            var textCommand = emote.TextCommand.Value!;
            this.Command = textCommand.Command.RawString;
            this.ShortCommand = textCommand.ShortCommand.RawString;
            this.Alias = textCommand.Alias.RawString;
            this.ShortAlias = textCommand.ShortAlias.RawString;
            this.UnlockLink = emote.UnlockLink;
        }

        public bool Equals(SearchableEmote? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.Command == other.Command ||
                this.ShortCommand == other.ShortCommand;
        }

        public bool Equals(string command)
        {
            if (ReferenceEquals(null, command)) return false;
            if (ReferenceEquals(this, command)) return true;

            var slashCommand = $"/{command}";
            return this.Command.Equals(slashCommand) ||
                this.ShortCommand.Equals(slashCommand) ||
                this.Alias.Equals(slashCommand) ||
                this.ShortAlias.Equals(slashCommand);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SearchableEmote)obj);
        }

        public override int GetHashCode() => (this.Command, this.ShortCommand, this.Alias, this.ShortAlias).GetHashCode();
    }
}
