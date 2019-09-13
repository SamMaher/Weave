public class EncounterProvider : JsonProvider<Encounter> {

    protected override string GetJsonDataFileName() => "encounter";

    public Encounter GetEncounter(string encounterIdentity) => Read(encounterIdentity);

    public Encounter GetRandomEncounter()
    {
        var randomEncounterId = GetIdentities().SelectRandom();

        return GetEncounter(randomEncounterId);
    }
}