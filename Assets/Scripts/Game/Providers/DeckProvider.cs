public class DeckProvider : JsonEntityProvider<Deck> {

    protected override string GetJsonDataFileName() => "deck";

    public Deck GetDeck(string deckIdentity) => Read(deckIdentity);
}