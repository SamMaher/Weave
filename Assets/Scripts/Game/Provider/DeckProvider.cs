public class DeckProvider : JsonProvider<Deck> {

    protected override string GetJsonDataFileName() => "deck";

    public Deck GetDeck(string deckIdentity) => Read(deckIdentity);
}