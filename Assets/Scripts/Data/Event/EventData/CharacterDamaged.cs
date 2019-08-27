/// <summary>
///     Describes the damaging of a Character
/// </summary>
public class CharacterDamaged : EventData {

	public Character Character { get; set; }
	public int Damage { get; set; }

	public CharacterDamaged(Character character, int damage)
	{
		Character = character;
		Damage = damage;
	}
	
	public override string ToString()
	{
		return $"Character {Character.GetIdentifier()}, Damaged by {Damage}";
	}
}
