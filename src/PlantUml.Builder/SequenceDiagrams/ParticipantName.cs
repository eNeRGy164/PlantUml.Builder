using System;
using System.Text.RegularExpressions;

namespace PlantUml.Builder.SequenceDiagrams
{
    public class ParticipantName
    {
        private static readonly Regex nameAlias = new("^(?:[\"]?(?<Name>[^\"]+)(?:[\"][\\s]*|[\\s]+)as[\\s]+(?<Alias>[^\"\\s]+)|(?<Alias>[^\"\\s]+)[\\s]+as(?:[\\s]*[\"]|[\\s]+)(?<Name>[^\"]+)[\"]?|[\"]?(?<Name>[^\"]+)[\"]?)$", RegexOptions.Singleline | RegexOptions.Compiled);
        private const string ValidNameChars = "0123456789_@.";

        public string Name { get; private set; }

        public string Alias { get; private set; } = string.Empty;

        public ParticipantName(string name)
            : this(name, default)
        {
        }

        public ParticipantName(string name, string displayName)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("A non-empty value should be provided", nameof(name));

            if (string.IsNullOrWhiteSpace(displayName))
            {
                this.Name = name;
            }
            else
            {
                this.Alias = name;
                this.Name = displayName;
            }
        }

        public static implicit operator ParticipantName(string input)
        {
            var match = nameAlias.Match(input.Replace("\n", "\\n"));

            var name = match.Groups["Name"].Value;

            var hasAlias = match.Groups["Alias"].Success;
            if (hasAlias)
            {
                var alias = match.Groups["Alias"].Value;

                return new ParticipantName(alias, name);
            }

            return new ParticipantName(name);
        }

        public override string ToString()
        {
            if (this.Alias.Length == 0)
            {
                return FormatLongName(this.Name);
            }

            return $"{FormatLongName(this.Name)} as {this.Alias}";
        }

        private static string FormatLongName(string name)
        {
            var mustBeQuoted = MustBeQuoted(name);
            if (mustBeQuoted)
            {
                return Constant.Quote + name + Constant.Quote;
            }
            else
            {
                return name;
            }
        }

        private static bool MustBeQuoted(string name)
        {
            foreach (var c in name)
            {
                if (char.IsLetter(c) || ValidNameChars.IndexOf(c) > -1)
                {
                    continue;
                }

                return true;
            }

            return false;
        }
    }
}
