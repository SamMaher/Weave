/// <summary>
///     Describes the healing of a Character
/// </summary>
public class CharacterHealed : EventData {

	public Character Character { get; set; }
	public int Heal { get; set; }

	public CharacterHealed(Character character, int heal)
	{
		Character = character;
		Heal = heal;
	}

	public override string ToString()
	{
		return $"Character {Character.GetIdentifier()}, Healed by {Heal}";
	}
}
